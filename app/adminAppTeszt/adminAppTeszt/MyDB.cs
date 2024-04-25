// ------------------------------------------------------- //
// Készült: 2023/2024. tanév, Wiezl Csaba, Kemenes Tamás   // 
// Verzió: 2.2 (2023.11.27.)                               // 
// ------------------------------------------------------- //
using System;
using System.Collections.Generic;
using System.Data; // DataSet miatt 
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // MySql... miatt

namespace MyDatabaseMySQL
{
    /// <summary>
    /// Caption és ID adatot tároló osztály. ListBox és ComboBox Items részének tárolásához, így a felirat (Caption) látszik a listában, de a kiválasztásnál az ID is ott lesz, ami az egyedi kódot jelenti.
    /// </summary>
    public class ListItemMy
    {
        public dynamic ID { get; set; }
        public string Caption { get; set; }
        public object OtherData { get; set; }
        public ListItemMy(dynamic ID, string Caption)
        {
            this.ID = ID;
            this.Caption = Caption;
            this.OtherData = null;
        }
        public ListItemMy(dynamic ID, string Caption, object OtherData)
        {
            this.ID = ID;
            this.Caption = Caption;
            this.OtherData = OtherData;
        }
        public override string ToString()
        {
            return Caption;
        }
    }

    /// <summary>
    /// MySQL szerver eléréshez és használathoz saját osztály 
    /// </summary>
    public class MyDB
    {
        /// <summary>
        /// Kapcsolódási sztring MySQL szerverhez
        /// </summary>
        private string connection_string;
        
        /// <summary>
        /// Kapcsolódási objektum a MySQL szerverhez
        /// </summary>
        private MySqlConnection connection;
        public MySqlConnection Connection { get => connection; }

        /// <summary>
        /// INSERT parancs esetén LAST_INSERT_ID() MySQL függvény értékét tárolja, különben nulla;    
        /// </summary>
        private int lastInsertId;
        public int LastInsertId { get => lastInsertId; }

        /// <summary>
        /// Konstruktor a MySQL szerver eléréshez
        /// </summary>
        /// <param name="server">Szerver/Host MySQL szerver megnevezése</param>
        /// <param name="userid">MySQL szerver eléréséhez felhasználói név</param>
        /// <param name="password">MySQL szerver eléréséhez jelszó</param>
        /// <param name="database">MySQL szerveren lévő elérhető adatbázis neve, alapértelmezetten üres sztring (pl. olyankor, ha az adatbázist kódból szeretnénk létrehozni)</param>
        /// <param name="charset">Karakter kódolás megadása, alapértelmezetten utf8</param>
        /// <param name="port">MySQL szerver eléréshez port megadása, alapértelmezetten 3306</param>
        public MyDB(string server, string userid, string password, string database = "", string charset = "utf8", int port = 3306)
        {
            if (database == "")
            {
                connection_string = $"server={server};userid={userid};password={password};charset={charset};port={port};";
            }
            else
            {
                connection_string = $"server={server};userid={userid};password={password};database={database};charset={charset};port={port};";
            }
            ConnectInit();

        }

        /// <summary>
        /// Konstruktor a MySQL szerver eléréshez
        /// </summary>
        /// <param name="connection_string">MySQL szerver eléréséhez kapcsolódási sztring megadása egyben: 
        /// pl1: "server=...;userid=...;password=...;database=...;charset=...;port=...;"
        /// pl2: "server=...;uid=...;pwd=...;database=...;charset=...;port=...;")</param>
        public MyDB(string connection_string)
        {
            this.connection_string = connection_string; 
            ConnectInit();
        }

        /// <summary>
        /// Kapcsolódási objektum inicializálása
        /// </summary>
        private void ConnectInit()
        { 
            connection = new MySqlConnection(connection_string);
        }

        /// <summary>
        /// MySQL szerverhez a kapcsolat megnyitott-e?
        /// </summary>
        /// <returns>True: a kapcsolat állapota nyitott, False: a kapcsolat állapota lezárt</returns>
        /// <exception cref="Exception"></exception>
        public bool IsOpen()
        {
            try
            {
                return connection.State.ToString().ToLower() == "open";
            }
            catch (MySqlException err)
            {
                throw new Exception($"{err.Message} (Hibakód: {err.Number})");
            }
        }

        /// <summary>
        /// MySQL szerverhez a kapcsolat megnyitása
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Open()
        {
            try
            {
                if (IsOpen())
                {
                    Close();
                }
                connection.Open();
            }
            catch (MySqlException err)
            {
                throw new Exception($"{err.Message} (Hibakód: {err.Number})");
            }
        }

        /// <summary>
        /// MySQL szerverhez a kapcsolat lezárása
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Close() 
        {
            try
            {
                if (IsOpen())
                {
                    connection.Close();
                }
            }
            catch (MySqlException err)
            {
                throw new Exception($"{err.Message} (Hibakód: {err.Number})");
            }
        }

        /// <summary>
        /// Egy paraméteres sql paramétereit beállítja és előkészíti
        /// </summary>
        /// <param name="command">A MySQL command parancsa</param>
        /// <param name="parameters">Az sql paraméterei, amely egy Nx2-es string tömb. A 0. oszlopban vannak a paraméterek név adatai (ha nincs előtte @ karakter, akkor hozzáteszi, tehát @ nélkül is működik és @ megadásával is). Az 1. oszlopban vannak a paraméterek értékei. Fontos: az sql parancsban lévő paramétereknek szinkronban kell lenni a parameters tömb adataival!</param>
        /// <exception cref="Exception"></exception>
        private void ParametersInit(MySqlCommand command, string[,] parameters)
        {
            try
            {
                command.Parameters.Clear();
                if (parameters.GetLength(1) != 2)
                {
                    throw new Exception("A paraméteres sql paraméterei nem 2 oszlopból álló tömb!");
                }
                int n = parameters.GetLength(0);    
                for (int i = 0; i < n; i++)
                {
                    string name = parameters[i, 0];
                    if (name[0] != '@')
                    {
                        name = "@" + name;
                    }
                    string value = parameters[i, 1];
                    if (value.ToUpper() == "NULL")
                    {
                        command.Parameters.AddWithValue(name, null);
                    }
                    else
                    {
                        command.Parameters.AddWithValue(name, value);
                    }
                    
                }
                command.Prepare();
            }
            catch (MySqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// Nem select jellegű sql parancs (pl.: update, delete, insert, alter, drop, stb.) végrehajtása tranzakció kezeléssel. Ha kell paraméteres sql-ként is működik.
        /// </summary>
        /// <param name="sql">Az sql parancs, melyet szeretnénk végrehajtani</param>
        /// <param name="parameters">Opcionális paraméter. Az sql paraméterei, amely egy Nx2-es string tömb. A 0. oszlopban vannak a paraméterek név adatai (ha nincs előtte @ karakter, akkor hozzáteszi, tehát @ nélkül is működik és @ megadásával is). Az 1. oszlopban vannak a paraméterek értékei. Fontos: az sql parancsban lévő paramétereknek szinkronban kell lenni a parameters tömb adataival!</param>
        /// <returns>A visszatérése egy logikai érték. True: sikeres végrehajtás. False-hiba, sikertelen végrehajtás.</returns>
        /// <exception cref="Exception"></exception>
        public bool Query(string sql, string[,] parameters = null)
        {
            lastInsertId = 0;
            MySqlTransaction transaction = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Open();
                transaction = connection.BeginTransaction();
                MySqlCommand command = new MySqlCommand(sql, connection, transaction);
                if (parameters != null)
                {
                    ParametersInit(command, parameters);
                }
                command.ExecuteNonQuery();
                transaction.Commit();
                
                if (sql.Substring(0, 6).ToUpper() == "INSERT")
                {
                    lastInsertId = (int)SelectOneValue("SELECT LAST_INSERT_ID()");
                }
                
                Close();
                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (MySqlException err)
            {
                Cursor.Current = Cursors.Default;
                transaction.Rollback();
                throw new Exception($"{err.Message} (Hibakód: {err.Number})");
            }
        }

        /// <summary>
        /// Nem select jellegű sql parancsok (pl.: update, delete, insert, alter, drop, stb.) csoportos végrehajtása tranzakció kezeléssel. A több sql parancsot egy sztring tömb tartalmazza. Paraméteres sql nem lehet benne! 
        /// </summary>
        /// <param name="sql">Az sql parancsok sztring tömbje, melyet szeretnénk végrehajtani</param>
        /// <returns>A visszatérése egy logikai érték. True: sikeres végrehajtás. False-hiba, sikertelen végrehajtás.</returns>
        /// <exception cref="Exception"></exception>
        public bool Query(string[] sql)
        {
            lastInsertId = 0;
            MySqlTransaction transaction = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Open();
                transaction = connection.BeginTransaction();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;

                for (int i = 0; i < sql.Length; i++)
                {
                    command.CommandText = sql[i];
                    command.ExecuteNonQuery();

                    if (sql[i].Substring(0, 6).ToUpper() == "INSERT")
                    {
                        lastInsertId = (int)SelectOneValue("SELECT LAST_INSERT_ID()");
                    }
                }

                transaction.Commit();
                Close();
                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (MySqlException err)
            {
                Cursor.Current = Cursors.Default;
                transaction.Rollback();
                throw new Exception($"{err.Message} (Hibakód: {err.Number})");
            }
        }

        /// <summary>
        /// Nem select jellegű sql parancsok (pl.: update, delete, insert, alter, drop, stb.) csoportos végrehajtása tranzakció kezeléssel. A több sql parancsot egy sztring lista tartalmazza. Paraméteres sql nem lehet benne! 
        /// </summary>
        /// <param name="sql">Az sql parancsok sztring listája, melyet szeretnénk végrehajtani</param>
        /// <returns>A visszatérése egy logikai érték. True: sikeres végrehajtás. False-hiba, sikertelen végrehajtás.</returns>
        /// <exception cref="Exception"></exception>
        public bool Query(List<string> sql)
        {
            return Query(sql.ToArray()); // ez nem lesz rekurzív hívás!!!
        }

        /// <summary>
        /// Lekérdezés jellegű sql parancs végrehajtása, de minden esetben csak egyetlen adatot ad vissza
        /// </summary>
        /// <param name="sql">Az sql parancs, melyet szeretnénk végrehajtani</param>
        /// <param name="parameters">Opcionális paraméter. Az sql paraméterei, amely egy Nx2-es string tömb. A 0. oszlopban vannak a paraméterek név adatai (ha nincs előtte @ karakter, akkor hozzáteszi, tehát @ nélkül is működik és @ megadásával is). Az 1. oszlopban vannak a paraméterek értékei. Fontos: az sql parancsban lévő paramétereknek szinkronban kell lenni a parameters tömb adataival!</param>
        /// <returns>A lekérdezés visszatérési értéke minden esetben csak egyetlen adat! Ha több sora, több oszlopa lenne a lekérdezésnek, akkor is csak az első oszlopban lévő első sorának adatát adja vissza!</returns>
        /// <exception cref="Exception"></exception>
        public dynamic SelectOneValue(string sql, string[,] parameters = null)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Open();
                MySqlCommand command = new MySqlCommand(sql,connection);
                if (parameters != null)
                { 
                    ParametersInit(command, parameters);
                }
                var data = command.ExecuteScalar();
                Close();
                Cursor.Current = Cursors.Default;
                return data;
            }
            catch (MySqlException err)
            {
                Cursor.Current = Cursors.Default;
                throw new Exception($"{err.Message} (Hibakód: {err.Number})");
            }
        }

        /// <summary>
        /// Lekérdezés jellegű sql parancs végrehajtása, de minden esetben csak az első oszlopban lévő adatokat adja vissza egy listában </summary>
        /// <param name="sql">Az sql parancs, melyet szeretnénk végrehajtani</param>
        /// <param name="parameters">Opcionális paraméter. Az sql paraméterei, amely egy Nx2-es string tömb. A 0. oszlopban vannak a paraméterek név adatai (ha nincs előtte @ karakter, akkor hozzáteszi, tehát @ nélkül is működik és @ megadásával is). Az 1. oszlopban vannak a paraméterek értékei. Fontos: az sql parancsban lévő paramétereknek szinkronban kell lenni a parameters tömb adataival!</param>
        /// <returns>A lekérdezés visszatérési értéke minden esetben egy lista! Ha több oszlopa lenne a lekérdezésnek, akkor is csak az első oszlopban lévő adatokat adja vissza a listában!</returns>
        /// <exception cref="Exception"></exception>
        public List<dynamic> SelectOneColumn(string sql, string[,] parameters = null)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                List<dynamic> data = new List<dynamic>();
                Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                if (parameters != null)
                {
                    ParametersInit(command, parameters);
                }
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    data.Add(reader[0]);
                }
                Close();
                Cursor.Current = Cursors.Default;
                return data;
            }
            catch (MySqlException err)
            {
                Cursor.Current = Cursors.Default;
                throw new Exception($"{err.Message} (Hibakód: {err.Number})");
            }
        }

        /// <summary>
        /// Lekérdezés jellegű sql parancs végrehajtása, az adathalmazt (táblázatot) egy listában adja vissza, minden egyes listaelem egy sztring tömb.
        /// </summary>
        /// <param name="sql">Az sql parancs, melyet szeretnénk végrehajtani</param>
        /// <param name="with_column_names">Kell-e az oszlopok elnevezése is? True: a lista első eleme az oszlopok elnevezéseit tartalmazza. False: nem adja vissza az oszlopok elnevezéseit az első listaelemben, ez az alapértelmezett.</param>
        /// <param name="parameters">Opcionális paraméter. Az sql paraméterei, amely egy Nx2-es string tömb. A 0. oszlopban vannak a paraméterek név adatai (ha nincs előtte @ karakter, akkor hozzáteszi, tehát @ nélkül is működik és @ megadásával is). Az 1. oszlopban vannak a paraméterek értékei. Fontos: az sql parancsban lévő paramétereknek szinkronban kell lenni a parameters tömb adataival!</param>
        /// <returns>A lekérdezés visszatérési értéke a teljes adathalmaz, mint egy táblázat. Minden esetben egy lista, melynek elemei sztring tömbök. A lista első eleme tartalmazhatja az oszlopok elnevezéseit is (with_column_names=true esetén).</returns>
        public List<string[]> SelectListTable(string sql, bool with_column_names = false, string[,] parameters = null)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                List<string[]> data = new List<string[]>();
                Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                if (parameters != null)
                {
                    ParametersInit(command, parameters);
                }
                MySqlDataReader reader = command.ExecuteReader();
                int n = reader.FieldCount;
                string[] row;
                if (with_column_names)
                {
                    row = new string[n];
                    for (int i = 0; i < n; i++)
                    {
                        row[i] = reader.GetName(i);
                    }
                    data.Add(row);
                }
                while (reader.Read())
                {
                    row = new string[n];
                    for (int i = 0; i < n; i++)
                    {
                        row[i] = reader[i].ToString();
                    }
                    data.Add(row);
                }
                Close();
                Cursor.Current = Cursors.Default;
                return data;
            }
            catch (MySqlException err)
            {
                Cursor.Current = Cursors.Default;
                throw new Exception($"{err.Message} (Hibakód: {err.Number})");
            }
        }

        /// <summary>
        /// Lekérdezés jellegű sql parancs végrehajtása, az adathalmazt (táblázatot) egy listában adja vissza, minden egyes listaelem egy adott karakterrel tagolt sztring. Alapértelmezés szerint tagoláshoz az elválasztó karakter a pontosvessző.
        /// </summary>
        /// <param name="sql">Az sql parancs, melyet szeretnénk végrehajtani</param>
        /// <param name="separator">Tagoláshoz milyen elválasztó karakter legyen, alapértelmezetten a pontosvessző.</param>
        /// <param name="with_column_names">Kell-e az oszlopok elnevezése is? True: a lista első eleme az oszlopok elnevezéseit tartalmazza. False: nem adja vissza az oszlopok elnevezéseit az első listaelemben, ez az alapértelmezett.</param>
        /// <param name="parameters">Opcionális paraméter. Az sql paraméterei, amely egy Nx2-es string tömb. A 0. oszlopban vannak a paraméterek név adatai (ha nincs előtte @ karakter, akkor hozzáteszi, tehát @ nélkül is működik és @ megadásával is). Az 1. oszlopban vannak a paraméterek értékei. Fontos: az sql parancsban lévő paramétereknek szinkronban kell lenni a parameters tömb adataival!</param>
        /// <returns>A lekérdezés visszatérési értéke a teljes adathalmaz, mint egy táblázat. Minden esetben egy lista, melynek elemei tagolt/elválasztott sztringek. Tagoláshoz pl. separator='\t' és tabulátorral lesznek elválasztva a soron belül. A lista első eleme tartalmazhatja az oszlopok elnevezéseit is tagoltan (with_column_names=true esetén).</returns>
        public List<string> SelectSeparatedTable(string sql, char separator = ';', bool with_column_names = false, string[,] parameters = null)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                List<string> data = new List<string>();
                Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                if (parameters != null)
                {
                    ParametersInit(command, parameters);
                }
                MySqlDataReader reader = command.ExecuteReader();
                int n = reader.FieldCount;
                string row;
                if (with_column_names)
                {
                    row = "";
                    for (int i = 0; i < n; i++)
                    {
                        row += reader.GetName(i) + separator;
                    }
                    row = row.Remove(row.Length - 1, 1);
                    data.Add(row);
                }
                while (reader.Read())
                {
                    row = "";
                    for (int i = 0; i < n; i++)
                    {
                        row += reader[i].ToString() + separator;
                    }
                    row = row.Remove(row.Length - 1, 1);
                    data.Add(row);
                }
                Cursor.Current = Cursors.Default;
                Close();
                return data;
            }
            catch (MySqlException err)
            {
                Cursor.Current = Cursors.Default;
                throw new Exception($"{err.Message} (Hibakód: {err.Number})");
            }
        }

        /// <summary>
        /// Lekérdezés jellegű sql parancs végrehajtása, de minden esetben csak az első oszlopban lévő adatokat adja vissza egy szöveg típusú tömbben. Asztali alkalmazásnál használható listbox, combobox feltöltéséhez az Items.AddRange(...) paraméreként átadva.</summary>
        /// <param name="sql">Az sql parancs, melyet szeretnénk végrehajtani</param>
        /// <param name="parameters">Opcionális paraméter. Az sql paraméterei, amely egy Nx2-es string tömb. A 0. oszlopban vannak a paraméterek név adatai (ha nincs előtte @ karakter, akkor hozzáteszi, tehát @ nélkül is működik és @ megadásával is). Az 1. oszlopban vannak a paraméterek értékei. Fontos: az sql parancsban lévő paramétereknek szinkronban kell lenni a parameters tömb adataival!</param>
        /// <returns>A lekérdezés visszatérési értéke minden esetben egy sztring tömb! Ha több oszlopa lenne a lekérdezésnek, akkor is csak az első oszlopban lévő adatokat adja vissza a tömbben!</returns>
        /// <exception cref="Exception"></exception>
        public string[] SelectOneColumnGUI(string sql, string[,] parameters = null)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                List<string> data = new List<string>();
                Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                if (parameters != null)
                {
                    ParametersInit(command, parameters);
                }
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    data.Add(reader[0].ToString());
                }
                Close();
                Cursor.Current = Cursors.Default;
                return data.ToArray();
            }
            catch (MySqlException err)
            {
                Cursor.Current = Cursors.Default;
                throw new Exception($"{err.Message} (Hibakód: {err.Number})");
            }
        }

        /// <summary>
        /// Lekérdezés jellegű sql parancs végrehajtása, ahol a lekérdezés egy ID (kulcs) és egy szöveges megnevezés/felirat (Caption). A lekérdezés adatait egy ListItemMy objektumokból álló tömbben adja vissza. Asztali alkalmazásnál használható listbox, combobox feltöltéséhez az Items.AddRange(...) paraméreként átadva. Így az Items nem csak a szöveges feliratokat fogja tartalmazni, hanem az azokhoz tartozó egyedi azonosítókat (ID) is.</summary>
        /// <param name="sql">Az sql parancs, melyet szeretnénk végrehajtani. Fontos előfeltétel: két oszlopa legyen, az első oszlop mindig az egyedi azonosító (ID), míg a második oszlop a szöveges megnevezés/felirat (Caption)!</param>
        /// <param name="parameters">Opcionális paraméter. Az sql paraméterei, amely egy Nx2-es string tömb. A 0. oszlopban vannak a paraméterek név adatai (ha nincs előtte @ karakter, akkor hozzáteszi, tehát @ nélkül is működik és @ megadásával is). Az 1. oszlopban vannak a paraméterek értékei. Fontos: az sql parancsban lévő paramétereknek szinkronban kell lenni a parameters tömb adataival!</param>
        /// <returns>A lekérdezés visszatérési értéke minden esetben egy ListItemMy objektumokból álló tömb.</returns>
        /// <exception cref="Exception"></exception>
        public ListItemMy[] SelectItemsGUI(string sql, string[,] parameters = null)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                List<ListItemMy> data = new List<ListItemMy>();
                Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                if (parameters != null)
                {
                    ParametersInit(command, parameters);
                }
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.FieldCount != 2)
                {
                    throw new Exception("Az sql lekérdezésnek csak két oszlopa lehet!");
                }
                while (reader.Read())
                {
                    data.Add(new ListItemMy(reader[0], reader[1].ToString()));
                }
                Close();
                Cursor.Current = Cursors.Default;
                return data.ToArray();
            }
            catch (MySqlException err)
            {
                Cursor.Current = Cursors.Default;
                throw new Exception($"{err.Message} (Hibakód: {err.Number})");
            }
        }

        /// <summary>
        /// Lekérdezés jellegű sql parancs végrehajtása, az adathalmazt (táblázatot) egy DataTable-ben adja vissza, melyet asztali alkalmazásnál fel lehet használni egy DataGridView-nál. MySqlDataAdapter-t használ.
        /// </summary>
        /// <param name="sql">Az sql parancs, melyet szeretnénk végrehajtani</param>
        /// <param name="parameters">Opcionális paraméter. Az sql paraméterei, amely egy Nx2-es string tömb. A 0. oszlopban vannak a paraméterek név adatai (ha nincs előtte @ karakter, akkor hozzáteszi, tehát @ nélkül is működik és @ megadásával is). Az 1. oszlopban vannak a paraméterek értékei. Fontos: az sql parancsban lévő paramétereknek szinkronban kell lenni a parameters tömb adataival!</param>
        /// <returns>A lekérdezés visszatérési értéke a teljes adattábla (DataTable), mint egy táblázat.</returns>
        public DataTable SelectDataTableGUI(string sql, string[,] parameters = null)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataSet data = new DataSet();
                Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                if (parameters != null)
                {
                    ParametersInit(command, parameters);
                }
                adapter.SelectCommand = command;
                adapter.Fill(data);
                Close();
                Cursor.Current = Cursors.Default;
                return data.Tables[0];
            }
            catch (MySqlException err)
            {
                Cursor.Current = Cursors.Default;
                throw new Exception($"{err.Message} (Hibakód: {err.Number})");
            }
        }

        /// <summary>
        /// Lekérdezés jellegű sql parancs végrehajtása, az adathalmazt (táblázatot) egy DataTable-ben adja vissza, melyet asztali alkalmazásnál fel lehet használni egy DataGridView-nál. MySqlDataReader-t használ.
        /// </summary>
        /// <param name="sql">Az sql parancs, melyet szeretnénk végrehajtani</param>
        /// <param name="parameters">Opcionális paraméter. Az sql paraméterei, amely egy Nx2-es string tömb. A 0. oszlopban vannak a paraméterek név adatai (ha nincs előtte @ karakter, akkor hozzáteszi, tehát @ nélkül is működik és @ megadásával is). Az 1. oszlopban vannak a paraméterek értékei. Fontos: az sql parancsban lévő paramétereknek szinkronban kell lenni a parameters tömb adataival!</param>
        /// <returns>A lekérdezés visszatérési értéke a teljes adattábla (DataTable), mint egy táblázat.</returns>
        public DataTable SelectDataTableGUI2(string sql, string[,] parameters = null)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataTable table = new DataTable();
                Open();
				MySqlCommand command = new MySqlCommand(sql, connection);
                if (parameters != null)
                {
                    ParametersInit(command, parameters);
                }
				MySqlDataReader reader = command.ExecuteReader();
				table.Load(reader);
				Close();
                Cursor.Current = Cursors.Default;
				return table;
            }
            catch (MySqlException err)
            {
                Cursor.Current = Cursors.Default;
                throw new Exception($"{err.Message} (Hibakód: {err.Number})");
            }
        }

        /// <summary>
        /// Lekérdezés jellegű sql parancs végrehajtása, az adathalmazt (táblázatot) egy BindingSource-ben adja vissza, melyet asztali alkalmazásnál fel lehet használni egy DataGridView-nál. MySqlDataAdapter-t használ.
        /// </summary>
        /// <param name="sql">Az sql parancs, melyet szeretnénk végrehajtani</param>
        /// <param name="parameters">Opcionális paraméter. Az sql paraméterei, amely egy Nx2-es string tömb. A 0. oszlopban vannak a paraméterek név adatai (ha nincs előtte @ karakter, akkor hozzáteszi, tehát @ nélkül is működik és @ megadásával is). Az 1. oszlopban vannak a paraméterek értékei. Fontos: az sql parancsban lévő paramétereknek szinkronban kell lenni a parameters tömb adataival!</param>
        /// <returns>A lekérdezés visszatérési értéke a teljes adattábla (DataTable), mint egy táblázat.</returns>
        public BindingSource SelectBindingSourceGUI(string sql, string[,] parameters = null)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataSet data = new DataSet();
                BindingSource bindingSource = new BindingSource();
                Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                if (parameters != null)
                {
                    ParametersInit(command, parameters);
                }
                adapter.SelectCommand = command;
                adapter.Fill(data);
                bindingSource.DataSource = data.Tables[0];
                Close();
                Cursor.Current = Cursors.Default;
                return bindingSource;
            }
            catch (MySqlException err)
            {
                Cursor.Current = Cursors.Default;
                throw new Exception($"{err.Message} (Hibakód: {err.Number})");
            }
        }

        /// <summary>
        /// Lapozáshoz előkészítés. Egy listát feltölt annyi "?.oldal" elemmel, amennyi szükséges. 
        /// </summary>
        /// <param name="count">Az teljes sql lekérdezés sorainak a száma. Referencia szerinti  paraméter!</param>
        /// <param name="sql">A lekérdezés sql parancsa. Fontos: COUNT darabszám értéket kérdezzen le!</param>
        /// <param name="pagePerCount">A lapozásnál egy oldalon mennyi adatsor látszódjék. Hányasával történjék a lapozás. Nem kötelező paraméter, alapértelmezetten 20.</param>
        /// <param name="parameters">Opcionális paraméter. Az sql paraméterei, amely egy Nx2-es string tömb. A 0. oszlopban vannak a paraméterek név adatai (ha nincs előtte @ karakter, akkor hozzáteszi, tehát @ nélkül is működik és @ megadásával is). Az 1. oszlopban vannak a paraméterek értékei. Fontos: az sql parancsban lévő paramétereknek szinkronban kell lenni a parameters tömb adataival!</param>
        /// <returns>A lekérdezés visszatérési értéke minden esetben egy ListItemMy objektumokból álló tömb, ahol az ID az adott oldal, ami 0-val kezdődik.</returns>
        public ListItemMy[] PaginatorInit(ref int count, string sql, int pagePerCount = 20, string[,] parameters = null)
        {
            count = (int)SelectOneValue(sql, parameters);
            List<ListItemMy> data = new List<ListItemMy>();
            int page = 0;
            for (int i = 0; i < count; i+=pagePerCount)
            {
                data.Add(new ListItemMy(page, $"{page + 1}. oldal"));
                page++;
            }
            return data.ToArray();
        }

    }
}
