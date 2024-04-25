using MyDatabaseMySQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adminAppTeszt
{
    public partial class TermekModositTorolForm : ModositTorolAlapForm
    {
        protected FormMain main;
        private string termek_csoport_id, termek_kategoria_id;

        public TermekModositTorolForm(FormMain main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void TermekModositTorolForm_Load(object sender, EventArgs e)
        {
            termek_kategoria_cb.Items.AddRange(DB.SelectItemsGUI("SELECT id, megnevezes FROM termek_kategoria ORDER BY 1;"));
            termek_cs_cb.Visible = false;
            megn_tb.Visible = false;
            leiras_tb.Visible= false;
            fajl_btn.Visible = false;
            netto_ar_nud.Visible = false;
            menny_egys_cb.Visible = false;
            afa_cb.Visible = false;
            termek_cs_lbl.Visible = false;
            megn_lbl.Visible = false;
            leiras_lbl.Visible = false;
            kep_felt_lbl.Visible = false;
            netto_ar_lbl.Visible = false;
            menny_egys_lbl.Visible = false;
            afa_lbl.Visible = false;
            OK_btn.Visible = false;
            vissza_btn.Visible = false;
            
        }

        private void termek_csoport_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int termek_csoport_index = termek_csoport_cb.SelectedIndex;
            ListItemMy termek_csoport = termek_csoport_cb.Items[termek_csoport_index] as ListItemMy;
            termek_csoport_id = Convert.ToString(termek_csoport.ID);
            megn_cb.Items.Clear();
            megn_cb.Text = "";
            megn_cb.Items.AddRange(DB.SelectItemsGUI("SELECT id, megnevezes FROM termek WHERE termek_csoport_id = '" + termek_csoport_id + "' ORDER BY 1;"));
        }

        private void termek_kategoria_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int termek_kategoria_index = termek_kategoria_cb.SelectedIndex;
            ListItemMy termek_kategoria = termek_kategoria_cb.Items[termek_kategoria_index] as ListItemMy;
            termek_kategoria_id = Convert.ToString(termek_kategoria.ID);
            termek_csoport_cb.Items.Clear();
            termek_csoport_cb.Text = "";
            megn_cb.Items.Clear();
            megn_cb.Text = "";
            termek_csoport_cb.Items.AddRange(DB.SelectItemsGUI("SELECT id, megnevezes FROM termek_csoport WHERE termek_kategoria_id = '" + termek_kategoria_id +  "' ORDER BY 1;"));

        }

        private void fajl_btn_Click(object sender, EventArgs e)
        {
            OFD1.InitialDirectory = @"C:\xampp\htdocs\project-main\app\img\";
            OFD1.Filter = "Image Files(*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg ";
            this.OFD1.ShowDialog();

            string fajlnev = OFD1.FileName;
            List<string> kep_elut = new List<string>();
            string[] OFD1Split = fajlnev.Split('\\');
            int db = 0;
            foreach (var adat in OFD1Split)
            {
                kep_elut.Add(adat);
                db++;
            }
            this.fajl_btn.Text = Convert.ToString(kep_elut[db - 1]);
        }

        private void modosit_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (megn_cb.SelectedItem == null)
                {
                    throw new Exception("Nincs kiválasztott termék!");
                }
                
                Size = new Size(660, 500);
                termek_cs_cb.Visible = true;
                megn_tb.Visible = true;
                leiras_tb.Visible = true;
                fajl_btn.Visible = true;
                netto_ar_nud.Visible = true;
                menny_egys_cb.Visible = true;
                afa_cb.Visible = true;
                termek_cs_lbl.Visible = true;
                megn_lbl.Visible = true;
                leiras_lbl.Visible = true;
                kep_felt_lbl.Visible = true;
                netto_ar_lbl.Visible = true;
                menny_egys_lbl.Visible = true;
                afa_lbl.Visible = true;
                OK_btn.Visible = true;
                torol_btn.Visible = false;
                modosit_btn.Visible = false;
                vissza_btn.Visible = true;
                megse_btn.Visible = false;

                
                string megnevezes = megn_cb.SelectedItem.ToString();
                string termek_cs_megn = termek_csoport_cb.SelectedItem.ToString();
                


                megn_cb.Visible = false;
                termek_csoport_cb.Visible = false;
                termek_kategoria_cb.Visible = false;
                modosit_btn.Visible = false;

                termek_cs_cb.Items.Clear();
                termek_cs_cb.Items.AddRange(DB.SelectItemsGUI("SELECT id,megnevezes FROM termek_csoport WHERE termek_kategoria_id = '"+ termek_kategoria_id + "' ORDER BY 1"));
                menny_egys_cb.Items.Clear();
                menny_egys_cb.Items.AddRange(DB.SelectItemsGUI("SELECT id,megnevezes FROM mennyisegi_egysegek ORDER BY 1"));
                afa_cb.Items.Clear();
                afa_cb.Items.AddRange(DB.SelectItemsGUI("SELECT id,megnevezes FROM afa_kulcsok ORDER BY 1"));
                int menny_egys_id = Convert.ToInt32(DB.SelectOneValue("SELECT mennyisegi_egysegek_id FROM termek WHERE megnevezes = '" + megnevezes + "'"));
                string mennyisegi_megn = DB.SelectOneValue("SELECT megnevezes FROM mennyisegi_egysegek WHERE id = '" + menny_egys_id + "'");
                int afa_kulcs_id = Convert.ToInt32(DB.SelectOneValue("SELECT afa_kulcs_id FROM termek WHERE megnevezes = '" + megnevezes + "'"));
                string afa_kulcs_megn = DB.SelectOneValue("SELECT megnevezes FROM afa_kulcsok WHERE id = '" + afa_kulcs_id + "'");


                List<string> termek_csoportok = new List<string>();
                for (int i = 0; i < termek_cs_cb.Items.Count; i++)
                {
                    termek_csoportok.Add(termek_cs_cb.Items[i].ToString());
                    if (termek_csoportok[i] == termek_cs_megn)
                    {
                        termek_cs_cb.SelectedIndex = i;
                    }

                }
                List<string> mennyisegi_egysegek = new List<string>();
                for (int i = 0; i < menny_egys_cb.Items.Count; i++)
                {
                    mennyisegi_egysegek.Add(menny_egys_cb.Items[i].ToString());
                    if (mennyisegi_egysegek[i] == mennyisegi_megn)
                    {
                        menny_egys_cb.SelectedIndex = i;
                    }
                }
                List<string> afa_kulcsok = new List<string>();
                for (int i = 0; i < afa_cb.Items.Count; i++)
                {
                    afa_kulcsok.Add(afa_cb.Items[i].ToString());
                   if (afa_kulcsok[i]==afa_kulcs_megn)
                    {
                        afa_cb.SelectedIndex = i;
                    }
                }

                megn_tb.Text = DB.SelectOneValue("SELECT megnevezes FROM termek WHERE megnevezes = '" + megnevezes + "'");
                leiras_tb.Text = DB.SelectOneValue("SELECT leiras FROM termek WHERE megnevezes = '" + megnevezes + "'");
                OFD1.FileName = DB.SelectOneValue("SELECT kep FROM termek WHERE megnevezes = '" + megnevezes + "'");
                netto_ar_nud.Value = Convert.ToInt32(DB.SelectOneValue("SELECT netto_egyseg_ar FROM termek WHERE megnevezes = '" + megnevezes + "'"));
                fajl_btn.Text = DB.SelectOneValue("SELECT kep FROM termek WHERE megnevezes = '" + megnevezes + "'");

                

            }

            catch (Exception err)
            {
                MessageBox.Show("Hiba: " + err.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void torol_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (megn_cb.SelectedItem == null)
                {
                    throw new Exception("Nincs kiválasztott termék!");
                }
                DialogResult eredmeny = MessageBox.Show("Biztosan törlöd? ", "Törlés", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                if (eredmeny == DialogResult.OK)
                {
                    string megnevezes = megn_cb.SelectedItem.ToString();
                    string sql = ("DELETE FROM termek WHERE megnevezes = '" + megnevezes + "'");
                    DB.Query(sql);
                    MessageBox.Show("Sikeresen törölted ezt: " + megnevezes , "\nAz ablak bezárul!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Hiba: " + err.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void megse_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (megn_tb.Text == "")
                {
                    throw new Exception("Üresen maradt a megnevezés!");
                }
                if (leiras_tb.Text == "")
                {
                    throw new Exception("Üresen maradt a leírás!");
                }
                string kivalasztott_megn = megn_cb.SelectedItem.ToString();
                int id = DB.SelectOneValue("SELECT id FROM termek WHERE megnevezes = '" + kivalasztott_megn + "'");
                int termek_csoport_index = termek_cs_cb.SelectedIndex;
                string megn = megn_tb.Text;
                string leiras = leiras_tb.Text;
                string kep = fajl_btn.Text;
                int netto_ar_int = Convert.ToInt32(netto_ar_nud.Value);
                string netto_ar = Convert.ToString(netto_ar_int);
                int menny_egys_index = menny_egys_cb.SelectedIndex;
                int afa_index = afa_cb.SelectedIndex;

                ListItemMy termek_csoport = termek_cs_cb.Items[termek_csoport_index] as ListItemMy;
                string termek_csoport_id = Convert.ToString(termek_csoport.ID);
                ListItemMy menny_egys = menny_egys_cb.Items[menny_egys_index] as ListItemMy;
                string menny_egys_id = Convert.ToString(menny_egys.ID);
                ListItemMy afa = afa_cb.Items[afa_index] as ListItemMy;
                string afa_id = Convert.ToString(afa.ID);
                string[,] feltoltendo_adatok =
            {
                    {"@id", id.ToString() },
                    {"@t_cs_id", termek_csoport_id },
                    {"@megn", megn },
                    {"@leiras", leiras },
                    {"@kep", kep },
                    {"@netto_ar", netto_ar },
                    {"@menny_egys_id", menny_egys_id },
                    {"@afa_id", afa_id },
                };
                string sql = "UPDATE `termek` SET `termek_csoport_id` = @t_cs_id , `megnevezes` = @megn,`leiras` = @leiras, `kep` = @kep, `netto_egyseg_ar` = @netto_ar, `mennyisegi_egysegek_id` = @menny_egys_id, `afa_kulcs_id` = @afa_id WHERE termek.id = @id; ";
                this.DB.Query(sql, feltoltendo_adatok);
                MessageBox.Show("Az adatokat sikeresen módosítottad\nAz ablak bezárul!", "Módosítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();                
            }
            catch (Exception err)
            {
                MessageBox.Show("Nem sikerült a módosítás!\nHiba: " + err.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vissza_btn_Click(object sender, EventArgs e)
        {
            Size = new Size(660, 240);
            termek_kategoria_cb.Visible = true;
            termek_csoport_cb.Visible = true;
            megn_cb.Visible = true;
            modosit_btn.Visible = true;
            megse_btn.Visible = true;
            torol_btn.Visible = true;
            termek_cs_cb.Visible = false;
            megn_tb.Visible = false;
            leiras_tb.Visible = false;
            fajl_btn.Visible = false;
            netto_ar_nud.Visible = false;
            menny_egys_cb.Visible = false;
            afa_cb.Visible = false;
            termek_cs_lbl.Visible = false;
            megn_lbl.Visible = false;
            leiras_lbl.Visible = false;
            kep_felt_lbl.Visible = false;
            netto_ar_lbl.Visible = false;
            menny_egys_lbl.Visible = false;
            afa_lbl.Visible = false;
            OK_btn.Visible = false;
            vissza_btn.Visible = false;
        }
    }
}
 