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
    public partial class SetupDirectory : Form
    {
        public SqlCeConnection cn = new SqlCeConnection(HTConsoleHelper.ConnectionString);
        public SetupDirectory()
        {
            InitializeComponent();
        }

        private void SetupDirectory_Shown(object sender, EventArgs e)
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

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (txtHTBackupInstallDir.Text != "")
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCeCommand cm = new SqlCeCommand("UPDATE INSTALLINFO SET DIRECTORY = @DIRECTORY, ClustureDirectory = @ClustureDir where ID=1");
            cm.Connection = new SqlCeConnection(HTConsoleHelper.ConnectionString);
            cm.Connection.Open();

            cm.Parameters.AddWithValue("@DIRECTORY", txtHTBackupInstallDir.Text);
            cm.Parameters.AddWithValue("@ClustureDir", txtHTClusterInstallDir.Text);

            try
            {
                int affectedRows = cm.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    MessageBox.Show("Paths updated successfully.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update Failed!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cm.Connection.Close();
            }
        }

        private void SetupDirectory_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM INSTALLINFO");
            cmd.Connection = cn;

            try
            {
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txtHTBackupInstallDir.Text = dr["DIRECTORY"].ToString();
                    txtHTClusterInstallDir.Text = dr["ClustureDirectory"].ToString();
                }
                dr.Close();
                dr.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}