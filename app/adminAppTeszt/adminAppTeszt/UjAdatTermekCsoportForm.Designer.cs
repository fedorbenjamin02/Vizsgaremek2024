namespace adminAppTeszt
{
    partial class UjAdatTermekCsoportForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.termek_kategoria_cb = new System.Windows.Forms.ComboBox();
            this.megnevezes_tb = new System.Windows.Forms.TextBox();
            this.megse_btn = new System.Windows.Forms.Button();
            this.feltolt_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Termék kategória";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Megnevezés";
            // 
            // termek_kategoria_cb
            // 
            this.termek_kategoria_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.termek_kategoria_cb.FormattingEnabled = true;
            this.termek_kategoria_cb.Location = new System.Drawing.Point(192, 46);
            this.termek_kategoria_cb.Name = "termek_kategoria_cb";
            this.termek_kategoria_cb.Size = new System.Drawing.Size(284, 25);
            this.termek_kategoria_cb.TabIndex = 19;
            // 
            // megnevezes_tb
            // 
            this.megnevezes_tb.Location = new System.Drawing.Point(192, 97);
            this.megnevezes_tb.Name = "megnevezes_tb";
            this.megnevezes_tb.Size = new System.Drawing.Size(284, 25);
            this.megnevezes_tb.TabIndex = 20;
            // 
            // megse_btn
            // 
            this.megse_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.megse_btn.Location = new System.Drawing.Point(356, 147);
            this.megse_btn.Name = "megse_btn";
            this.megse_btn.Size = new System.Drawing.Size(120, 32);
            this.megse_btn.TabIndex = 22;
            this.megse_btn.Text = "Mégse";
            this.megse_btn.UseVisualStyleBackColor = true;
            // 
            // feltolt_btn
            // 
            this.feltolt_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.feltolt_btn.Location = new System.Drawing.Point(192, 147);
            this.feltolt_btn.Name = "feltolt_btn";
            this.feltolt_btn.Size = new System.Drawing.Size(120, 32);
            this.feltolt_btn.TabIndex = 21;
            this.feltolt_btn.Text = "Feltölt";
            this.feltolt_btn.UseVisualStyleBackColor = true;
            // 
            // UjAdatTermekCsoportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 221);
            this.Controls.Add(this.megse_btn);
            this.Controls.Add(this.feltolt_btn);
            this.Controls.Add(this.megnevezes_tb);
            this.Controls.Add(this.termek_kategoria_cb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(500, 150);
            this.Name = "UjAdatTermekCsoportForm";
            this.Text = "Új termék csoport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox termek_kategoria_cb;
        private System.Windows.Forms.TextBox megnevezes_tb;
        private System.Windows.Forms.Button megse_btn;
        private System.Windows.Forms.Button feltolt_btn;
    }
}