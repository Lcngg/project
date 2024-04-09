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
    public partial class FormUser : Form
    {
        public static FormUser instance;
        public TextBox total,charge,change;
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string servername= @"Data Source=DESKTOP-2QG0E2L\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True";
        DataTable dt= new DataTable();       
        
        public FormUser()
        {
            InitializeComponent();
            instance = this;
            total = txtTotal;
            change = txtChange;
            charge = txtCharge;
            
        } 
    
        private void FormUser_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(servername);
            dataGridView2.DataSource = adapter;
        }

        private void button26_Click(object sender, EventArgs e)
        {           
                DialogResult dialogResult = MessageBox.Show("Are you sure to sign out? ", "Sign out Verify", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Form1 form1 = new Form1();
                    form1.Show();
                    Close();
                }            
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            btnBook1.Show();
            btnBook2.Show();
            btnBook3.Show();
            btnBook4.Show();
            btnBook5.Show();

            btnComics1.Hide();
            btnComics2.Hide();
            btnComics3.Hide();
            btnComics4.Hide();
            btnComics5.Hide();
            
            btnMagazine1.Hide();
            btnMagazine2.Hide();    
            btnMagazine3.Hide();
            btnMagazine4.Hide();
            btnMagazine5.Hide();

            btnNews1.Hide();
            btnNews2.Hide();
            btnNews3.Hide();
            btnNews4.Hide();
            btnNews5.Hide();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            
        }
       
        private void btnHome_Click(object sender, EventArgs e)
        {
            btnBook1.Show();
            btnBook2.Show();
            btnBook3.Show();
            btnBook4.Show();
            btnBook5.Show();

            btnNews1.Show();
            btnNews2.Show();
            btnNews3.Show();
            btnNews4.Show();
            btnNews5.Show();

            btnMagazine1.Show();
            btnMagazine2.Show();
            btnMagazine3.Show();
            btnMagazine4.Show();
            btnMagazine5.Show();

            btnComics1.Show();
            btnComics2.Show();
            btnComics3.Show();
            btnComics4.Show();
            btnComics5.Show();

        }

        private void btnComics_Click(object sender, EventArgs e)
        {
            btnComics1.Show();
            btnComics2.Show();
            btnComics3.Show();
            btnComics4.Show();
            btnComics5.Show();

            btnBook1.Hide();
            btnBook2.Hide();
            btnBook3.Hide();
            btnBook4.Hide();
            btnBook5.Hide();

            btnMagazine1.Hide();
            btnMagazine2.Hide();
            btnMagazine3.Hide();
            btnMagazine4.Hide();
            btnMagazine5.Hide();

            btnNews1.Hide();
            btnNews2.Hide();
            btnNews3.Hide();
            btnNews4.Hide();
            btnNews5.Hide();
        }

        private void btnMagazine_Click(object sender, EventArgs e)
        {
            btnMagazine1.Show();
            btnMagazine2.Show();
            btnMagazine3.Show();
            btnMagazine4.Show();
            btnMagazine5.Show();

            btnBook1.Hide();
            btnBook2.Hide();
            btnBook3.Hide();
            btnBook4.Hide();
            btnBook5.Hide();

            btnComics1.Hide();
            btnComics2.Hide();
            btnComics3.Hide();
            btnComics4.Hide();
            btnComics5.Hide();

            btnNews1.Hide();
            btnNews2.Hide();
            btnNews3.Hide();
            btnNews4.Hide();
            btnNews5.Hide();
        }

        private void btnNews_Click(object sender, EventArgs e)
        {
            btnNews1.Show();
            btnNews2.Show();
            btnNews3.Show();
            btnNews4.Show();
            btnNews5.Show();

            btnBook1.Hide();
            btnBook2.Hide();
            btnBook3.Hide();
            btnBook4.Hide();
            btnBook5.Hide();

            btnComics1.Hide();
            btnComics2.Hide();
            btnComics3.Hide();
            btnComics4.Hide();
            btnComics5.Hide();

            btnMagazine1.Hide();
            btnMagazine2.Hide();
            btnMagazine3.Hide();
            btnMagazine4.Hide();
            btnMagazine5.Hide();
        }

        void DisplayBook()
        {
            
            command = connection.CreateCommand();
            command.CommandText = "Select * From AllTable";
            adapter.SelectCommand = command;
            dt.Clear();
            adapter.Fill(dt);
            
            dataGridView2.DataSource = dt;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(servername);
            string search = "select * from Alltable where Name like '"+txtSearch.Text+"'";
            connection.Open();
            command = new SqlCommand(search,connection);            
            adapter.SelectCommand = command;            
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            
        }

        private void btnBook5_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Books where Name='Self-Help'";
            adapter.SelectCommand = command;            
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnBook1_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Books where Name='Ha Do'";
            adapter.SelectCommand = command;            
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnBook2_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Books where Name='Harry Potter'";
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnBook3_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Books where Name='Mat Biec'";
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnBook4_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Books where Name='Ngoi Khoc Tren Cay'";
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnComics1_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Comics where Name='Crayon Shin-Chan'";
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnComics2_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * From Comics Where Name='Detective Conan '";
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnComics3_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * From Comics Where Name='Doraemon'";
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnComics4_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * From Comics Where Name='Naruto '";
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnComics5_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * From Comics Where Name='One Piece'";
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnMagazine1_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * From Magazines Where Name='Marie Claire '";
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnMagazine2_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * From Magazines Where Name='Rolling Stone'";
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnMagazine3_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * From Magazines Where Name='Time'";
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnMagazine4_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * From Magazines Where Name='Vanity Fair'";
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnMagazine5_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * From Magazines Where Name='Vogue'";
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnNews1_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * From News Where Name='Economics'";
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnNews2_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * From News Where Name='Laws'";
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnNews3_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * From News Where Name='Technology'";
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnNews4_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * From News Where Name='Music'";
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnNews5_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * From News Where Name='WorldNews'";
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dt.Clear();
            txtChange.Text = "";
            txtTotal.Text = "";
            txtCharge.Text = "";
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "Charge: ")
            {
                if (txtCharge.Text == "" || int.Parse(txtCharge.Text) / 1 != int.Parse(txtCharge.Text))
                {
                    MessageBox.Show("Wrong format or not have enter the charge", "Purchase Issues", MessageBoxButtons.OK);
                }
                else
                {


                    if (txtTotal.Text == "" || txtChange.Text == "")
                    {
                        MessageBox.Show("Please order first", "Purchase issues", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (int.Parse(txtCharge.Text) < int.Parse(txtTotal.Text))
                        {
                            MessageBox.Show("No enough money", "Purchase Issues", MessageBoxButtons.OK);
                        }
                        else
                        {
                            {
                                connection = new SqlConnection(servername);
                                command = new SqlCommand("insert into Bills (Name,Cost,Author) values (@Name,@Cost,@Author)", connection);

                                connection.Open();
                                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                                {
                                    command.Parameters.Clear();
                                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[0].Value.ToString();
                                    command.Parameters.Add("@Cost", SqlDbType.Float).Value = dataGridView2.Rows[i].Cells[1].Value.ToString();
                                    command.Parameters.Add("@Author", SqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[2].Value.ToString();
                                    command.ExecuteNonQuery();
                                }

                                DialogResult dialogResult = MessageBox.Show("Successfull", "Purchase Status", MessageBoxButtons.OK);
                                if (dialogResult == DialogResult.OK)
                                {
                                    dt.Clear();
                                    FormReciept formReciept = new FormReciept();
                                    formReciept.Show();
                                    /*txtChange.Text = "";
                                    txtTotal.Text = "";
                                    txtCharge.Text = "";*/
                                }
                            }
                        }
                    }


                }
            }
            else
            {
                connection = new SqlConnection(servername);
                command = new SqlCommand("insert into Bills (Name,Cost,Author) values (@Name,@Cost,@Author)", connection);

                connection.Open();
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    command.Parameters.Clear();
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    command.Parameters.Add("@Cost", SqlDbType.Float).Value = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    command.Parameters.Add("@Author", SqlDbType.VarChar).Value = dataGridView2.Rows[i].Cells[2].Value.ToString();
                    command.ExecuteNonQuery();
                }

                DialogResult dialogResult = MessageBox.Show("Successfull", "Purchase Status", MessageBoxButtons.OK);
                if (dialogResult == DialogResult.OK)
                {
                    dt.Clear();
                    FormReciept formReciept = new FormReciept();
                    formReciept.Show();
                }
            }
            
        }

        private void txtChange_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            
            DialogResult dialogResult = MessageBox.Show("Cash method ? ", "Payment Method", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                
                try
                {
                    if (txtCharge.Text == "")
                    {
                        MessageBox.Show("Please select item and enter money", "Order Issues", MessageBoxButtons.OK);
                    }
                    else
                    {
                        int change = 0;
                        int total = 0;
                        for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        {
                            total = total + Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value);
                        }
                        txtTotal.Text = (total.ToString());
                        change = int.Parse(txtCharge.Text) - int.Parse(txtTotal.Text);
                        if (change < 0)
                        {
                            MessageBox.Show("No enough money", "Purchase Issues", MessageBoxButtons.OK);
                        }
                        else
                        {
                            txtChange.Text = change.ToString();
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wrong Format", "" + ex.Message, MessageBoxButtons.OK);
                }
            }
            else
            {
                textBox4.Text = "PaymentID: ";
                textBox5.Text = "Payment Method";
                txtChange.Hide();
            }
           
            
           
                
            
            
            
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void txtCharge_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
