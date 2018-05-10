using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LIS
{
    public partial class frmFeeList : Form
    {
        public frmFeeList()
        {
            InitializeComponent();
        }
        //Note: Strict Order of Items. Item order must match order in database.
        private void frmFeeList_Load(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
