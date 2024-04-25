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
    public partial class MennyisegiEgysegekModositTorolForm : ModositTorolAlapForm
    {
        protected FormMain main;
        public MennyisegiEgysegekModositTorolForm(FormMain main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void MennyisegiEgysegekModositTorolForm_Load(object sender, EventArgs e)
        {
            megn_lbl.Visible = false;
            megn_tb.Visible = false;
            OK_btn.Visible = false;
            vissza_btn.Visible = false;
            mennyisegi_egysegek_cb.Items.AddRange(DB.SelectItemsGUI("SELECT id, megnevezes FROM mennyisegi_egysegek ORDER BY 1;"));
        }

        private void megse_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void modosit_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (mennyisegi_egysegek_cb.SelectedItem == null)
                {
                    throw new Exception("Nincs áfakulcs kiválasztva!");
                }
                string megnevezes = mennyisegi_egysegek_cb.SelectedItem.ToString();
                megn_lbl.Visible = true;
                megn_tb.Visible = true;
                OK_btn.Visible = true;
                vissza_btn.Visible = true;
                mennyisegi_egysegek_cb.Visible = false;
                modosit_btn.Visible = false;
                megse_btn.Visible = false;
                torol_btn.Visible = false;
                megn_tb.Text = DB.SelectOneValue("SELECT megnevezes FROM mennyisegi_egysegek WHERE megnevezes = '" + megnevezes + "'");
            }
            catch (Exception err)
            {
                MessageBox.Show("Hiba: " + err.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (megn_tb.Text == "")
                {
                    throw new Exception("Üresen maradt a megnevezés!");
                }
                string kivalasztott_megn = mennyisegi_egysegek_cb.SelectedItem.ToString();
                int id = DB.SelectOneValue("SELECT id FROM mennyisegi_egysegek WHERE megnevezes = '" + kivalasztott_megn + "'");
                string megn = megn_tb.Text;
                string[,] feltoltendo_adatok =
           {
                    {"@id", id.ToString() },
                    {"@megn", megn },
                };
                string sql = "UPDATE `mennyisegi_egysegek` SET `megnevezes` = @megn WHERE mennyisegi_egysegek.id = @id; ";
                this.DB.Query(sql, feltoltendo_adatok);
                MessageBox.Show("Az adatokat sikeresen módosítottad\nAz ablak bezárul!", "Módosítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Hiba: " + err.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void torol_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (mennyisegi_egysegek_cb.SelectedItem == null)
                {
                    throw new Exception("Nincs mennyiségi egység kiválasztva!");
                }
                string menny_egys_m = mennyisegi_egysegek_cb.SelectedItem.ToString();
                int menny_egys_m_id = DB.SelectOneValue("SELECT id FROM mennyisegi_egysegek WHERE megnevezes = '" + menny_egys_m + "';");
                
                if (DB.SelectOneValue("SELECT id FROM termek WHERE mennyisegi_egysegek_id = '" + menny_egys_m_id + "'") != null)
                {
                    throw new Exception("A megadott mennyiségi egység nem üres!");
                }
                DialogResult eredmeny = MessageBox.Show("Biztosan törlöd? ", "Törlés", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (eredmeny == DialogResult.OK)
                {
                    string megnevezes = mennyisegi_egysegek_cb.SelectedItem.ToString();
                    string sql = ("DELETE FROM mennyisegi_egysegek WHERE megnevezes = '" + megnevezes + "'");
                    DB.Query(sql);
                    MessageBox.Show("Sikeresen törölted ezt: " + megnevezes, "\nAz ablak bezárul!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Hiba: " + err.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vissza_btn_Click(object sender, EventArgs e)
        {
            megn_lbl.Visible = false;
            megn_tb.Visible = false;
            OK_btn.Visible = false;
            vissza_btn.Visible = false;
            mennyisegi_egysegek_cb.Visible = true;
            torol_btn.Visible = true;
            modosit_btn.Visible = true;
            megse_btn.Visible = true;
        }
    }
}
