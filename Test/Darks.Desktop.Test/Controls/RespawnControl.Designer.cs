namespace Darks.Desktop.Test.Controls
{
    partial class RespawnControl
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
            label3 = new Label();
            label4 = new Label();
            bedNameTxtBox = new TextBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(3, 11);
            label2.Name = "label2";
            label2.Size = new Size(176, 25);
            label2.TabIndex = 6;
            label2.Text = "Respawn Manager";
            // 
            // button1
            // 
            button1.Location = new Point(13, 80);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "Respawn";
            button1.UseVisualStyleBackColor = true;
            button1.Click += OnRespawnBtnClicked;
            // 
            // button2
            // 
            button2.Location = new Point(13, 107);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 8;
            button2.Text = "Fast Travel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += OnFastTravelBtnClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(94, 111);
            label1.Name = "label1";
            label1.Size = new Size(111, 15);
            label1.TabIndex = 9;
            label1.Text = "Be looking at a bed.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(94, 84);
            label3.Name = "label3";
            label3.Size = new Size(261, 15);
            label3.TabIndex = 10;
            label3.Text = "Be at the spawn screen, in your inventory or not.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 54);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 11;
            label4.Text = "Bed Name:";
            // 
            // bedNameTxtBox
            // 
            bedNameTxtBox.Location = new Point(94, 51);
            bedNameTxtBox.Name = "bedNameTxtBox";
            bedNameTxtBox.Size = new Size(100, 23);
            bedNameTxtBox.TabIndex = 12;
            // 
            // RespawnControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(bedNameTxtBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Name = "RespawnControl";
            Size = new Size(596, 333);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button button1;
        private Button button2;
        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox bedNameTxtBox;
    }
}
