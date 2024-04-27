using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DatabaseConnection;

namespace User_Interface
{
    public partial class Form9 : Form
    {
        private DatabaseConnection dbConnection;
        public bool IsAttorney { get; set; }
        public Form9()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }
        private void InitializeDatabaseConnection()
        {
            dbConnection = new DatabaseConnection();
        }

        public void AddOrUpdateData(bool isAttorney)
        {
            try
            {
                string lastName = txtLastName.Text;
                string firstName = txtFirstName.Text;
                string middleName = txtMiddleName.Text;
                string specialization = txtSpecialization.Text;
                string phone = txtPhone.Text;
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                string status = txtAccountStatus.Text;

                if (isAttorney)
                {
                    dbConnection.InsertAttorney(lastName, firstName, middleName, specialization, phone, email, password, status);
                }
                else
                {
                    dbConnection.InsertProsecutor(lastName, firstName, middleName, specialization, phone, email, password, status);
                }

                MessageBox.Show((isAttorney ? "Attorney" : "Prosecutor") + " added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the necessary data from the text boxes
                string lastName = txtLastName.Text;
                string firstName = txtFirstName.Text;
                string middleName = txtMiddleName.Text;
                string specialization = txtSpecialization.Text;
                string phone = txtPhone.Text;
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                string status = txtAccountStatus.Text;

                // Determine whether it's an attorney or a prosecutor
                bool isAttorney = UserRoles.IsAttorney;

                // Call the AddOrUpdateData method based on the role
                if (isAttorney)
                {
                    dbConnection.InsertAttorney(lastName, firstName, middleName, specialization, phone, email, password, status);
                }
                else
                {
                    dbConnection.InsertProsecutor(lastName, firstName, middleName, specialization, phone, email, password, status);
                }

                MessageBox.Show((isAttorney ? "Attorney" : "Prosecutor") + " added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void label8_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Get the necessary data from the text boxes
        //        //int userId = int.Parse(boxID.Text); // Assuming there's a textbox for the user ID
        //        string lastName = txtLastName.Text;
        //        string firstName = txtFirstName.Text;
        //        string middleName = txtMiddleName.Text;
        //        string specialization = txtSpecialization.Text;
        //        string phone = txtPhone.Text;
        //        string email = txtEmail.Text;
        //        string password = txtPassword.Text;
        //        string status = txtAccountStatus.Text;

        //        // Determine whether it's an attorney or a prosecutor
        //        bool isAttorney = (true); // Replace this with the actual boolean value based on your logic

        //        // Call the appropriate method to update user information
        //        if (isAttorney)
        //        {
        //            dbConnection.UpdateAttorney(userId, lastName, firstName, middleName, specialization, phone, email, password, status, isAttorney);
        //        }
        //        else
        //        {
        //            dbConnection.UpdateProsecutor(userId, lastName, firstName, middleName, specialization, phone, email, password, status, isAttorney);
        //        }

        //        MessageBox.Show((isAttorney ? "Attorney" : "Prosecutor") + " updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error updating user information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void label1_Click(object sender, EventArgs e)
        {
            // Navigate to Form6
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide(); // Hide the current form
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Navigate to Form6
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide(); // Hide the current form
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Navigate to Form6
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide(); // Hide the current form
        }

        private void iconPictureBox7_Click(object sender, EventArgs e)
        {
            // Close the form and end all processes
            Application.Exit();
        }

        private void iconPictureBox6_Click(object sender, EventArgs e)
        {
            // Minimize the form
            this.WindowState = FormWindowState.Minimized;
        }

        private void backToSignIN_Click(object sender, EventArgs e)
        {
            // Close the connection to the database
            //dbConnection.CloseConnection(); // Assuming dbConnection is your DatabaseConnection object

            // Show Form1 and hide the current form
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
