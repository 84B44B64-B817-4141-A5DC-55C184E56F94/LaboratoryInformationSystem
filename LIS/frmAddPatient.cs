using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIS
{
    public partial class frmAddPatient : Form
    {
        public frmAddPatient()
        {
            InitializeComponent();
        }

        private void frmAddPatient_Load(object sender, EventArgs e)
        {
            dtpNew.Value = DateTime.Now;
            radMobile.Checked = true;
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            var today = DateTime.Today;
            var age = today.Year - dtpBirthday.Value.Year;
            if (dtpBirthday.Value > today.AddYears(-age))
            {
                age--;
            }
            txtAge.Text = age.ToString();
        }

        private void radMobile_CheckedChanged(object sender, EventArgs e)
        {
            if (radMobile.Checked == true)
            {
                txtContact_1.Text = "";
                txtContact_2.Text = "";
                txtContact_3.Text = "";
                radTelephone.Checked = false;
                txtContact_1.Text = "09";
                txtContact_1.Focus();
            }
        }

        private void radTelephone_CheckedChanged(object sender, EventArgs e)
        {
            if (radTelephone.Checked == true)
            {
                txtContact_1.Text = "";
                txtContact_2.Text = "";
                txtContact_3.Text = "";
                radMobile.Checked = false;
            }
        }

        private void txtContact_1_TextChanged(object sender, EventArgs e)
        {
            if (radMobile.Checked == true)
            {
                if (txtContact_1.Text.Length > 3)
                {
                    txtContact_2.Focus();
                }
            }
            else if (radMobile.Checked == true)
            {
                if (radTelephone.Text.Length > 2)
                {
                    txtContact_2.Focus();
                }
            }
        }

        private void txtContact_2_TextChanged(object sender, EventArgs e)
        {
            if (txtContact_2.Text.Length > 2)
            {
                txtContact_3.Focus();
            }
        }
    }
}
