namespace adminAppTeszt
{
    partial class UjAdatTermekForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.termek_cs_lbl = new System.Windows.Forms.Label();
            this.megn_lbl = new System.Windows.Forms.Label();
            this.leiras_lbl = new System.Windows.Forms.Label();
            this.kep_felt_lbl = new System.Windows.Forms.Label();
            this.netto_ar_lbl = new System.Windows.Forms.Label();
            this.menny_egys_lbl = new System.Windows.Forms.Label();
            this.afa_lbl = new System.Windows.Forms.Label();
            this.termek_csoport_cb = new System.Windows.Forms.ComboBox();
            this.megn_tb = new System.Windows.Forms.TextBox();
            this.leiras_tb = new System.Windows.Forms.TextBox();
            this.netto_ar_nud = new System.Windows.Forms.NumericUpDown();
            this.menny_egys_cb = new System.Windows.Forms.ComboBox();
            this.afa_cb = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fajl_btn = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.megse_btn = new System.Windows.Forms.Button();
            this.feltolt_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.netto_ar_nud)).BeginInit();
            this.SuspendLayout();
            // 
            // termek_cs_lbl
            // 
            this.termek_cs_lbl.AutoSize = true;
            this.termek_cs_lbl.Location = new System.Drawing.Point(97, 37);
            this.termek_cs_lbl.Name = "termek_cs_lbl";
            this.termek_cs_lbl.Size = new System.Drawing.Size(134, 17);
            this.termek_cs_lbl.TabIndex = 1;
            this.termek_cs_lbl.Text = "Termék csoport";
            // 
            // megn_lbl
            // 
            this.megn_lbl.AutoSize = true;
            this.megn_lbl.Location = new System.Drawing.Point(133, 94);
            this.megn_lbl.Name = "megn_lbl";
            this.megn_lbl.Size = new System.Drawing.Size(98, 17);
            this.megn_lbl.TabIndex = 2;
            this.megn_lbl.Text = "Megnevezés";
            // 
            // leiras_lbl
            // 
            this.leiras_lbl.AutoSize = true;
            this.leiras_lbl.Location = new System.Drawing.Point(169, 188);
            this.leiras_lbl.Name = "leiras_lbl";
            this.leiras_lbl.Size = new System.Drawing.Size(62, 17);
            this.leiras_lbl.TabIndex = 3;
            this.leiras_lbl.Text = "Leírás";
            // 
            // kep_felt_lbl
            // 
            this.kep_felt_lbl.AutoSize = true;
            this.kep_felt_lbl.Location = new System.Drawing.Point(106, 285);
            this.kep_felt_lbl.Name = "kep_felt_lbl";
            this.kep_felt_lbl.Size = new System.Drawing.Size(125, 17);
            this.kep_felt_lbl.TabIndex = 4;
            this.kep_felt_lbl.Text = "Kép feltöltés";
            // 
            // netto_ar_lbl
            // 
            this.netto_ar_lbl.AutoSize = true;
            this.netto_ar_lbl.Location = new System.Drawing.Point(151, 338);
            this.netto_ar_lbl.Name = "netto_ar_lbl";
            this.netto_ar_lbl.Size = new System.Drawing.Size(80, 17);
            this.netto_ar_lbl.TabIndex = 5;
            this.netto_ar_lbl.Text = "Nettó ár";
            // 
            // menny_egys_lbl
            // 
            this.menny_egys_lbl.AutoSize = true;
            this.menny_egys_lbl.Location = new System.Drawing.Point(52, 392);
            this.menny_egys_lbl.Name = "menny_egys_lbl";
            this.menny_egys_lbl.Size = new System.Drawing.Size(179, 17);
            this.menny_egys_lbl.TabIndex = 6;
            this.menny_egys_lbl.Text = "Mennyiségi egységek";
            // 
            // afa_lbl
            // 
            this.afa_lbl.AutoSize = true;
            this.afa_lbl.Location = new System.Drawing.Point(151, 444);
            this.afa_lbl.Name = "afa_lbl";
            this.afa_lbl.Size = new System.Drawing.Size(80, 17);
            this.afa_lbl.TabIndex = 7;
            this.afa_lbl.Text = "Áfakulcs";
            // 
            // termek_csoport_cb
            // 
            this.termek_csoport_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.termek_csoport_cb.FormattingEnabled = true;
            this.termek_csoport_cb.Location = new System.Drawing.Point(237, 34);
            this.termek_csoport_cb.Name = "termek_csoport_cb";
            this.termek_csoport_cb.Size = new System.Drawing.Size(246, 25);
            this.termek_csoport_cb.TabIndex = 8;
            // 
            // megn_tb
            // 
            this.megn_tb.Location = new System.Drawing.Point(237, 91);
            this.megn_tb.Name = "megn_tb";
            this.megn_tb.Size = new System.Drawing.Size(246, 25);
            this.megn_tb.TabIndex = 9;
            // 
            // leiras_tb
            // 
            this.leiras_tb.Location = new System.Drawing.Point(237, 150);
            this.leiras_tb.Multiline = true;
            this.leiras_tb.Name = "leiras_tb";
            this.leiras_tb.Size = new System.Drawing.Size(246, 100);
            this.leiras_tb.TabIndex = 10;
            // 
            // netto_ar_nud
            // 
            this.netto_ar_nud.Location = new System.Drawing.Point(237, 336);
            this.netto_ar_nud.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.netto_ar_nud.Name = "netto_ar_nud";
            this.netto_ar_nud.Size = new System.Drawing.Size(246, 25);
            this.netto_ar_nud.TabIndex = 11;
            // 
            // menny_egys_cb
            // 
            this.menny_egys_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menny_egys_cb.FormattingEnabled = true;
            this.menny_egys_cb.Location = new System.Drawing.Point(237, 389);
            this.menny_egys_cb.Name = "menny_egys_cb";
            this.menny_egys_cb.Size = new System.Drawing.Size(246, 25);
            this.menny_egys_cb.TabIndex = 12;
            // 
            // afa_cb
            // 
            this.afa_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.afa_cb.FormattingEnabled = true;
            this.afa_cb.Location = new System.Drawing.Point(237, 441);
            this.afa_cb.Name = "afa_cb";
            this.afa_cb.Size = new System.Drawing.Size(246, 25);
            this.afa_cb.TabIndex = 13;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fajl_btn
            // 
            this.fajl_btn.Location = new System.Drawing.Point(237, 278);
            this.fajl_btn.Name = "fajl_btn";
            this.fajl_btn.Size = new System.Drawing.Size(246, 30);
            this.fajl_btn.TabIndex = 14;
            this.fajl_btn.Text = "Fájl kiválasztása";
            this.fajl_btn.UseVisualStyleBackColor = true;
            this.fajl_btn.Click += new System.EventHandler(this.fajl_btn_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // megse_btn
            // 
            this.megse_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.megse_btn.Location = new System.Drawing.Point(376, 498);
            this.megse_btn.Name = "megse_btn";
            this.megse_btn.Size = new System.Drawing.Size(107, 32);
            this.megse_btn.TabIndex = 22;
            this.megse_btn.Text = "Mégse";
            this.megse_btn.UseVisualStyleBackColor = true;
            // 
            // feltolt_btn
            // 
            this.feltolt_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.feltolt_btn.Location = new System.Drawing.Point(236, 498);
            this.feltolt_btn.Name = "feltolt_btn";
            this.feltolt_btn.Size = new System.Drawing.Size(107, 32);
            this.feltolt_btn.TabIndex = 21;
            this.feltolt_btn.Text = "Feltölt";
            this.feltolt_btn.UseVisualStyleBackColor = true;
            // 
            // UjAdatTermekForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 561);
            this.Controls.Add(this.megse_btn);
            this.Controls.Add(this.feltolt_btn);
            this.Controls.Add(this.fajl_btn);
            this.Controls.Add(this.afa_cb);
            this.Controls.Add(this.menny_egys_cb);
            this.Controls.Add(this.netto_ar_nud);
            this.Controls.Add(this.leiras_tb);
            this.Controls.Add(this.megn_tb);
            this.Controls.Add(this.termek_csoport_cb);
            this.Controls.Add(this.afa_lbl);
            this.Controls.Add(this.menny_egys_lbl);
            this.Controls.Add(this.netto_ar_lbl);
            this.Controls.Add(this.kep_felt_lbl);
            this.Controls.Add(this.leiras_lbl);
            this.Controls.Add(this.megn_lbl);
            this.Controls.Add(this.termek_cs_lbl);
            this.MinimumSize = new System.Drawing.Size(500, 150);
            this.Name = "UjAdatTermekForm";
            this.Text = "Új termék feltöltése";
            this.Load += new System.EventHandler(this.UjAdatTermekForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.netto_ar_nud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label termek_cs_lbl;
        private System.Windows.Forms.Label megn_lbl;
        private System.Windows.Forms.Label leiras_lbl;
        private System.Windows.Forms.Label kep_felt_lbl;
        private System.Windows.Forms.Label netto_ar_lbl;
        private System.Windows.Forms.Label menny_egys_lbl;
        private System.Windows.Forms.Label afa_lbl;
        private System.Windows.Forms.ComboBox termek_csoport_cb;
        private System.Windows.Forms.TextBox megn_tb;
        private System.Windows.Forms.TextBox leiras_tb;
        private System.Windows.Forms.NumericUpDown netto_ar_nud;
        private System.Windows.Forms.ComboBox menny_egys_cb;
        private System.Windows.Forms.ComboBox afa_cb;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button fajl_btn;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button megse_btn;
        private System.Windows.Forms.Button feltolt_btn;
    }
}