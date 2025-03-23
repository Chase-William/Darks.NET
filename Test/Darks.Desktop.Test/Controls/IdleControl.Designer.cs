namespace Darks.Desktop.Test.Controls
{
    partial class IdleControl
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
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(14, 12);
            label2.Name = "label2";
            label2.Size = new Size(199, 25);
            label2.TabIndex = 7;
            label2.Text = "Main Menu Manager";
            // 
            // button1
            // 
            button1.Location = new Point(14, 49);
            button1.Name = "button1";
            button1.Size = new Size(109, 23);
            button1.TabIndex = 8;
            button1.Text = "Enter Idle State";
            button1.UseVisualStyleBackColor = true;
            button1.Click += OnEnterIdleStateBtnClicked;
            // 
            // button2
            // 
            button2.Location = new Point(14, 78);
            button2.Name = "button2";
            button2.Size = new Size(109, 23);
            button2.TabIndex = 9;
            button2.Text = "Leave Idle State";
            button2.UseVisualStyleBackColor = true;
            button2.Click += OnLeaveIdleStateBtnClicked;
            // 
            // IdleControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Name = "IdleControl";
            Size = new Size(540, 309);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button button1;
        private Button button2;
    }
}
