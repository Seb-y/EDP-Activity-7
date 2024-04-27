namespace User_Interface
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label4 = new Label();
            label6 = new Label();
            label5 = new Label();
            confirmButton = new Button();
            txtConfirmEmail = new TextBox();
            label2 = new Label();
            label7 = new Label();
            label11 = new Label();
            label13 = new Label();
            backToSignIN = new Label();
            label3 = new Label();
            iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(135, 114);
            label4.Name = "label4";
            label4.Size = new Size(0, 23);
            label4.TabIndex = 36;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Cursor = Cursors.Hand;
            label6.Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(93, 53, 135);
            label6.Location = new Point(171, 332);
            label6.Name = "label6";
            label6.Size = new Size(132, 23);
            label6.TabIndex = 34;
            label6.Text = "Create Account";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(136, 300);
            label5.Name = "label5";
            label5.Size = new Size(194, 23);
            label5.TabIndex = 33;
            label5.Text = "Don't Have an Account?";
            // 
            // confirmButton
            // 
            confirmButton.BackColor = Color.FromArgb(116, 86, 174);
            confirmButton.Cursor = Cursors.Hand;
            confirmButton.FlatAppearance.BorderSize = 0;
            confirmButton.FlatStyle = FlatStyle.Flat;
            confirmButton.ForeColor = Color.White;
            confirmButton.Location = new Point(124, 218);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(216, 35);
            confirmButton.TabIndex = 32;
            confirmButton.Text = "Confirm";
            confirmButton.UseVisualStyleBackColor = false;
            confirmButton.Click += confirmButton_Click;
            // 
            // txtConfirmEmail
            // 
            txtConfirmEmail.BackColor = Color.FromArgb(230, 231, 233);
            txtConfirmEmail.BorderStyle = BorderStyle.None;
            txtConfirmEmail.Font = new Font("MS UI Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmEmail.Location = new Point(88, 172);
            txtConfirmEmail.Multiline = true;
            txtConfirmEmail.Name = "txtConfirmEmail";
            txtConfirmEmail.Size = new Size(295, 28);
            txtConfirmEmail.TabIndex = 28;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(89, 146);
            label2.Name = "label2";
            label2.Size = new Size(116, 23);
            label2.TabIndex = 27;
            label2.Text = "Email Address";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("MS UI Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(116, 86, 174);
            label7.Location = new Point(33, 47);
            label7.Name = "label7";
            label7.Size = new Size(181, 23);
            label7.TabIndex = 37;
            label7.Text = "Reset Password";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(33, 83);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(400, 17);
            label11.TabIndex = 39;
            label11.Text = "Enter the email address associated with your account and we'll";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            label11.Click += label11_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(33, 101);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(408, 17);
            label13.TabIndex = 48;
            label13.Text = "match an email within the database for verification code to reset";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            label13.Click += label13_Click;
            // 
            // backToSignIN
            // 
            backToSignIN.AutoSize = true;
            backToSignIN.Cursor = Cursors.Hand;
            backToSignIN.Font = new Font("Nirmala UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            backToSignIN.Location = new Point(186, 265);
            backToSignIN.Name = "backToSignIN";
            backToSignIN.Size = new Size(93, 17);
            backToSignIN.TabIndex = 49;
            backToSignIN.Text = "Back to Sign In";
            backToSignIN.Click += backToSignIN_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(33, 118);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(102, 17);
            label3.TabIndex = 50;
            label3.Text = "your password";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // iconPictureBox2
            // 
            iconPictureBox2.BackColor = Color.White;
            iconPictureBox2.ForeColor = Color.FromArgb(116, 86, 174);
            iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            iconPictureBox2.IconColor = Color.FromArgb(116, 86, 174);
            iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox2.IconSize = 30;
            iconPictureBox2.Location = new Point(400, 0);
            iconPictureBox2.Name = "iconPictureBox2";
            iconPictureBox2.Size = new Size(30, 30);
            iconPictureBox2.TabIndex = 53;
            iconPictureBox2.TabStop = false;
            iconPictureBox2.Click += iconPictureBox2_Click;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.White;
            iconPictureBox1.ForeColor = Color.FromArgb(116, 86, 174);
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.RectangleTimes;
            iconPictureBox1.IconColor = Color.FromArgb(116, 86, 174);
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 30;
            iconPictureBox1.Location = new Point(430, 0);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(30, 30);
            iconPictureBox1.TabIndex = 52;
            iconPictureBox1.TabStop = false;
            iconPictureBox1.Click += iconPictureBox1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(460, 398);
            Controls.Add(iconPictureBox2);
            Controls.Add(iconPictureBox1);
            Controls.Add(label3);
            Controls.Add(backToSignIN);
            Controls.Add(label13);
            Controls.Add(label11);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(confirmButton);
            Controls.Add(txtConfirmEmail);
            Controls.Add(label2);
            Font = new Font("Nirmala UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.MidnightBlue;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label6;
        private Label label5;
        private Button confirmButton;
        private TextBox txtConfirmEmail;
        private Label label2;
        private Label label7;
        private Label label11;
        private Label label13;
        private Label backToSignIN;
        private Label label3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
    }
}