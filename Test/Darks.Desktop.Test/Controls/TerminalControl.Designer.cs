namespace Darks.Desktop.Test.Controls
{
    partial class TerminalControl
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
            terminalTxtBox = new TextBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(14, 15);
            label2.Name = "label2";
            label2.Size = new Size(173, 25);
            label2.TabIndex = 7;
            label2.Text = "Terminal Manager";
            // 
            // button1
            // 
            button1.Location = new Point(209, 53);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += OnSendBtnClicked;
            // 
            // terminalTxtBox
            // 
            terminalTxtBox.Location = new Point(14, 53);
            terminalTxtBox.Name = "terminalTxtBox";
            terminalTxtBox.Size = new Size(189, 23);
            terminalTxtBox.TabIndex = 9;
            // 
            // TerminalControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(terminalTxtBox);
            Controls.Add(button1);
            Controls.Add(label2);
            Name = "TerminalControl";
            Size = new Size(568, 310);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button button1;
        private TextBox terminalTxtBox;
    }
}
