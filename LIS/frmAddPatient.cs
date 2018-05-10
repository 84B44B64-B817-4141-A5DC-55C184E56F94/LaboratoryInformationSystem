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
        double fee;

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
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkFBS.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "FBS" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }     
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "FBS" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkBUN_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkBUN.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "BUN" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "BUN" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkCreatinine_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkCreatinine.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Creatinine" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Creatinine" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkUric_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkUric.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Uric Acid" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Uric Acid" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkChole_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkChole.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Cholesterol" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Cholesterol" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkTrigly_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkTrigly.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Triglycerides" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Triglycerides" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            lblGrossTotal.Text = fee.ToString("0.00"); double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkHDL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkHDL.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "HDL/LDL" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "HDL/LDL" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkSgpt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkSgpt.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "SGPT" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "SGPT" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkSgot_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkSgot.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "SGOT" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "SGOT" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkECG_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkECG.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "ECG" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "ECG" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkCBC_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkCBC.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "CBC" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "CBC" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkPlatelet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkPlatelet.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Platelet" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Platelet" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkUrinalysis_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkUrinalysis.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Urinalysis" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Urinalysis" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chk2hrPPBS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chk2hrPPBS.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "2-hr PPBS" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "2-hr PPBS" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkHBA1C_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkHBA1C.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "HBA1C" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "HBA1C" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkSodium_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkSodium.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Na" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Na" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkPotassium_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkPotassium.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "K" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "K" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkHbsag_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkHbsag.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "HBSAG" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "HBSAG" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkFecalysis_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkFecalysis.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Fecalysis" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Fecalysis" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkXray1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkXray1.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Thoracic Spine" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Thoracic Spine" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkXray2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkXray2.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Extremities" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Extremities" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkXray3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkXray3.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Cervical Spine" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Cervical Spine" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkXray4_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkXray4.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Shoulder" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Shoulder" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkXray5_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkXray5.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Skull" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Skull" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkXray6_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkXray6.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "PNS" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "PNS" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkXray7_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkXray7.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "CXR PA" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "CXR PA" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkXray8_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkXray8.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "CXR APL" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "CXR APL" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkUltrasound1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkUltrasound1.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Whole Abd" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Whole Abd" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkUltrasound2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkUltrasound2.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Upper Abd" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Upper Abd" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkUltrasound3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkUltrasound3.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Lower Abd" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Lower Abd" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkUltrasound4_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkUltrasound4.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "HBT" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "HBT" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkUltrasound5_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkUltrasound5.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "KUB" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "KUB" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkUltrasound6_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkUltrasound6.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Pelvic" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Pelvic" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkUltrasound7_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkUltrasound7.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Thyroid" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Thyroid" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkUltrasound8_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkUltrasound8.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Breast" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "Breast" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
            }
        }

        private void chkDrugTest_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDrugTest.CheckState == CheckState.Unchecked && chk2hrPPBS.CheckState == CheckState.Unchecked && chkBUN.CheckState == CheckState.Unchecked && chkCBC.CheckState == CheckState.Unchecked && chkChole.CheckState == CheckState.Unchecked && chkCreatinine.CheckState == CheckState.Unchecked && chkECG.CheckState == CheckState.Unchecked && chkFBS.CheckState == CheckState.Unchecked && chkFecalysis.CheckState == CheckState.Unchecked && chkHBA1C.CheckState == CheckState.Unchecked && chkHbsag.CheckState == CheckState.Unchecked && chkHDL.CheckState == CheckState.Unchecked && chkPlatelet.CheckState == CheckState.Unchecked && chkPotassium.CheckState == CheckState.Unchecked && chkSgot.CheckState == CheckState.Unchecked && chkSgpt.CheckState == CheckState.Unchecked && chkSodium.CheckState == CheckState.Unchecked && chkTrigly.CheckState == CheckState.Unchecked && chkUric.CheckState == CheckState.Unchecked && chkUrinalysis.CheckState == CheckState.Unchecked && chkXray1.CheckState == CheckState.Unchecked && chkXray2.CheckState == CheckState.Unchecked && chkXray3.CheckState == CheckState.Unchecked && chkXray4.CheckState == CheckState.Unchecked && chkXray5.CheckState == CheckState.Unchecked && chkXray6.CheckState == CheckState.Unchecked && chkXray7.CheckState == CheckState.Unchecked && chkXray8.CheckState == CheckState.Unchecked && chkUltrasound1.CheckState == CheckState.Unchecked && chkUltrasound2.CheckState == CheckState.Unchecked && chkUltrasound3.CheckState == CheckState.Unchecked && chkUltrasound4.CheckState == CheckState.Unchecked && chkUltrasound5.CheckState == CheckState.Unchecked && chkUltrasound6.CheckState == CheckState.Unchecked && chkUltrasound7.CheckState == CheckState.Unchecked && chkUltrasound8.CheckState == CheckState.Unchecked)
            {
                grbPrint.Enabled = false;
            }
            else
            {
                grbPrint.Enabled = true;
            }
            switch (chkHbsag.CheckState)
            {
                case CheckState.Checked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "HBSAG" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee + fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
                case CheckState.Unchecked:
                    {
                        MySqlDataReader fetchFee = Program.Query("SELECT * from lis.tbl_services where servicename like '" + "HBSAG" + "'");
                        while (fetchFee.Read())
                        {
                            fee = fee - fetchFee.GetDouble(1);
                            lblNetTotal.Text = fee.ToString("0.00");
                            double discount_value;
                            switch (cboDiscount.SelectedIndex)
                            {
                                case 1:
                                    {
                                        discount_value = (fee * 0.20);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 2:
                                    {
                                        discount_value = (fee * 0.10);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                case 3:
                                    {
                                        discount_value = (fee * 0.50);
                                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                                        break;
                                    }
                                default:
                                    {
                                        lblDiscount.Text =  "- " + "0.00";
                                        lblGrossTotal.Text = lblNetTotal.Text;
                                        break;
                                    }
                            }
                        }
                        fetchFee.Close();
                        break;
                    }
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

        private void cboDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            double discount_value;
            switch (cboDiscount.SelectedIndex)
            {
                case 1:
                    {                 
                        discount_value = (fee * 0.20);
                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                        break;
                    }
                case 2:
                    {
                        discount_value = (fee * 0.10);
                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                        break;
                    }
                case 3:
                    {
                        discount_value = (fee * 0.50);
                        lblDiscount.Text = "- " + discount_value.ToString("0.00");
                        lblGrossTotal.Text = (fee - discount_value).ToString("0.00");
                        break;
                    }
                default:
                    {
                        lblDiscount.Text =  "- " + "0.00";
                        lblGrossTotal.Text = lblNetTotal.Text;
                        break;
                    }
            }
        }

        private void btnPriceCheck_Click(object sender, EventArgs e)
        {
            frmFeeList list = new frmFeeList();
            list.ShowDialog();
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
                if (!fetchCity.IsDBNull(0))
                {
                    if (arrayCounter != arrayReference)
                    {
                        cityArray[arrayCounter] = fetchCity.GetString(0);
                        arrayCounter++;
                    }
                }
            }
            fetchCity.Close();
        }
    }
}
