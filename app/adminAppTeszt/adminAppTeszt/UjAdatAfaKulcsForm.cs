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
    public partial class UjAdatAfaKulcsForm : UjAdatFormAlap
    {
        protected FormMain main;
        public UjAdatAfaKulcsForm(FormMain main)
        {
            InitializeComponent();
            this.main = main;
        }
        public TextBox AKMegnevezesTb { get => megn_tb; }
        public NumericUpDown AKAfaKulcsNud { get => afa_k_nud; }
    }
}
