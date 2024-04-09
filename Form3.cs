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
    public partial class FormManager : Form
    {
        public static FormManager instance;
        SqlConnection connection;
        SqlCommand command;
        string servername = @"Data Source=DESKTOP-2QG0E2L\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable data = new DataTable();   
        DataTable data2 = new DataTable();

        void DisplayBook()
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * From AllTable";
            adapter.SelectCommand = command;
            data.Clear();
            adapter.Fill(data);
            dataGridView1.DataSource = data;
        }
        void DisplayAccount()
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * From AccountBS";
            adapter.SelectCommand = command;
            data2.Clear();
            adapter.Fill(data2);
            dataGridView2.DataSource = data2;
        }
        public FormManager()
        {
            InitializeComponent();
            instance = this;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void FormManager_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(servername);
            DisplayBook();
            DisplayAccount();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text==""|| txtCost.Text == ""|| txtAuthor.Text == "")
            {
                MessageBox.Show("Not enough information", "Add item issues");
            }    
            else
            {
                try
                {
                    connection = new SqlConnection(servername);
                    string add = "Insert into AllTable values ('" + txtName.Text + "','" + txtCost.Text + "','" + txtAuthor.Text + "')";
                    connection.Open();
                    command = new SqlCommand(add, connection);
                    command.ExecuteNonQuery();
                    DisplayBook();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    
                    MessageBox.Show(""+txtName.Text+" was exist or wrong format", "Add Issues",MessageBoxButtons.OK);
                }
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*int i = 0;
            i = dataGridView1.CurrentRow.Index;
            txtName.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtCost.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtAuthor.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(servername);
                string update = "Update AllTable set Name='" + txtName.Text + "',Cost='" + txtCost.Text + "',Author='" + txtAuthor.Text + "' Where Name='" + txtName.Text + "'";
                connection.Open();
                command = new SqlCommand(update, connection);
                command.ExecuteNonQuery();
                DisplayBook();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong  cost format", "Update Issues",MessageBoxButtons.OK);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult= MessageBox.Show("Are you sure to delete this item ?", "Delete confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                connection = new SqlConnection(servername);
                string delete = "Delete from AllTable where Name='" + txtName.Text + "'";
                connection.Open();
                command = new SqlCommand(delete, connection);
                command.ExecuteNonQuery();
                DisplayBook();
            }    
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtUserName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Not enough information", "Add account issues");
            }
            else
            {
                connection = new SqlConnection(servername);
                string addaccount = @"Insert into AccountBS values('" + txtID.Text + "','" + txtUserName.Text + "','" + txtPassword.Text + "')";
                connection.Open();
                command = new SqlCommand(addaccount, connection);
                command.ExecuteNonQuery();
                DisplayAccount();
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            connection = new SqlConnection (servername);
            string updateaccount = @"update AccountBS set id='"+txtID.Text+@"',username='" + txtUserName.Text+@"', password='"+txtPassword.Text+@"' where id='"+txtID.Text+@"'";
            connection.Open( );
            command = new SqlCommand(updateaccount,connection);
            command.ExecuteNonQuery();
            DisplayAccount() ;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete? ", "Delete Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                connection = new SqlConnection(servername);
                string deleteaccount = "delete from AccountBS where id='" + txtID.Text + "'";
                connection.Open();
                command = new SqlCommand(deleteaccount, connection);
                command.ExecuteNonQuery();
                DisplayAccount();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to sign out? ", "Sign out Verify", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Form1 form1 = new Form1();
                form1.Show();
                Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                      
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = 0;
            i= dataGridView2.CurrentRow.Index;
            txtID.Text = dataGridView2.Rows[i].Cells[0].Value.ToString();
            txtUserName.Text = dataGridView2.Rows[i].Cells[1].Value.ToString();
            txtPassword.Text = dataGridView2.Rows[i].Cells[2].Value.ToString();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==(char)Keys.Enter)
            {
                txtCost.Focus();
            }
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtAuthor.Focus();
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtUserName.Focus();
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtCost.Text = "";
            txtAuthor.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
        }
    }
}
