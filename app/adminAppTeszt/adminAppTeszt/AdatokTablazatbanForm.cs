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
    public partial class AdatokTablazatbanForm : FormAlap
    {
        
        public DataGridView DGV { get => dgv; }
        private FormMain main;
        public AdatokTablazatbanForm()
        {
            InitializeComponent();
        }

        private void AdatokTablazatbanForm_Load(object sender, EventArgs e)
        {
            dgv.Parent = this;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            TablazatAdataiReadIni(this.Name, dgv);
        }

        private void AdatokTablazatbanForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            TablazatAdataiWriteIni(this.Name, dgv);
        }

       
    }
}
