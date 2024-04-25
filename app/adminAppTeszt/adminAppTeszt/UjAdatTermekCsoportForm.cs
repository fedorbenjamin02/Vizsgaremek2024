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
    public partial class UjAdatTermekCsoportForm : UjAdatFormAlap
    {
        protected FormMain main;
        public UjAdatTermekCsoportForm(FormMain main)
        {

            InitializeComponent();
            this.main = main;
        }
        public ComboBox TCsTermekKategoriaCb { get => termek_kategoria_cb; }
        public TextBox TCsMegnTb { get => megnevezes_tb; }
    }
}
