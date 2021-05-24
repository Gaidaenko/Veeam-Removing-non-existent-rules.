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

namespace DB_value_delete
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              SqlConn();
        }
        public void SqlConn()
        {
           //string DataSource = Environment.MachineName;
           //string DataSource = "THINKPAD";

           string DataSource = richTextBox1.Text;

           //string DBname = textBox2.Text;
           //string Login = textBox3.Text;
           //string Pass = textBox4.Text;
           //string connString = @"Data Source=" + DataSource + ";Initial Catalog=VeeamBackup" + ";Persist Security Info=True;User ID=" + Login + ";Password=" + Pass; // Подключение по логину, паролю и имени базы.

           SqlConnection conn;
           string connString = @"Data Source=" + DataSource + ";Initial Catalog=VeeamBackup" + ";Integrated Security=True"; 

           conn = new SqlConnection(connString);
           string sqlExpression = "DELETE FROM [Backup.Model.OIBs] WHERE link_id is NULL";
          
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try                
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, conn);

                    int number = command.ExecuteNonQuery();
                    command.Connection = connection;

                    label2.ForeColor = Color.Green;
                    label2.Text= "Подключение открыто! Удалено объектов " + Convert.ToString(number);
                    conn.Close();
                }
                catch
                {
                    label2.ForeColor = Color.Red;
                    label2.Text = "Подключение не открыто!\nПроверьте правильность имени сервера (экземпляра)!";
                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
