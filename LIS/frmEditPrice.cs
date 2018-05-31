using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace LIS
{
    public partial class frmEditPrice : Form
    {

        string _username;
        string _usertype;
        double fee;

        public frmEditPrice()
        {
            InitializeComponent();
        }

        private void frmEditPrice_Load(object sender, EventArgs e)
        {
            _username = lbl_username.Text;
            _usertype = lbl_usertype.Text;
            getPrice();
        }
        //Loads prices
        void getPrice()
        {
            int labelCounter = 1;
            MySqlDataReader fetchFee = Program.Query("Select servicefee from lis.tbl_services");
            while (fetchFee.Read())
            {
                switch (labelCounter)
                {
                    case 1:
                        {
                            lblFBS.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 2:
                        {
                            lblBUN.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 3:
                        {
                            lblCrea.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 4:
                        {
                            lblUric.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 5:
                        {
                            lblChole.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 6:
                        {
                            lblTrigly.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 7:
                        {
                            lblHDL.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 8:
                        {
                            lblSGPT.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 9:
                        {
                            lblSGOT.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 10:
                        {
                            lblECG.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 11:
                        {
                            lblUrinalysis.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 12:
                        {
                            lblPPBS.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 13:
                        {
                            lblHBA1C.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 14:
                        {
                            lblHbsag.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 15:
                        {
                            lblCBC.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 16:
                        {
                            lblPlatelet.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 17:
                        {
                            lblPotassium.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 18:
                        {
                            lblSodium.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 19:
                        {
                            lblFecalysis.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 20:
                        {
                            lblDrugTest.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 21:
                        {
                            lblXray1.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 22:
                        {
                            lblXray2.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 23:
                        {
                            lblXray3.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 24:
                        {
                            lblXray4.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 25:
                        {
                            lblXray5.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 26:
                        {
                            lblXray6.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 27:
                        {
                            lblXray7.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 28:
                        {
                            lblXray8.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 29:
                        {
                            lblUltrasound1.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 30:
                        {
                            lblUltrasound2.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 31:
                        {
                            lblUltrasound3.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 32:
                        {
                            lblUltrasound4.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 33:
                        {
                            lblUltrasound5.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 34:
                        {
                            lblUltrasound6.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 35:
                        {
                            lblUltrasound7.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                    case 36:
                        {
                            lblUltrasound8.Text = (fetchFee.GetDouble(0)).ToString("0.00");
                            break;
                        }
                }
                labelCounter++;
            }
            fetchFee.Close();
        }

        private void txtFBS_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBUN_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCrea_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtUric_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtChole_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTrigly_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHDL_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSGPT_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSGOT_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtECG_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtUrinalysis_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPPBS_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHBA1C_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHbsag_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCBC_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPlatelet_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPotassium_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSodium_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtFecalysis_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDrugTest_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtXray1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtXray2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtXray3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtXray4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtXray5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtXray6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtXray7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtXray8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtUltrasound1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtUltrasound2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtUltrasound3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtUltrasound4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtUltrasound5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtUltrasound6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtUltrasound7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtUltrasound8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtFBS_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBUN_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCrea_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtUric_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtChole_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTrigly_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHDL_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSGPT_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSGOT_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtECG_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtUrinalysis_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPPBS_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHBA1C_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHbsag_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCBC_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPlatelet_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPotassium_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSodium_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtFecalysis_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDrugTest_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtXray1_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtXray2_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtXray3_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtXray4_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtXray5_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtXray6_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtXray7_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtXray8_Dec_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtFBS_Dec_Leave(object sender, EventArgs e)
        {
            txtFBS_Dec.Text = int.Parse(txtFBS_Dec.Text).ToString("00");
        }

        private void txtBUN_Dec_Leave(object sender, EventArgs e)
        {
            txtBUN_Dec.Text = int.Parse(txtBUN_Dec.Text).ToString("00");
        }

        private void txtCrea_Dec_Leave(object sender, EventArgs e)
        {
            txtCrea_Dec.Text = int.Parse(txtCrea_Dec.Text).ToString("00");
        }

        private void txtUric_Dec_Leave(object sender, EventArgs e)
        {
            txtUric_Dec.Text = int.Parse(txtUric_Dec.Text).ToString("00");
        }

        private void txtChole_Dec_Leave(object sender, EventArgs e)
        {
            txtChole_Dec.Text = int.Parse(txtChole_Dec.Text).ToString("00");
        }

        private void txtTrigly_Dec_Leave(object sender, EventArgs e)
        {
            txtTrigly_Dec.Text = int.Parse(txtTrigly_Dec.Text).ToString("00");
        }

        private void txtHDL_Dec_Leave(object sender, EventArgs e)
        {
            txtHDL_Dec.Text = int.Parse(txtHDL_Dec.Text).ToString("00");
        }

        private void txtSGPT_Dec_Leave(object sender, EventArgs e)
        {
            txtSGPT_Dec.Text = int.Parse(txtSGPT_Dec.Text).ToString("00");
        }

        private void txtSGOT_Dec_Leave(object sender, EventArgs e)
        {
            txtSGOT_Dec.Text = int.Parse(txtSGOT_Dec.Text).ToString("00");
        }

        private void txtECG_Dec_Leave(object sender, EventArgs e)
        {
            txtECG_Dec.Text = int.Parse(txtECG_Dec.Text).ToString("00");
        }

        private void txtUrinalysis_Dec_Leave(object sender, EventArgs e)
        {
            txtUrinalysis_Dec.Text = int.Parse(txtUrinalysis_Dec.Text).ToString("00");
        }

        private void txtPPBS_Dec_Leave(object sender, EventArgs e)
        {
            txtPPBS_Dec.Text = int.Parse(txtPPBS_Dec.Text).ToString("00");
        }

        private void txtHBA1C_Dec_Leave(object sender, EventArgs e)
        {
            txtHBA1C_Dec.Text = int.Parse(txtHBA1C_Dec.Text).ToString("00");
        }

        private void txtHbsag_Dec_Leave(object sender, EventArgs e)
        {
            txtHbsag_Dec.Text = int.Parse(txtHbsag_Dec.Text).ToString("00");
        }

        private void txtCBC_Dec_Leave(object sender, EventArgs e)
        {
            txtCBC_Dec.Text = int.Parse(txtCBC_Dec.Text).ToString("00");
        }

        private void txtPlatelet_Dec_Leave(object sender, EventArgs e)
        {
            txtPlatelet_Dec.Text = int.Parse(txtPlatelet_Dec.Text).ToString("00");
        }

        private void txtPotassium_Dec_Leave(object sender, EventArgs e)
        {
            txtPotassium_Dec.Text = int.Parse(txtPotassium_Dec.Text).ToString("00");
        }

        private void txtSodium_Dec_Leave(object sender, EventArgs e)
        {
            txtSodium_Dec.Text = int.Parse(txtSodium_Dec.Text).ToString("00");
        }

        private void txtFecalysis_Dec_Leave(object sender, EventArgs e)
        {
            txtFecalysis_Dec.Text = int.Parse(txtFecalysis_Dec.Text).ToString("00");
        }

        private void txtDrugTest_Dec_Leave(object sender, EventArgs e)
        {
            txtDrugTest_Dec.Text = int.Parse(txtDrugTest_Dec.Text).ToString("00");
        }

        private void txtXray1_Dec_Leave(object sender, EventArgs e)
        {
            txtXray1_Dec.Text = int.Parse(txtXray1_Dec.Text).ToString("00");
        }

        private void txtXray2_Dec_Leave(object sender, EventArgs e)
        {
            txtXray2_Dec.Text = int.Parse(txtXray2_Dec.Text).ToString("00");
        }

        private void txtXray3_Dec_Leave(object sender, EventArgs e)
        {
            txtXray3_Dec.Text = int.Parse(txtXray3_Dec.Text).ToString("00");
        }

        private void txtXray4_Dec_Leave(object sender, EventArgs e)
        {
            txtXray4_Dec.Text = int.Parse(txtXray4_Dec.Text).ToString("00");
        }

        private void txtXray5_Dec_Leave(object sender, EventArgs e)
        {
            txtXray5_Dec.Text = int.Parse(txtXray5_Dec.Text).ToString("00");
        }

        private void txtXray6_Dec_Leave(object sender, EventArgs e)
        {
            txtXray6_Dec.Text = int.Parse(txtXray6_Dec.Text).ToString("00");
        }

        private void txtXray7_Dec_Leave(object sender, EventArgs e)
        {
            txtXray7_Dec.Text = int.Parse(txtXray7_Dec.Text).ToString("00");
        }

        private void txtXray8_Dec_Leave(object sender, EventArgs e)
        {
            txtXray8_Dec.Text = int.Parse(txtXray8_Dec.Text).ToString("00");
        }

        private void txtUltrasound1_Dec_Leave(object sender, EventArgs e)
        {
            txtUltrasound1_Dec.Text = int.Parse(txtUltrasound1_Dec.Text).ToString("00");
        }

        private void txtUltrasound2_Dec_Leave(object sender, EventArgs e)
        {
            txtUltrasound2_Dec.Text = int.Parse(txtUltrasound2_Dec.Text).ToString("00");
        }

        private void txtUltrasound3_Dec_Leave(object sender, EventArgs e)
        {
            txtUltrasound3_Dec.Text = int.Parse(txtUltrasound3_Dec.Text).ToString("00");
        }

        private void txtUltrasound4_Dec_Leave(object sender, EventArgs e)
        {
            txtUltrasound4_Dec.Text = int.Parse(txtUltrasound4_Dec.Text).ToString("00");
        }

        private void txtUltrasound5_Dec_Leave(object sender, EventArgs e)
        {
            txtUltrasound5_Dec.Text = int.Parse(txtUltrasound5_Dec.Text).ToString("00");
        }

        private void txtUltrasound6_Dec_Leave(object sender, EventArgs e)
        {
            txtUltrasound6_Dec.Text = int.Parse(txtUltrasound6_Dec.Text).ToString("00");
        }

        private void txtUltrasound7_Dec_Leave(object sender, EventArgs e)
        {
            txtUltrasound7_Dec.Text = int.Parse(txtUltrasound7_Dec.Text).ToString("00");
        }

        private void txtUltrasound8_Dec_Leave(object sender, EventArgs e)
        {
            txtUltrasound8_Dec.Text = int.Parse(txtUltrasound8_Dec.Text).ToString("00");
        }

        private void txtBUN_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtCrea_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtUric_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtChole_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtTrigly_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtHDL_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtSGPT_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtSGOT_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtECG_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtUrinalysis_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtPPBS_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtHBA1C_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtHbsag_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtCBC_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtFBS_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtPlatelet_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtPotassium_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtSodium_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtFecalysis_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtDrugTest_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtXray1_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtXray2_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtXray3_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtXray4_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtXray5_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtXray6_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtXray7_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtXray8_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtUltrasound1_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtUltrasound2_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtUltrasound3_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtUltrasound4_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtUltrasound5_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtUltrasound6_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtUltrasound7_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void txtUltrasound8_TextChanged(object sender, EventArgs e)
        {
            if (txtBUN.Text.Trim() != "" || txtCBC.Text.Trim() != "" || txtChole.Text.Trim() != "" || txtCrea.Text.Trim() != "" || txtDrugTest.Text.Trim() != "" || txtECG.Text.Trim() != "" || txtFBS.Text.Trim() != "" || txtFecalysis.Text.Trim() != "" || txtHBA1C.Text.Trim() != "" || txtHbsag.Text.Trim() != "" || txtHDL.Text.Trim() != "" || txtPlatelet.Text.Trim() != "" || txtPotassium.Text.Trim() != "" || txtPPBS.Text.Trim() != "" || txtSGOT.Text.Trim() != "" || txtSGPT.Text.Trim() != "" || txtSodium.Text.Trim() != "" || txtTrigly.Text.Trim() != "" || txtUltrasound1.Text.Trim() != "" || txtUltrasound2.Text.Trim() != "" || txtUltrasound3.Text.Trim() != "" || txtUltrasound4.Text.Trim() != "" || txtUltrasound5.Text.Trim() != "" || txtUltrasound6.Text.Trim() != "" || txtUltrasound7.Text.Trim() != "" || txtUltrasound8.Text.Trim() != "" || txtUric.Text.Trim() != "" || txtUrinalysis.Text.Trim() != "" || txtXray1.Text.Trim() != "" || txtXray2.Text.Trim() != "" || txtXray3.Text.Trim() != "" || txtXray4.Text.Trim() != "" || txtXray5.Text.Trim() != "" || txtXray6.Text.Trim() != "" || txtXray7.Text.Trim() != "" || txtXray8.Text.Trim() != "")
            {
                btnUpdate.FlatStyle = FlatStyle.System;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.FlatStyle = FlatStyle.Flat;
                btnUpdate.Enabled = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update fee list?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (txtBUN.Text.Trim() != "")
                {
                    fee = double.Parse(txtBUN.Text + '.' + txtBUN_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "BUN" + "'").Close();
                    txtBUN.Text = "";
                    txtBUN_Dec.Text = "00";
                }
                if (txtCBC.Text.Trim() != "")
                {
                    fee = double.Parse(txtCBC.Text + '.' + txtCBC_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "CBC" + "'").Close();
                }
                if (txtChole.Text.Trim() != "")
                {
                    fee = double.Parse(txtChole.Text + '.' + txtChole_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Cholesterol" + "'").Close();
                    txtChole.Text = "";
                    txtChole_Dec.Text = "00";
                }
                if (txtCrea.Text.Trim() != "")
                {
                    fee = double.Parse(txtCrea.Text + '.' + txtCrea_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Creatinine" + "'").Close();
                    txtCrea.Text = "";
                    txtCrea_Dec.Text = "00";
                }
                if (txtDrugTest.Text.Trim() != "")
                {
                    fee = double.Parse(txtDrugTest.Text + '.' + txtDrugTest_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Drug Test" + "'").Close();
                    txtDrugTest.Text = "";
                    txtDrugTest_Dec.Text = "00";
                }
                if (txtECG.Text.Trim() != "")
                {
                    fee = double.Parse(txtECG.Text + '.' + txtECG_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "ECG" + "'").Close();
                    txtECG.Text = "";
                    txtECG_Dec.Text = "00";
                }
                if (txtFBS.Text.Trim() != "")
                {
                    fee = double.Parse(txtFBS.Text + '.' + txtFBS_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "FBS" + "'").Close();
                    txtFBS.Text = "";
                    txtFBS_Dec.Text = "00";
                }
                if (txtFecalysis.Text.Trim() != "")
                {
                    fee = double.Parse(txtFecalysis.Text + '.' + txtFecalysis_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Fecalysis" + "'").Close();
                    txtFecalysis.Text = "";
                    txtFecalysis_Dec.Text = "00";
                }
                if (txtHBA1C.Text.Trim() != "")
                {
                    fee = double.Parse(txtHBA1C.Text + '.' + txtHBA1C_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "HBA1C" + "'").Close();
                    txtHBA1C.Text = "";
                    txtHBA1C_Dec.Text = "00";
                }
                if (txtHbsag.Text.Trim() != "")
                {
                    fee = double.Parse(txtHbsag.Text + '.' + txtHbsag_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "HBSAG" + "'").Close();
                    txtHbsag.Text = "";
                    txtHbsag_Dec.Text = "00";
                }
                if (txtHDL.Text.Trim() != "")
                {
                    fee = double.Parse(txtHDL.Text + '.' + txtHDL_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "HDL/LDL" + "'").Close();
                    txtHDL.Text = "";
                    txtHDL_Dec.Text = "00";
                }
                if (txtPlatelet.Text.Trim() != "")
                {
                    fee = double.Parse(txtPlatelet.Text + '.' + txtPlatelet_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Platelet" + "'").Close();
                }
                if (txtPotassium.Text.Trim() != "")
                {
                    fee = double.Parse(txtPotassium.Text + '.' + txtPotassium_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "K" + "'").Close();
                    txtPotassium.Text = "";
                    txtPotassium_Dec.Text = "00";
                }
                if (txtPPBS.Text.Trim() != "")
                {
                    fee = double.Parse(txtPPBS.Text + '.' + txtPPBS_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "2-hr PPBS" + "'").Close();
                    txtPPBS.Text = "";
                    txtPPBS_Dec.Text = "00";
                }
                if (txtSGOT.Text.Trim() != "")
                {
                    fee = double.Parse(txtSGOT.Text + '.' + txtSGOT_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "SGOT" + "'").Close();
                    txtSGOT.Text = "";
                    txtSGOT_Dec.Text = "00";
                }
                if (txtSGPT.Text.Trim() != "")
                {
                    fee = double.Parse(txtSGPT.Text + '.' + txtSGPT_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "SGPT" + "'").Close();
                    txtSGPT.Text = "";
                    txtSGPT_Dec.Text = "00";
                }
                if (txtSodium.Text.Trim() != "")
                {
                    fee = double.Parse(txtSodium.Text + '.' + txtSodium_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Na" + "'").Close();
                    txtSodium.Text = "";
                    txtSodium_Dec.Text = "00";
                }
                if (txtTrigly.Text.Trim() != "")
                {
                    fee = double.Parse(txtTrigly.Text + '.' + txtTrigly_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Triglycerides" + "'").Close();
                    txtTrigly.Text = "";
                    txtTrigly_Dec.Text = "00";
                }
                if (txtUltrasound1.Text.Trim() != "")
                {
                    fee = double.Parse(txtUltrasound1.Text + '.' + txtUltrasound1_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Whole Abd" + "'").Close();
                    txtUltrasound1.Text = "";
                    txtUltrasound1_Dec.Text = "00";
                }
                if (txtUltrasound2.Text.Trim() != "")
                {
                    fee = double.Parse(txtUltrasound2.Text + '.' + txtUltrasound2_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Upper Abd" + "'").Close();
                    txtUltrasound2.Text = "";
                    txtUltrasound2_Dec.Text = "00";
                }
                if (txtUltrasound3.Text.Trim() != "")
                {
                    fee = double.Parse(txtUltrasound3.Text + '.' + txtUltrasound3_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Lower Abd" + "'").Close();
                    txtUltrasound3.Text = "";
                    txtUltrasound3_Dec.Text = "00";
                }
                if (txtUltrasound4.Text.Trim() != "")
                {
                    fee = double.Parse(txtUltrasound4.Text + '.' + txtUltrasound4_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "HBT" + "'").Close();
                    txtUltrasound4.Text = "";
                    txtUltrasound4_Dec.Text = "00";
                }
                if (txtUltrasound5.Text.Trim() != "")
                {
                    fee = double.Parse(txtUltrasound5.Text + '.' + txtUltrasound5_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "KUB" + "'").Close();
                    txtUltrasound5.Text = "";
                    txtUltrasound5_Dec.Text = "00";
                }
                if (txtUltrasound6.Text.Trim() != "")
                {
                    fee = double.Parse(txtUltrasound6.Text + '.' + txtUltrasound6_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Pelvic" + "'").Close();
                    txtUltrasound6.Text = "";
                    txtUltrasound6_Dec.Text = "00";
                }
                if (txtUltrasound7.Text.Trim() != "")
                {
                    fee = double.Parse(txtUltrasound7.Text + '.' + txtUltrasound7_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Thyroid" + "'").Close();
                    txtUltrasound7.Text = "";
                    txtUltrasound7_Dec.Text = "00";
                }
                if (txtUltrasound8.Text.Trim() != "")
                {
                    fee = double.Parse(txtUltrasound8.Text + '.' + txtUltrasound8_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Breast" + "'").Close();
                    txtUltrasound8.Text = "";
                    txtUltrasound8_Dec.Text = "00";
                }
                if (txtUric.Text.Trim() != "")
                {
                    fee = double.Parse(txtUric.Text + '.' + txtUric_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Uric Acid" + "'").Close();
                    txtUric.Text = "";
                    txtUric_Dec.Text = "00";
                }
                if (txtUrinalysis.Text.Trim() != "")
                {
                    fee = double.Parse(txtUrinalysis.Text + '.' + txtUrinalysis_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Urinalysis" + "'").Close();
                    txtUrinalysis.Text = "";
                    txtUrinalysis_Dec.Text = "00";
                }
                if (txtXray1.Text.Trim() != "")
                {
                    fee = double.Parse(txtXray1.Text + '.' + txtXray1_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Thoracic Spine" + "'").Close();
                    txtXray1.Text = "";
                    txtXray1_Dec.Text = "00";
                }
                if (txtXray2.Text.Trim() != "")
                {
                    fee = double.Parse(txtXray2.Text + '.' + txtXray2_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Extremities" + "'").Close();
                    txtXray2.Text = "";
                    txtXray2_Dec.Text = "00";
                }
                if (txtXray3.Text.Trim() != "")
                {
                    fee = double.Parse(txtXray3.Text + '.' + txtXray3_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Cervical Spine" + "'").Close();
                    txtXray3.Text = "";
                    txtXray3_Dec.Text = "00";
                }
                if (txtXray4.Text.Trim() != "")
                {
                    fee = double.Parse(txtXray4.Text + '.' + txtXray4_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Shoulder" + "'").Close();
                    txtXray4.Text = "";
                    txtXray4_Dec.Text = "00";
                }
                if (txtXray5.Text.Trim() != "")
                {
                    fee = double.Parse(txtXray5.Text + '.' + txtXray5_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "Skull" + "'").Close();
                    txtXray5.Text = "";
                    txtXray5_Dec.Text = "00";
                }
                if (txtXray6.Text.Trim() != "")
                {
                    fee = double.Parse(txtXray6.Text + '.' + txtXray6_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "PNS" + "'").Close();
                    txtXray6.Text = "";
                    txtXray6_Dec.Text = "00";
                }
                if (txtXray7.Text.Trim() != "")
                {
                    fee = double.Parse(txtXray7.Text + '.' + txtXray7_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "CXR PA" + "'").Close();
                    txtXray7.Text = "";
                    txtXray7_Dec.Text = "00";
                }
                if (txtXray8.Text.Trim() != "")
                {
                    fee = double.Parse(txtXray8.Text + '.' + txtXray8_Dec.Text);
                    Program.Query("Update lis.tbl_services set servicefee = '" + fee.ToString("0.00") + "' where servicename = '" + "CXR APL" + "'").Close();
                    txtXray8.Text = "";
                    txtXray8_Dec.Text = "00";
                }
                MessageBox.Show("Fee list has been updated.","System",MessageBoxButtons.OK,MessageBoxIcon.Information);
                getPrice();
            }
        }
    }
}
