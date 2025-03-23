namespace Darks.Desktop.Test
{
    partial class MainWindow
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
            tabPage2 = new TabPage();
            tabPage1 = new TabPage();
            defaultTabControl = new TabControl();
            button2 = new Button();
            discordConnectionStatusLbl = new Label();
            dispatchConnectivityBtn = new Button();
            discordConnectivityBtn = new Button();
            label1 = new Label();
            label3 = new Label();
            jobTabControl = new TabControl();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            defaultTabControl.SuspendLayout();
            jobTabControl.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(768, 356);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(768, 209);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            defaultTabControl.Controls.Add(tabPage1);
            defaultTabControl.Controls.Add(tabPage2);
            defaultTabControl.Location = new Point(12, 54);
            defaultTabControl.Name = "tabControl";
            defaultTabControl.SelectedIndex = 0;
            defaultTabControl.Size = new Size(776, 237);
            defaultTabControl.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(51, 13);
            button2.Name = "button2";
            button2.Size = new Size(8, 8);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // discordConnectionStatusLbl
            // 
            discordConnectionStatusLbl.AutoSize = true;
            discordConnectionStatusLbl.Location = new Point(153, 26);
            discordConnectionStatusLbl.Name = "discordConnectionStatusLbl";
            discordConnectionStatusLbl.Size = new Size(0, 15);
            discordConnectionStatusLbl.TabIndex = 3;
            // 
            // dispatchConnectivityBtn
            // 
            dispatchConnectivityBtn.Location = new Point(209, 20);
            dispatchConnectivityBtn.Name = "dispatchConnectivityBtn";
            dispatchConnectivityBtn.Size = new Size(75, 23);
            dispatchConnectivityBtn.TabIndex = 7;
            dispatchConnectivityBtn.Text = "Connect";
            dispatchConnectivityBtn.UseVisualStyleBackColor = true;
            dispatchConnectivityBtn.Click += OnDispatchToggleConnectionBtnClicked;
            // 
            // discordConnectivityBtn
            // 
            discordConnectivityBtn.Location = new Point(69, 20);
            discordConnectivityBtn.Name = "discordConnectivityBtn";
            discordConnectivityBtn.Size = new Size(75, 23);
            discordConnectivityBtn.TabIndex = 8;
            discordConnectivityBtn.Text = "Connect";
            discordConnectivityBtn.UseVisualStyleBackColor = true;
            discordConnectivityBtn.Click += OnDiscordToggleConnectionBtnClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 24);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 9;
            label1.Text = "Discord";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(150, 24);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 10;
            label3.Text = "Dispatch";
            // 
            // jobTabControl
            // 
            jobTabControl.Controls.Add(tabPage3);
            jobTabControl.Controls.Add(tabPage4);
            jobTabControl.Location = new Point(16, 309);
            jobTabControl.Name = "jobTabControl";
            jobTabControl.SelectedIndex = 0;
            jobTabControl.Size = new Size(768, 229);
            jobTabControl.TabIndex = 11;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(760, 201);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(192, 72);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "tabPage4";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 550);
            Controls.Add(jobTabControl);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(discordConnectivityBtn);
            Controls.Add(dispatchConnectivityBtn);
            Controls.Add(discordConnectionStatusLbl);
            Controls.Add(button2);
            Controls.Add(defaultTabControl);
            Name = "MainWindow";
            Text = "Debug Window";
            defaultTabControl.ResumeLayout(false);
            jobTabControl.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabPage tabPage2;
        private TabPage tabPage1;
        private TabControl defaultTabControl;
        private Button button2;
        private Label discordConnectionStatusLbl;
        private Button dispatchConnectivityBtn;
        private Button discordConnectivityBtn;
        private Label label1;
        private Label label3;
        private TabControl jobTabControl;
        private TabPage tabPage3;
        private TabPage tabPage4;
    }
}
