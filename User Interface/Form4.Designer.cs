namespace User_Interface
{
    partial class Form4
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
            label7 = new Label();
            label4 = new Label();
            confirmButtonf4 = new Button();
            confirmPasswordTextBox = new TextBox();
            label3 = new Label();
            newPasswordTextBox = new TextBox();
            label2 = new Label();
            iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            backToSignIN = new Label();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("MS UI Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(116, 86, 174);
            label7.Location = new Point(89, 60);
            label7.Name = "label7";
            label7.Size = new Size(164, 23);
            label7.TabIndex = 61;
            label7.Text = "New Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(191, 53);
            label4.Name = "label4";
            label4.Size = new Size(0, 23);
            label4.TabIndex = 60;
            // 
            // confirmButtonf4
            // 
            confirmButtonf4.BackColor = Color.FromArgb(116, 86, 174);
            confirmButtonf4.Cursor = Cursors.Hand;
            confirmButtonf4.FlatAppearance.BorderSize = 0;
            confirmButtonf4.FlatStyle = FlatStyle.Flat;
            confirmButtonf4.ForeColor = Color.White;
            confirmButtonf4.Location = new Point(125, 254);
            confirmButtonf4.Name = "confirmButtonf4";
            confirmButtonf4.Size = new Size(216, 35);
            confirmButtonf4.TabIndex = 56;
            confirmButtonf4.Text = "Confirm";
            confirmButtonf4.UseVisualStyleBackColor = false;
            confirmButtonf4.Click += confirmButton_Click;
            // 
            // confirmPasswordTextBox
            // 
            confirmPasswordTextBox.BackColor = Color.FromArgb(230, 231, 233);
            confirmPasswordTextBox.BorderStyle = BorderStyle.None;
            confirmPasswordTextBox.Font = new Font("MS UI Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            confirmPasswordTextBox.Location = new Point(88, 209);
            confirmPasswordTextBox.Multiline = true;
            confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            confirmPasswordTextBox.PasswordChar = '*';
            confirmPasswordTextBox.Size = new Size(295, 28);
            confirmPasswordTextBox.TabIndex = 54;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(89, 183);
            label3.Name = "label3";
            label3.Size = new Size(146, 23);
            label3.TabIndex = 53;
            label3.Text = "Confirm Password";
            // 
            // newPasswordTextBox
            // 
            newPasswordTextBox.BackColor = Color.FromArgb(230, 231, 233);
            newPasswordTextBox.BorderStyle = BorderStyle.None;
            newPasswordTextBox.Font = new Font("MS UI Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newPasswordTextBox.Location = new Point(88, 137);
            newPasswordTextBox.Multiline = true;
            newPasswordTextBox.Name = "newPasswordTextBox";
            newPasswordTextBox.PasswordChar = '*';
            newPasswordTextBox.Size = new Size(295, 28);
            newPasswordTextBox.TabIndex = 52;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(89, 111);
            label2.Name = "label2";
            label2.Size = new Size(164, 23);
            label2.TabIndex = 51;
            label2.Text = "Enter New Password";
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
            iconPictureBox2.TabIndex = 63;
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
            iconPictureBox1.TabIndex = 62;
            iconPictureBox1.TabStop = false;
            iconPictureBox1.Click += iconPictureBox1_Click;
            // 
            // backToSignIN
            // 
            backToSignIN.AutoSize = true;
            backToSignIN.Cursor = Cursors.Hand;
            backToSignIN.Font = new Font("Nirmala UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            backToSignIN.Location = new Point(188, 296);
            backToSignIN.Name = "backToSignIN";
            backToSignIN.Size = new Size(93, 17);
            backToSignIN.TabIndex = 64;
            backToSignIN.Text = "Back to Sign In";
            backToSignIN.Click += backToSignIN_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(460, 398);
            Controls.Add(backToSignIN);
            Controls.Add(iconPictureBox2);
            Controls.Add(iconPictureBox1);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(confirmButtonf4);
            Controls.Add(confirmPasswordTextBox);
            Controls.Add(label3);
            Controls.Add(newPasswordTextBox);
            Controls.Add(label2);
            Font = new Font("Nirmala UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.MidnightBlue;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form4";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label label4;
        private Button confirmButtonf4;
        private TextBox confirmPasswordTextBox;
        private Label label3;
        private TextBox newPasswordTextBox;
        private Label label2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Label backToSignIN;
    }
}