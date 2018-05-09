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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            ActiveControl = txtUsername;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = Program.Query("Select * from lis.tbl_users where username collate latin1_general_cs like '" + txtUsername.Text + "' and password collate latin1_general_cs like '" + txtPassword.Text + "'");
            if (reader.Read() == false)
            {
                MessageBox.Show("Invalid username/password", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnClose.PerformClick();
            }
            else
            {
                frmMain main = new frmMain();
                main.lbl_username.Text = txtUsername.Text;
                main.Show();
                Close();
            }
            reader.Close();
        }

        private void lblRecover_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lblVersion_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() != "" || txtPassword.Text.Trim() != "")
            {
                btnClose.Text = "Clear";
            }
            else
            {
                btnClose.Text = "Close";
            }

            if (txtUsername.Text.Trim() != "" && txtPassword.Text.Trim() != "" && txtPassword.Text.Length > 4)
            {
                btnOK.FlatStyle = FlatStyle.System;
                btnOK.Enabled = true;
                AcceptButton = btnOK;
            }
            else
            {
                btnOK.FlatStyle = FlatStyle.Flat;
                btnOK.Enabled = false;
                AcceptButton = null;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() != "" || txtPassword.Text.Trim() != "")
            {
                btnClose.Text = "Clear";
            }
            else
            {
                btnClose.Text = "Close";
            }

            if (txtUsername.Text.Trim() != "" && txtPassword.Text.Trim() != "" && txtPassword.Text.Length > 4)
            {
                btnOK.FlatStyle = FlatStyle.System;
                btnOK.Enabled = true;
                AcceptButton = btnOK;
            }
            else
            {
                btnOK.FlatStyle = FlatStyle.Flat;
                btnOK.Enabled = false;
                AcceptButton = null;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            switch (btnClose.Text)
            {
                case "Close":
                    {
                        btnExit.PerformClick();
                        break;
                    }
                case "Clear":
                    {
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        AcceptButton = null;
                        btnClose.Text = "Close";
                        txtUsername.Focus();
                        break;
                    }
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        //For Ctrl+A, Ctrl+C, Ctrl+X, Ctrl+V keyboard commands over filtered textboxes
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender != null)
                {
                    ((TextBox)sender).SelectAll();
                }
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                if (sender != null)
                {
                    ((TextBox)sender).Copy();
                }

            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                if (sender != null)
                {
                    ((TextBox)sender).Paste();
                }
            }
            else if (e.Control && e.KeyCode == Keys.X)
            {
                if (sender != null)
                {
                    ((TextBox)sender).Cut();
                }
            }
            else
            {
                return;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                if (sender != null)
                {
                    ((TextBox)sender).SelectAll();
                }
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                if (sender != null)
                {
                    ((TextBox)sender).Paste();
                }
            }
            else
            {
                return;
            }
        }
    }
}
