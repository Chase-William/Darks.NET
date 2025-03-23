namespace Darks.Desktop.Test.Controls
{
    partial class MainMenuControl
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
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            serverTxtBox = new TextBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(12, 13);
            label2.Name = "label2";
            label2.Size = new Size(199, 25);
            label2.TabIndex = 6;
            label2.Text = "Main Menu Manager";
            // 
            // button1
            // 
            button1.Location = new Point(12, 52);
            button1.Name = "button1";
            button1.Size = new Size(126, 23);
            button1.TabIndex = 7;
            button1.Text = "Join Server";
            button1.UseVisualStyleBackColor = true;
            button1.Click += OnJoinServerBtnClicked;
            // 
            // button2
            // 
            button2.Location = new Point(12, 81);
            button2.Name = "button2";
            button2.Size = new Size(126, 23);
            button2.TabIndex = 8;
            button2.Text = "Join Last Session";
            button2.UseVisualStyleBackColor = true;
            button2.Click += OnJoinLastSessionBtnClicked;
            // 
            // button3
            // 
            button3.Location = new Point(12, 110);
            button3.Name = "button3";
            button3.Size = new Size(126, 23);
            button3.TabIndex = 9;
            button3.Text = "Exit To Main Menu";
            button3.UseVisualStyleBackColor = true;
            button3.Click += OnExitToMainMenu;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(144, 56);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 10;
            label1.Text = "Server";
            // 
            // serverTxtBox
            // 
            serverTxtBox.Location = new Point(188, 52);
            serverTxtBox.Name = "serverTxtBox";
            serverTxtBox.Size = new Size(100, 23);
            serverTxtBox.TabIndex = 11;
            // 
            // MainMenuControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(serverTxtBox);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Name = "MainMenuControl";
            Size = new Size(471, 283);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private TextBox serverTxtBox;
    }
}
