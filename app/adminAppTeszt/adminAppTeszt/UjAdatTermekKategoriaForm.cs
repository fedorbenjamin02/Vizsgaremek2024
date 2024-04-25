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
    public partial class UjAdatTermekKategoriaForm : UjAdatFormAlap
    {
        protected FormMain main;
        public UjAdatTermekKategoriaForm(FormMain main)
        {
            InitializeComponent();
            this.main = main;
        }
        public TextBox TKMegnTb { get => megn_tb; }
    }
}
