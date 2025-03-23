namespace Darks.Desktop.Controls
{
    partial class ToggleControl
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
            toggleBtn = new Button();
            SuspendLayout();
            // 
            // toggleBtn
            // 
            toggleBtn.Location = new Point(3, 3);
            toggleBtn.Name = "toggleBtn";
            toggleBtn.Size = new Size(134, 23);
            toggleBtn.TabIndex = 0;
            toggleBtn.Text = "Toggle (Disabled)";
            toggleBtn.UseVisualStyleBackColor = true;
            toggleBtn.Click += OnToggleBtn_Clicked;
            // 
            // ToggleControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(toggleBtn);
            Name = "ToggleControl";
            Size = new Size(141, 32);
            ResumeLayout(false);
        }

        #endregion

        private Button toggleBtn;
    }
}
