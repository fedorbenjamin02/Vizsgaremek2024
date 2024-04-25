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
    public partial class TermekKatModositTorolForm : ModositTorolAlapForm
    {
        protected FormMain main;
        public TermekKatModositTorolForm(FormMain main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void TermekKatModositTorolForm_Load(object sender, EventArgs e)
        {
            megn_lbl.Visible = false;
            megn_tb.Visible = false;
            OK_btn.Visible = false;
            vissza_btn.Visible = false;

            termek_kategoria_cb.Items.AddRange(DB.SelectItemsGUI("SELECT id, megnevezes FROM termek_kategoria ORDER BY 1;"));
        }
        private void megse_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void modosit_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (termek_kategoria_cb.SelectedItem == null)
                {
                    throw new Exception("Nincs termék kategória kiválasztva!");
                }
                string megnevezes = termek_kategoria_cb.SelectedItem.ToString();
                megn_lbl.Visible = true;
                megn_tb.Visible = true;
                OK_btn.Visible = true;
                vissza_btn.Visible = true;
                termek_kategoria_cb.Visible = false;
                megse_btn.Visible = false;
                modosit_btn.Visible = false;
                torol_btn.Visible = false;


                megn_tb.Text = DB.SelectOneValue("SELECT megnevezes FROM termek_kategoria WHERE megnevezes = '" + megnevezes + "'");
            }
            catch (Exception err)
            {
                MessageBox.Show("Hiba: "+ err.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string kivalasztott_megn = termek_kategoria_cb.SelectedItem.ToString();
                int id = DB.SelectOneValue("SELECT id FROM termek_kategoria WHERE megnevezes = '" + kivalasztott_megn + "'");
                string megn = megn_tb.Text;
                string[,] feltoltendo_adatok =
           {
                    {"@id", id.ToString() },
                    {"@megn", megn },
                };
                string sql = "UPDATE `termek_kategoria` SET `megnevezes` = @megn WHERE termek_kategoria.id = @id; ";
                this.DB.Query(sql, feltoltendo_adatok);
                MessageBox.Show("Az adatokat sikeresen módosítottad\nAz ablak bezárul!", "Módosítás", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Hiba: "+ err.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void torol_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (termek_kategoria_cb.SelectedItem == null)
                {
                    throw new Exception("Nincs kiválasztott termék kategória!");
                }
                string termek_kat = termek_kategoria_cb.SelectedItem.ToString();
                int termek_kat_id = DB.SelectOneValue("SELECT id FROM termek_kategoria WHERE megnevezes = '" + termek_kat + "';");
                if (DB.SelectOneValue("SELECT id FROM termek_csoport WHERE termek_kategoria_id = '" + termek_kat_id + "'") != null)
                {
                    throw new Exception("A megadott termék kategória nem üres");
                }
                DialogResult eredmeny = MessageBox.Show("Biztosan törlöd? ", "Törlés", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (eredmeny == DialogResult.OK)
                {
                    string megnevezes = termek_kategoria_cb.SelectedItem.ToString();
                    string sql = ("DELETE FROM termek_kategoria WHERE megnevezes = '" + megnevezes + "'");
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
            termek_kategoria_cb.Visible = true;
            megse_btn.Visible = true;
            modosit_btn.Visible = true;
            torol_btn.Visible = true;
        }
    }
}
