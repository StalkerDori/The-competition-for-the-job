using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace LORENATable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
               
            }
        }
          

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\source\repos\LORENATable\LORENATable\Database1.mdf;Integrated Security=True"

            SQLiteConnection connection = new SQLiteConnection(connectionString);

            await SQLiteConnection.OpenAsync();

            SQLiteDataReader sqliteReader = null;

            SQLiteCommand command = new SQLiteCommand("Select From [Products]", SQLiteConnection);
            
            try
            {
                sqliteReader = await command.ExecuteReaderAsync();

                while (await sqliteReader.ReadAsync());
                {
                    listBox1.Items.Add(Convert.ToString(sqliteReader["Id"]) + "    "
                    + Convert.ToString(sqliteReader["Наименование товара"]) + "    "
                    + Convert.ToString(sqliteReader["Цена"]) + "    "
                    + Convert.ToString(sqliteReader["Скидка"]) + "    "
                    + Convert.ToString(sqliteReader["Зависимость"]) + "    "
                    + Convert.ToString(sqliteReader["Описание "]));
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqliteReader != null)
                    sqliteReader.Close();
            }
        }
    }
}
