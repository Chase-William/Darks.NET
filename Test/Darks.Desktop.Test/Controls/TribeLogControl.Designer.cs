namespace Darks.Desktop.Test.Controls
{
    partial class TribeLogControl
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
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(15, 13);
            label2.Name = "label2";
            label2.Size = new Size(180, 25);
            label2.TabIndex = 6;
            label2.Text = "Tribe Log Capturer";
            // 
            // button1
            // 
            button1.Location = new Point(15, 113);
            button1.Name = "button1";
            button1.Size = new Size(108, 23);
            button1.TabIndex = 7;
            button1.Text = "Take Screenshot";
            button1.UseVisualStyleBackColor = true;
            button1.Click += OnTakeScreenshotBtnClicked;
            // 
            // button2
            // 
            button2.Location = new Point(15, 55);
            button2.Name = "button2";
            button2.Size = new Size(108, 23);
            button2.TabIndex = 8;
            button2.Text = "Open Tribe Log";
            button2.UseVisualStyleBackColor = true;
            button2.Click += OnOpenTribeLogBtnClicked;
            // 
            // button3
            // 
            button3.Location = new Point(15, 84);
            button3.Name = "button3";
            button3.Size = new Size(108, 23);
            button3.TabIndex = 9;
            button3.Text = "Close Tribe Log";
            button3.UseVisualStyleBackColor = true;
            button3.Click += OnCloseTribeLogBtnClicked;
            // 
            // TribeLogControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Name = "TribeLogControl";
            Size = new Size(416, 267);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
