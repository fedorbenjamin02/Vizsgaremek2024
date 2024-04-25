// ------------------------------------------------------- //
// Készült: 2023/2024. tanév, Wiezl Csaba                  // 
// Verzió: 1.1 (2023.11.27.)                               // 
// ------------------------------------------------------- //
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace MyProgNameSpace
{
    /// <summary>
    /// ; Comment1
    /// [Section1 name]
    /// Keyword11 = Value11
    /// Keyword12 = Value12    
    /// [Section2 name]
    /// ; Comment2
    /// Keyword21 = Value21
    /// Keyword22 = Value22
    /// INI fájlok kezelését végző osztály. A szakaszok (sections) és a kulcsok (keys) egyformán kezeli a kis- és a nagybetűket, minden esetben nagybetűssé alakítja azt. A szakaszok és a kulcsok neve automatikusan átalakításra kerül, hogy se az elején, se a végén ne legyen szóköz, továbbá közben a szóköz ismétlések közül csak egy szóköz maradjon. A felesleges üres sorokat kitörli. A megjegyzéseket nem veszi figyelembe, de ott marad. Megjegyzés: csak teljes sor lehet és ahol pontosvesszővel kezdődik a sor. 
    /// </summary>
    public class MyINI
    {
        /// <summary>
        /// Az ini fájl neve teljes elérési úttal.
        /// </summary>
        private string fileName;
        public string FileName { get => fileName; }

        /// <summary>
        /// Csak a szakaszok listája (plusz az esetleges egjegyzések is). Üres sorok nem kerülnek bele.
        /// </summary>
        private List<string> sections = new List<string>();

        /// <summary>
        /// Az ini fájl minden egyes sora egy listákból álló szöveg típusú listákban. A fő lista a szakaszokat (plusz megjegyzéseket) tartalmazza. Az egyes belső listák minden esetben az adott szakaszon belüli kulcsok és értékek (0. index a szakasz, utána a kulcsok+értékek: páratlan indexen a kulcs, páros indexen az érték). Ha a szakaszon belül megjegyzés szerepel, akkor a kulcs maga a megjegyzés, az érték egy fiktív üres szöveg.
        /// </summary>
        private List<List<string>> rows = new List<List<string>>();

        /// <summary>
        /// 1. konstruktor: paraméter nélküli. Ebben az esetben az exe fájl mellett jön létre az ini fájl, melynek neve ugyanaz, mint a programfájl neve, csak az exe helyett ini lesz a kiterjesztése.
        /// </summary>
        public MyINI()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string dir = Path.GetDirectoryName(path);
            string name = Path.GetFileNameWithoutExtension(path);
            fileName = $@"{dir}\{name}.ini";
            CreateIniFile();
        }

        /// <summary>
        /// 2. konstruktor: a fájlnév konkrét megadásával lehet létrehozni az ini fájt.
        /// </summary>
        /// <param name="fileName">Ha csak a fájl nevét adja meg, akkor automatikusan az exe fájl mappájában jön étre az ini fájl. Ha elérési úttal együtt adja meg a fájl nevét, akkor az odott mappában jön létre az ini fájl.</param>
        /// <exception cref="Exception"></exception>
        public MyINI(string fileName)
        {
            if (fileName.IndexOf('\\') == -1)
            {
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string dir = Path.GetDirectoryName(path);
                this.fileName = $@"{dir}\{fileName}";
            }
            else
            {
                string dir = Path.GetDirectoryName(fileName);
                if (Directory.Exists(dir)) 
                {
                    this.fileName = fileName;
                }
                else
                {
                    throw new Exception($"Nincs ilyen mappa: {dir}");
                }
            }
            CreateIniFile();
        }

        /// <summary>
        /// Az ini fájl tényleges létrehozása adott mappában, adott névvel.
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void CreateIniFile()
        {
            try
            {
                if (!File.Exists(FileName))
                {
                    StreamWriter file = new StreamWriter(FileName);
                    file.Close();
                }
            }
            catch (Exception)
            {
                throw new Exception($"Nem sikerült az ini fájlt létrehozni!\nFájl: {FileName}");
            }
        }

        /// <summary>
        /// Saját átalakítása a paraméterben átadott szövegnek. Elejéről és a végéről kiszedi az összes szóközt. Ha van közbülső szóköz ismétlés, akkor ott csak egyetlen szóköz marad. A szöveg minenképpen nagybetűs lesz.
        /// </summary>
        /// <param name="str">Az a szöveg, amit szeretnénk átalakítani.</param>
        /// <returns>Az átalakított szöveg felesleges szóközök nélkül és csupa nagbetűsen.</returns>
        private string MyTrim(string str)
        {
            return string.Join(" ", str.Trim().ToUpper().Split(' ').Where(x => x != "")).Trim();
        }

        /// <summary>
        /// Saját kereső IndexOf függvény. A paraméterben kapott szakasz (section) keresi meg. Kis- és nagybetűt azonosnak veszi. A MyTrim függvénnyel átalaktja, hogy a keresés egyforma legyen. 
        /// </summary>
        /// <param name="section">Az a szakasz (section), amit keresni szeretne.</param>
        /// <returns>Visszatérési érték -1, ha nincs benne az adott szakasz. Különben egy nem negatív érték, az az index, ahol a szakasz megtalálható.</returns>
        private int MyIndexOf(string section)
        {
            section = $"[{MyTrim(section)}]";
            return sections.IndexOf(section);
        }

        /// <summary>
        /// Saját kereső IndexOf függvény. A paraméterben kapott szakaszon (section) belül keresi meg az adott kulcsot (key). Kis- és nagybetűt azonosnak veszi. A MyTrim függvénnyel átalaktja, hogy a keresés egyforma legyen. 
        /// </summary>
        /// <param name="section">Az a szakasz (section), amiben keresni szeretne.</param>
        /// <param name="key">Az a kulcs (key) a szakaszon belül, amit keresni szeretne.</param>
        /// <returns>Visszatérési érték -1, ha nincs benne az adott szakaszon belül az adott kulcs. Különben egy nem negatív érték, az az index, ahol a szakaszon belül megtalálható a keresett kulcs.</returns>
        private int MyIndexOf(string section, string key)
        {
            int index = MyIndexOf(section);
            if (index != -1)
            {
                key = MyTrim(key); 
                for (int i = 1; i < rows[index].Count; i += 2)
                {
                    if (rows[index][i] == key)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// A teljes ini beolvasásra kerül a memóriába saját szerkezetű listában listával. Ezt a kétszintű listát üríti ki. 
        /// </summary>
        private void ClearAll()
        {
            foreach (List<string> row in rows)
            {
                row.Clear();
            }
            rows.Clear();
            sections.Clear();
        }

        /// <summary>
        /// Az ini fájl tartalmát beolvassa a memóriába egy saját szerkezetű listákba. A megjegyzéseket megtartja, de a felesleges üres sorokat nem tárolja. A szakaszok és a kulcsok nevét mindenképpen átalakítja csupa nagybetűssé és a felesleges szóközöket kiszedi.
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void ReadAllDataFromIniFile()
        {
            try
            {
                ClearAll();
                List<string> temp = new List<string>();
                string[] lines = File.ReadAllLines(FileName);
                string s;
                int i = 0;
                while (i < lines.Length)
                {
                    s = lines[i].Trim().ToUpper();
                    if (s == "")
                    {
                        i++;
                    }
                    else if (s[0] == ';')
                    {
                        sections.Add(s);
                        List<string> data = new List<string>();
                        data.Add(s);
                        rows.Add(data);
                        i++;
                    }
                    else if (s[0] == '[' && s[s.Length - 1] == ']')
                    {
                        if (sections.IndexOf(s) == -1)
                        {
                            sections.Add(s);
                            temp.Clear();
                            temp.Add(s);
                            if (i < lines.Length)
                            {
                                i++;
                                while (i < lines.Length)
                                {
                                    s = lines[i].Trim();
                                    if (s != "" && s[0] == ';')
                                    {
                                        temp.Add(s);
                                        temp.Add("");
                                    }
                                    else if (s != "" && s[0] == '[' && s[s.Length - 1] == ']')
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        int index = s.IndexOf('=');
                                        if (index != -1)
                                        {
                                            string key = s.Substring(0, index).ToUpper();
                                            string value = s.Substring(index + 1);
                                            temp.Add(key.Trim());
                                            temp.Add(value.Trim());
                                        }
                                    }
                                    i++;
                                }
                                List<string> data = new List<string>();
                                data.AddRange(temp.ToArray());
                                rows.Add(data);
                            }
                        }
                        else
                        {
                            if (i < lines.Length)
                            {
                                i++;
                                while (i < lines.Length && (lines[i] == "" || !(lines[i][0] == '[' && lines[i][lines[i].Length - 1] == ']')))
                                {
                                    i++;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Hiba az ini fájl beolvasása során!");
            }
        }

        /// <summary>
        /// A memóriában lévő tartalmat kiírja az ini fájlba. Az ini fájl szerkezete megfelel az ini fájloknál megszokottal. A korábbi fájl tartalmát minden esetben felülírja! 
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void SaveAllDataToIniFile()
        {
            try
            {
                StreamWriter file = new StreamWriter(FileName, false, Encoding.UTF8);
                foreach (List<string> row in rows)
                {
                    string temp = row[0];
                    file.WriteLine(temp);
                    if (temp != "" && temp[0] == '[' && temp[temp.Length - 1] == ']')
                    {
                        for (int j = 1; j < row.Count; j += 2)
                        {
                            if (row[j] != "" && row[j][0] != ';')
                            {
                                file.WriteLine($"{row[j]}={row[j + 1]}");
                            }
                            else
                            {
                                file.WriteLine($"{row[j]}");
                            }
                        }
                    }
                }
                file.Close();
            }
            catch (Exception)
            {
                throw new Exception("Hiba az ini fájl írása során!");
            }
        }

        /// <summary>
        /// Az ini fájlban lévő szakaszok (sections) listáját kérdezheti le.
        /// </summary>
        /// <returns>A szakaszokat egy szöveg típusú listában adja vissza.</returns>
        public List<string> ReadSections()
        {
            List<string> names = new List<string>();
            ReadAllDataFromIniFile();
            foreach (string name in sections)
            {
                if (name != "" && name[0] != ';')
                {
                    names.Add(name.Substring(1, name.Length - 2));
                }
            }
            return names;
        }

        /// <summary>
        /// Az ini fájlban lévő adott szakaszon belüli kulcsok listáját kérdezheti le.
        /// </summary>
        /// <returns>Az adott szakaszon belüli kulcsokat adja vissza egy szöveg típusú listában. fontos: csak a kulcsok neve!</returns>
        public List<string> ReadSection(string section)
        {
            List<string> keys = new List<string>();
            int index = MyIndexOf(section);
            if (index != -1)
            {
                for (int i = 1; i < rows[index].Count; i += 2)
                {
                    keys.Add(rows[index][i]);
                }
            }
            return keys;
        }

        /// <summary>
        /// Az ini fájlban lévő adott szakaszon belüli kulcsok értékeinek listáját kérdezheti le.
        /// </summary>
        /// <returns>Az adott szakaszon belüli kulcsok értékeit adja vissza egy szöveg típusú listában. Fontos: csak a kulcsok értékei!</returns>
        public List<string> ReadSectionValues(string section)
        {
            List<string> values = new List<string>();
            int index = MyIndexOf(section);
            if (index != -1)
            {
                for (int i = 1; i < rows[index].Count; i += 2)
                {
                    values.Add(rows[index][i+1]);
                }
            }
            return values;
        }

        /// <summary>
        /// Létezik-e az ini fájlban a megadott szakasz?
        /// </summary>
        /// <param name="section">A vizsgált szakasz neve.</param>
        /// <returns>True: létezik az adott szakasz. False: nem létezik az adott szakasz.</returns>
        public bool SectionExists(string section)
        {
            return MyIndexOf(section) != -1;
        }

        /// <summary>
        /// Létezik-e az ini fájlban a megadott szakaszon belül az adott kulcs?
        /// </summary>
        /// <param name="section">A vizsgált szakasz neve.</param>
        /// <param name="key">A vizsgált szakaszo belüli kulcs neve.</param>
        /// <returns>True: létezik az adott szakaszon belül az adott kulcs. False: nem létezik ilyen szakaszon belül ilyen kulcs.</returns>
        public bool KeyExists(string section, string key)
        {
            return MyIndexOf(section, key) != -1;
        }

        /// <summary>
        /// Az ini fájlba beír egy szöveg típusú értéket. Az ini fájlba az adott szakaszon belüli adott kulccsal kerül be az érték. Ha a szakaszon belül létezik már ilyen kulcs, akkor annak csak az értékét cseréli le. Ha még nem létezik a szakaszon belül ilyen kulcs, akkor a kulccsal együtt hozza létre. 
        /// </summary>
        /// <param name="section">Az adott szakasz neve.</param>
        /// <param name="key">A szakaszon belüli kulcs neve</param>
        /// <param name="value">A kulcshoz tartozó érték szövegként.</param>
        public void WriteString(string section, string key, string value)
        {
            ReadAllDataFromIniFile();

            int index = MyIndexOf(section);
            int pos = MyIndexOf(section, key);

            section = $"[{MyTrim(section)}]";
            key = MyTrim(key);
            value = value.Trim();

            if (index == -1)
            {
                sections.Add(section);
                List<string> data = new List<string>();
                data.Add(section);
                data.Add(key);
                data.Add(value);
                rows.Add(data);
            }
            else
            {
                if (pos == -1)
                {
                    rows[index].Add(key);
                    rows[index].Add(value);
                }
                else
                {
                    rows[index][pos + 1] = value;
                }
            }

            SaveAllDataToIniFile();
        }

        /// <summary>
        /// Az ini fájlba beír egy egész típusú értéket. Az ini fájlba az adott szakaszon belüli adott kulccsal kerül be az érték. Ha a szakaszon belül létezik már ilyen kulcs, akkor annak csak az értékét cseréli le. Ha még nem létezik a szakaszon belül ilyen kulcs, akkor a kulccsal együtt hozza létre. 
        /// </summary>
        /// <param name="section">Az adott szakasz neve.</param>
        /// <param name="key">A szakaszon belüli kulcs neve</param>
        /// <param name="value">A kulcshoz tartozó érték egész számként.</param>
        public void WriteInteger(string section, string key, int value)
        {
            WriteString(section, key, value.ToString());
        }

        /// <summary>
        /// Az ini fájlba beír egy valós típusú értéket. Az ini fájlba az adott szakaszon belüli adott kulccsal kerül be az érték. Ha a szakaszon belül létezik már ilyen kulcs, akkor annak csak az értékét cseréli le. Ha még nem létezik a szakaszon belül ilyen kulcs, akkor a kulccsal együtt hozza létre. 
        /// </summary>
        /// <param name="section">Az adott szakasz neve.</param>
        /// <param name="key">A szakaszon belüli kulcs neve</param>
        /// <param name="value">A kulcshoz tartozó érték valós számként. Fontos: az ini fájlban a valós szám tizedes ponttal fog szerpelni!</param>
        public void WriteDouble(string section, string key, double value)
        {
            WriteString(section, key, value.ToString().Replace(',', '.'));
        }

        /// <summary>
        /// Az ini fájlba beír egy logikai típusú értéket. Az ini fájlba az adott szakaszon belüli adott kulccsal kerül be az érték. Ha a szakaszon belül létezik már ilyen kulcs, akkor annak csak az értékét cseréli le. Ha még nem létezik a szakaszon belül ilyen kulcs, akkor a kulccsal együtt hozza létre. Fontos: True esetében a kulcs értéke 1, különben 0.
        /// </summary>
        /// <param name="section">Az adott szakasz neve.</param>
        /// <param name="key">A szakaszon belüli kulcs neve</param>
        /// <param name="value">A kulcshoz tartozó logikai érték (true/false).</param>
        public void WriteBoolean(string section, string key, bool value)
        {
            WriteString(section, key, value ? "1" : "0");
        }

        /// <summary>
        /// Az ini fájlból az adott szakaszon belüli kulcs értékét adja vissza szövegként. 
        /// </summary>
        /// <param name="section">Az érintett szakasz neve.</param>
        /// <param name="key">Az érintett kulcs neve az adott szakaszon belül.</param>
        /// <param name="defaultValue">Ha nem létezik vagy a szakasz, vagy a szakasz+kulcs, akkor ezt az értéket adja vissza. Nem kötelező paraméter.</param>
        /// <returns>Az adott szakaszon belüli kulcs értékét adja vissza szövegként. Ha nincs ilyen, akkor a defaultValue értékét adja vissza.</returns>
        public string ReadString(string section, string key, string defaultValue = "")
        {
            ReadAllDataFromIniFile();
            int index = MyIndexOf(section);
            int pos = MyIndexOf(section, key);

            if (index != -1 && pos != -1)
            {
                return rows[index][pos + 1];
            }
            return defaultValue;
        }

        /// <summary>
        /// Az ini fájlból az adott szakaszon belüli kulcs értékét adja vissza egész számként. 
        /// </summary>
        /// <param name="section">Az érintett szakasz neve.</param>
        /// <param name="key">Az érintett kulcs neve az adott szakaszon belül.</param>
        /// <param name="defaultValue">Ha nem létezik vagy a szakasz, vagy a szakasz+kulcs, akkor ezt az értéket adja vissza. Nem kötelező paraméter.</param>
        /// <returns>Az adott szakaszon belüli kulcs értékét adja vissza egész számként. Ha nincs ilyen, akkor a defaultValue értékét adja vissza.</returns>
        public int ReadInteger(string section, string key, int defaultValue = 0)
        {
            return Convert.ToInt32(ReadString(section, key, defaultValue.ToString()));
        }

        /// <summary>
        /// Az ini fájlból az adott szakaszon belüli kulcs értékét adja vissza valós számként. 
        /// </summary>
        /// <param name="section">Az érintett szakasz neve.</param>
        /// <param name="key">Az érintett kulcs neve az adott szakaszon belül.</param>
        /// <param name="defaultValue">Ha nem létezik vagy a szakasz, vagy a szakasz+kulcs, akkor ezt az értéket adja vissza. Nem kötelező paraméter.</param>
        /// <returns>Az adott szakaszon belüli kulcs értékét adja vissza valós számként. Ha nincs ilyen, akkor a defaultValue értékét adja vissza. Fontos: az ini fájlban pl.  2.8 szerepel, de a visszaadott érték már a területi beállításnak megfelelő 2,8 lesz majd és valós típusú!</returns>
        public double ReadDouble(string section, string key, double defaultValue = 0)
        {
            return Convert.ToDouble(ReadString(section, key, defaultValue.ToString().Replace(',', '.')).Replace('.', ','));
        }

        /// <summary>
        /// Az ini fájlból az adott szakaszon belüli kulcs értékét adja vissza logikai értékként. 
        /// </summary>
        /// <param name="section">Az érintett szakasz neve.</param>
        /// <param name="key">Az érintett kulcs neve az adott szakaszon belül.</param>
        /// <param name="defaultValue">Ha nem létezik vagy a szakasz, vagy a szakasz+kulcs, akkor ezt az értéket adja vissza. Nem kötelező paraméter.</param>
        /// <returns>Az adott szakaszon belüli kulcs értékét adja vissza logikai értékkel. Ha nincs ilyen, akkor a defaultValue értékét adja vissza. Fontos: az ini fájlban 1 esetén true, míg 0 esetén false értéket ad vissza!</returns>
        public bool ReadBoolean(string section, string key, bool defaultValue = false)
        {
            return ReadInteger(section, key, defaultValue ? 1 : 0) == 1;
        }

        /// <summary>
        /// Az ini fájlból az adott szakaszon belüli kulcsot törli ki az értékkel együtt.
        /// </summary>
        /// <param name="section">Az érintett szakasz neve.</param>
        /// <param name="key">Az érintett kulcs neve az adott szakaszon belül.</param>
        /// <returns>True: volt tényleges törlés. False: nem történt tényleges törlés, vagy a szakasz vagy a szakasz+kulcs eleve sem létezett.</returns>
        public bool DeleteKey(string section, string key)
        {
            ReadAllDataFromIniFile();
            int index = MyIndexOf(section);
            int pos = MyIndexOf(section, key);

            if (index != -1 && pos != -1)
            {
                rows[index].RemoveAt(pos + 1);
                rows[index].RemoveAt(pos);
                SaveAllDataToIniFile();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Az ini fájlból az adott szakasz teljes törlése. (A szakaszon belüli kulcsokkal együtt.)
        /// </summary>
        /// <param name="section">Az érintett szakasz neve.</param>
        /// <returns>True: volt tényleges törlés. False: nem történt tényleges törlés, a szakasz már eleve nem létezett.</returns>
        public bool DeleteSection(string section)
        {
            ReadAllDataFromIniFile();
            int index = MyIndexOf(section);

            if (index != -1)
            {
                rows[index].Clear();
                rows.RemoveAt(index);
                SaveAllDataToIniFile();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Minden szakasz törlése az ini fájlból - üres lesz.
        /// </summary>
        /// <returns>True: sikeres törlés. False: sikertelen törlés.</returns>
        public bool DeleteAllSection()
        {
            try
            {
                StreamWriter file = new StreamWriter(FileName);
                file.Close();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

    }
}
