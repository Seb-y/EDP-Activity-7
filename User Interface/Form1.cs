using static User_Interface.Form1;
using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.Common;

namespace User_Interface
{
    public partial class Form1 : Form
    {
        //private string username;
        //private string password;
        //private DatabaseConnection dbConnection = new DatabaseConnection();
        public static string LoggedInUser { get; private set; }
        public Form1()
        {
            InitializeComponent();
        }
        //private void loginButton_Click(object sender, EventArgs e)
        //{
        //    DatabaseConnection dbConnection = new DatabaseConnection();

        //    try
        //    {
        //        if (dbConnection.OpenConnection())
        //        {
        //            // Query for retrieving data from the Attorneys table
        //            string attorneyQuery = $"SELECT * FROM Attorneys WHERE attorney_email = '{txtUser.Text}' AND attorney_password = '{txtPass.Text}'";
        //            Console.WriteLine($"Attorney Query: {attorneyQuery}"); // Debug message
        //            MySqlCommand attorneyCmd = new MySqlCommand(attorneyQuery, dbConnection.Connection);
        //            MySqlDataReader attorneyDataReader = attorneyCmd.ExecuteReader();

        //            // Check if the login is successful for Attorneys
        //            if (attorneyDataReader.Read())
        //            {
        //                // Check if the account is active
        //                string attorneyStatus = attorneyDataReader["attorney_status"].ToString();
        //                if (attorneyStatus == "Active")
        //                {
        //                    MessageBox.Show("Login successful as Attorney!");
        //                    // Additional actions for successful Attorney login

        //                    // Retrieve the attorney's last name from the database
        //                    string lastName = attorneyDataReader["attorney_lastname"].ToString();

        //                    // Set the LoggedInUser property to the attorney's last name
        //                    LoggedInUser = lastName;

        //                    attorneyDataReader.Close(); // Close the DataReader after use

        //                    // Navigate to Form5 after successful login
        //                    Form5 form5 = new Form5();
        //                    form5.Show();
        //                    this.Hide(); // Hide the current form
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Your account is not active. Please contact the administrator.");
        //                }
        //            }
        //            else
        //            {
        //                // If not successful for Attorneys, try Prosecutors
        //                attorneyDataReader.Close(); // Close the DataReader before reusing the connection
        //                string prosecutorQuery = $"SELECT * FROM Prosecutors WHERE prosecutor_email = '{txtUser.Text}' AND prosecutor_password = '{txtPass.Text}'";
        //                Console.WriteLine($"Prosecutor Query: {prosecutorQuery}"); // Debug message
        //                MySqlCommand prosecutorCmd = new MySqlCommand(prosecutorQuery, dbConnection.Connection);
        //                MySqlDataReader prosecutorDataReader = prosecutorCmd.ExecuteReader();

        //                // Check if the login is successful for Prosecutors
        //                if (prosecutorDataReader.Read())
        //                {
        //                    // Check if the account is active
        //                    string prosecutorStatus = prosecutorDataReader["prosecutor_status"].ToString();
        //                    if (prosecutorStatus == "Active")
        //                    {
        //                        MessageBox.Show("Login successful as Prosecutor!");
        //                        // Additional actions for successful Prosecutor login

        //                        // Navigate to Form5 after successful login
        //                        Form5 form5 = new Form5();
        //                        form5.Show();
        //                        this.Hide(); // Hide the current form
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Your account is not active. Please contact the administrator.");
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Invalid username or password");
        //                }

        //                prosecutorDataReader.Close(); // Close the DataReader after use
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Failed to connect to the database");
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //    }
        //    finally
        //    {
        //        dbConnection.CloseConnection();
        //    }
        //}

        private void loginButton_Click(object sender, EventArgs e)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();

            try
            {
                if (dbConnection.OpenConnection())
                {
                    // Query for retrieving data from the Attorneys table
                    string attorneyQuery = $"SELECT * FROM Attorneys WHERE attorney_email = '{txtUser.Text}' AND attorney_password = '{txtPass.Text}'";
                    Console.WriteLine($"Attorney Query: {attorneyQuery}"); // Debug message
                    MySqlCommand attorneyCmd = new MySqlCommand(attorneyQuery, dbConnection.Connection);
                    MySqlDataReader attorneyDataReader = attorneyCmd.ExecuteReader();

                    // Check if the login is successful for Attorneys
                    if (attorneyDataReader.Read())
                    {
                        // Check if the account is active
                        string attorneyStatus = attorneyDataReader["attorney_status"].ToString();
                        if (attorneyStatus == "Active")
                        {
                            MessageBox.Show("Login successful as Attorney!");
                            // Additional actions for successful Attorney login

                            // Retrieve the attorney's first name, middle name, and last name from the database
                            string firstName = attorneyDataReader["attorney_firstname"].ToString();
                            string middleName = attorneyDataReader["attorney_middlename"].ToString();
                            string lastName = attorneyDataReader["attorney_lastname"].ToString();

                            // Combine first name, middle name (if available), and last name to form the full name
                            string fullName = $"{firstName} {(string.IsNullOrWhiteSpace(middleName) ? "" : middleName + " ")}{lastName}";

                            // Set the LoggedInUser property to the full name
                            LoggedInUser = fullName;

                            attorneyDataReader.Close(); // Close the DataReader after use

                            // Navigate to Form5 after successful login
                            Form5 form5 = new Form5();
                            form5.Show();
                            this.Hide(); // Hide the current form
                        }
                        else
                        {
                            MessageBox.Show("Your account is not active. Please contact the administrator.");
                        }
                    }
                    else
                    {
                        // If not successful for Attorneys, try Prosecutors
                        attorneyDataReader.Close(); // Close the DataReader before reusing the connection
                        string prosecutorQuery = $"SELECT * FROM Prosecutors WHERE prosecutor_email = '{txtUser.Text}' AND prosecutor_password = '{txtPass.Text}'";
                        Console.WriteLine($"Prosecutor Query: {prosecutorQuery}"); // Debug message
                        MySqlCommand prosecutorCmd = new MySqlCommand(prosecutorQuery, dbConnection.Connection);
                        MySqlDataReader prosecutorDataReader = prosecutorCmd.ExecuteReader();

                        // Check if the login is successful for Prosecutors
                        if (prosecutorDataReader.Read())
                        {
                            // Check if the account is active
                            string prosecutorStatus = prosecutorDataReader["prosecutor_status"].ToString();
                            if (prosecutorStatus == "Active")
                            {
                                MessageBox.Show("Login successful as Prosecutor!");
                                // Additional actions for successful Prosecutor login

                                // Navigate to Form5 after successful login
                                Form5 form5 = new Form5();
                                form5.Show();
                                this.Hide(); // Hide the current form
                            }
                            else
                            {
                                MessageBox.Show("Your account is not active. Please contact the administrator.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password");
                        }

                        prosecutorDataReader.Close(); // Close the DataReader after use
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

        private void checkshowPass_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the checkbox is checked
            if (checkshowPass.Checked)
            {
                // Show the password by setting UseSystemPasswordChar to true
                txtPass.UseSystemPasswordChar = true;
            }
            else
            {
                // Hide the password by setting UseSystemPasswordChar to false
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void frgtPass_Click(object sender, EventArgs e)
        {
            // Hide the current form
            this.Hide();

            // Create an instance of Form2
            Form2 form2 = new Form2();

            // Show Form2
            form2.ShowDialog();

            // Close Form2 if needed
            // form2.Close();

            // Close Form1
            //this.Close();
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
