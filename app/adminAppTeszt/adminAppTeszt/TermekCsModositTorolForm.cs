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
    public partial class TermekCsModositTorolForm : ModositTorolAlapForm
    {
        protected FormMain main;
        public TermekCsModositTorolForm(FormMain main)
        {
            InitializeComponent();
            this.main = main;
        }
        private void TermekCsModositTorolForm_Load(object sender, EventArgs e)
        {
            megn_lbl.Visible = false;
            megn_tb.Visible = false;
            OK_btn.Visible = false;
            vissza_btn.Visible = false;

            termek_csoport_cb.Items.AddRange(DB.SelectItemsGUI("SELECT id, megnevezes FROM termek_csoport ORDER BY 1;"));
        }
        private void megse_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void modosit_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (termek_csoport_cb.SelectedItem == null)
                {
                    throw new Exception("Nincs termék csoport kiválasztva!");
                }
                string megnevezes = termek_csoport_cb.SelectedItem.ToString();
                megn_lbl.Visible = true;
                megn_tb.Visible = true;
                OK_btn.Visible = true;
                vissza_btn.Visible = true;
                modosit_btn.Visible = false;
                megse_btn.Visible = false;
                termek_csoport_cb.Visible = false;
                torol_btn.Visible = false;
                megn_tb.Text = DB.SelectOneValue("SELECT megnevezes FROM termek_csoport WHERE megnevezes = '" + megnevezes + "'");
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
                string kivalasztott_megn = termek_csoport_cb.SelectedItem.ToString();
                int id = DB.SelectOneValue("SELECT id FROM termek_csoport WHERE megnevezes = '" + kivalasztott_megn + "'");
                string megn = megn_tb.Text;
                string[,] feltoltendo_adatok =
           {
                    {"@id", id.ToString() },
                    {"@megn", megn },
                };
                string sql = "UPDATE `termek_csoport` SET `megnevezes` = @megn WHERE termek_csoport.id = @id; ";
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
                if (termek_csoport_cb.SelectedItem == null)
                {
                    throw new Exception("Nincs termék csoport kiválasztva!");
                }
                string termek_cs = termek_csoport_cb.SelectedItem.ToString();
                int termek_cs_id = DB.SelectOneValue("SELECT id FROM termek_csoport WHERE megnevezes = '" + termek_cs + "';");
                if (DB.SelectOneValue("SELECT id FROM termek WHERE termek_csoport_id = '" + termek_cs_id + "'") != null)
                {
                    throw new Exception("A megadott termék csoport nem üres");
                }
                DialogResult eredmeny = MessageBox.Show("Biztosan törlöd? ", "Törlés", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (eredmeny == DialogResult.OK)
                {
                    string megnevezes = termek_csoport_cb.SelectedItem.ToString();
                    string sql = ("DELETE FROM termek_csoport WHERE megnevezes = '" + megnevezes + "'");
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
            modosit_btn.Visible = true;
            torol_btn.Visible = true;
            megse_btn.Visible = true;
            termek_csoport_cb.Visible = true;
        }
    }
}
