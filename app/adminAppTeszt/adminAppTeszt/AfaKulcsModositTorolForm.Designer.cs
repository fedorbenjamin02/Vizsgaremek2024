namespace adminAppTeszt
{
    partial class AfaKulcsModositTorolForm
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
            this.megn_tb = new System.Windows.Forms.TextBox();
            this.megn_lbl = new System.Windows.Forms.Label();
            this.vissza_btn = new System.Windows.Forms.Button();
            this.OK_btn = new System.Windows.Forms.Button();
            this.afa_kulcsok_cb = new System.Windows.Forms.ComboBox();
            this.torol_btn = new System.Windows.Forms.Button();
            this.megse_btn = new System.Windows.Forms.Button();
            this.modosit_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // megn_tb
            // 
            this.megn_tb.Location = new System.Drawing.Point(201, 77);
            this.megn_tb.Margin = new System.Windows.Forms.Padding(4);
            this.megn_tb.Name = "megn_tb";
            this.megn_tb.Size = new System.Drawing.Size(264, 25);
            this.megn_tb.TabIndex = 61;
            // 
            // megn_lbl
            // 
            this.megn_lbl.AutoSize = true;
            this.megn_lbl.Location = new System.Drawing.Point(95, 80);
            this.megn_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.megn_lbl.Name = "megn_lbl";
            this.megn_lbl.Size = new System.Drawing.Size(98, 17);
            this.megn_lbl.TabIndex = 60;
            this.megn_lbl.Text = "Megnevezés";
            // 
            // vissza_btn
            // 
            this.vissza_btn.Location = new System.Drawing.Point(475, 97);
            this.vissza_btn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.vissza_btn.Name = "vissza_btn";
            this.vissza_btn.Size = new System.Drawing.Size(168, 25);
            this.vissza_btn.TabIndex = 59;
            this.vissza_btn.Text = "Mégse";
            this.vissza_btn.UseVisualStyleBackColor = true;
            this.vissza_btn.Click += new System.EventHandler(this.vissza_btn_Click);
            // 
            // OK_btn
            // 
            this.OK_btn.Location = new System.Drawing.Point(475, 61);
            this.OK_btn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.OK_btn.Name = "OK_btn";
            this.OK_btn.Size = new System.Drawing.Size(168, 26);
            this.OK_btn.TabIndex = 58;
            this.OK_btn.Text = "OK";
            this.OK_btn.UseVisualStyleBackColor = true;
            this.OK_btn.Click += new System.EventHandler(this.OK_btn_Click);
            // 
            // afa_kulcsok_cb
            // 
            this.afa_kulcsok_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.afa_kulcsok_cb.FormattingEnabled = true;
            this.afa_kulcsok_cb.Location = new System.Drawing.Point(15, 14);
            this.afa_kulcsok_cb.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.afa_kulcsok_cb.Name = "afa_kulcsok_cb";
            this.afa_kulcsok_cb.Size = new System.Drawing.Size(268, 25);
            this.afa_kulcsok_cb.TabIndex = 57;
            // 
            // torol_btn
            // 
            this.torol_btn.Location = new System.Drawing.Point(475, 13);
            this.torol_btn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.torol_btn.Name = "torol_btn";
            this.torol_btn.Size = new System.Drawing.Size(168, 25);
            this.torol_btn.TabIndex = 56;
            this.torol_btn.Text = "Töröl";
            this.torol_btn.UseVisualStyleBackColor = true;
            this.torol_btn.Click += new System.EventHandler(this.torol_btn_Click);
            // 
            // megse_btn
            // 
            this.megse_btn.Location = new System.Drawing.Point(655, 14);
            this.megse_btn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.megse_btn.Name = "megse_btn";
            this.megse_btn.Size = new System.Drawing.Size(168, 25);
            this.megse_btn.TabIndex = 55;
            this.megse_btn.Text = "Mégse";
            this.megse_btn.UseVisualStyleBackColor = true;
            this.megse_btn.Click += new System.EventHandler(this.megse_btn_Click);
            // 
            // modosit_btn
            // 
            this.modosit_btn.Location = new System.Drawing.Point(295, 14);
            this.modosit_btn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.modosit_btn.Name = "modosit_btn";
            this.modosit_btn.Size = new System.Drawing.Size(168, 25);
            this.modosit_btn.TabIndex = 54;
            this.modosit_btn.Text = "Módosít";
            this.modosit_btn.UseVisualStyleBackColor = true;
            this.modosit_btn.Click += new System.EventHandler(this.modosit_btn_Click);
            // 
            // AfaKulcsModositTorolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 139);
            this.Controls.Add(this.megn_tb);
            this.Controls.Add(this.megn_lbl);
            this.Controls.Add(this.vissza_btn);
            this.Controls.Add(this.OK_btn);
            this.Controls.Add(this.afa_kulcsok_cb);
            this.Controls.Add(this.torol_btn);
            this.Controls.Add(this.megse_btn);
            this.Controls.Add(this.modosit_btn);
            this.Name = "AfaKulcsModositTorolForm";
            this.Text = "Áfakulcs módosítás";
            this.Load += new System.EventHandler(this.AfaKulcsModositTorolForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox megn_tb;
        private System.Windows.Forms.Label megn_lbl;
        private System.Windows.Forms.Button vissza_btn;
        private System.Windows.Forms.Button OK_btn;
        private System.Windows.Forms.ComboBox afa_kulcsok_cb;
        private System.Windows.Forms.Button torol_btn;
        private System.Windows.Forms.Button megse_btn;
        private System.Windows.Forms.Button modosit_btn;
    }
}