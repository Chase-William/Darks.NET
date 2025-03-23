namespace Darks.Desktop.Test.Controls
{
    partial class ParasaurAlarmControl
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
            label1 = new Label();
            detectionStateLbl = new Label();
            alarmImgBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)alarmImgBox).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(12, 14);
            label2.Name = "label2";
            label2.Size = new Size(172, 25);
            label2.TabIndex = 6;
            label2.Text = "Parasaur Detector";
            // 
            // button1
            // 
            button1.Location = new Point(12, 54);
            button1.Name = "button1";
            button1.Size = new Size(114, 23);
            button1.TabIndex = 7;
            button1.Text = "Take Screenshot";
            button1.UseVisualStyleBackColor = true;
            button1.Click += OnTakeScreenshotBtnClicked;
            // 
            // button2
            // 
            button2.Location = new Point(12, 83);
            button2.Name = "button2";
            button2.Size = new Size(114, 23);
            button2.TabIndex = 8;
            button2.Text = "Check If Detecting";
            button2.UseVisualStyleBackColor = true;
            button2.Click += OnCheckIfDetectingBtnClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(132, 87);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 9;
            label1.Text = "State:";
            // 
            // detectionStateLbl
            // 
            detectionStateLbl.AutoSize = true;
            detectionStateLbl.Location = new Point(174, 87);
            detectionStateLbl.Name = "detectionStateLbl";
            detectionStateLbl.Size = new Size(12, 15);
            detectionStateLbl.TabIndex = 10;
            detectionStateLbl.Text = "?";
            // 
            // alarmImgBox
            // 
            alarmImgBox.Location = new Point(12, 124);
            alarmImgBox.Name = "alarmImgBox";
            alarmImgBox.Size = new Size(369, 74);
            alarmImgBox.TabIndex = 11;
            alarmImgBox.TabStop = false;
            // 
            // ParasaurAlarmControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(alarmImgBox);
            Controls.Add(detectionStateLbl);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Name = "ParasaurAlarmControl";
            Size = new Size(396, 266);
            ((System.ComponentModel.ISupportInitialize)alarmImgBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button button1;
        private Button button2;
        private Label label1;
        private Label detectionStateLbl;
        private PictureBox alarmImgBox;
    }
}
