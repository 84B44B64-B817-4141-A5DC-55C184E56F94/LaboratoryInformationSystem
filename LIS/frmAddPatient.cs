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
            cboGender.SelectedIndex = -1;
            cboProvince.SelectedIndex = -1;
            cboCity.SelectedIndex = -1;
            cboDiscount.SelectedIndex = 0;
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
                txtContact_1.Select(txtContact_1.MaxLength,txtContact_1.MaxLength);
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
                txtContact_1.Focus();
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

        private void chkFBS_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBAIC.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
        }

        private void chkBUN_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBAIC.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
        }

        private void chkCreatinine_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBAIC.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
        }

        private void chkUric_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBAIC.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
        }

        private void chkChole_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBAIC.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
        }

        private void chkTrigly_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBAIC.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
        }

        private void chkHDL_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBAIC.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
        }

        private void chkSgpt_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBAIC.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
        }

        private void chkSgot_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBAIC.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
        }

        private void chkECG_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBAIC.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
        }

        private void chkCBC_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBAIC.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
        }

        private void chkPlatelet_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBAIC.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
        }

        private void chkUrinalysis_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBAIC.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
        }

        private void chk2hrPPBS_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBAIC.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
        }

        private void chkHBAIC_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBAIC.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
        }

        private void chkSodium_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBAIC.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
        }

        private void chkPotassium_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBAIC.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
        }

        private void chkHbsag_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBAIC.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
        }

        private void chkFecalysis_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBAIC.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
        }

        private void txtLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtFirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtMidname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtSuffix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtContact_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtContact_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtContact_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void frmAddPatient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtFirstname.Text.Trim() != "" || txtLastname.Text.Trim() != "" || txtMidname.Text.Trim() != "" || txtSuffix.Text.Trim() != "" || cboCity.SelectedIndex != -1 || cboGender.SelectedIndex != -1 || cboProvince.SelectedIndex != -1 || txtAge.Text.Trim() != "" || chk2hrPPBS.CheckState != CheckState.Unchecked && chkBUN.CheckState != CheckState.Unchecked && chkCBC.CheckState != CheckState.Unchecked && chkChole.CheckState != CheckState.Unchecked && chkCreatinine.CheckState != CheckState.Unchecked && chkECG.CheckState != CheckState.Unchecked && chkFBS.CheckState != CheckState.Unchecked && chkFecalysis.CheckState != CheckState.Unchecked && chkHBAIC.CheckState != CheckState.Unchecked && chkHbsag.CheckState != CheckState.Unchecked && chkHDL.CheckState != CheckState.Unchecked && chkPlatelet.CheckState != CheckState.Unchecked && chkPotassium.CheckState != CheckState.Unchecked && chkSgot.CheckState != CheckState.Unchecked && chkSgpt.CheckState != CheckState.Unchecked && chkSodium.CheckState != CheckState.Unchecked && chkTrigly.CheckState != CheckState.Unchecked && chkUric.CheckState != CheckState.Unchecked && chkUrinalysis.CheckState != CheckState.Unchecked)
            {
                if (MessageBox.Show("Input details are already present. Continue closing form?","System",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
