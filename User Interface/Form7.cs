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
using System.Collections.Generic;
using System.IO;
using static DatabaseConnection;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace User_Interface
{

    public partial class Form7 : Form
    {
        private DatabaseConnection dbConnection;
        public Form7()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            LoadCasesToDataGridView();
        }
        private void InitializeDatabaseConnection()
        {
            dbConnection = new DatabaseConnection();
        }
        private void LoadCasesToDataGridView()
        {
            try
            {
                DataTable dataTable = new DataTable();

                using (DatabaseConnection conn = new DatabaseConnection())
                {
                    if (conn.OpenConnection())
                    {
                        // Execute your SQL query to retrieve case information
                        string query = @"SELECT courtcases.case_number, courtcases.case_title, courtcases.case_type, courtcases.case_status, courtcases.case_filing_date, 
                         caseassignments.attorney_id, caseassignments.prosecutor_id 
                         FROM courtcases 
                         INNER JOIN caseassignments ON courtcases.case_id = caseassignments.case_id";
                        MySqlCommand cmd = new MySqlCommand(query, conn.Connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                        // Fill the DataTable with the data
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dataTable;

                        // Assuming you want to manually define columns
                        dataGridView1.Columns.Clear();

                        dataGridView1.Columns.Add("case_number", "Case Number");
                        dataGridView1.Columns["case_number"].DataPropertyName = "case_number";
                        dataGridView1.Columns["case_number"].Width = 100;

                        dataGridView1.Columns.Add("case_title", "Case Title");
                        dataGridView1.Columns["case_title"].DataPropertyName = "case_title";
                        dataGridView1.Columns["case_title"].Width = 100;

                        dataGridView1.Columns.Add("case_type", "Case Type");
                        dataGridView1.Columns["case_type"].DataPropertyName = "case_type";
                        dataGridView1.Columns["case_type"].Width = 100; // Corrected width assignment here

                        dataGridView1.Columns.Add("case_status", "Case status");
                        dataGridView1.Columns["case_status"].DataPropertyName = "case_status";
                        dataGridView1.Columns["case_status"].Width = 100;

                        dataGridView1.Columns.Add("case_filing_date", "Filing Date");
                        dataGridView1.Columns["case_filing_date"].DataPropertyName = "case_filing_date";
                        dataGridView1.Columns["case_filing_date"].Width = 100;

                        dataGridView1.Columns.Add("attorney_id", "Assigned to Atty ID");
                        dataGridView1.Columns["attorney_id"].DataPropertyName = "attorney_id";
                        dataGridView1.Columns["attorney_id"].Width = 100;

                        dataGridView1.Columns.Add("prosecutor_id", "Assigned to ProSec ID");
                        dataGridView1.Columns["prosecutor_id"].DataPropertyName = "prosecutor_id";
                        dataGridView1.Columns["prosecutor_id"].Width = 100;

                        dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10); // Change "Arial" and 10 to your desired font and size

                        // Set the font size for the DataGridView headers
                        dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);
                    }
                    else
                    {
                        MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
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

        private void label1_Click(object sender, EventArgs e)
        {
            // Navigate to Form6
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide(); // Hide the current form
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Navigate to Form6
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide(); // Hide the current form
        }

        private void iconPictureBox6_Click(object sender, EventArgs e)
        {
            // Close the form and end all processes
            System.Windows.Forms.Application.Exit();
        }

        private void iconPictureBox5_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconPictureBox7_Click(object sender, EventArgs e)
        {
            searchBox_TextChanged(sender, e);
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = searchBox.Text.Trim();

            if (DateTime.TryParse(searchQuery, out _))
            {
                // If the input is a valid date, search by date
                SearchByDate(searchQuery);
            }
            else if (searchQuery.StartsWith("ATT"))
            {
                // If the input starts with "ATT", search by Attorney ID
                string attorneyID = searchQuery.Substring(3); // Remove "ATT" prefix
                SearchByAttorneyID(attorneyID);
            }
            else if (searchQuery.StartsWith("PROS"))
            {
                // If the input starts with "PROS", search by Prosecutor ID
                string prosecutorID = searchQuery.Substring(4); // Remove "PROS" prefix
                SearchByProsecutorID(prosecutorID);
            }
            else if (searchQuery.Equals("ACTIVE", StringComparison.OrdinalIgnoreCase) || searchQuery.Equals("CLOSED", StringComparison.OrdinalIgnoreCase))
            {
                // If the input matches "ACTIVE" or "CLOSED", search by Case Status
                SearchByCaseStatus(searchQuery.ToUpper()); // Convert to uppercase for case-insensitive comparison
            }
            else if (int.TryParse(searchQuery, out _))
            {
                // If the input is a valid integer, search by case number
                SearchByCaseNumber(searchQuery);
            }
            else
            {
                // If the input is not a valid date, integer, or attorney/prosecutor ID, search by name
                // Here, you should provide the correct case type based on your data or logic
                SearchByType(searchQuery); // Pass the search query as it might contain the case type
            }
        }

        private void SearchByAttorneyID(string searchQuery)
        {
            try
            {
                DataTable dataTable = new DataTable();

                using (DatabaseConnection conn = new DatabaseConnection())
                {
                    if (conn.OpenConnection())
                    {
                        // Execute your SQL query to retrieve case information by Attorney ID
                        string query = @"SELECT courtcases.case_number, courtcases.case_title, courtcases.case_type, courtcases.case_status, courtcases.case_filing_date, 
                                 caseassignments.attorney_id, caseassignments.prosecutor_id 
                                 FROM courtcases 
                                 INNER JOIN caseassignments ON courtcases.case_id = caseassignments.case_id
                                 WHERE attorney_id = @searchQuery";
                        MySqlCommand cmd = new MySqlCommand(query, conn.Connection);
                        cmd.Parameters.AddWithValue("@searchQuery", searchQuery);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                        // Fill the DataTable with the data
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchByProsecutorID(string searchQuery)
        {
            try
            {
                DataTable dataTable = new DataTable();

                using (DatabaseConnection conn = new DatabaseConnection())
                {
                    if (conn.OpenConnection())
                    {
                        // Execute your SQL query to retrieve case information by Prosecutor ID
                        string query = @"SELECT courtcases.case_number, courtcases.case_title, courtcases.case_type, courtcases.case_status, courtcases.case_filing_date, 
                                 caseassignments.attorney_id, caseassignments.prosecutor_id 
                                 FROM courtcases 
                                 INNER JOIN caseassignments ON courtcases.case_id = caseassignments.case_id
                                 WHERE prosecutor_ID = @searchQuery";
                        MySqlCommand cmd = new MySqlCommand(query, conn.Connection);
                        cmd.Parameters.AddWithValue("@searchQuery", searchQuery);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                        // Fill the DataTable with the data
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchByCaseStatus(string searchQuery)
        {
            try
            {
                DataTable dataTable = new DataTable();

                using (DatabaseConnection conn = new DatabaseConnection())
                {
                    if (conn.OpenConnection())
                    {
                        // Execute your SQL query to retrieve case information by Case Status
                        string query = @"SELECT courtcases.case_number, courtcases.case_title, courtcases.case_type, courtcases.case_status, courtcases.case_filing_date, 
                                 caseassignments.attorney_id, caseassignments.prosecutor_id 
                                 FROM courtcases 
                                 INNER JOIN caseassignments ON courtcases.case_id = caseassignments.case_id 
                                 WHERE case_status = @status";
                        MySqlCommand cmd = new MySqlCommand(query, conn.Connection);
                        cmd.Parameters.AddWithValue("@status", searchQuery);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                        // Fill the DataTable with the data
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchByCaseNumber(string searchQuery)
        {
            try
            {
                DataTable dataTable = new DataTable();

                using (DatabaseConnection conn = new DatabaseConnection())
                {
                    if (conn.OpenConnection())
                    {
                        // Execute your SQL query to retrieve case information by case number
                        string query = @"SELECT courtcases.case_number, courtcases.case_title, courtcases.case_type, courtcases.case_status, courtcases.case_filing_date, 
                             caseassignments.attorney_id, caseassignments.prosecutor_id 
                             FROM courtcases 
                             INNER JOIN caseassignments ON courtcases.case_id = caseassignments.case_id 
                             WHERE case_number = @searchQuery";
                        MySqlCommand cmd = new MySqlCommand(query, conn.Connection);
                        cmd.Parameters.AddWithValue("@searchQuery", searchQuery);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                        // Fill the DataTable with the data
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchByType(string searchQuery)
        {
            try
            {
                DataTable dataTable = new DataTable();

                using (DatabaseConnection conn = new DatabaseConnection())
                {
                    if (conn.OpenConnection())
                    {
                        // Execute your SQL query to retrieve case information by type
                        string query = @"SELECT courtcases.case_number, courtcases.case_title, courtcases.case_type, courtcases.case_status, courtcases.case_filing_date, 
                     caseassignments.attorney_id, caseassignments.prosecutor_id 
                     FROM courtcases 
                     INNER JOIN caseassignments ON courtcases.case_id = caseassignments.case_id 
                     WHERE case_type = @searchQuery";
                        MySqlCommand cmd = new MySqlCommand(query, conn.Connection);
                        cmd.Parameters.AddWithValue("@searchQuery", searchQuery);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                        // Fill the DataTable with the data
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchByDate(string searchQuery)
        {
            try
            {
                DataTable dataTable = new DataTable();

                using (DatabaseConnection conn = new DatabaseConnection())
                {
                    if (conn.OpenConnection())
                    {
                        // Parse the searchQuery string to a DateTime object
                        if (DateTime.TryParse(searchQuery, out DateTime date))
                        {
                            // Format the date string in a format compatible with MySQL (YYYY-MM-DD)
                            string formattedDate = date.ToString("yyyy-MM-dd");

                            // Execute your SQL query to retrieve case information by date
                            string query = @"SELECT courtcases.case_number, courtcases.case_title, courtcases.case_type, courtcases.case_status, courtcases.case_filing_date, 
                                     caseassignments.attorney_id, caseassignments.prosecutor_id 
                                     FROM courtcases 
                                     INNER JOIN caseassignments ON courtcases.case_id = caseassignments.case_id 
                                     WHERE DATE(case_filing_date) = @searchDate";
                            MySqlCommand cmd = new MySqlCommand(query, conn.Connection);
                            cmd.Parameters.AddWithValue("@searchDate", formattedDate);
                            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                            // Fill the DataTable with the data
                            adapter.Fill(dataTable);

                            // Bind the DataTable to the DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            // Display a message if the input is not a valid date
                            MessageBox.Show("Please enter a valid date in the format YYYY-MM-DD.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateAttorneyCases()
        {
            try
            {
                string templateFilePath = "Z:\\EDP\\attorneycases.xlsx"; // Update the template file path as needed
                string outputFilePath = "Z:\\EDP\\output_attorneycases.xlsx"; // Update the output file path as needed

                // Check if the template file exists
                if (!File.Exists(templateFilePath))
                {
                    MessageBox.Show("Template Excel file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Load the template file into memory
                byte[] templateData = File.ReadAllBytes(templateFilePath);

                // Create a MemoryStream from the template data
                using (MemoryStream templateStream = new MemoryStream(templateData))
                {
                    // Open the template file using ExcelPackage
                    using (ExcelPackage existingPackage = new ExcelPackage(templateStream))
                    {
                        ExcelWorksheet worksheet = existingPackage.Workbook.Worksheets.FirstOrDefault(ws => ws.Name == "Data");

                        // If the worksheet doesn't exist, create a new one
                        if (worksheet == null)
                        {
                            MessageBox.Show("Worksheet 'Data' not found in the template file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Find the last used row in the worksheet
                        int lastUsedRow = worksheet.Dimension?.End.Row ?? 1;

                        // Write the data starting from the next available row
                        int startRow = lastUsedRow + 1;
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            // Write case_number
                            worksheet.Cells[startRow + i, 2].Value = dataGridView1.Rows[i].Cells["case_number"].Value;
                            // Write case_title
                            worksheet.Cells[startRow + i, 3].Value = dataGridView1.Rows[i].Cells["case_title"].Value;
                            // Write case_type
                            worksheet.Cells[startRow + i, 4].Value = dataGridView1.Rows[i].Cells["case_type"].Value;
                            // Write case_status
                            worksheet.Cells[startRow + i, 5].Value = dataGridView1.Rows[i].Cells["case_status"].Value;
                            // Write case_filing_date
                            if (dataGridView1.Rows[i].Cells["case_filing_date"].Value != null)
                            {
                                DateTime filingDate = (DateTime)dataGridView1.Rows[i].Cells["case_filing_date"].Value;
                                worksheet.Cells[startRow + i, 6].Value = filingDate.ToString("yyyy-MM-dd");
                            }
                        }

                        // Update last used row after writing data
                        lastUsedRow = startRow + dataGridView1.Rows.Count - 1;

                        // Write the first attorney_id from the DataGridView at column G, row 8
                        if (dataGridView1.Rows.Count > 0)
                        {
                            worksheet.Cells[8, 6].Value = dataGridView1.Rows[0].Cells["attorney_id"].Value;
                        }

                        // Write total number of cases two rows below the last row from the DataGridView
                        worksheet.Cells[lastUsedRow + 2, 2].Value = "Total Cases: ";
                        worksheet.Cells[lastUsedRow + 2, 3].Formula = string.Format("COUNTA(B{0}:B{1})", startRow, lastUsedRow);

                        // Write the name of the logged-in user one row below the total cases
                        worksheet.Cells[lastUsedRow + 2, 5].Value = "Prepared by:";
                        // Assuming you have a variable 'loggedInUser' containing the name of the logged-in user
                        //string loggedInUser = "John Doe"; // Replace this with the actual name of the logged-in user
                        worksheet.Cells[lastUsedRow + 2, 6].Value = Form1.LoggedInUser;

                        // Add a new worksheet for the graph
                        ExcelWorksheet graphWorksheet = existingPackage.Workbook.Worksheets.Add("Graph");

                        // Count the number of active and inactive cases
                        int activeCases = 0;
                        int inactiveCases = 0;

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells["case_status"].Value?.ToString() == "Active")
                            {
                                activeCases++;
                            }
                            else if (row.Cells["case_status"].Value?.ToString() == "Inactive")
                            {
                                inactiveCases++;
                            }
                        }

                        // Add the counts to the graph worksheet
                        graphWorksheet.Cells["A1"].Value = "Case Status";
                        graphWorksheet.Cells["B1"].Value = "Number of Cases";
                        graphWorksheet.Cells["A2"].Value = "Active";
                        graphWorksheet.Cells["B2"].Value = activeCases;
                        graphWorksheet.Cells["A3"].Value = "Inactive";
                        graphWorksheet.Cells["B3"].Value = inactiveCases;

                        // Create a range for the data to be plotted in the graph
                        ExcelRange dataRange = graphWorksheet.Cells["B2:B3"]; // Adjusted to include only the counts of Active and Inactive

                        // Create a chart in the graph worksheet
                        var chart = graphWorksheet.Drawings.AddChart("CaseChart", OfficeOpenXml.Drawing.Chart.eChartType.ColumnClustered);

                        // Set chart title
                        chart.Title.Text = "Case Status";

                        // Set chart data
                        chart.Series.Add(dataRange, graphWorksheet.Cells["A2:A3"]); // Swapped the arguments to match the correct format

                        // Set category axis (X-axis) labels
                        chart.XAxis.Title.Text = "Case Status";

                        // Set value axis (Y-axis) labels
                        chart.YAxis.Title.Text = "Number of Cases";

                        // Set the position and size of the chart
                        chart.SetPosition(0, 0, 0, 0);
                        chart.SetSize(800, 600);

                        // Save changes to the output Excel file
                        using (FileStream outputFileStream = new FileStream(outputFilePath, FileMode.Create))
                        {
                            existingPackage.SaveAs(outputFileStream);
                        }
                    }
                }

                MessageBox.Show("Data appended to Excel file successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsFileLocked(string filePath)
        {
            try
            {
                using (File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return false;
                }
            }
            catch (IOException)
            {
                return true;
            }
        }
        private void GenerateCaseReport()
        {
            try
            {
                string templateFilePath = "Z:\\EDP\\casereport.xlsx"; // Update the template file path as needed
                string outputFilePath = "Z:\\EDP\\output_casereport.xlsx"; // Update the output file path as needed

                // Check if the template file exists
                if (!File.Exists(templateFilePath))
                {
                    MessageBox.Show("Template Excel file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Load the template file into memory
                byte[] templateData = File.ReadAllBytes(templateFilePath);

                // Create a MemoryStream from the template data
                using (MemoryStream templateStream = new MemoryStream(templateData))
                {
                    // Open the template file using ExcelPackage
                    using (ExcelPackage existingPackage = new ExcelPackage(templateStream))
                    {
                        ExcelWorksheet worksheet = existingPackage.Workbook.Worksheets.FirstOrDefault(ws => ws.Name == "Data");

                        // If the worksheet doesn't exist, create a new one
                        if (worksheet == null)
                        {
                            MessageBox.Show("Worksheet 'Data' not found in the template file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Create an instance of DatabaseConnection
                        using (var dbConnection = new DatabaseConnection())
                        {
                            // Create SQL query based on searchBoxNum value
                            string searchValue = searchBoxNum.Text; // Assuming searchBoxNum is a TextBox control

                            // Retrieve case information from the database
                            DatabaseConnection.CaseInfo caseInfo = dbConnection.SearchCase(searchValue);

                            // If caseInfo is null, the case with the specified case number was not found
                            if (caseInfo == null)
                            {
                                MessageBox.Show("Case not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Write case information to Excel worksheet
                            worksheet.Cells["B10"].Value = caseInfo.CaseNumber;
                            worksheet.Cells["B12"].Value = caseInfo.CaseTitle;
                            worksheet.Cells["D10"].Value = caseInfo.CaseDescription;
                            worksheet.Cells["B14"].Value = caseInfo.CaseType;
                            worksheet.Cells["B16"].Value = caseInfo.CaseStatus;
                            worksheet.Cells["D14"].Value = caseInfo.CaseFilingDate;
                            worksheet.Cells["D14"].Style.Numberformat.Format = "yyyy-MM-dd"; // Format the case filing date cell
                            worksheet.Cells["E23"].Value = Form1.LoggedInUser;

                            // Retrieve assignment information from the database
                            List<CaseAssignmentInfo> assignmentInfoList = dbConnection.GetCaseAssignments(searchValue);

                            // If assignmentInfoList is null or empty, no assignments were found for the case number
                            if (assignmentInfoList == null || assignmentInfoList.Count == 0)
                            {
                                MessageBox.Show("No assignments found for the case.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Find the last used row in the worksheet
                            //int lastUsedRow = worksheet.Dimension.End.Row;

                            // Write assignment information to Excel worksheet
                            //int rowIndex = lastUsedRow + 2; // Starting row index for writing assignment data
                            foreach (var assignmentInfo in assignmentInfoList)
                            {
                                worksheet.Cells["F14"].Value = assignmentInfo.AssignmentId;
                                worksheet.Cells["D16"].Value = assignmentInfo.AssignmentDate;
                                worksheet.Cells["D16"].Style.Numberformat.Format = "yyyy-MM-dd";

                                // Retrieve attorney information
                                AttorneyInfo attorneyInfo = dbConnection.SearchAttorney(int.Parse(assignmentInfo.AttorneyId));

                                // Write attorney information to Excel worksheet
                                if (attorneyInfo != null)
                                {
                                    worksheet.Cells["C18"].Value = attorneyInfo.LastName;
                                    worksheet.Cells["C19"].Value = attorneyInfo.FirstName;
                                    worksheet.Cells["C20"].Value = attorneyInfo.Specialization;
                                }

                                // Retrieve prosecutor information
                                ProsecutorInfo prosecutorInfo = dbConnection.SearchProsecutor(int.Parse(assignmentInfo.ProsecutorId));

                                // Write prosecutor information to Excel worksheet
                                if (prosecutorInfo != null)
                                {
                                    worksheet.Cells["F18"].Value = prosecutorInfo.LastName;
                                    worksheet.Cells["F19"].Value = prosecutorInfo.FirstName;
                                    worksheet.Cells["F20"].Value = prosecutorInfo.Prosecutoroffice;
                                }

                                // Increment row index for the next assignment data
                                //rowIndex += 10;
                            }

                            // Save changes to the output Excel file
                            FileInfo outputFile = new FileInfo(outputFilePath);
                            existingPackage.SaveAs(outputFile);
                        }
                    }
                }

                MessageBox.Show("Data appended to Excel file successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateFilingDateReport()
        {
            try
            {
                string templateFilePath = "Z:\\EDP\\filingdate.xlsx"; // Update the template file path as needed
                string outputFilePath = "Z:\\EDP\\output_filingdate.xlsx"; // Update the output file path as needed

                // Check if the template file exists
                if (!File.Exists(templateFilePath))
                {
                    MessageBox.Show("Template Excel file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Load the template file into memory
                byte[] templateData = File.ReadAllBytes(templateFilePath);

                // Create a MemoryStream from the template data
                using (MemoryStream templateStream = new MemoryStream(templateData))
                {
                    // Open the template file using ExcelPackage
                    using (ExcelPackage existingPackage = new ExcelPackage(templateStream))
                    {
                        ExcelWorksheet worksheet = existingPackage.Workbook.Worksheets.FirstOrDefault(ws => ws.Name == "Data");

                        // If the worksheet doesn't exist, create a new one
                        if (worksheet == null)
                        {
                            MessageBox.Show("Worksheet 'Data' not found in the template file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Define the starting row for writing data from the DataGridView
                        int startRow = 10; // Start from row 10 (B10)

                        // Create a dictionary to hold counts of cases per filing date
                        Dictionary<string, int> filingDateCounts = new Dictionary<string, int>();

                        // Write the data starting from the next available row (B10)
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            // Write case_number
                            worksheet.Cells[startRow + i, 2].Value = dataGridView1.Rows[i].Cells["case_number"].Value;
                            // Write case_title
                            worksheet.Cells[startRow + i, 3].Value = dataGridView1.Rows[i].Cells["case_title"].Value;
                            // Write case_status
                            worksheet.Cells[startRow + i, 4].Value = dataGridView1.Rows[i].Cells["case_status"].Value;
                            // Write case_filing_date
                            if (dataGridView1.Rows[i].Cells["case_filing_date"].Value != null)
                            {
                                DateTime filingDate = (DateTime)dataGridView1.Rows[i].Cells["case_filing_date"].Value;
                                worksheet.Cells[startRow + i, 5].Value = filingDate.ToString("yyyy-MM-dd");

                                // Count cases for each filing date
                                string filingDateString = filingDate.ToString("yyyy-MM-dd");
                                if (!filingDateCounts.ContainsKey(filingDateString))
                                {
                                    filingDateCounts[filingDateString] = 1;
                                }
                                else
                                {
                                    filingDateCounts[filingDateString]++;
                                }
                            }
                        }

                        // Find the last used row in the worksheet after writing data
                        int lastUsedRow = startRow + dataGridView1.Rows.Count - 1;

                        // Write total number of cases for each filing date
                        foreach (var kvp in filingDateCounts)
                        {
                            string filingDate = kvp.Key;
                            int totalCases = kvp.Value;
                            int row = Array.FindIndex(worksheet.Cells[startRow, 5, lastUsedRow, 5].ToArray(), c => c.Text == filingDate) + startRow + 1;
                            worksheet.Cells[row, 6].Value = $"Total cases on '{filingDate}' = {totalCases}";
                        }

                        // Add a new worksheet for the pie chart
                        ExcelWorksheet chartWorksheet = existingPackage.Workbook.Worksheets.Add("PieChart");

                        // Write data for pie chart
                        int rowCounter = 1;
                        foreach (var kvp in filingDateCounts)
                        {
                            chartWorksheet.Cells[rowCounter, 1].Value = kvp.Key;
                            chartWorksheet.Cells[rowCounter, 2].Value = kvp.Value;
                            rowCounter++;
                        }

                        // Create a range for the data to be plotted in the pie chart
                        ExcelRange dataRange = chartWorksheet.Cells[1, 2, rowCounter - 1, 2];

                        // Add the pie chart to the worksheet (2D)
                        var pieChart = chartWorksheet.Drawings.AddChart("PieChart", OfficeOpenXml.Drawing.Chart.eChartType.Pie);
                        pieChart.SetPosition(0, 0, 0, 0);
                        pieChart.SetSize(600, 400);
                        pieChart.Series.Add(dataRange, chartWorksheet.Cells["A1:A" + (rowCounter - 1)]);
                        pieChart.Title.Text = "Cases by Filing Date";

                        // Write the name of the logged-in user
                        worksheet.Cells[lastUsedRow + 2, 4].Value = "Prepared by:";
                        worksheet.Cells[lastUsedRow + 2, 5].Value = Form1.LoggedInUser;

                        // Save changes to the output Excel file
                        using (FileStream outputFileStream = new FileStream(outputFilePath, FileMode.Create))
                        {
                            existingPackage.SaveAs(outputFileStream);
                        }
                    }
                }

                MessageBox.Show("Data appended to Excel file successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void exportAtty_Click(object sender, EventArgs e)
        {
            GenerateAttorneyCases();
        }

        private void caseReport_Click(object sender, EventArgs e)
        {
            //ExportAllCasesToExcel();
            GenerateCaseReport();
        }

        private void generateFilingDateButton_Click(object sender, EventArgs e)
        {
            GenerateFilingDateReport();
        }
    }
}
