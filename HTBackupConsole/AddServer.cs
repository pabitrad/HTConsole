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
    public partial class AddServer : Form
    {

        public SqlCeConnection cn = new SqlCeConnection(HTConsoleHelper.ConnectionString);

        public AddServer()
        {
            InitializeComponent();
        }

        private void AddServer_Shown(object sender, EventArgs e)
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

            textBox3.PasswordChar = '*';
            textBox5.PasswordChar = '*';

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
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
            SqlCeCommand cm = new SqlCeCommand("INSERT INTO SCHEDULER VALUES (@SERVERNAME, @USER, @PASSWORD, @ESSUSER, @ESSPASSWORD, @SERVERIP)");
            cm.Connection = cn;

            cm.Parameters.AddWithValue("@SERVERNAME", textBox1.Text);
            cm.Parameters.AddWithValue("@USER", textBox2.Text);
            cm.Parameters.AddWithValue("@PASSWORD", textBox3.Text);
            cm.Parameters.AddWithValue("@ESSUSER", textBox4.Text);
            cm.Parameters.AddWithValue("@ESSPASSWORD", textBox5.Text);
            cm.Parameters.AddWithValue("@SERVERIP", textBox6.Text);

            try
            {
                int affectedRows = cm.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    MessageBox.Show("Insert Success!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
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

        private void AddServer_Load(object sender, EventArgs e)
        {

        }
    }
}
