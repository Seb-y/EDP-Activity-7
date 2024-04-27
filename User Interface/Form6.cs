using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DatabaseConnection;
using static User_Interface.Form1;

namespace User_Interface
{
    public partial class Form6 : Form
    {
        private DatabaseConnection dbConnection;
        public Form6()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            LoadCasesToListBox();
        }
        private void InitializeDatabaseConnection()
        {
            dbConnection = new DatabaseConnection();
        }

        private void LoadCasesToListBox()
        {
            try
            {
                if (dbConnection.OpenConnection())
                {
                    // Retrieve case information from the database
                    var cases = dbConnection.GetCases();

                    // Clear the ListBox before adding new items
                    listBoxCases.Items.Clear();

                    // Display case information in the ListBox
                    foreach (var caseInfo in cases)
                    {
                        listBoxCases.Items.Add($"{caseInfo.CaseNumber}: {caseInfo.CaseTitle}");
                    }
                }
                else
                {
                    MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }


        private void panel8_Paint(object sender, EventArgs e)
        {
            //try
            //{
            //    // Get values from your form controls
            //    string caseNumber = txtCaseNo.Text;
            //    string caseTitle = txtCaseTitle.Text;
            //    string caseType = txtCaseType.Text; // Default value for caseType
            //    string caseDescription = txtCaseDescription.Text;
            //    string caseStatus = txtCaseStatus.Text;

            //    // Parse the DateTime from the filing_box TextBox
            //    if (DateTime.TryParse(txtCaseFilingDate.Text, out DateTime caseFilingDate))
            //    {
            //        string courtLocation = txtCaseCourtLocation.Text;

            //        // Using statement ensures proper disposal of resources, including closing the connection
            //        using (DatabaseConnection dbConnection = new DatabaseConnection())
            //        {
            //            // Insert into the database
            //            if (dbConnection.OpenConnection())
            //            {
            //                try
            //                {
            //                    // Use the InsertCase method from the DatabaseConnection class
            //                    dbConnection.InsertCase(caseNumber, caseTitle, caseType, caseDescription, caseStatus, caseFilingDate, courtLocation);

            //                    MessageBox.Show("Case inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                }
            //                catch (Exception ex)
            //                {
            //                    MessageBox.Show("Error inserting case: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Invalid date format in Filing Date. Please enter the date in the format: MM/DD/YYYY", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Handle any unexpected exceptions at a higher level
            //    MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ////string caseNumber = txtCaseNo.Text;
            ////string caseTitle = txtCaseTitle.Text;
            ////int caseType = 0; // Default value for caseType
            ////string caseDescription = txtCaseDescription.Text;
            ////string caseStatus = txtCaseStatus.Text.Trim(); // Trim leading and trailing whitespace
            ////DateTime caseFilingDate;
            ////string caseCourtLocation = txtCaseCourtLocation.Text;

            try
            {
                // Get values from your form controls
                string caseNumber = txtCaseNo.Text;
                string caseTitle = txtCaseTitle.Text;
                string caseType = txtCaseType.Text; // Default value for caseType
                string caseDescription = txtCaseDescription.Text;
                string caseStatus = txtCaseStatus.Text;
                //string caseNumber = txtCaseNo.Text;
                //string caseTitle = txtCaseTitle.Text;
                //string caseType = txtCaseType.Text; // Default value for caseType
                //string caseDescription = txtCaseDescription.Text;
                //string caseStatus = txtCaseStatus.Text;

                // Parse the DateTime from the filing_box TextBox
                if (DateTime.TryParse(txtCaseFilingDate.Text, out DateTime caseFilingDate))
                {
                    string courtLocation = txtCaseCourtLocation.Text;

                    // Using statement ensures proper disposal of resources, including closing the connection
                    using (DatabaseConnection dbConnection = new DatabaseConnection())
                    {
                        // Insert into the database
                        if (dbConnection.OpenConnection())
                        {
                            try
                            {
                                // Use the InsertCase method from the DatabaseConnection class
                                dbConnection.InsertCase(caseNumber, caseTitle, caseType, caseDescription, caseStatus, caseFilingDate, courtLocation);

                                MessageBox.Show("Case inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error inserting case: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid date format in Filing Date. Please enter the date in the format: YYYY-MM-DD", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected exceptions at a higher level
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // Navigate to Form6
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide(); // Hide the current form
        }

        private void label8_Click(object sender, EventArgs e)
        {
            //    try
            //    {
            //        // Get values from your form controls
            //        string caseNumberToUpdate = txtCaseNo.Text;
            //        string caseTitleUpdate = txtCaseTitle.Text;
            //        string caseTypeUpdate = txtCaseType.Text; // Default value for caseType
            //        string caseDescriptionUpdate = txtCaseDescription.Text;
            //        string caseStatusUpdate = txtCaseStatus.Text;
            //        //string caseNumberToUpdate = caseno_box.Text; // Assuming you get the case number from a textbox
            //        //string updatedCaseTitle = case_title_box.Text; // Assuming you get the updated title from a textbox
            //        //string updatedCaseType = case_type_box.Text; // Assuming you get the updated type from a textbox
            //        //string updatedCaseDescription = case_descr_box.Text; // Assuming you get the updated description from a textbox
            //        //string updatedCaseStatus = case_status_box.Text; // Assuming you get the updated status from a textbox

            //        // Parse the DateTime from the updated_filing_box TextBox
            //        if (DateTime.TryParse(txtCaseFilingDate.Text, out DateTime caseFilingDateUpdate))
            //        {
            //            string CourtLocationUpdate = txtCaseCourtLocation.Text; // Assuming you get the updated court location from a textbox

            //            // Using statement ensures proper disposal of resources, including closing the connection
            //            using (DatabaseConnection dbConnection = new DatabaseConnection())
            //            {
            //                // Update the database
            //                if (dbConnection.OpenConnection())
            //                {
            //                    // Use the UpdateCaseInfo method from the DatabaseConnection class
            //                    dbConnection.UpdateCaseInfo(caseNumberToUpdate, caseTitleUpdate, caseTypeUpdate, caseDescriptionUpdate, caseStatusUpdate, caseFilingDateUpdate, CourtLocationUpdate);

            //                    // Optionally, you can reload the cases in the ListBox after the update
            //                    //LoadCasesToListBox();
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                }
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Invalid date format in updated_filing_box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        // Handle any unexpected exceptions at a higher level
            //        MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            try
            {
                // Get values from your form controls
                //string caseNumber = txtCaseNo.Text;
                //string caseTitle = txtCaseTitle.Text;
                //string caseType = txtCaseType.Text; // Default value for caseType
                //string caseDescription = txtCaseDescription.Text;
                //string caseStatus = txtCaseStatus.Text;
                string caseNumberToUpdate = txtCaseNo.Text;
                string caseTitleUpdate = txtCaseTitle.Text;
                string caseTypeUpdate = txtCaseType.Text; // Default value for caseType
                string caseDescriptionUpdate = txtCaseDescription.Text;
                string caseStatusUpdate = txtCaseStatus.Text;
                //string caseNumberToUpdate = caseno_box.Text; // Assuming you get the case number from a textbox
                //string updatedCaseTitle = case_title_box.Text; // Assuming you get the updated title from a textbox
                //string updatedCaseType = case_type_box.Text; // Assuming you get the updated type from a textbox
                //string updatedCaseDescription = case_descr_box.Text; // Assuming you get the updated description from a textbox
                //string updatedCaseStatus = case_status_box.Text; // Assuming you get the updated status from a textbox

                // Parse the DateTime from the updated_filing_box TextBox
                if (DateTime.TryParse(txtCaseFilingDate.Text, out DateTime updatedCaseFilingDate))
                {
                    string updatedCourtLocation = txtCaseCourtLocation.Text; // Assuming you get the updated court location from a textbox

                    // Using statement ensures proper disposal of resources, including closing the connection
                    using (dbConnection = new DatabaseConnection())
                    {
                        // Update the database
                        if (dbConnection.OpenConnection())
                        {
                            // Use the UpdateCaseInfo method from the DatabaseConnection class
                            dbConnection.UpdateCaseInfo(caseNumberToUpdate, caseTitleUpdate, caseTypeUpdate, caseDescriptionUpdate, caseStatusUpdate, updatedCaseFilingDate, updatedCourtLocation);

                            // Optionally, you can reload the cases in the ListBox after the update
                            LoadCasesToListBox();
                        }
                        else
                        {
                            MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid date format in updated_filing_box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected exceptions at a higher level
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void txtCaseNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox6_Click(object sender, EventArgs e)
        {
            string caseNumberToSearch = searchBox.Text;

            if (!string.IsNullOrEmpty(caseNumberToSearch))
            {
                using (DatabaseConnection dbConnection = new DatabaseConnection())
                {
                    CaseInfo foundCase = dbConnection.SearchCase(caseNumberToSearch);

                    if (foundCase != null)
                    {
                        // Display the found case information in your text boxes
                        txtCaseNo.Text = foundCase.CaseNumber;
                        txtCaseTitle.Text = foundCase.CaseTitle;
                        txtCaseType.Text = foundCase.CaseType;
                        txtCaseDescription.Text = foundCase.CaseDescription;
                        txtCaseStatus.Text = foundCase.CaseStatus;
                        txtCaseFilingDate.Text = foundCase.CaseFilingDate.ToString("yyyy-MM-dd");
                        txtCaseCourtLocation.Text = foundCase.CourtLocation;

                        MessageBox.Show("Case found!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Case not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a case number to search.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconPictureBox9_Click(object sender, EventArgs e)
        {
            // Close the form and end all processes
            Application.Exit();
        }

        private void iconPictureBox8_Click(object sender, EventArgs e)
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


