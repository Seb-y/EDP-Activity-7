namespace User_Interface
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label7 = new Label();
            label4 = new Label();
            frgtPass = new Label();
            label6 = new Label();
            label5 = new Label();
            loginButton = new Button();
            checkshowPass = new CheckBox();
            txtPass = new TextBox();
            label3 = new Label();
            txtUser = new TextBox();
            label2 = new Label();
            label1 = new Label();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("MS UI Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(116, 86, 174);
            label7.Location = new Point(47, 129);
            label7.Name = "label7";
            label7.Size = new Size(270, 23);
            label7.TabIndex = 49;
            label7.Text = "Sign In to Your Account";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(135, 129);
            label4.Name = "label4";
            label4.Size = new Size(0, 23);
            label4.TabIndex = 48;
            // 
            // frgtPass
            // 
            frgtPass.AutoSize = true;
            frgtPass.Cursor = Cursors.Hand;
            frgtPass.FlatStyle = FlatStyle.Popup;
            frgtPass.Font = new Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            frgtPass.Location = new Point(32, 319);
            frgtPass.Name = "frgtPass";
            frgtPass.Size = new Size(133, 20);
            frgtPass.TabIndex = 47;
            frgtPass.Text = "Forget Password?";
            frgtPass.Click += frgtPass_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Cursor = Cursors.Hand;
            label6.Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(93, 53, 135);
            label6.Location = new Point(117, 436);
            label6.Name = "label6";
            label6.Size = new Size(132, 23);
            label6.TabIndex = 46;
            label6.Text = "Create Account";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(79, 404);
            label5.Name = "label5";
            label5.Size = new Size(200, 23);
            label5.TabIndex = 45;
            label5.Text = "Don't Have an Account?";
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.FromArgb(116, 86, 174);
            loginButton.Cursor = Cursors.Hand;
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.ForeColor = Color.White;
            loginButton.Location = new Point(69, 355);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(216, 35);
            loginButton.TabIndex = 44;
            loginButton.Text = "LOGIN";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // checkshowPass
            // 
            checkshowPass.AutoSize = true;
            checkshowPass.Cursor = Cursors.Hand;
            checkshowPass.FlatStyle = FlatStyle.Flat;
            checkshowPass.Font = new Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkshowPass.Location = new Point(192, 317);
            checkshowPass.Name = "checkshowPass";
            checkshowPass.Size = new Size(136, 24);
            checkshowPass.TabIndex = 43;
            checkshowPass.Text = "Show Password";
            checkshowPass.UseVisualStyleBackColor = true;
            checkshowPass.CheckedChanged += checkshowPass_CheckedChanged;
            // 
            // txtPass
            // 
            txtPass.BackColor = Color.FromArgb(230, 231, 233);
            txtPass.BorderStyle = BorderStyle.None;
            txtPass.Font = new Font("MS UI Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPass.Location = new Point(32, 281);
            txtPass.Multiline = true;
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(295, 28);
            txtPass.TabIndex = 42;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 255);
            label3.Name = "label3";
            label3.Size = new Size(84, 23);
            label3.TabIndex = 41;
            label3.Text = "Password";
            // 
            // txtUser
            // 
            txtUser.BackColor = Color.FromArgb(230, 231, 233);
            txtUser.BorderStyle = BorderStyle.None;
            txtUser.Font = new Font("MS UI Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUser.Location = new Point(32, 213);
            txtUser.Multiline = true;
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(295, 28);
            txtUser.TabIndex = 40;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 187);
            label2.Name = "label2";
            label2.Size = new Size(89, 23);
            label2.TabIndex = 39;
            label2.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(116, 86, 174);
            label1.Location = new Point(107, 91);
            label1.Name = "label1";
            label1.Size = new Size(155, 34);
            label1.TabIndex = 38;
            label1.Text = "Welcome!";
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.White;
            iconPictureBox1.ForeColor = Color.FromArgb(116, 86, 174);
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.RectangleTimes;
            iconPictureBox1.IconColor = Color.FromArgb(116, 86, 174);
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 30;
            iconPictureBox1.Location = new Point(331, 0);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(30, 30);
            iconPictureBox1.TabIndex = 50;
            iconPictureBox1.TabStop = false;
            iconPictureBox1.Click += iconPictureBox1_Click;
            // 
            // iconPictureBox2
            // 
            iconPictureBox2.BackColor = Color.White;
            iconPictureBox2.ForeColor = Color.FromArgb(116, 86, 174);
            iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            iconPictureBox2.IconColor = Color.FromArgb(116, 86, 174);
            iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox2.IconSize = 30;
            iconPictureBox2.Location = new Point(301, 0);
            iconPictureBox2.Name = "iconPictureBox2";
            iconPictureBox2.Size = new Size(30, 30);
            iconPictureBox2.TabIndex = 51;
            iconPictureBox2.TabStop = false;
            iconPictureBox2.Click += iconPictureBox2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(360, 550);
            Controls.Add(iconPictureBox2);
            Controls.Add(iconPictureBox1);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(frgtPass);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(loginButton);
            Controls.Add(checkshowPass);
            Controls.Add(txtPass);
            Controls.Add(label3);
            Controls.Add(txtUser);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.MidnightBlue;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label label4;
        private Label frgtPass;
        private Label label6;
        private Label label5;
        private Button loginButton;
        private CheckBox checkshowPass;
        private TextBox txtPass;
        private Label label3;
        private TextBox txtUser;
        private Label label2;
        private Label label1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
    }
}
