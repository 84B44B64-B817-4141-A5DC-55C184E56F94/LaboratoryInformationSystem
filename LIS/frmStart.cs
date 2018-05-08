using System;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LIS
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }
        bool isChecking;
        bool isSet = true;
        bool checkingDone = false;
        bool DBAccessible;
        System.Threading.Thread ip_checker;
        string ipchecker;
        string path = "config.ini";
        int delay_2;
        private void frmStart_Load(object sender, EventArgs e)
        {
            configParser();
        }
        private void txt1st_TextChanged(object sender, EventArgs e)
        {
            if (txt1st.Text.Trim() != "" && txt2nd.Text.Trim() != "" && txt3rd.Text.Trim() != "" && txt4th.Text.Trim() != "")
            {
                btnCheck.Enabled = true;
                btnCheck.BackColor = SystemColors.Control;
            }
            else
            {
                btnCheck.Enabled = false;
                btnCheck.BackColor = SystemColors.WindowFrame;
            }
            if (txt1st.Text.Trim() == "")
            {
                return;
            }
            else
            {
                if (int.Parse(txt1st.Text) > 255)
                {
                    MessageBox.Show("Range is 0 - 255 only.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt1st.Text = "";
                }
                else
                {
                    if (txt1st.TextLength == txt1st.MaxLength)
                    {
                        txt2nd.Select(0, txt1st.MaxLength);
                        txt2nd.Focus();
                    }
                }
            }
        }
        private void txt2nd_TextChanged(object sender, EventArgs e)
        {
            if (txt1st.Text.Trim() != "" && txt2nd.Text.Trim() != "" && txt3rd.Text.Trim() != "" && txt4th.Text.Trim() != "")
            {
                btnCheck.Enabled = true;
                btnCheck.BackColor = SystemColors.Control;
            }
            else
            {
                btnCheck.Enabled = false;
                btnCheck.BackColor = SystemColors.WindowFrame;
            }
            if (txt2nd.Text.Trim() == "")
            {
                return;
            }
            else
            {
                if (int.Parse(txt2nd.Text) > 255)
                {
                    MessageBox.Show("Range is 0 - 255 only.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt2nd.Text = "";
                }
                else
                {
                    if (txt2nd.TextLength == txt2nd.MaxLength)
                    {
                        txt3rd.Select(0, txt1st.MaxLength);
                        txt3rd.Focus();
                    }
                }
            }
        }
        private void txt3rd_TextChanged(object sender, EventArgs e)
        {
            if (txt1st.Text.Trim() != "" && txt2nd.Text.Trim() != "" && txt3rd.Text.Trim() != "" && txt4th.Text.Trim() != "")
            {
                btnCheck.Enabled = true;
                btnCheck.BackColor = SystemColors.Control;
            }
            else
            {
                btnCheck.Enabled = false;
                btnCheck.BackColor = SystemColors.WindowFrame;
            }
            if (txt3rd.Text.Trim() == "")
            {
                return;
            }
            else
            {
                if (int.Parse(txt3rd.Text) > 255)
                {
                    MessageBox.Show("Range is 0 - 255 only.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt3rd.Text = "";
                }
                else
                {
                    if (txt3rd.TextLength == txt3rd.MaxLength)
                    {
                        txt4th.Select(0, txt1st.MaxLength);
                        txt4th.Focus();
                    }
                }
            }
        }
        private void txt4th_TextChanged(object sender, EventArgs e)
        {
            if (txt1st.Text.Trim() != "" && txt2nd.Text.Trim() != "" && txt3rd.Text.Trim() != "" && txt4th.Text.Trim() != "")
            {
                btnCheck.Enabled = true;
                btnCheck.BackColor = SystemColors.Control;
            }
            else
            {
                btnCheck.Enabled = false;
                btnCheck.BackColor = SystemColors.WindowFrame;
            }
            if (txt4th.Text.Trim() == "")
            {
                return;
            }
            else
            {
                if (int.Parse(txt4th.Text) > 255)
                {
                    MessageBox.Show("Range is 0 - 255 only.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt4th.Text = "";
                }
                else
                {
                    if (txt4th.TextLength == txt4th.MaxLength)
                    {
                        btnCheck.Focus();
                    }
                }
            }
        }
        private void txt1st_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                txt2nd.Focus();
            }

            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        private void txt2nd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                txt3rd.Focus();
            }
            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        private void txt3rd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                txt4th.Focus();
            }
            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        private void txt4th_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                btnCheck.Focus();
            }
            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        void ipChecker()
        {
            isChecking = true;
            MySqlConnection conn;
            string connectionString = "datasource= " + ipchecker + ";port=3306;username=root;password=mySQL09122016;";
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                DBAccessible = true;
                conn.Close();
            }
            catch (Exception ex)
            {
                DBAccessible = false;
            }
            isChecking = false;
        }

        private void timChecker_Tick(object sender, EventArgs e)
        {
            ip_checker = new System.Threading.Thread(ipChecker);
            ip_checker.Start();
            if (delay_2 > 0)
            {
                delay_2--;
                return;
            }
            if (isChecking != true)
            {
                if (DBAccessible == true)
                {
                    frmLogin log = new frmLogin();
                    log.Show();
                    Close();
                }
                else
                {
                    lblCheck.Visible = false;
                    lblSQL.Visible = true;
                    lbl1.Visible = true;
                    lbl2.Visible = true;
                    lbl3.Visible = true;
                    txt1st.Visible = true;
                    txt2nd.Visible = true;
                    txt3rd.Visible = true;
                    txt4th.Visible = true;
                    btnCheck.Visible = true;
                }
                checkingDone = true;
                timChecker.Enabled = false;
                if (delay_2 == 0 && DBAccessible == false)
                {
                    delay_2 = -1;
                    showMessage();
                }
                else
                {
                    delay_2 = -1;
                }
            }
        }
        void showMessage()
        {
            MessageBox.Show("Connection to MySQL Server failed.\nPlease reconfigure your Server IP Address.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            lblCheck.Visible = true;
            lblSQL.Visible = false;
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            txt1st.Visible = false;
            txt2nd.Visible = false;
            txt3rd.Visible = false;
            txt4th.Visible = false;
            btnCheck.Visible = false;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ip_set=1");
            sb.AppendLine("ip_address=" + txt1st.Text + "." + txt2nd.Text + "." + txt3rd.Text + "." + txt4th.Text);
            File.WriteAllText(path, sb.ToString());
            configParser();
            timChecker.Enabled = true;
            timChecker.Start();
        }
        void configParser()
        {
            delay_2 = 1;
            if (!File.Exists(path))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("ip_set=0");
                sb.AppendLine("ip_address=0.0.0.0");
                File.WriteAllText(path, sb.ToString());
                lblCheck.Visible = false;
                lblSQL.Visible = true;
                lbl1.Visible = true;
                lbl2.Visible = true;
                lbl3.Visible = true;
                txt1st.Visible = true;
                txt2nd.Visible = true;
                txt3rd.Visible = true;
                txt4th.Visible = true;
                btnCheck.Visible = true;
                isSet = false;
            }
            string line;
            StreamReader file = new StreamReader("config.ini");
            while ((line = file.ReadLine()) != null)
            {
                string read = line;
                line = line.Remove(4, line.Length - 4);
                if (line == "ip_s")
                {
                    read = read.Remove(0, 7);
                    if (read == "0")
                    {
                        lblCheck.Visible = false;
                        lblSQL.Visible = true;
                        lbl1.Visible = true;
                        lbl2.Visible = true;
                        lbl3.Visible = true;
                        txt1st.Visible = true;
                        txt2nd.Visible = true;
                        txt3rd.Visible = true;
                        txt4th.Visible = true;
                        btnCheck.Visible = true;
                        showMessage();
                        isSet = false;
                    }
                }
                else if (line == "ip_a")
                {
                    read = read.Remove(0, 11);
                    ipchecker = read;
                    txt1st.Text = read.Substring(0, read.IndexOf("."));
                    read = read.Remove(0, read.IndexOf("."));
                    read = read.Remove(0, 1);
                    txt2nd.Text = read.Substring(0, read.IndexOf("."));
                    read = read.Remove(0, read.IndexOf("."));
                    read = read.Remove(0, 1);
                    txt3rd.Text = read.Substring(0, read.IndexOf("."));
                    read = read.Remove(0, read.IndexOf("."));
                    read = read.Remove(0, 1);
                    txt4th.Text = read;
                    if (isSet == true)
                    {
                        timChecker.Enabled = true;
                        timChecker.Start();
                    }
                    txt1st.Select(0, txt1st.MaxLength);
                    txt1st.Focus();
                }
            }
            file.Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
