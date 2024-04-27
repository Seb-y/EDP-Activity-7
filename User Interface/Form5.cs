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
    public partial class Form5 : Form
    {
        private DatabaseConnection dbConnection;
        public Form5()
        {
            InitializeComponent();
        }

        public static class PromptDialog
        {
            public static string PromptUser(string[] options, string promptMessage)
            {
                using (var form = new Form())
                {
                    form.Text = "Select Title";
                    var label = new Label() { Left = 50, Top = 20, Text = promptMessage };
                    var comboBox = new ComboBox() { Left = 50, Top = 50, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
                    comboBox.Items.AddRange(options);
                    var buttonOk = new Button() { Text = "Confirm", Left = 50, Width = 100, Top = 80, DialogResult = DialogResult.OK };
                    var buttonCancel = new Button() { Text = "Cancel", Left = 150, Width = 100, Top = 80, DialogResult = DialogResult.Cancel };

                    buttonOk.Click += (sender, e) => { form.Close(); };

                    form.Controls.Add(label);
                    form.Controls.Add(comboBox);
                    form.Controls.Add(buttonOk);
                    form.Controls.Add(buttonCancel);

                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        return comboBox.SelectedItem.ToString();
                    }

                    return null;
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Navigate to Form6
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide(); // Hide the current form
        }

        private void label8_Click(object sender, EventArgs e)
        {
            // Navigate to Form6
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide(); // Hide the current form
        }

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

        private void label9_Click(object sender, EventArgs e)
        {
            // Prompt the user to select attorney or prosecutor
            string[] options = { "Attorney", "Prosecutor" };
            string selectedOption = PromptDialog.PromptUser(options, "Select your role:");

            // Depending on the selection, set the IsAttorney value
            if (selectedOption == "Attorney")
            {
                UserRoles.IsAttorney = true;
            }
            else if (selectedOption == "Prosecutor")
            {
                UserRoles.IsAttorney = false;
            }

            // Navigate to Form9
            Form9 form9 = new Form9();
            form9.Show();

            // Hide the current form
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Prompt the user to select attorney or prosecutor
            string[] options = { "Attorney", "Prosecutor" };
            string selectedOption = PromptDialog.PromptUser(options, "Select your role:");

            // Depending on the selection, navigate to Form9 and add data to the appropriate table
            if (selectedOption == "Attorney")
            {
                Form10 form10 = new Form10();
                form10.IsAttorney = true;
                //form9.AddOrUpdateData(true); // Add data to the Attorneys table
                form10.Show();
            }
            else if (selectedOption == "Prosecutor")
            {
                Form10 form10 = new Form10();
                form10.IsAttorney = false;
                //form9.AddOrUpdateData(false); // Add data to the Prosecutors table
                form10.Show();
            }

            // Hide the current form
            this.Hide();
        }

        private void iconPictureBox10_Click(object sender, EventArgs e)
        {
            // Close the form and end all processes
            Application.Exit();
        }

        private void iconPictureBox9_Click(object sender, EventArgs e)
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
