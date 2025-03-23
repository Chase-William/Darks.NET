namespace Darks.Desktop.Controls
{
    partial class LoginControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            usernameTxtBox = new TextBox();
            usernameLbl = new Label();
            passwordTxtBox = new TextBox();
            passwordLbl = new Label();
            loginBtn = new Button();
            SuspendLayout();
            // 
            // usernameTxtBox
            // 
            usernameTxtBox.Location = new Point(76, 9);
            usernameTxtBox.Name = "usernameTxtBox";
            usernameTxtBox.Size = new Size(100, 23);
            usernameTxtBox.TabIndex = 0;
            // 
            // usernameLbl
            // 
            usernameLbl.AutoSize = true;
            usernameLbl.Location = new Point(10, 12);
            usernameLbl.Name = "usernameLbl";
            usernameLbl.Size = new Size(60, 15);
            usernameLbl.TabIndex = 1;
            usernameLbl.Text = "Username";
            // 
            // passwordTxtBox
            // 
            passwordTxtBox.Location = new Point(76, 38);
            passwordTxtBox.Name = "passwordTxtBox";
            passwordTxtBox.Size = new Size(100, 23);
            passwordTxtBox.TabIndex = 2;
            // 
            // passwordLbl
            // 
            passwordLbl.AutoSize = true;
            passwordLbl.Location = new Point(10, 41);
            passwordLbl.Name = "passwordLbl";
            passwordLbl.Size = new Size(57, 15);
            passwordLbl.TabIndex = 3;
            passwordLbl.Text = "Password";
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(101, 67);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(75, 23);
            loginBtn.TabIndex = 4;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += OnLoginBtn_Clicked;
            // 
            // LoginControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(loginBtn);
            Controls.Add(passwordLbl);
            Controls.Add(passwordTxtBox);
            Controls.Add(usernameLbl);
            Controls.Add(usernameTxtBox);
            Name = "LoginControl";
            Size = new Size(190, 106);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usernameTxtBox;
        private Label usernameLbl;
        private TextBox passwordTxtBox;
        private Label passwordLbl;
        private Button loginBtn;
    }
}
