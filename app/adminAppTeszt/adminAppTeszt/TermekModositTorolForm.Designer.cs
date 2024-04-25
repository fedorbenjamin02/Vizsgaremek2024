namespace adminAppTeszt
{
    partial class TermekModositTorolForm
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
            this.modosit_btn = new System.Windows.Forms.Button();
            this.OK_btn = new System.Windows.Forms.Button();
            this.termek_kategoria_cb = new System.Windows.Forms.ComboBox();
            this.termek_csoport_cb = new System.Windows.Forms.ComboBox();
            this.megn_cb = new System.Windows.Forms.ComboBox();
            this.megse_btn = new System.Windows.Forms.Button();
            this.fajl_btn = new System.Windows.Forms.Button();
            this.afa_cb = new System.Windows.Forms.ComboBox();
            this.menny_egys_cb = new System.Windows.Forms.ComboBox();
            this.netto_ar_nud = new System.Windows.Forms.NumericUpDown();
            this.leiras_tb = new System.Windows.Forms.TextBox();
            this.megn_tb = new System.Windows.Forms.TextBox();
            this.termek_cs_cb = new System.Windows.Forms.ComboBox();
            this.afa_lbl = new System.Windows.Forms.Label();
            this.menny_egys_lbl = new System.Windows.Forms.Label();
            this.netto_ar_lbl = new System.Windows.Forms.Label();
            this.kep_felt_lbl = new System.Windows.Forms.Label();
            this.leiras_lbl = new System.Windows.Forms.Label();
            this.megn_lbl = new System.Windows.Forms.Label();
            this.termek_cs_lbl = new System.Windows.Forms.Label();
            this.OFD1 = new System.Windows.Forms.OpenFileDialog();
            this.torol_btn = new System.Windows.Forms.Button();
            this.vissza_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.netto_ar_nud)).BeginInit();
            this.SuspendLayout();
            // 
            // modosit_btn
            // 
            this.modosit_btn.Location = new System.Drawing.Point(103, 86);
            this.modosit_btn.Margin = new System.Windows.Forms.Padding(4);
            this.modosit_btn.Name = "modosit_btn";
            this.modosit_btn.Size = new System.Drawing.Size(112, 27);
            this.modosit_btn.TabIndex = 0;
            this.modosit_btn.Text = "Módosít";
            this.modosit_btn.UseVisualStyleBackColor = true;
            this.modosit_btn.Click += new System.EventHandler(this.modosit_btn_Click);
            // 
            // OK_btn
            // 
            this.OK_btn.Location = new System.Drawing.Point(487, 123);
            this.OK_btn.Margin = new System.Windows.Forms.Padding(4);
            this.OK_btn.Name = "OK_btn";
            this.OK_btn.Size = new System.Drawing.Size(128, 59);
            this.OK_btn.TabIndex = 1;
            this.OK_btn.Text = "OK";
            this.OK_btn.UseVisualStyleBackColor = true;
            this.OK_btn.Click += new System.EventHandler(this.OK_btn_Click);
            // 
            // termek_kategoria_cb
            // 
            this.termek_kategoria_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.termek_kategoria_cb.FormattingEnabled = true;
            this.termek_kategoria_cb.Location = new System.Drawing.Point(18, 16);
            this.termek_kategoria_cb.Margin = new System.Windows.Forms.Padding(4);
            this.termek_kategoria_cb.Name = "termek_kategoria_cb";
            this.termek_kategoria_cb.Size = new System.Drawing.Size(147, 25);
            this.termek_kategoria_cb.TabIndex = 2;
            this.termek_kategoria_cb.SelectedIndexChanged += new System.EventHandler(this.termek_kategoria_cb_SelectedIndexChanged);
            // 
            // termek_csoport_cb
            // 
            this.termek_csoport_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.termek_csoport_cb.FormattingEnabled = true;
            this.termek_csoport_cb.Location = new System.Drawing.Point(173, 16);
            this.termek_csoport_cb.Margin = new System.Windows.Forms.Padding(4);
            this.termek_csoport_cb.Name = "termek_csoport_cb";
            this.termek_csoport_cb.Size = new System.Drawing.Size(186, 25);
            this.termek_csoport_cb.TabIndex = 3;
            this.termek_csoport_cb.SelectedIndexChanged += new System.EventHandler(this.termek_csoport_cb_SelectedIndexChanged);
            // 
            // megn_cb
            // 
            this.megn_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.megn_cb.FormattingEnabled = true;
            this.megn_cb.Location = new System.Drawing.Point(367, 16);
            this.megn_cb.Margin = new System.Windows.Forms.Padding(4);
            this.megn_cb.Name = "megn_cb";
            this.megn_cb.Size = new System.Drawing.Size(263, 25);
            this.megn_cb.TabIndex = 4;
            // 
            // megse_btn
            // 
            this.megse_btn.Location = new System.Drawing.Point(343, 86);
            this.megse_btn.Margin = new System.Windows.Forms.Padding(4);
            this.megse_btn.Name = "megse_btn";
            this.megse_btn.Size = new System.Drawing.Size(112, 26);
            this.megse_btn.TabIndex = 5;
            this.megse_btn.Text = "Mégse";
            this.megse_btn.UseVisualStyleBackColor = true;
            this.megse_btn.Click += new System.EventHandler(this.megse_btn_Click);
            // 
            // fajl_btn
            // 
            this.fajl_btn.Location = new System.Drawing.Point(200, 231);
            this.fajl_btn.Name = "fajl_btn";
            this.fajl_btn.Size = new System.Drawing.Size(231, 30);
            this.fajl_btn.TabIndex = 28;
            this.fajl_btn.Text = "Fájl kiválasztása";
            this.fajl_btn.UseVisualStyleBackColor = true;
            this.fajl_btn.Click += new System.EventHandler(this.fajl_btn_Click);
            // 
            // afa_cb
            // 
            this.afa_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.afa_cb.FormattingEnabled = true;
            this.afa_cb.Location = new System.Drawing.Point(200, 375);
            this.afa_cb.Name = "afa_cb";
            this.afa_cb.Size = new System.Drawing.Size(231, 25);
            this.afa_cb.TabIndex = 27;
            // 
            // menny_egys_cb
            // 
            this.menny_egys_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menny_egys_cb.FormattingEnabled = true;
            this.menny_egys_cb.Location = new System.Drawing.Point(200, 329);
            this.menny_egys_cb.Name = "menny_egys_cb";
            this.menny_egys_cb.Size = new System.Drawing.Size(231, 25);
            this.menny_egys_cb.TabIndex = 26;
            // 
            // netto_ar_nud
            // 
            this.netto_ar_nud.Location = new System.Drawing.Point(200, 281);
            this.netto_ar_nud.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.netto_ar_nud.Name = "netto_ar_nud";
            this.netto_ar_nud.Size = new System.Drawing.Size(231, 25);
            this.netto_ar_nud.TabIndex = 25;
            // 
            // leiras_tb
            // 
            this.leiras_tb.Location = new System.Drawing.Point(200, 110);
            this.leiras_tb.Multiline = true;
            this.leiras_tb.Name = "leiras_tb";
            this.leiras_tb.Size = new System.Drawing.Size(231, 100);
            this.leiras_tb.TabIndex = 24;
            // 
            // megn_tb
            // 
            this.megn_tb.Location = new System.Drawing.Point(200, 63);
            this.megn_tb.Name = "megn_tb";
            this.megn_tb.Size = new System.Drawing.Size(231, 25);
            this.megn_tb.TabIndex = 23;
            // 
            // termek_cs_cb
            // 
            this.termek_cs_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.termek_cs_cb.FormattingEnabled = true;
            this.termek_cs_cb.Location = new System.Drawing.Point(200, 18);
            this.termek_cs_cb.Name = "termek_cs_cb";
            this.termek_cs_cb.Size = new System.Drawing.Size(231, 25);
            this.termek_cs_cb.TabIndex = 22;
            // 
            // afa_lbl
            // 
            this.afa_lbl.AutoSize = true;
            this.afa_lbl.Location = new System.Drawing.Point(100, 378);
            this.afa_lbl.Name = "afa_lbl";
            this.afa_lbl.Size = new System.Drawing.Size(80, 17);
            this.afa_lbl.TabIndex = 21;
            this.afa_lbl.Text = "Áfakulcs";
            // 
            // menny_egys_lbl
            // 
            this.menny_egys_lbl.AutoSize = true;
            this.menny_egys_lbl.Location = new System.Drawing.Point(1, 332);
            this.menny_egys_lbl.Name = "menny_egys_lbl";
            this.menny_egys_lbl.Size = new System.Drawing.Size(179, 17);
            this.menny_egys_lbl.TabIndex = 20;
            this.menny_egys_lbl.Text = "Mennyiségi egységek";
            // 
            // netto_ar_lbl
            // 
            this.netto_ar_lbl.AutoSize = true;
            this.netto_ar_lbl.Location = new System.Drawing.Point(100, 283);
            this.netto_ar_lbl.Name = "netto_ar_lbl";
            this.netto_ar_lbl.Size = new System.Drawing.Size(80, 17);
            this.netto_ar_lbl.TabIndex = 19;
            this.netto_ar_lbl.Text = "Nettó ár";
            // 
            // kep_felt_lbl
            // 
            this.kep_felt_lbl.AutoSize = true;
            this.kep_felt_lbl.Location = new System.Drawing.Point(55, 238);
            this.kep_felt_lbl.Name = "kep_felt_lbl";
            this.kep_felt_lbl.Size = new System.Drawing.Size(125, 17);
            this.kep_felt_lbl.TabIndex = 18;
            this.kep_felt_lbl.Text = "Kép feltöltés";
            // 
            // leiras_lbl
            // 
            this.leiras_lbl.AutoSize = true;
            this.leiras_lbl.Location = new System.Drawing.Point(118, 144);
            this.leiras_lbl.Name = "leiras_lbl";
            this.leiras_lbl.Size = new System.Drawing.Size(62, 17);
            this.leiras_lbl.TabIndex = 17;
            this.leiras_lbl.Text = "Leírás";
            // 
            // megn_lbl
            // 
            this.megn_lbl.AutoSize = true;
            this.megn_lbl.Location = new System.Drawing.Point(73, 66);
            this.megn_lbl.Name = "megn_lbl";
            this.megn_lbl.Size = new System.Drawing.Size(107, 17);
            this.megn_lbl.TabIndex = 16;
            this.megn_lbl.Text = "Megnevezés ";
            // 
            // termek_cs_lbl
            // 
            this.termek_cs_lbl.AutoSize = true;
            this.termek_cs_lbl.Location = new System.Drawing.Point(46, 21);
            this.termek_cs_lbl.Name = "termek_cs_lbl";
            this.termek_cs_lbl.Size = new System.Drawing.Size(134, 17);
            this.termek_cs_lbl.TabIndex = 15;
            this.termek_cs_lbl.Text = "Termék csoport";
            // 
            // OFD1
            // 
            this.OFD1.FileName = "openFileDialog1";
            // 
            // torol_btn
            // 
            this.torol_btn.Location = new System.Drawing.Point(223, 86);
            this.torol_btn.Margin = new System.Windows.Forms.Padding(4);
            this.torol_btn.Name = "torol_btn";
            this.torol_btn.Size = new System.Drawing.Size(112, 27);
            this.torol_btn.TabIndex = 29;
            this.torol_btn.Text = "Töröl";
            this.torol_btn.UseVisualStyleBackColor = true;
            this.torol_btn.Click += new System.EventHandler(this.torol_btn_Click);
            // 
            // vissza_btn
            // 
            this.vissza_btn.Location = new System.Drawing.Point(487, 202);
            this.vissza_btn.Margin = new System.Windows.Forms.Padding(4);
            this.vissza_btn.Name = "vissza_btn";
            this.vissza_btn.Size = new System.Drawing.Size(128, 59);
            this.vissza_btn.TabIndex = 30;
            this.vissza_btn.Text = "Mégse";
            this.vissza_btn.UseVisualStyleBackColor = true;
            this.vissza_btn.Click += new System.EventHandler(this.vissza_btn_Click);
            // 
            // TermekModositTorolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 211);
            this.Controls.Add(this.vissza_btn);
            this.Controls.Add(this.torol_btn);
            this.Controls.Add(this.fajl_btn);
            this.Controls.Add(this.afa_cb);
            this.Controls.Add(this.menny_egys_cb);
            this.Controls.Add(this.netto_ar_nud);
            this.Controls.Add(this.leiras_tb);
            this.Controls.Add(this.megn_tb);
            this.Controls.Add(this.termek_cs_cb);
            this.Controls.Add(this.afa_lbl);
            this.Controls.Add(this.menny_egys_lbl);
            this.Controls.Add(this.netto_ar_lbl);
            this.Controls.Add(this.kep_felt_lbl);
            this.Controls.Add(this.leiras_lbl);
            this.Controls.Add(this.megn_lbl);
            this.Controls.Add(this.termek_cs_lbl);
            this.Controls.Add(this.megse_btn);
            this.Controls.Add(this.megn_cb);
            this.Controls.Add(this.termek_csoport_cb);
            this.Controls.Add(this.termek_kategoria_cb);
            this.Controls.Add(this.OK_btn);
            this.Controls.Add(this.modosit_btn);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "TermekModositTorolForm";
            this.Text = "Termék módosítás";
            this.Load += new System.EventHandler(this.TermekModositTorolForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.netto_ar_nud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button modosit_btn;
        private System.Windows.Forms.Button OK_btn;
        private System.Windows.Forms.ComboBox termek_kategoria_cb;
        private System.Windows.Forms.ComboBox termek_csoport_cb;
        private System.Windows.Forms.ComboBox megn_cb;
        private System.Windows.Forms.Button megse_btn;
        private System.Windows.Forms.Button fajl_btn;
        private System.Windows.Forms.ComboBox afa_cb;
        private System.Windows.Forms.ComboBox menny_egys_cb;
        private System.Windows.Forms.NumericUpDown netto_ar_nud;
        private System.Windows.Forms.TextBox leiras_tb;
        private System.Windows.Forms.TextBox megn_tb;
        private System.Windows.Forms.ComboBox termek_cs_cb;
        private System.Windows.Forms.Label afa_lbl;
        private System.Windows.Forms.Label menny_egys_lbl;
        private System.Windows.Forms.Label netto_ar_lbl;
        private System.Windows.Forms.Label kep_felt_lbl;
        private System.Windows.Forms.Label leiras_lbl;
        private System.Windows.Forms.Label megn_lbl;
        private System.Windows.Forms.Label termek_cs_lbl;
        private System.Windows.Forms.OpenFileDialog OFD1;
        private System.Windows.Forms.Button torol_btn;
        private System.Windows.Forms.Button vissza_btn;
    }
}