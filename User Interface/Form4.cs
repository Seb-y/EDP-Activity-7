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
using static User_Interface.Form2;

namespace User_Interface
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            string newPassword = newPasswordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;

            // Check if the new password and confirm password match
            if (newPassword == confirmPassword)
            {
                // Passwords match, perform the desired actions
                MessageBox.Show("Passwords match. Password changed successfully!");

                // Update password in the database
                string email = UserInfo.Email;
                string userType = UserInfo.UserType;

                if (userType == "Attorney")
                {
                    UpdateAttorneyPassword(email, newPassword);
                }
                else if (userType == "Prosecutor")
                {
                    UpdateProsecutorPassword(email, newPassword);
                }
                else
                {
                    MessageBox.Show("User not found in the database.");
                }
            }
            else
            {
                // Passwords don't match, display a warning message
                MessageBox.Show("Passwords do not match. Please try again.");
                // Additional actions for password mismatch
            }
        }

        // Method to update attorney password in the database
        private void UpdateAttorneyPassword(string email, string newPassword)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                if (dbConnection.OpenConnection())
                {
                    string updateQuery = $"UPDATE Attorneys SET attorney_password = '{newPassword}' WHERE attorney_email = '{email}'";
                    MySqlCommand cmd = new MySqlCommand(updateQuery, dbConnection.Connection);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password updated for Attorney!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update password for Attorney.");
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

        // Method to update prosecutor password in the database
        private void UpdateProsecutorPassword(string email, string newPassword)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                if (dbConnection.OpenConnection())
                {
                    string updateQuery = $"UPDATE Prosecutors SET prosecutor_password = '{newPassword}' WHERE prosecutor_email = '{email}'";
                    MySqlCommand cmd = new MySqlCommand(updateQuery, dbConnection.Connection);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password updated for Prosecutor!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update password for Prosecutor.");
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
    }
}
