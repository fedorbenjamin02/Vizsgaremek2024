using MyDatabaseMySQL;
using MyProgNameSpace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adminAppTeszt
{
    public partial class FormAlap : Form
    {
        private MyDB db;
        public MyDB DB { get => db; }
        private MyINI ini;
        internal MyINI INI { get => ini; set => ini = value; }

        
        public FormAlap()
        {
            InitializeComponent();
            ini = new MyINI();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Connect();
        }
        private void Connect()
        {
            try
            {
                MyINI myINI = new MyINI("connect.ini");
                string host = myINI.ReadString("CONNECT", "HOST", "localhost");
                string user = myINI.ReadString("CONNECT", "USER", "root");
                string pwd = myINI.ReadString("CONNECT", "PWD", "");
                string database = myINI.ReadString("CONNECT", "DATABASE", "frissfutar");
                db = new MyDB(host, user, pwd, database);
            }
            catch (Exception err)
            {
                MessageBox.Show("Nem sikerült csatlakozni az adatbázishoz! Az alkalmazás bezáródik!\n" + err.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        protected virtual bool AblakNemBezarhato()
        {
            return false;
        }
        private void FormAlap_Load(object sender, EventArgs e)
        {
            
            //
            if (FormBorderStyle == FormBorderStyle.Sizable)
            {
                Location = new Point(
                    ini.ReadInteger(this.Name, "LEFT", Left),
                    ini.ReadInteger(this.Name, "TOP", Top)
                );
                Width = ini.ReadInteger(this.Name, "WIDTH", Width);
                Height = ini.ReadInteger(this.Name, "HEIGHT", Height);
            }
        }
        private void FormAlap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.Cancel)
            {
                e.Cancel = AblakNemBezarhato();
            }
        }
        private void FormAlap_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FormBorderStyle == FormBorderStyle.Sizable)
            {
                ini.WriteInteger(this.Name, "LEFT", Left);
                ini.WriteInteger(this.Name, "TOP", Top);
                ini.WriteInteger(this.Name, "WIDTH", Width);
                ini.WriteInteger(this.Name, "HEIGHT", Height);
            }
        }
        private void FormAlap_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    SendKeys.Send("{TAB}");
                    break;
                case (char)Keys.Escape:
                    Close();
                    break;
                default:
                    break;
            }
        }
        protected void TablazatAdataiWriteIni(string formName, DataGridView táblázat)
        {
            string szakasz = formName + "-" + "OSZLOPOK";
            for (int i = 0; i < táblázat.Columns.Count; i++)
            {
                string kulcs = $"SZÉLESSÉG-{i}";
                ini.WriteInteger(szakasz, kulcs, táblázat.Columns[i].Width);
            }
        }
        protected void TablazatAdataiReadIni(string formName, DataGridView táblázat)
        {
            string szakasz = this.Name + "-" + "OSZLOPOK";
            for (int i = 0; i < táblázat.Columns.Count; i++)
            {
                táblázat.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                string kulcs = $"SZÉLESSÉG-{i}";
                int w = ini.ReadInteger(szakasz, kulcs, táblázat.Columns[i].Width);

                táblázat.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                táblázat.Columns[i].Width = w;
            }
        }
    }
}
