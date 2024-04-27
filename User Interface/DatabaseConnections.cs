using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Linq;

public class DatabaseConnection : IDisposable
{
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    public DatabaseConnection()
    {
        Initialize();
    }

    private void Initialize()
    {
        server = "localhost";
        database = "court";
        uid = "root";
        password = "@Sebyiah0219";
        string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

        connection = new MySqlConnection(connectionString);
    }

    public bool OpenConnection()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            // Log the exception instead of showing a MessageBox
            Console.WriteLine("Error: " + ex.Message);
            return false;
        }
    }

    public bool CloseConnection()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            // Log the exception instead of showing a MessageBox
            Console.WriteLine("Error: " + ex.Message);
            return false;
        }
    }
    public void InsertCase(string caseNumber, string caseTitle, string caseType, string caseDescription, string caseStatus, DateTime caseFilingDate, string courtLocation)
    {
        try
        {
            if (!IsConnectionOpen())
            {
                OpenConnection(); // Open the connection if it's not already open
            }

            string query = "INSERT INTO courtcases (case_number, case_title, case_type, case_description, case_status, case_filing_date, case_court_location) " +
                           "VALUES (@case_number, @case_title, @case_type, @case_description, @case_status, @case_filing_date, @case_court_location)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@case_number", caseNumber);
                command.Parameters.AddWithValue("@case_title", caseTitle);
                command.Parameters.AddWithValue("@case_type", caseType);
                command.Parameters.AddWithValue("@case_description", caseDescription);
                command.Parameters.AddWithValue("@case_status", caseStatus);
                command.Parameters.AddWithValue("@case_filing_date", caseFilingDate);
                command.Parameters.AddWithValue("@case_court_location", courtLocation);

                command.ExecuteNonQuery();
            }

            MessageBox.Show("Case inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error inserting case: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            CloseConnection();
        }
    }
    public void UpdateCaseInfo(string caseNumber, string updatedCaseTitle, string updatedCaseType, string updatedCaseDescription, string updatedCaseStatus, DateTime updatedCaseFilingDate, string updatedCourtLocation)
    {
        try
        {
            if (IsConnectionOpen())
            {
                string query = "UPDATE courtcases " +
                               "SET case_title = @updatedCaseTitle, case_type = @updatedCaseType, " +
                               "case_description = @updatedCaseDescription, case_status = @updatedCaseStatus, " +
                               "case_filing_date = @updatedCaseFilingDate, case_court_location = @updatedCourtLocation " +
                               "WHERE case_number = @caseNumber";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@caseNumber", caseNumber);
                    command.Parameters.AddWithValue("@updatedCaseTitle", updatedCaseTitle);
                    command.Parameters.AddWithValue("@updatedCaseType", updatedCaseType);
                    command.Parameters.AddWithValue("@updatedCaseDescription", updatedCaseDescription);
                    command.Parameters.AddWithValue("@updatedCaseStatus", updatedCaseStatus);
                    command.Parameters.AddWithValue("@updatedCaseFilingDate", updatedCaseFilingDate);
                    command.Parameters.AddWithValue("@updatedCourtLocation", updatedCourtLocation);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Case information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Case not found for update. No rows affected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error updating case information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            CloseConnection();
        }
    }

    public static class UserRoles
    {
        public static bool IsAttorney { get; set; }
    }

    public void InsertAttorney(string lastName, string firstName, string middleName, string specialization, string phone, string email, string password, string status)
    {
        try
        {
            if (!IsConnectionOpen())
            {
                OpenConnection(); // Open the connection if it's not already open
            }

            string query = "INSERT INTO Attorneys (attorney_lastname, attorney_firstname, attorney_middlename, attorney_specialization, attorney_phone, attorney_email, attorney_password, attorney_status) " +
                           "VALUES (@lastName, @firstName, @middleName, @specialization, @phone, @email, @password, @status)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@middleName", middleName);
                command.Parameters.AddWithValue("@specialization", specialization);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@status", status);

                command.ExecuteNonQuery();
            }

            MessageBox.Show("Attorney added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error adding attorney: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            CloseConnection();
        }
    }

    public void InsertProsecutor(string lastName, string firstName, string middleName, string specialization, string phone, string email, string password, string status)
    {
        try
        {
            if (!IsConnectionOpen())
            {
                OpenConnection(); // Open the connection if it's not already open
            }

            string query = "INSERT INTO Prosecutors (prosecutor_name, prosecutor_firstname, prosecutor_middlename, prosecutor_office, prosecutor_phone, prosecutor_email, prosecutor_password, prosecutor_status) " +
                           "VALUES (@lastName, @firstName, @middleName, @specialization, @phone, @email, @password, @status)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@middleName", middleName);
                command.Parameters.AddWithValue("@specialization", specialization);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@status", status);

                command.ExecuteNonQuery();
            }

            MessageBox.Show("Prosecutor added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error adding prosecutor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            CloseConnection();
        }
    }

    public void UpdateAttorney(int attorneyId, string lastName, string firstName, string middleName, string specialization, string phone, string email, string password, string status, bool isAttorney)
    {
        try
        {
            if (!IsConnectionOpen())
            {
                OpenConnection(); // Open the connection if it's not already open
            }

            string query = "UPDATE Attorneys SET attorney_lastname = @lastName, attorney_firstname = @firstName, attorney_middlename = @middleName, " +
                           "attorney_specialization = @specialization, attorney_phone = @phone, attorney_email = @email, attorney_password = @password, " +
                           "attorney_status = @status WHERE attorney_id = @attorneyId ";

            if (!isAttorney)
            {
                query += "AND role = 'Attorney' ";
            }

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@attorneyId", attorneyId);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@middleName", middleName);
                command.Parameters.AddWithValue("@specialization", specialization);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@status", status);

                command.ExecuteNonQuery();
            }

            MessageBox.Show("Attorney updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error updating attorney: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            CloseConnection();
        }
    }

    public void UpdateProsecutor(int prosecutorId, string lastName, string firstName, string middleName, string specialization, string phone, string email, string password, string status, bool isAttorney)
    {
        try
        {
            if (!IsConnectionOpen())
            {
                OpenConnection(); // Open the connection if it's not already open
            }

            string query = "UPDATE Prosecutors SET prosecutor_name = @lastName, prosecutor_firstname = @firstName, prosecutor_middlename = @middleName, " +
                           "prosecutor_office = @specialization, prosecutor_phone = @phone, prosecutor_email = @email, prosecutor_password = @password, " +
                           "prosecutor_status = @status WHERE prosecutor_id = @prosecutorId ";

            if (!isAttorney)
            {
                query += "AND role = 'Prosecutor' ";
            }

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@prosecutorId", prosecutorId);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@middleName", middleName);
                command.Parameters.AddWithValue("@specialization", specialization);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@status", status);

                command.ExecuteNonQuery();
            }

            MessageBox.Show("Prosecutor updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error updating prosecutor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            CloseConnection();
        }
    }

    public AttorneyInfo SearchAttorney(int attorneyId, bool isAttorney)
    {
        AttorneyInfo attorneyInfo = null;

        try
        {
            if (OpenConnection())
            {
                string query = "SELECT attorney_lastname, attorney_firstname, attorney_specialization " +
                               "FROM Attorneys " +
                               "WHERE attorney_id = @attorneyId ";

                if (isAttorney)
                {
                    query += "AND role = 'Attorney'";
                }

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@attorneyId", attorneyId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            attorneyInfo = new AttorneyInfo(
                                reader["attorney_lastname"].ToString(),
                                reader["attorney_firstname"].ToString(),
                                reader["attorney_specialization"].ToString()
                            // Add other properties if needed
                            );
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error searching for attorney: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            CloseConnection();
        }

        return attorneyInfo;
    }

    public ProsecutorInfo SearchProsecutor(int prosecutorId, bool isAttorney)
    {
        ProsecutorInfo prosecutorInfo = null;

        try
        {
            if (OpenConnection())
            {
                string query = "SELECT prosecutor_name, prosecutor_firstname, prosecutor_office " +
                               "FROM Prosecutors " +
                               "WHERE prosecutor_id = @prosecutorId ";

                if (!isAttorney)
                {
                    query += "AND role = 'Prosecutor'";
                }

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@prosecutorId", prosecutorId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            prosecutorInfo = new ProsecutorInfo(
                                reader["prosecutor_lastname"].ToString(),
                                reader["prosecutor_firstname"].ToString(),
                                reader["prosecutor_office"].ToString()
                            // Add other properties if needed
                            );
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error searching for prosecutor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            CloseConnection();
        }

        return prosecutorInfo;
    }

    public class AttorneyInfo
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Specialization { get; set; }

        // Add other properties as needed

        public AttorneyInfo(string lastName, string firstName, string specialization)
        {
            LastName = lastName;
            FirstName = firstName;
            Specialization = specialization;
        }
    }

    // Define ProsecutorInfo class
    public class ProsecutorInfo
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Prosecutoroffice { get; set; }

        // Add other properties as needed

        public ProsecutorInfo(string lastName, string firstName, string prosecutor_office)
        {
            LastName = lastName;
            FirstName = firstName;
            Prosecutoroffice = prosecutor_office;
        }
    }

    public AttorneyInfo SearchAttorney(int attorneyId)
    {
        AttorneyInfo attorneyInfo = null;

        try
        {
            if (OpenConnection())
            {
                string query = "SELECT attorney_lastname, attorney_firstname, attorney_specialization " +
                               "FROM Attorneys " +
                               "WHERE attorney_id = @attorneyId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@attorneyId", attorneyId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            attorneyInfo = new AttorneyInfo(
                                reader["attorney_lastname"].ToString(),
                                reader["attorney_firstname"].ToString(),
                                reader["attorney_specialization"].ToString()
                            // Add other properties if needed
                            );
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error searching for attorney: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            CloseConnection();
        }

        return attorneyInfo;
    }

    public ProsecutorInfo SearchProsecutor(int prosecutorId)
    {
        ProsecutorInfo prosecutorInfo = null;

        try
        {
            if (OpenConnection())
            {
                string query = "SELECT prosecutor_name, prosecutor_firstname, prosecutor_office " +
                               "FROM Prosecutors " +
                               "WHERE prosecutor_id = @prosecutorId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@prosecutorId", prosecutorId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            prosecutorInfo = new ProsecutorInfo(
                                reader["prosecutor_name"].ToString(),
                                reader["prosecutor_firstname"].ToString(),
                                reader["prosecutor_office"].ToString()
                            // Add other properties if needed
                            );
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error searching for prosecutor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            CloseConnection();
        }

        return prosecutorInfo;
    }


    public CaseInfo SearchCase(string caseNumber)
    {
        CaseInfo caseInfo = null;

        try
        {
            if (OpenConnection())
            {
                string query = "SELECT * FROM courtcases WHERE case_number = @caseNumber";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@caseNumber", caseNumber);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            caseInfo = new CaseInfo
                            {
                                CaseNumber = reader["case_number"].ToString(),
                                CaseTitle = reader["case_title"].ToString(),
                                CaseType = reader["case_type"].ToString(),
                                CaseDescription = reader["case_description"].ToString(),
                                CaseStatus = reader["case_status"].ToString(),
                                CaseFilingDate = Convert.ToDateTime(reader["case_filing_date"]),
                                CourtLocation = reader["case_court_location"].ToString()
                                // Add other properties accordingly
                            };
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error searching for case: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            CloseConnection();
        }

        return caseInfo;
    }

    public List<CaseAssignmentInfo> GetCaseAssignments(string caseNumber)
    {
        List<CaseAssignmentInfo> caseAssignments = new List<CaseAssignmentInfo>();

        try
        {
            string caseId = GetCaseIdFromDatabase(caseNumber);

            if (string.IsNullOrEmpty(caseId))
            {
                return new List<CaseAssignmentInfo>(); // Return an empty list if case ID is not found
            }

            if (OpenConnection())
            {
                string query = "SELECT * FROM CaseAssignments WHERE case_id = @caseId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@caseId", caseId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CaseAssignmentInfo assignmentInfo = new CaseAssignmentInfo(
                                reader["assignment_id"].ToString(),
                                Convert.ToDateTime(reader["assignment_date"]),
                                reader["attorney_id"].ToString(), // Use the correct column name here
                                reader["prosecutor_id"].ToString()// Use the correct column name here
                            );

                            caseAssignments.Add(assignmentInfo);
                        }
                    }
                }
            }
            else
            {
                return new List<CaseAssignmentInfo>(); // Return an empty list if connection cannot be opened
            }
        }
        catch (Exception ex)
        {
            return new List<CaseAssignmentInfo>(); // Return an empty list if an error occurs
        }
        finally
        {
            CloseConnection();
        }

        return caseAssignments;
    }

    //public List<CaseInfo> SearchCasesByType(int caseType)
    //{
    //    List<CaseInfo> foundCases = new List<CaseInfo>();

    //    try
    //    {
    //        if (OpenConnection())
    //        {
    //            string query = "SELECT * FROM courtcases WHERE case_type = @caseType";

    //            using (MySqlCommand command = new MySqlCommand(query, connection))
    //            {
    //                command.Parameters.AddWithValue("@caseType", caseType);

    //                using (MySqlDataReader reader = command.ExecuteReader())
    //                {
    //                    while (reader.Read())
    //                    {
    //                        CaseInfo caseInfo = new CaseInfo
    //                        {
    //                            CaseNumber = reader["case_number"].ToString(),
    //                            CaseTitle = reader["case_title"].ToString(),
    //                            CaseType = reader["case_type"].ToString(),
    //                            CaseDescription = reader["case_description"].ToString(),
    //                            CaseStatus = reader["case_status"].ToString(),
    //                            CaseFilingDate = Convert.ToDateTime(reader["case_filing_date"]),
    //                            CourtLocation = reader["case_court_location"].ToString()
    //                            // Add other properties accordingly
    //                        };

    //                        foundCases.Add(caseInfo);
    //                    }
    //                }
    //            }
    //        }
    //        else
    //        {
    //            MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show("Error searching for cases: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //    }
    //    finally
    //    {
    //        CloseConnection();
    //    }

    //    return foundCases;
    //}

    public List<CaseInfo> GetCases()
    {
        List<CaseInfo> cases = new List<CaseInfo>();

        try
        {
            string query = "SELECT * FROM courtcases";  // Replace 'your_table_name' with the actual name of your table

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Assuming CaseInfo is a class representing case information
                        CaseInfo caseInfo = new CaseInfo
                        {
                            CaseNumber = reader["case_number"].ToString(),
                            CaseTitle = reader["case_title"].ToString(),
                            // Add other properties accordingly
                        };

                        cases.Add(caseInfo);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error retrieving cases: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        return cases;
    }

    public string GetCaseIdFromDatabase(string caseNumber)
    {
        string caseId = string.Empty;

        try
        {
            if (OpenConnection())
            {
                string query = "SELECT cc.case_id FROM CourtCases cc INNER JOIN CaseAssignments ca ON cc.case_id = ca.case_id WHERE cc.case_number = @caseNumber";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@caseNumber", caseNumber);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        caseId = result.ToString();
                    }
                }
            }
            else
            {
                return "Error connecting to the database.";
            }
        }
        catch (Exception ex)
        {
            return "Error retrieving case ID: " + ex.Message;
        }
        finally
        {
            CloseConnection();
        }

        return caseId;
    }

    //public string GetCaseDescriptionFromDatabase(string caseNumber)
    //{
    //    string caseDescription = string.Empty;

    //    try
    //    {
    //        if (OpenConnection())
    //        {
    //            string query = "SELECT cc.case_description " +
    //                           "FROM CourtCases cc " +
    //                           "INNER JOIN CaseAssignments ca ON cc.case_id = ca.case_id " +
    //                           "WHERE cc.case_number = @caseNumber";

    //            using (MySqlCommand command = new MySqlCommand(query, connection))
    //            {
    //                command.Parameters.AddWithValue("@caseNumber", caseNumber);

    //                object result = command.ExecuteScalar();
    //                if (result != null)
    //                {
    //                    caseDescription = result.ToString();
    //                }
    //            }
    //        }
    //        else
    //        {
    //            MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show("Error retrieving case description: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //    }
    //    finally
    //    {
    //        CloseConnection();
    //    }

    //    return caseDescription;
    //}

    //public string GetCaseCourtLocationFromDatabase(string caseNumber)
    //{
    //    string courtLocation = string.Empty;

    //    try
    //    {
    //        if (OpenConnection())
    //        {
    //            string query = "SELECT cc.case_court_location " +
    //                           "FROM CourtCases cc " +
    //                           "INNER JOIN CaseAssignments ca ON cc.case_id = ca.case_id " +
    //                           "WHERE cc.case_number = @caseNumber";

    //            using (MySqlCommand command = new MySqlCommand(query, connection))
    //            {
    //                command.Parameters.AddWithValue("@caseNumber", caseNumber);

    //                object result = command.ExecuteScalar();
    //                if (result != null)
    //                {
    //                    courtLocation = result.ToString();
    //                }
    //            }
    //        }
    //        else
    //        {
    //            MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show("Error retrieving court location: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //    }
    //    finally
    //    {
    //        CloseConnection();
    //    }

    //    return courtLocation;
    //}

    //public string GetAssignmentIdFromDatabase(string caseNumber)
    //{
    //    string assignmentId = string.Empty;

    //    try
    //    {
    //        if (OpenConnection())
    //        {
    //            string query = "SELECT ca.assignment_id " +
    //                           "FROM CourtCases cc " +
    //                           "INNER JOIN CaseAssignments ca ON cc.case_id = ca.case_id " +
    //                           "WHERE cc.case_number = @caseNumber";

    //            using (MySqlCommand command = new MySqlCommand(query, connection))
    //            {
    //                command.Parameters.AddWithValue("@caseNumber", caseNumber);

    //                object result = command.ExecuteScalar();
    //                if (result != null)
    //                {
    //                    assignmentId = result.ToString();
    //                }
    //            }
    //        }
    //        else
    //        {
    //            MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show("Error retrieving assignment ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //    }
    //    finally
    //    {
    //        CloseConnection();
    //    }

    //    return assignmentId;
    //}

    //public DateTime? GetAssignmentDateFromDatabase(string assignmentId)
    //{
    //    DateTime? assignmentDate = null;

    //    try
    //    {
    //        if (OpenConnection())
    //        {
    //            string query = "SELECT assignment_date " +
    //                           "FROM CaseAssignments " +
    //                           "WHERE assignment_id = @assignmentId";

    //            using (MySqlCommand command = new MySqlCommand(query, connection))
    //            {
    //                command.Parameters.AddWithValue("@assignmentId", assignmentId);

    //                object result = command.ExecuteScalar();
    //                if (result != null)
    //                {
    //                    assignmentDate = Convert.ToDateTime(result);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            MessageBox.Show("Error connecting to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show("Error retrieving assignment date: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //    }
    //    finally
    //    {
    //        CloseConnection();
    //    }

    //    return assignmentDate;
    //}

    public class CaseAssignmentInfo
    {
        public string AssignmentId { get; set; }
        public string AttorneyId { get; set; }
        public string ProsecutorId { get; set; }
        public DateTime AssignmentDate { get; set; }

        public CaseAssignmentInfo(string assignmentId, DateTime assignmentDate, string attorneyId, string prosecutorId)
        {
            AssignmentId = assignmentId;
            AssignmentDate = assignmentDate;
            AttorneyId = attorneyId;
            ProsecutorId = prosecutorId;
        }
    }

    public class CaseInfo
    {
        public string CaseNumber { get; set; }
        public string CaseTitle { get; set; }
        public string CaseType { get; set; }
        public string CaseDescription { get; set; }
        public string CaseStatus { get; set; }
        public DateTime CaseFilingDate { get; set; }
        public string CourtLocation { get; set; }
        // Add other properties accordingly
    }

    private bool IsConnectionOpen()
    {
        return connection.State == ConnectionState.Open;
    }

    public MySqlConnection Connection => connection;

    public void Dispose()
    {
        connection.Dispose();
    }
}
