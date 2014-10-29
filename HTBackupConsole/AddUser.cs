using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using HTConsoleCommonUtil;

namespace HTBackupConsole
{
    public partial class AddUser : Form
    {
        public SqlCeConnection cn = new SqlCeConnection(HTConsoleHelper.ConnectionString);

        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void AddUser_Shown(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }
        }

        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCeCommand cm = new SqlCeCommand("INSERT INTO HTBACKUPUSER (HTUSER, PASSWORD, CREATEDATE) VALUES (@HTUSER, @PASSWORD, @CREATEDATE)");
            cm.Connection = cn;

            cm.Parameters.AddWithValue("@HTUSER", textBox1.Text);
            cm.Parameters.AddWithValue("@PASSWORD", textBox2.Text);
            cm.Parameters.AddWithValue("@CREATEDATE", DateTime.Now);

            try
            {
                int affectedRows = cm.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    MessageBox.Show("Insert Success!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Insert Failed!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
