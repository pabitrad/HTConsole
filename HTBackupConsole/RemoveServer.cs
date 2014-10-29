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
    public partial class RemoveServer : Form
    {

        //SqlCeConnection cn = new SqlCeConnection(@"Data Source = c:\users\bandrade\documents\visual studio 2010\Projects\HTBackupConsole\HTBackupConsole\MyDatabase#1.sdf; Password='Inter20Net11'");
        public SqlCeConnection cn = new SqlCeConnection(HTConsoleHelper.ConnectionString);

        public RemoveServer()
        {
            InitializeComponent();
        }

        private void Populate()
        {

            listView1.Items.Clear();

            SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM SCHEDULER ORDER BY SERVERNAME ASC");
            cmd.Connection = cn;

            try
            {
                SqlCeDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ListViewItem it = new ListViewItem(dr["SERVERNAME"].ToString());
                    it.SubItems.Add(dr["SERVERIP"].ToString());

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

        private void RemoveServer_Shown(object sender, EventArgs e)
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
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
            if (MessageBox.Show("Are you sure?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCeCommand cmd = new SqlCeCommand("DELETE FROM SCHEDULER WHERE SERVERNAME = @SERVERNAME");
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@SERVERNAME", listView1.SelectedItems[0].Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    Populate();
                    button1.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
