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
    
    public partial class UjAdatFizetesiModokForm : UjAdatFormAlap
    {
        protected FormMain main;
        public UjAdatFizetesiModokForm(FormMain main)
        {
            InitializeComponent();
            this.main = main;
        }
        public TextBox FMMegnTb { get => megn_tb; }
    }
}
