namespace adminAppTeszt
{
    partial class UjAdatTermekKategoriaForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.feltolt_btn = new System.Windows.Forms.Button();
            this.megse_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // megn_tb
            // 
            this.megn_tb.Location = new System.Drawing.Point(146, 43);
            this.megn_tb.Name = "megn_tb";
            this.megn_tb.Size = new System.Drawing.Size(247, 25);
            this.megn_tb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Megnevezés";
            // 
            // feltolt_btn
            // 
            this.feltolt_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.feltolt_btn.Location = new System.Drawing.Point(146, 97);
            this.feltolt_btn.Name = "feltolt_btn";
            this.feltolt_btn.Size = new System.Drawing.Size(107, 32);
            this.feltolt_btn.TabIndex = 3;
            this.feltolt_btn.Text = "Feltölt";
            this.feltolt_btn.UseVisualStyleBackColor = true;
            // 
            // megse_btn
            // 
            this.megse_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.megse_btn.Location = new System.Drawing.Point(286, 97);
            this.megse_btn.Name = "megse_btn";
            this.megse_btn.Size = new System.Drawing.Size(107, 32);
            this.megse_btn.TabIndex = 4;
            this.megse_btn.Text = "Mégse";
            this.megse_btn.UseVisualStyleBackColor = true;
            // 
            // UjAdatTermekKategoriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 161);
            this.Controls.Add(this.megse_btn);
            this.Controls.Add(this.feltolt_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.megn_tb);
            this.MinimumSize = new System.Drawing.Size(500, 150);
            this.Name = "UjAdatTermekKategoriaForm";
            this.Text = "Új termék kategória";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox megn_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button feltolt_btn;
        private System.Windows.Forms.Button megse_btn;
    }
}