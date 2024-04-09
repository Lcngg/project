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
    public partial class FormReciept : Form
    {
        public static FormReciept instance;
        SqlConnection connection;
        SqlCommand command;
        string servername = @"Data Source=DESKTOP-2QG0E2L\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable data = new DataTable();
        public FormReciept()
        {
            InitializeComponent();
            instance = this;
        }
        void DisplayBill()
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * from Bills";
            adapter.SelectCommand = command;
            data.Clear();
            adapter.Fill(data);
            

            dataGridView1.DataSource = data;
        }
        private void FormReciept_Load(object sender, EventArgs e)
        {

            txtTotal4.Text = FormUser.instance.total.Text;
            txtChange4.Text = FormUser.instance.change.Text;
            txtCharge4.Text = FormUser.instance.charge.Text;
            txtDate.Text = DateTime.Now.ToString();
            Random random = new Random();
            string bc = "";
            string Numrd;
            string Charrd;

            for (int i = 0; i < 5; i++)
            {
                Numrd = random.Next(1, 100).ToString();
                Charrd = Convert.ToString((char)random.Next(65, 90));

                bc += "" + Numrd + "" + Charrd;
            }
            txtBillCode.Text = bc;
            connection = new SqlConnection(servername);
            DisplayBill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(servername);
            string delete = "Delete from Bills";
            connection.Open();
            command = new SqlCommand(delete, connection);
            command.ExecuteNonQuery();
            MessageBox.Show("Printed", "Print status", MessageBoxButtons.OK);
            FormUser.instance.total.Text = "";
            FormUser.instance.charge.Text = "";
            FormUser.instance.change.Text = "";
            Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(servername);
            string delete = "Delete from Bills";
            connection.Open();
            command = new SqlCommand(delete, connection);
            command.ExecuteNonQuery();
            FormUser.instance.total.Text = "";
            FormUser.instance.charge.Text = "";
            FormUser.instance.change.Text = "";
            Close();
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtBillCode_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
