﻿namespace adminAppTeszt
{
    partial class UjAdatAfaKulcsForm
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
            this.megn_tb = new System.Windows.Forms.TextBox();
            this.afa_k_nud = new System.Windows.Forms.NumericUpDown();
            this.megse_btn = new System.Windows.Forms.Button();
            this.feltolt_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.afa_k_nud)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Megnevezés";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Áfa kulcs";
            // 
            // megn_tb
            // 
            this.megn_tb.Location = new System.Drawing.Point(127, 25);
            this.megn_tb.Name = "megn_tb";
            this.megn_tb.Size = new System.Drawing.Size(247, 25);
            this.megn_tb.TabIndex = 19;
            // 
            // afa_k_nud
            // 
            this.afa_k_nud.DecimalPlaces = 1;
            this.afa_k_nud.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.afa_k_nud.Location = new System.Drawing.Point(127, 75);
            this.afa_k_nud.Name = "afa_k_nud";
            this.afa_k_nud.Size = new System.Drawing.Size(247, 25);
            this.afa_k_nud.TabIndex = 20;
            // 
            // megse_btn
            // 
            this.megse_btn.Location = new System.Drawing.Point(267, 123);
            this.megse_btn.Name = "megse_btn";
            this.megse_btn.Size = new System.Drawing.Size(107, 32);
            this.megse_btn.TabIndex = 22;
            this.megse_btn.Text = "Mégse";
            this.megse_btn.UseVisualStyleBackColor = true;
            // 
            // feltolt_btn
            // 
            this.feltolt_btn.Location = new System.Drawing.Point(127, 123);
            this.feltolt_btn.Name = "feltolt_btn";
            this.feltolt_btn.Size = new System.Drawing.Size(107, 32);
            this.feltolt_btn.TabIndex = 21;
            this.feltolt_btn.Text = "Feltölt";
            this.feltolt_btn.UseVisualStyleBackColor = true;
            // 
            // UjAdatAfaKulcsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 184);
            this.Controls.Add(this.megse_btn);
            this.Controls.Add(this.feltolt_btn);
            this.Controls.Add(this.afa_k_nud);
            this.Controls.Add(this.megn_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(500, 150);
            this.Name = "UjAdatAfaKulcsForm";
            this.Text = "Új áfakulcs";
            ((System.ComponentModel.ISupportInitialize)(this.afa_k_nud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox megn_tb;
        private System.Windows.Forms.NumericUpDown afa_k_nud;
        private System.Windows.Forms.Button megse_btn;
        private System.Windows.Forms.Button feltolt_btn;
    }
}