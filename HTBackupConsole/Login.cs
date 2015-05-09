using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using HTConsoleCommonUtil;

namespace HTBackupConsole
{
    public partial class Login : Form
    {
        SqlCeConnection cn = new SqlCeConnection(HTConsoleHelper.ConnectionString);

        public Login()
        {
            InitializeComponent();
        }

        private bool CompareStrings(string string1, string string2)
        {
            return String.Compare(string1, string2, true, System.Globalization.CultureInfo.InvariantCulture) == 0 ? true : false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();

                SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM HTBACKUPUSER WHERE HTUSER='" + username.Text + "' and PASSWORD='" + password.Text + "'");
                cmd.Connection = cn;

                SqlCeDataReader dr = cmd.ExecuteReader();

                string userText = username.Text;
                string passText = password.Text;

                if (dr.Read() && 
                    (this.CompareStrings(dr["HTUSER"].ToString(), userText) &&
                    this.CompareStrings(dr["PASSWORD"].ToString(), passText)))
                {
                    Form1 Form1 = new Form1();
                    Form1.Show();
                    this.Hide();
                    PolicyManager.runAutomaticPoliciesHandling();
                }
                else
                {
                    MessageBox.Show("Invalid login credentials. Please try again");
                }
                dr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            password.PasswordChar = '*';
            ActiveControl = username;
        }
    }
}
