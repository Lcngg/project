using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable data = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(@"Data Source=DESKTOP-2QG0E2L\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True");
            command = connection.CreateCommand();
            command.CommandText = "Select * From AccountBS Where username = @username AND password = @password";
            command.Parameters.AddWithValue("@username",txtUserName.Text);
            command.Parameters.AddWithValue("@password", txtPass.Text);
            adapter.SelectCommand = command;
            adapter.Fill(data);
            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = data.Columns["id"];
            data.PrimaryKey = keyColumns;
            if (data.Rows.Count > 0)
            {
                if (txtUserName.Text.Contains("staff") == true)
                {
                    Hide();
                    FormUser formUser = new FormUser();
                    formUser.Show();
                    
                }
                else
                {
                   Hide();
                    FormManager formManager = new FormManager();
                    formManager.Show();
                   
                }
            }
            else
            {
                MessageBox.Show("Check your account information again", "Login Issues", MessageBoxButtons.OK);
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
