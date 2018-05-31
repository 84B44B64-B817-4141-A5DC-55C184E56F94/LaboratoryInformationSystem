using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LIS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        string _username;
        string _usertype;

        private void addNewPatientDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmAddPatient)
                {
                    if (MessageBox.Show("Open another patient form?","System",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        frmAddPatient add = new frmAddPatient();
                        add.lbl_username.Text = _username;
                        add.lbl_usertype.Text = _usertype;
                        add.Show();
                        return;
                    }
                    else
                    {
                        f.Focus();
                        return;
                    }
                }
            }
            frmAddPatient addd = new frmAddPatient();
            addd.lbl_username.Text = _username;
            addd.lbl_usertype.Text = _usertype;
            addd.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _username = lbl_username.Text;
            MySqlDataReader reader = Program.Query("Select * from lis.tbl_users where username collate latin1_general_cs like '" + _username + "'");
            while (reader.Read())
            {
                Text = "Logged user: " + reader.GetString(3) + " " + reader.GetString(4) + ". " + reader.GetString(5) + " - " + reader.GetString(6);
                _usertype = reader.GetString(2);
            }
            reader.Close();
            switch (_usertype)
            {
                case "admin":
                    {
                        tsmMaintenance.Visible = true;
                        break;
                    }
                case "user":
                    {
                        tsmMaintenance.Visible = false;
                        break;
                    }
            }
            lbl_usertype.Text = _usertype;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int counter = Program.Count("Select Count( " + "BULACAN" + ") from lis.tbl_city");
            MessageBox.Show(counter.ToString());
        }

        private void priceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditPrice edit = new frmEditPrice();
            edit.lbl_username.Text = _username;
            edit.lbl_usertype.Text = _usertype;
            edit.ShowDialog();
        }
    }
}
