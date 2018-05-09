using System;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace LIS
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //For Creating only one instance of the program
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Only one instance of this program can be run at a time.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var main_form = new frmStart();
                main_form.Show();
                Application.Run();
            }
        }
        private static string appGuid = "14003790-d057-463f-9d-592b4ae51717";
        static bool DBAccessible = true;
        static string read;
        public static MySqlConnection Connect()
        {
            //For MySQL Server IP Checking
            string line;
            StreamReader file = new StreamReader("config.ini");
            while ((line = file.ReadLine()) != null)
            {
                read = line;
                line = line.Remove(4, line.Length - 4);
                if (line == "ip_a")
                {
                    read = read.Remove(0, 11);
                }
            }
            string ConnectionString = "datasource=" + read + ";port=3306;username=root;password=mySQL09122016;";
            MySqlConnection Connection = new MySqlConnection(ConnectionString);
            Connection.Close();
            try
            {
                Connection.Open();
                if (DBAccessible == false && Connection.State == ConnectionState.Open)
                {
                    DBAccessible = true;
                    MessageBox.Show("Database access re-gained.", "MySQL - Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (DBAccessible == true && Connection.State != ConnectionState.Open)
                {
                    DBAccessible = false;
                    MessageBox.Show("Database connect attempt failed.", "MySQL - Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { }
            return Connection;
        }
        //For MySQL Commands SELECT, INSERT, UPDATE, DELETE
        public static MySqlDataReader Query(string Text)
        {
            try
            {
                MySqlConnection Connection = Connect();
                MySqlCommand Command = new MySqlCommand(Text, Connection);
                Command.Prepare();
                MySqlDataReader Reader = Command.ExecuteReader(CommandBehavior.CloseConnection);
                return Reader;
            }
            catch (MySqlException msex)
            {
                MessageBox.Show(msex.Message);
                return null;
            }
        }
        //For Audit Trail
        public static void AuditTrail(string activity, string username, string workgroup, string databasename)
        {
            string actdate = DateTime.Now.ToString("yyyy-MM-dd"), acttime = DateTime.Now.ToString("HH:mm:ss");
            string forAudit = "insert into " + databasename + ".tbl_audit" + " (username, workgroup, actdate, acttime, activity) values ('" + username + "', '" + workgroup + "', '" + actdate + "', '" + acttime + "', '" + activity + "');";
            Query(forAudit).Close();
        }
        internal static void AuditTrail()
        {
            throw new NotImplementedException();
        }
    }
}
