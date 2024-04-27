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

namespace User_Interface
{
    public partial class Form8 : Form
    {
        private DatabaseConnection dbConnection;
        public Form8()
        {
            InitializeComponent();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Navigate to Form7
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide(); // Hide the current form
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Navigate to Form6
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide(); // Hide the current form
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // Navigate to Form6
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide(); // Hide the current form
        }

        private void iconPictureBox6_Click(object sender, EventArgs e)
        {
            // Close the form and end all processes
            Application.Exit();
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
    }
}
