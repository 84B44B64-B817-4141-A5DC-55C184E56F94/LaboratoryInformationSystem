using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LIS
{
    public partial class frmAddPatient : Form
    {
        Thread loadCity;
        string[] cityArray;
        int arrayReference, arrayCounter = 0;
        string provinceName;

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
            if (dtpBirthday.Value > DateTime.Now)
            {
                MessageBox.Show("Birthdate cannot be more than the date today.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpBirthday.Value = DateTime.Now;
            }
            else
            {
                var today = DateTime.Today;
                var age = today.Year - dtpBirthday.Value.Year;
                if (dtpBirthday.Value > today.AddYears(-age))
                {
                    age--;
                }
                txtAge.Text = age.ToString();
            }
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
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
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
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
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
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
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
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
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
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
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
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
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
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
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
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
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
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
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
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
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
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
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
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
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
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
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
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
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
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
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
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
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
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
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
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
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
            if (chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked)
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
            if (!char.IsLetter(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)) && (!(e.KeyChar == (char)Keys.Space)))
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
            if (!char.IsLetter(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)) && (!(e.KeyChar == (char)Keys.Space)))
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

        private void txtPhysician_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)) && (!(e.KeyChar == (char)Keys.Space)))
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
            if (txtFirstname.Text.Trim() != "" || txtLastname.Text.Trim() != "" || txtMidname.Text.Trim() != "" || txtSuffix.Text.Trim() != "" || cboCity.SelectedIndex != -1 || cboGender.SelectedIndex != -1 || cboProvince.SelectedIndex != -1 || txtAge.Text.Trim() != "" || chk2hrPPBS.CheckState != CheckState.Unchecked && chkBUN.CheckState != CheckState.Unchecked && chkCBC.CheckState != CheckState.Unchecked && chkChole.CheckState != CheckState.Unchecked && chkCreatinine.CheckState != CheckState.Unchecked && chkECG.CheckState != CheckState.Unchecked && chkFBS.CheckState != CheckState.Unchecked && chkFecalysis.CheckState != CheckState.Unchecked && chkHBA1C.CheckState != CheckState.Unchecked && chkHbsag.CheckState != CheckState.Unchecked && chkHDL.CheckState != CheckState.Unchecked && chkPlatelet.CheckState != CheckState.Unchecked && chkPotassium.CheckState != CheckState.Unchecked && chkSgot.CheckState != CheckState.Unchecked && chkSgpt.CheckState != CheckState.Unchecked && chkSodium.CheckState != CheckState.Unchecked && chkTrigly.CheckState != CheckState.Unchecked && chkUric.CheckState != CheckState.Unchecked && chkUrinalysis.CheckState != CheckState.Unchecked)
            {
                if (MessageBox.Show("Input details are already present. Continue closing form?","System",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void chkXray_CheckedChanged(object sender, EventArgs e)
        {
            if (chkXray.CheckState == CheckState.Checked)
            {
                grbXray.Enabled = true;
            }
            else
            {
                chkXray1.CheckState = CheckState.Unchecked;
                chkXray2.CheckState = CheckState.Unchecked;
                chkXray3.CheckState = CheckState.Unchecked;
                chkXray4.CheckState = CheckState.Unchecked;
                chkXray5.CheckState = CheckState.Unchecked;
                chkXray6.CheckState = CheckState.Unchecked;
                chkXray7.CheckState = CheckState.Unchecked;
                chkXray8.CheckState = CheckState.Unchecked;
                grbXray.Enabled = false;
            }
        }

        private void chkUltrasound_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUltrasound.CheckState == CheckState.Checked)
            {
                grbUltrasound.Enabled = true;
            }
            else
            {
                chkUltrasound1.CheckState = CheckState.Unchecked;
                chkUltrasound2.CheckState = CheckState.Unchecked;
                chkUltrasound3.CheckState = CheckState.Unchecked;
                chkUltrasound4.CheckState = CheckState.Unchecked;
                chkUltrasound5.CheckState = CheckState.Unchecked;
                chkUltrasound6.CheckState = CheckState.Unchecked;
                chkUltrasound7.CheckState = CheckState.Unchecked;
                chkUltrasound8.CheckState = CheckState.Unchecked;
                grbUltrasound.Enabled = false;
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            if (txtAge.Text == "-1")
            {
                txtAge.Text = "0";
            }
        }

        private void cboProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            provinceName = cboProvince.Text;
            cboCity.Items.Clear();
            loadCity = new Thread(getCity);
            loadCity.Start();
            while (loadCity.IsAlive) { }
            cboCity.Items.AddRange(cityArray);
        }

        //For loading the cities/municipalities on selected province
        void getCity()
        {
            arrayReference = Program.Count("SELECT COUNT( `" + provinceName + "`) from lis.tbl_city");
            cityArray = new string[arrayReference];
            MySqlDataReader fetchCity = Program.Query("SELECT `" + provinceName + "` from lis.tbl_city");
            arrayCounter = 0;
            while (fetchCity.Read())
            {
                if (arrayCounter != arrayReference)
                {
                    cityArray[arrayCounter] = fetchCity.GetString(0);
                    arrayCounter++;
                }
            }
            fetchCity.Close();
        }
    }
}
