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
    public partial class Users : Form
    {
        //public SqlCeConnection cn = new SqlCeConnection(@"Data Source = c:\users\bandrade\documents\visual studio 2010\Projects\HTBackupConsole\HTBackupConsole\MyDatabase#1.sdf; Password='Inter20Net11'");
        public SqlCeConnection cn = new SqlCeConnection(HTConsoleHelper.ConnectionString);

        public Users()
        {
            InitializeComponent();
        }

        private void Users_Shown(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                Populate();
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.ExitThread();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
                AddUser AddUser = new AddUser();
                AddUser.Show();
        }

        private void Users_Load(object sender, EventArgs e)
        {

        }

        private void Populate()
        {

            listView1.Items.Clear();

            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM HTBACKUPUSER");
            cmd.Connection = cn;

            try
            {
                SqlCeDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ListViewItem it = new ListViewItem(dr["HTUSER"].ToString());
                    it.SubItems.Add(dr["CREATEDATE"].ToString());

                    listView1.Items.Add(it);
                }

                dr.Close();
                dr.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the user?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCeCommand cmd = new SqlCeCommand("DELETE FROM HTBACKUPUSER WHERE HTUSER = @HTUSER");
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@HTUSER", listView1.SelectedItems[0].Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    Populate();
                    button2.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM HTBACKUPUSER");
            cmd.Connection = cn;

            try
            {
                SqlCeDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ListViewItem it = new ListViewItem(dr["HTUSER"].ToString());
                    it.SubItems.Add(dr["CREATEDATE"].ToString());

                    listView1.Items.Add(it);
                }

                dr.Close();
                dr.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
