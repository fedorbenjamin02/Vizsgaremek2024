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
    public partial class UjAdatMennyisegiEgysegForm : UjAdatFormAlap
    {
        protected FormMain main;
        
        public UjAdatMennyisegiEgysegForm(FormMain main)
        {
            InitializeComponent();
            this.main = main;
            
        }
        public TextBox MEMegnTb { get => megn_tb; }
        
    }
}
