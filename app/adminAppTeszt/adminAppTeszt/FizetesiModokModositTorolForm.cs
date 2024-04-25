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
    public partial class FizetesiModokModositTorolForm : ModositTorolAlapForm
    {
        protected FormMain main;
        public FizetesiModokModositTorolForm(FormMain main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void FizetesiModokModositTorolForm_Load(object sender, EventArgs e)
        {
            megn_lbl.Visible = false;
            megn_tb.Visible = false;
            OK_btn.Visible = false;
            vissza_btn.Visible = false;

            fizetesi_modok_cb.Items.AddRange(DB.SelectItemsGUI("SELECT id, megnevezes FROM fizetesi_modok ORDER BY 1;"));
        }

        private void megse_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void modosit_btn_Click(object sender, EventArgs e)
        {
            try
            {
            if (fizetesi_modok_cb.SelectedItem == null)
            {
                throw new Exception("Nincs fizetési mód kiválasztva!");
            }
            string megnevezes = fizetesi_modok_cb.SelectedItem.ToString();
            megn_lbl.Visible = true;
            megn_tb.Visible = true;
            OK_btn.Visible = true;
            vissza_btn.Visible = true;
            fizetesi_modok_cb.Visible = false;
            modosit_btn.Visible = false;
            megse_btn.Visible = false;
            torol_btn.Visible = false;
            megn_tb.Text = DB.SelectOneValue("SELECT megnevezes FROM fizetesi_modok WHERE megnevezes = '" + megnevezes + "'");
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
                string kivalasztott_megn = fizetesi_modok_cb.SelectedItem.ToString();
                int id = DB.SelectOneValue("SELECT id FROM fizetesi_modok WHERE megnevezes = '" + kivalasztott_megn + "'");
                string megn = megn_tb.Text;
                string[,] feltoltendo_adatok =
           {
                    {"@id", id.ToString() },
                    {"@megn", megn },
                };
                string sql = "UPDATE `fizetesi_modok` SET `megnevezes` = @megn WHERE fizetesi_modok.id = @id; ";
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
                if (fizetesi_modok_cb.SelectedItem == null)
                {
                    throw new Exception("Nincs kiválasztott fizetési mód!");
                }
                string fizetesi_m = fizetesi_modok_cb.SelectedItem.ToString();
                int fizetesi_m_id = DB.SelectOneValue("SELECT id FROM fizetesi_modok WHERE megnevezes = '" + fizetesi_m + "';");
                
                if (DB.SelectOneValue("SELECT id FROM rendeles WHERE fizetesi_modok_id = '" + fizetesi_m_id + "'") != null)
                {
                    throw new Exception("A megadott fizetési mód nem üres");
                }
                DialogResult eredmeny = MessageBox.Show("Biztosan törlöd? ", "Törlés", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (eredmeny == DialogResult.OK)
                {
                    string megnevezes = fizetesi_modok_cb.SelectedItem.ToString();
                    string sql = ("DELETE FROM fizetesi_modok WHERE megnevezes = '" + megnevezes + "'");
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
            fizetesi_modok_cb.Visible = true;
            modosit_btn.Visible = true;
            megse_btn.Visible = true;
            torol_btn.Visible = true;
        }
    }
}
