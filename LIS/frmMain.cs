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
            frmAddPatient add = new frmAddPatient();
            add.ShowDialog();
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
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
