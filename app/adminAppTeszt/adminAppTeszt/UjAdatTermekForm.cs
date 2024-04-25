using MyDatabaseMySQL;
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
    public partial class UjAdatTermekForm : UjAdatFormAlap 
    {
        protected FormMain main;

        public UjAdatTermekForm(FormMain main)
        {
            InitializeComponent();
            this.main = main;
        }
        public ComboBox TTermekCsoportCb { get => termek_csoport_cb; }
        public ComboBox TMennyEgysCb { get => menny_egys_cb; }
        public ComboBox TAfaCb { get => afa_cb; }
        public TextBox TMegnTb { get => megn_tb; }
        public TextBox TLeirasTb { get => leiras_tb; }
        public NumericUpDown TNettoArNud { get => netto_ar_nud; }
        public Button TFajlBtn { get => fajl_btn; }
        public OpenFileDialog TOFD1 { get => openFileDialog1; }

        private void fajl_btn_Click(object sender, EventArgs e)
        {
            TOFD1.InitialDirectory = @"C:\xampp\htdocs\project-main\app\img\";
            TOFD1.FileName = "almale.jpg";
            TOFD1.Filter = "Image Files(*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg ";
            this.TOFD1.ShowDialog();
            
            string fajlnev = TOFD1.FileName;
            List<string> kep_elut = new List<string>();
            string[] OFD1Split = fajlnev.Split('\\');
            int db = 0;
            foreach (var adat in OFD1Split)
            {
                kep_elut.Add(adat);
                db++;       
            }
            this.fajl_btn.Text = Convert.ToString(kep_elut[db-1]);
        }

        private void UjAdatTermekForm_Load(object sender, EventArgs e)
        {

        }
    }
}
