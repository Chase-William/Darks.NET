namespace Darks.Desktop.Test.Controls
{
    partial class ProcessControl
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
            isArkRunningLbl = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(14, 10);
            label2.Name = "label2";
            label2.Size = new Size(164, 25);
            label2.TabIndex = 7;
            label2.Text = "Process Manager";
            // 
            // button1
            // 
            button1.Location = new Point(14, 51);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Launch Ark";
            button1.UseVisualStyleBackColor = true;
            button1.Click += OnLaunchArkBtnClicked;
            // 
            // button2
            // 
            button2.Location = new Point(14, 80);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "Exit Ark";
            button2.UseVisualStyleBackColor = true;
            button2.Click += OnExitArkBtnClicked;
            // 
            // button3
            // 
            button3.Location = new Point(14, 109);
            button3.Name = "button3";
            button3.Size = new Size(150, 23);
            button3.TabIndex = 10;
            button3.Text = "Check If Ark Is Running";
            button3.UseVisualStyleBackColor = true;
            button3.Click += OnCheckIfArkIsRunningBtnClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(170, 113);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 11;
            label1.Text = "Is Running:";
            // 
            // isArkRunningLbl
            // 
            isArkRunningLbl.AutoSize = true;
            isArkRunningLbl.Location = new Point(242, 113);
            isArkRunningLbl.Name = "isArkRunningLbl";
            isArkRunningLbl.Size = new Size(12, 15);
            isArkRunningLbl.TabIndex = 12;
            isArkRunningLbl.Text = "?";
            // 
            // ProcessControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(isArkRunningLbl);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Name = "ProcessControl";
            Size = new Size(568, 301);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label isArkRunningLbl;
    }
}
