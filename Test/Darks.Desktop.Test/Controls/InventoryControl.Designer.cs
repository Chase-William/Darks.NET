namespace Darks.Desktop.Test.Controls
{
    partial class InventoryControl
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
            openInventoryBtn = new Button();
            closeInventoryBtn = new Button();
            selfInventoryRadioBtn = new RadioButton();
            otherInventoryRadioBtn = new RadioButton();
            label1 = new Label();
            label2 = new Label();
            giveAllBtn = new Button();
            takeAllBtn = new Button();
            SuspendLayout();
            // 
            // openInventoryBtn
            // 
            openInventoryBtn.Location = new Point(6, 47);
            openInventoryBtn.Name = "openInventoryBtn";
            openInventoryBtn.Size = new Size(115, 23);
            openInventoryBtn.TabIndex = 0;
            openInventoryBtn.Text = "Open Inventory";
            openInventoryBtn.UseVisualStyleBackColor = true;
            openInventoryBtn.Click += OnOpenInventoryBtnClicked;
            // 
            // closeInventoryBtn
            // 
            closeInventoryBtn.Location = new Point(6, 76);
            closeInventoryBtn.Name = "closeInventoryBtn";
            closeInventoryBtn.Size = new Size(115, 23);
            closeInventoryBtn.TabIndex = 1;
            closeInventoryBtn.Text = "Close Inventory";
            closeInventoryBtn.UseVisualStyleBackColor = true;
            closeInventoryBtn.Click += OnCloseInventoryBtnClicked;
            // 
            // selfInventoryRadioBtn
            // 
            selfInventoryRadioBtn.AutoSize = true;
            selfInventoryRadioBtn.Location = new Point(147, 111);
            selfInventoryRadioBtn.Name = "selfInventoryRadioBtn";
            selfInventoryRadioBtn.Size = new Size(44, 19);
            selfInventoryRadioBtn.TabIndex = 2;
            selfInventoryRadioBtn.TabStop = true;
            selfInventoryRadioBtn.Text = "Self";
            selfInventoryRadioBtn.UseVisualStyleBackColor = true;
            // 
            // otherInventoryRadioBtn
            // 
            otherInventoryRadioBtn.AutoSize = true;
            otherInventoryRadioBtn.Location = new Point(147, 138);
            otherInventoryRadioBtn.Name = "otherInventoryRadioBtn";
            otherInventoryRadioBtn.Size = new Size(55, 19);
            otherInventoryRadioBtn.TabIndex = 3;
            otherInventoryRadioBtn.TabStop = true;
            otherInventoryRadioBtn.Text = "Other";
            otherInventoryRadioBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(138, 89);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 4;
            label1.Text = "Who (Target)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(6, 9);
            label2.Name = "label2";
            label2.Size = new Size(185, 25);
            label2.TabIndex = 5;
            label2.Text = "Inventory Manager";
            // 
            // giveAllBtn
            // 
            giveAllBtn.Location = new Point(6, 130);
            giveAllBtn.Name = "giveAllBtn";
            giveAllBtn.Size = new Size(115, 23);
            giveAllBtn.TabIndex = 6;
            giveAllBtn.Text = "Give All";
            giveAllBtn.UseVisualStyleBackColor = true;
            giveAllBtn.Click += OnGiveAllBtnClicked;
            // 
            // takeAllBtn
            // 
            takeAllBtn.Location = new Point(6, 159);
            takeAllBtn.Name = "takeAllBtn";
            takeAllBtn.Size = new Size(115, 23);
            takeAllBtn.TabIndex = 7;
            takeAllBtn.Text = "Take All";
            takeAllBtn.UseVisualStyleBackColor = true;
            takeAllBtn.Click += OnTakeAllBtnClicked;
            // 
            // InventoryControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(takeAllBtn);
            Controls.Add(giveAllBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(otherInventoryRadioBtn);
            Controls.Add(selfInventoryRadioBtn);
            Controls.Add(closeInventoryBtn);
            Controls.Add(openInventoryBtn);
            Name = "InventoryControl";
            Size = new Size(491, 300);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button openInventoryBtn;
        private Button closeInventoryBtn;
        private RadioButton selfInventoryRadioBtn;
        private RadioButton otherInventoryRadioBtn;
        private Label label1;
        private Label label2;
        private Button giveAllBtn;
        private Button takeAllBtn;
    }
}
