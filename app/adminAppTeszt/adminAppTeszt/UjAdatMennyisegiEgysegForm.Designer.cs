
namespace adminAppTeszt
{
    partial class UjAdatMennyisegiEgysegForm
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
            this.megn_tb = new System.Windows.Forms.TextBox();
            this.megse_btn = new System.Windows.Forms.Button();
            this.feltolt_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Megnevezés";
            // 
            // megn_tb
            // 
            this.megn_tb.Location = new System.Drawing.Point(146, 50);
            this.megn_tb.Name = "megn_tb";
            this.megn_tb.Size = new System.Drawing.Size(246, 25);
            this.megn_tb.TabIndex = 18;
            // 
            // megse_btn
            // 
            this.megse_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.megse_btn.Location = new System.Drawing.Point(285, 102);
            this.megse_btn.Name = "megse_btn";
            this.megse_btn.Size = new System.Drawing.Size(107, 32);
            this.megse_btn.TabIndex = 20;
            this.megse_btn.Text = "Mégse";
            this.megse_btn.UseVisualStyleBackColor = true;
            // 
            // feltolt_btn
            // 
            this.feltolt_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.feltolt_btn.Location = new System.Drawing.Point(145, 102);
            this.feltolt_btn.Name = "feltolt_btn";
            this.feltolt_btn.Size = new System.Drawing.Size(107, 32);
            this.feltolt_btn.TabIndex = 19;
            this.feltolt_btn.Text = "Feltölt";
            this.feltolt_btn.UseVisualStyleBackColor = true;
            // 
            // UjAdatMennyisegiEgysegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 177);
            this.Controls.Add(this.megse_btn);
            this.Controls.Add(this.feltolt_btn);
            this.Controls.Add(this.megn_tb);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(500, 150);
            this.Name = "UjAdatMennyisegiEgysegForm";
            this.Text = "Új mennyiségi egység";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox megn_tb;
        private System.Windows.Forms.Button megse_btn;
        private System.Windows.Forms.Button feltolt_btn;
    }
}