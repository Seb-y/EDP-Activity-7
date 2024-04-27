using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static User_Interface.Form1;

namespace User_Interface
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public static class UserInfo
        {
            public static string Email { get; set; }
            public static string UserType { get; set; }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            string confirmEmail = txtConfirmEmail.Text;

            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                if (dbConnection.OpenConnection())
                {
                    // Query to check if the email exists in the Attorneys table
                    string attorneyQuery = $"SELECT COUNT(*) FROM Attorneys WHERE attorney_email = '{confirmEmail}'";
                    MySqlCommand attorneyCmd = new MySqlCommand(attorneyQuery, dbConnection.Connection);
                    int attorneyCount = Convert.ToInt32(attorneyCmd.ExecuteScalar());

                    // Query to check if the email exists in the Prosecutors table
                    string prosecutorQuery = $"SELECT COUNT(*) FROM Prosecutors WHERE prosecutor_email = '{confirmEmail}'";
                    MySqlCommand prosecutorCmd = new MySqlCommand(prosecutorQuery, dbConnection.Connection);
                    int prosecutorCount = Convert.ToInt32(prosecutorCmd.ExecuteScalar());

                    // Check if the email exists in either table
                    if (attorneyCount > 0)
                    {
                        MessageBox.Show("Email exists in Attorneys table!");
                        // Set the email and user type in UserInfo class
                        UserInfo.Email = confirmEmail;
                        UserInfo.UserType = "Attorney";
                        // Redirect to Form4
                        Form4 form4 = new Form4();
                        form4.Show();
                        this.Close();
                    }
                    else if (prosecutorCount > 0)
                    {
                        MessageBox.Show("Email exists in Prosecutors table!");
                        // Set the email and user type in UserInfo class
                        UserInfo.Email = confirmEmail;
                        UserInfo.UserType = "Prosecutor";
                        // Redirect to Form4
                        Form4 form4 = new Form4();
                        form4.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Email does not exist in either table");
                    }
                }
                else
                {
                    MessageBox.Show("Failed to connect to the database");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void backToSignIN_Click(object sender, EventArgs e)
        {
            // Hide the current form (Form2) and show Form1
            this.Hide();

            // Show Form1
            Form1 form1 = new Form1();
            form1.Show();

            // Close Form2
            this.Close();
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            // Close the form and end all processes
            Application.Exit();
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            // Minimize the form
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
