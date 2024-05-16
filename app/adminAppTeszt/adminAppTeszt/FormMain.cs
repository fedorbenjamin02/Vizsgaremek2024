using MyDatabaseMySQL;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace adminAppTeszt
{
    public partial class FormMain : FormAlap
    {
        private AdatokTablazatbanForm AdatokTablazatbanFrm;
        private UjAdatTermekForm ujTermekFrm;
        private UjAdatTermekKategoriaForm ujTermekKategoriaFrm;
        private UjAdatTermekCsoportForm ujTermekCsoportFrm;
        private UjAdatFizetesiModokForm ujFizetesiModokFrm;
        private UjAdatAfaKulcsForm ujAfaKulcsFrm;
        private UjAdatMennyisegiEgysegForm ujMennyisegiEgysegFrm;
        private TermekModositTorolForm termekModositTorolFrm;
        private TermekKatModositTorolForm termekKatModositTorolFrm;
        private TermekCsModositTorolForm termekCsModositTorolFrm;
        private FizetesiModokModositTorolForm FizetesiModokModositTorolFrm;
        private AfaKulcsModositTorolForm AfaKulcsModositTorolFrm;
        private MennyisegiEgysegekModositTorolForm MennyisegiEgysegekModositTorolFrm;

        public FormMain()
        {
            InitializeComponent();
            CreateForms();
        }
        private void CreateForms()
        {
            CreateAdatokTablazatbanForm();
        }
        private void CreateAdatokTablazatbanForm()
        {
            AdatokTablazatbanFrm = new AdatokTablazatbanForm();
        }
        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #region Adatok táblázatban click eseménykezelők
        private void termékekToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT t.id AS ID, tcs.megnevezes AS Termék_csoport, t.megnevezes AS Név," +
                " t.leiras AS Leírás, t.netto_egyseg_ar AS Nettó_ár, m.megnevezes AS Egység, a.megnevezes AS Áfakulcs " +
                "FROM termek AS t INNER JOIN termek_csoport AS tcs ON tcs.id = t.termek_csoport_id INNER JOIN mennyisegi_egysegek" +
                " AS m ON m.id = t.mennyisegi_egysegek_id INNER JOIN afa_kulcsok AS a ON a.id = t.afa_kulcs_id ORDER BY tcs.id;";
            //string sql = "SELECT t.megnevezes AS Megnevezés FROM termek AS t INNER JOIN termek_csoport AS tcs ON tcs.id = t.termek_csoport_id WHERE tcs.megnevezes = 'Levesek'";
            AdatokTablazatbanFrm.DGV.DataSource = DB.SelectDataTableGUI(sql);
            AdatokTablazatbanFrm.Text = "Termékek";
            AdatokTablazatbanFrm.ShowDialog();
            
        }
        private void felhasználóiAdatokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM felhasznalo_adatok";
            AdatokTablazatbanFrm.DGV.DataSource = DB.SelectDataTableGUI(sql);
            AdatokTablazatbanFrm.Text = "Felhasználói adatok";
            AdatokTablazatbanFrm.ShowDialog();
            
        }
        private void fizetésiMódokToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM fizetesi_modok";
            AdatokTablazatbanFrm.DGV.DataSource = DB.SelectDataTableGUI(sql);
            AdatokTablazatbanFrm.Text = "Fizetési módok";
            AdatokTablazatbanFrm.ShowDialog();
            
        }
        private void áfakulcsokToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM afa_kulcsok";
            AdatokTablazatbanFrm.DGV.DataSource = DB.SelectDataTableGUI(sql);
            AdatokTablazatbanFrm.Text = "Áfa kulcsok";
            AdatokTablazatbanFrm.ShowDialog();
            
        }
        private void településekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int limit = 100;
            int offset = 0;
            string sql = "SELECT * FROM telepulesek LIMIT " + limit + " OFFSET " + offset + " ;";
            AdatokTablazatbanFrm.DGV.DataSource = DB.SelectDataTableGUI(sql);
            AdatokTablazatbanFrm.Text = "Települések";
            AdatokTablazatbanFrm.ShowDialog();
            
        }
        private void termékCsoportokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT tcs.id AS ID, tk.megnevezes AS Termék_kategória," + 
                " tcs.megnevezes AS Megnevezés FROM termek_csoport AS tcs" + 
                " INNER JOIN termek_kategoria AS tk ON tcs.termek_kategoria_id=tk.id ORDER BY tcs.id;";
            AdatokTablazatbanFrm.DGV.DataSource = DB.SelectDataTableGUI(sql);
            AdatokTablazatbanFrm.Text = "Termék csoportok";
            AdatokTablazatbanFrm.ShowDialog();
            
        }
        private void rendelésekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT r.id AS Rendelés_Száma, r.teljes_nev AS Név," + 
                " fa.telefonszam AS Telefon, r.cim AS Cím, fm.megnevezes AS Fizetés_módja," + 
                " rs.rendeles_allapot AS Állapot, r.rendeles_datumido AS Ipőpont," + 
                " r.szallitas_datum AS Szállítási_dátum, r.szallitas_megj AS Megjegyzés," + 
                " r.netto_vegosszeg AS Nettó_végösszeg, r.brutto_vegosszeg AS Bruttó_végösszeg " + 
                "FROM rendeles AS r" + 
                " INNER JOIN felhasznalo_adatok AS fa ON fa.id = r.felhasznalo_adatok_id" + 
                " INNER JOIN fizetesi_modok AS fm ON fm.id = r.fizetesi_modok_id" + 
                " INNER JOIN rendeles_statusza AS rs ON rs.id = r.rendeles_statusza_id ORDER BY r.rendeles_datumido;";
            AdatokTablazatbanFrm.DGV.DataSource = DB.SelectDataTableGUI(sql);
            AdatokTablazatbanFrm.Text = "Rendelések";
            AdatokTablazatbanFrm.ShowDialog();
            
        }
        private void rendelésTételeiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT r.id AS Rendelés_Száma, rt.ID AS tétel_ID, t.megnevezes AS Termék," +
            " rt.netto_egyseg_ar AS Nettó_egységár, rt.afakulcs AS Áfa," +
            " rt.mennyiseg AS mennyiség FROM rendeles_tetelei AS rt INNER JOIN termek" +
            " AS t ON t.id = rt.termek_id INNER JOIN rendeles AS r ON r.id = rt.rendeles_id ORDER BY 1;";
            AdatokTablazatbanFrm.DGV.DataSource = DB.SelectDataTableGUI(sql);
            AdatokTablazatbanFrm.Text = "Rendelés tételei";
            AdatokTablazatbanFrm.ShowDialog();
            
        }
        private void mennyiségiEgységekToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM mennyisegi_egysegek";
            AdatokTablazatbanFrm.DGV.DataSource = DB.SelectDataTableGUI(sql);
            AdatokTablazatbanFrm.Text = "Mennyiségi egységek";
            AdatokTablazatbanFrm.ShowDialog();
            
        }
        private void szállításiCímToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT szc.id AS ID, fh.teljes_nev AS Felhasználói_adatok," +
                " t.telepules AS Település, szc.utca_hazszam AS Utca_házszám " +
                "FROM szallitasi_cim AS szc INNER JOIN felhasznalo_adatok" +
                " AS fh ON szc.felhasznalo_adatok_id = fh.id INNER JOIN " +
                " telepulesek AS t ON szc.telepules_id = t.id ORDER BY szc.id;";
            AdatokTablazatbanFrm.DGV.DataSource = DB.SelectDataTableGUI(sql);
            AdatokTablazatbanFrm.Text = "Szállítási címek";
            AdatokTablazatbanFrm.ShowDialog();
            

        }
        #endregion
        #region Módosítás, törlés click eseménykezelők
        private void termékekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            termekModositTorolFrm = new TermekModositTorolForm(this);
            termekModositTorolFrm.ShowDialog();
        }
        private void termékKategóriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            termekKatModositTorolFrm = new TermekKatModositTorolForm(this);
            termekKatModositTorolFrm.ShowDialog();
        }
        private void termékCsoportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            termekCsModositTorolFrm = new TermekCsModositTorolForm(this);
            termekCsModositTorolFrm.ShowDialog();
        }
        private void fizetésiMódokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FizetesiModokModositTorolFrm = new FizetesiModokModositTorolForm(this);
            FizetesiModokModositTorolFrm.ShowDialog();
        }
        private void áfaKulcsokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AfaKulcsModositTorolFrm = new AfaKulcsModositTorolForm(this);
            AfaKulcsModositTorolFrm.ShowDialog();
        }
        private void mennyiségiEgységekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MennyisegiEgysegekModositTorolFrm = new MennyisegiEgysegekModositTorolForm(this);
            MennyisegiEgysegekModositTorolFrm.ShowDialog();
        }
        #endregion
        #region Új adatok click eseménykezelők
        private void újTermékToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ujTermekFrm = new UjAdatTermekForm(this);
            TermekHozzaAd();
        }
        private void újTermékKategóriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ujTermekKategoriaFrm = new UjAdatTermekKategoriaForm(this);
            TermekKategoriaHozzaAd();
        }
        private void újTermékCsoportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ujTermekCsoportFrm = new UjAdatTermekCsoportForm(this);
            TermekCsoportHozzaAd();
        }
        private void újFizetésiMódToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ujFizetesiModokFrm = new UjAdatFizetesiModokForm(this);
            FizetesiModHozzaAd();
        }
        private void újÁfakulcsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ujAfaKulcsFrm = new UjAdatAfaKulcsForm(this);
            AfaKulcsHozzaAd();
        }
        private void újMennyiségiEgységToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ujMennyisegiEgysegFrm = new UjAdatMennyisegiEgysegForm(this);
            MennyisegiEgysegHozzaAd();
        }
        #endregion
        #region Termékek hozzáadása
        public bool TermekHozzaAd()
        {
            this.ujTermekFrm.TTermekCsoportCb.Items.AddRange(DB.SelectItemsGUI("SELECT id,megnevezes FROM termek_csoport ORDER BY 1"));
            this.ujTermekFrm.TMennyEgysCb.Items.AddRange(DB.SelectItemsGUI("SELECT id,megnevezes FROM mennyisegi_egysegek ORDER BY 1"));
            this.ujTermekFrm.TAfaCb.Items.AddRange(DB.SelectItemsGUI("SELECT id,megnevezes FROM afa_kulcsok ORDER BY 1"));
            if (this.ujTermekFrm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (this.ujTermekFrm.TTermekCsoportCb.SelectedItem == null)
                    {
                        throw new Exception("Nincs megadva termékcsoport!");
                    }
                    if (this.ujTermekFrm.TMegnTb.Text == "")
                    {
                        throw new Exception("Nincs megadva megnevezés!");
                    }
                    if (this.ujTermekFrm.TLeirasTb.Text == "")
                    {
                        throw new Exception("Nincs megadva leírás!");
                    }
                    if (this.ujTermekFrm.TOFD1.FileName == "")
                    {
                        throw new Exception("Nincs fájl kiválasztva!");
                    }
                    if (this.ujTermekFrm.TNettoArNud.Value == 0)
                    {
                        throw new Exception("Nincs megadva nettó ár!");
                    }

                    if (this.ujTermekFrm.TMennyEgysCb.SelectedItem == null)
                    {
                        throw new Exception("Nincs megadva mennyiségi egység!");
                    }
                    if (this.ujTermekFrm.TAfaCb.SelectedItem == null)
                    {
                        throw new Exception("Nincs megadva áfa!");
                    }
                    string id = "NULL";
                    int termek_csoport_index = this.ujTermekFrm.TTermekCsoportCb.SelectedIndex;
                    string megn = this.ujTermekFrm.TMegnTb.Text;
                    string leiras = this.ujTermekFrm.TLeirasTb.Text;
                    string kep = this.ujTermekFrm.TFajlBtn.Text;
                    string netto_ar = this.ujTermekFrm.TNettoArNud.Value.ToString();
                    int menny_egys_index = this.ujTermekFrm.TMennyEgysCb.SelectedIndex;
                    int afa_index = this.ujTermekFrm.TAfaCb.SelectedIndex;

                    ListItemMy termek_csoport = this.ujTermekFrm.TTermekCsoportCb.Items[termek_csoport_index] as ListItemMy;
                    string termek_csoport_id = Convert.ToString(termek_csoport.ID);
                    ListItemMy menny_egys = this.ujTermekFrm.TMennyEgysCb.Items[menny_egys_index] as ListItemMy;
                    string menny_egys_id = Convert.ToString(menny_egys.ID);
                    ListItemMy afa = this.ujTermekFrm.TAfaCb.Items[afa_index] as ListItemMy;
                    string afa_id = Convert.ToString(afa.ID);
                    string[,] feltoltendo_adatok =
                {
                    {"@id", id },
                    {"@t_cs_id", termek_csoport_id },
                    {"@megn", megn },
                    {"@leiras", leiras },
                    {"@kep", kep },
                    {"@netto_ar", netto_ar },
                    {"@menny_egys_id", menny_egys_id },
                    {"@afa_id", afa_id },
                };
                    string sql = "INSERT INTO `termek` (`id`, `termek_csoport_id`, `megnevezes`,`leiras`, `kep`, `netto_egyseg_ar`, `mennyisegi_egysegek_id`, `afa_kulcs_id`) VALUES(@id, @t_cs_id, @megn, @leiras, @kep, @netto_ar,@menny_egys_id, @afa_id); ";
                    this.DB.Query(sql, feltoltendo_adatok);
                    MessageBox.Show("Az adatokat sikeresen feltöltötted", "Feltöltés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Adatokat nem sikerült eltárolni!\nHiba: " + err.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }
        #endregion
        #region Termék kategóriák hozzáadása
        public bool TermekKategoriaHozzaAd()
        {
            if (this.ujTermekKategoriaFrm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (this.ujTermekKategoriaFrm.TKMegnTb.Text == "")
                    {
                        throw new Exception("Nincs megadva megnevezés!");
                    }
                    string id = "NULL";
                    string megn = this.ujTermekKategoriaFrm.TKMegnTb.Text;
                    string[,] feltoltendo_adatok =
                {
                    {"@id", id },
                    {"@megn", megn },
                };
                    string sql = "INSERT INTO `termek_kategoria` (`id`, `megnevezes`) VALUES(@id, @megn);";
                    this.DB.Query(sql, feltoltendo_adatok);
                    MessageBox.Show("Az adatokat sikeresen feltöltötted", "Feltöltés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Adatokat nem sikerült eltárolni!\nHiba: " + err.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            return false;
        }
        #endregion
        #region Termék csoportok hozzáadása
        public bool TermekCsoportHozzaAd()
        {
            this.ujTermekCsoportFrm.TCsTermekKategoriaCb.Items.AddRange(DB.SelectItemsGUI("SELECT id,megnevezes FROM termek_kategoria ORDER BY 1"));
            if (this.ujTermekCsoportFrm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (this.ujTermekCsoportFrm.TCsTermekKategoriaCb.SelectedItem == null)
                    {
                        throw new Exception("Nincs megadva termék kategória!");
                    }
                    if (this.ujTermekCsoportFrm.TCsMegnTb.Text == "")
                    {
                        throw new Exception("Nincs megadva megnevezés!");
                    }
                    string id = "NULL";
                    int termek_kategoria_index = this.ujTermekCsoportFrm.TCsTermekKategoriaCb.SelectedIndex;
                    string megn = this.ujTermekCsoportFrm.TCsMegnTb.Text;
                    ListItemMy termek_kategoria = this.ujTermekCsoportFrm.TCsTermekKategoriaCb.Items[termek_kategoria_index] as ListItemMy;
                    string termek_kategoria_id = Convert.ToString(termek_kategoria.ID);
                    string[,] feltoltendo_adatok =
                {
                    {"@id", id },
                    {"@t_k_id", termek_kategoria_id },
                    {"@megn", megn },
                };
                    string sql = "INSERT INTO `termek_csoport` (`id`, `termek_kategoria_id`, `megnevezes`) VALUES(@id, @t_k_id, @megn);";
                    this.DB.Query(sql, feltoltendo_adatok);
                    MessageBox.Show("Az adatokat sikeresen feltöltötted", "Feltöltés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Adatokat nem sikerült eltárolni!\nHiba: " + err.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }
        #endregion
        #region Fizetési módok hozzáadása
        public bool FizetesiModHozzaAd()
        {
            if (this.ujFizetesiModokFrm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (this.ujFizetesiModokFrm.FMMegnTb.Text == "")
                    {
                        throw new Exception("Nincs megadva megnevezés!");
                    }
                    string id = "NULL";
                    string megn = this.ujFizetesiModokFrm.FMMegnTb.Text;
                    string[,] feltoltendo_adatok =
                {
                    {"@id", id },
                    {"@megn", megn },
                };
                    string sql = "INSERT INTO `fizetesi_modok` (`id`, `megnevezes`) VALUES(@id, @megn);";
                    this.DB.Query(sql, feltoltendo_adatok);
                    MessageBox.Show("Az adatokat sikeresen feltöltötted", "Feltöltés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Adatokat nem sikerült eltárolni!\nHiba: " + err.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }
        #endregion
        #region Áfakulcsok hozzáadása
        public bool AfaKulcsHozzaAd()
        {
            if (this.ujAfaKulcsFrm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (this.ujAfaKulcsFrm.AKMegnevezesTb.Text == "")
                    {
                        throw new Exception("Nincs megadva megnevezés!");
                    }
                    string id = "NULL";
                    string megn = this.ujAfaKulcsFrm.AKMegnevezesTb.Text;
                    string afa = this.ujAfaKulcsFrm.AKAfaKulcsNud.Value.ToString();
                    string afa_kulcs = afa.Replace(',', '.');
                    string[,] feltoltendo_adatok =
                {
                    {"@id", id },
                    {"@megn", megn },
                    {"@afa_kulcs", afa_kulcs },
                };
                    string sql = "INSERT INTO `afa_kulcsok` (`id`, `megnevezes`,`kulcs`) VALUES(@id, @megn, @afa_kulcs);";
                    this.DB.Query(sql, feltoltendo_adatok);
                    MessageBox.Show("Az adatokat sikeresen feltöltötted", "Feltöltés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Adatokat nem sikerült eltárolni!\nHiba: " + err.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }
        #endregion
        #region Mennyiségi egységek hozzáadása
        public bool MennyisegiEgysegHozzaAd()
        {
            if (this.ujMennyisegiEgysegFrm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (this.ujMennyisegiEgysegFrm.MEMegnTb.Text == "")
                    {
                        throw new Exception("Nincs megadva megnevezés!");
                    }
                    string id = "NULL";
                    string megn = this.ujMennyisegiEgysegFrm.MEMegnTb.Text;
                    string[,] feltoltendo_adatok =
                {
                    {"@id", id },
                    {"@megn", megn },
                };
                    string sql = "INSERT INTO `mennyisegi_egysegek` (`id`, `megnevezes`) VALUES(@id, @megn);";
                    this.DB.Query(sql, feltoltendo_adatok);
                    MessageBox.Show("Az adatokat sikeresen feltöltötted","Feltöltés",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Adatokat nem sikerült eltárolni!\nHiba: " + err.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }
        #endregion
        #region Bejelentkezés
        private void bejel_btn_Click(object sender, EventArgs e)
        {
            try
            {

                string felhasznalo_nev = felh_nev_tb.Text;
                if (felhasznalo_nev == "" && jelszo_tb.Text == "")
                {
                    throw new Exception("Nincs megadva felhasználónév vagy jelszó!");
                }
                if (felh_nev_tb.Text != DB.SelectOneValue("SELECT felhasznalo_nev FROM `admin` WHERE felhasznalo_nev = '" + felhasznalo_nev + "' ;"))
                {
                    felh_nev_tb.Text = "";
                    jelszo_tb.Text = "";
                    throw new Exception("Nem jó a felhasználónév, vagy jelszó!");
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    MD5 md5 = MD5.Create();

                    byte[] hash_ertek = md5.ComputeHash(Encoding.UTF8.GetBytes(jelszo_tb.Text));
                    foreach (byte betu in hash_ertek)
                    {
                        sb.Append($"{betu:x2}");
                    }
                    string md5_jelszo = sb.ToString();
                    if (md5_jelszo == DB.SelectOneValue("SELECT jelszo FROM `admin` WHERE felhasznalo_nev = '" + felhasznalo_nev + "' ;"))
                    {
                        MessageBox.Show("Sikeres belépés!");
                        fájlToolStripMenuItem.Visible = true;
                        adatokMegtekintéseToolStripMenuItem.Visible = true;
                        adatokMódosításaTörléseToolStripMenuItem.Visible = true;
                        újAdatFelvételeToolStripMenuItem.Visible = true;
                        felh_nev_tb.Visible = false;
                        jelszo_tb.Visible = false;
                        bejel_btn.Visible = false;
                        label1.Visible = false;
                        label2.Visible = false;
                    }
                    else
                    {
                        felh_nev_tb.Text = "";
                        jelszo_tb.Text = "";
                        throw new Exception("Nem jó a felhasználónév, vagy jelszó!");
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Hiba: " + err.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        #endregion
    }
}
