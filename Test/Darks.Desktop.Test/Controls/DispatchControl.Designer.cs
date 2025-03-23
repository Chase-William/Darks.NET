namespace Darks.Desktop.Test.Controls
{
    partial class DispatchControl
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
            pingResponseLbl = new Label();
            button1 = new Button();
            localDispatchRadioBtn = new RadioButton();
            remoteDispatchRadioBtn = new RadioButton();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            enableRenderJob = new CheckBox();
            enableOilJob = new CheckBox();
            enableBerryFerry = new CheckBox();
            enableCratesJob = new CheckBox();
            queueImmediatelyRender = new CheckBox();
            queueImmediatelyOil = new CheckBox();
            queueImmediatelyBerryFerry = new CheckBox();
            queueImmediatelyCrates = new CheckBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(23, 18);
            label2.Name = "label2";
            label2.Size = new Size(127, 25);
            label2.TabIndex = 6;
            label2.Text = "Dispatch Test";
            // 
            // pingResponseLbl
            // 
            pingResponseLbl.AutoSize = true;
            pingResponseLbl.Location = new Point(246, 50);
            pingResponseLbl.Name = "pingResponseLbl";
            pingResponseLbl.Size = new Size(0, 15);
            pingResponseLbl.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new Point(23, 50);
            button1.Name = "button1";
            button1.Size = new Size(127, 23);
            button1.TabIndex = 9;
            button1.Text = "Start Botting";
            button1.UseVisualStyleBackColor = false;
            button1.Click += OnToggleWorkForceJoinedBtnClicked;
            // 
            // localDispatchRadioBtn
            // 
            localDispatchRadioBtn.AutoSize = true;
            localDispatchRadioBtn.Location = new Point(156, 50);
            localDispatchRadioBtn.Name = "localDispatchRadioBtn";
            localDispatchRadioBtn.Size = new Size(102, 19);
            localDispatchRadioBtn.TabIndex = 14;
            localDispatchRadioBtn.TabStop = true;
            localDispatchRadioBtn.Text = "Local Dispatch";
            localDispatchRadioBtn.UseVisualStyleBackColor = true;
            localDispatchRadioBtn.CheckedChanged += OnLocalDispatchRadioBtnValueChanged;
            // 
            // remoteDispatchRadioBtn
            // 
            remoteDispatchRadioBtn.AutoSize = true;
            remoteDispatchRadioBtn.Location = new Point(156, 25);
            remoteDispatchRadioBtn.Name = "remoteDispatchRadioBtn";
            remoteDispatchRadioBtn.Size = new Size(115, 19);
            remoteDispatchRadioBtn.TabIndex = 13;
            remoteDispatchRadioBtn.TabStop = true;
            remoteDispatchRadioBtn.Text = "Remote Dispatch";
            remoteDispatchRadioBtn.UseVisualStyleBackColor = true;
            remoteDispatchRadioBtn.CheckedChanged += OnRemoteDispatchRadioBtnValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 110);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 15;
            label1.Text = "Render";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 135);
            label3.Name = "label3";
            label3.Size = new Size(22, 15);
            label3.TabIndex = 16;
            label3.Text = "Oil";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 159);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 17;
            label4.Text = "Berry Ferry";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 183);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 18;
            label5.Text = "Crates";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 88);
            label6.Name = "label6";
            label6.Size = new Size(33, 15);
            label6.TabIndex = 19;
            label6.Text = "Jobs:";
            // 
            // enableRenderJob
            // 
            enableRenderJob.AutoSize = true;
            enableRenderJob.Location = new Point(111, 109);
            enableRenderJob.Name = "enableRenderJob";
            enableRenderJob.Size = new Size(61, 19);
            enableRenderJob.TabIndex = 20;
            enableRenderJob.Text = "Enable";
            enableRenderJob.UseVisualStyleBackColor = true;
            enableRenderJob.CheckedChanged += OnEnableRenderJob_CheckedChanged;
            // 
            // enableOilJob
            // 
            enableOilJob.AutoSize = true;
            enableOilJob.Location = new Point(111, 134);
            enableOilJob.Name = "enableOilJob";
            enableOilJob.Size = new Size(61, 19);
            enableOilJob.TabIndex = 21;
            enableOilJob.Text = "Enable";
            enableOilJob.UseVisualStyleBackColor = true;
            enableOilJob.CheckedChanged += OnEnableOilJob_CheckedChanged;
            // 
            // enableBerryFerry
            // 
            enableBerryFerry.AutoSize = true;
            enableBerryFerry.Location = new Point(111, 159);
            enableBerryFerry.Name = "enableBerryFerry";
            enableBerryFerry.Size = new Size(61, 19);
            enableBerryFerry.TabIndex = 22;
            enableBerryFerry.Text = "Enable";
            enableBerryFerry.UseVisualStyleBackColor = true;
            enableBerryFerry.CheckedChanged += OnEnableBerryFerry_CheckedChanged;
            // 
            // enableCratesJob
            // 
            enableCratesJob.AutoSize = true;
            enableCratesJob.Location = new Point(111, 182);
            enableCratesJob.Name = "enableCratesJob";
            enableCratesJob.Size = new Size(61, 19);
            enableCratesJob.TabIndex = 23;
            enableCratesJob.Text = "Enable";
            enableCratesJob.UseVisualStyleBackColor = true;
            enableCratesJob.CheckedChanged += OnEnableCratesJob_CheckedChanged;
            // 
            // queueImmediatelyRender
            // 
            queueImmediatelyRender.AutoSize = true;
            queueImmediatelyRender.Location = new Point(178, 109);
            queueImmediatelyRender.Name = "queueImmediatelyRender";
            queueImmediatelyRender.Size = new Size(130, 19);
            queueImmediatelyRender.TabIndex = 24;
            queueImmediatelyRender.Text = "Queue Immediately";
            queueImmediatelyRender.UseVisualStyleBackColor = true;
            // 
            // queueImmediatelyOil
            // 
            queueImmediatelyOil.AutoSize = true;
            queueImmediatelyOil.Location = new Point(178, 134);
            queueImmediatelyOil.Name = "queueImmediatelyOil";
            queueImmediatelyOil.Size = new Size(130, 19);
            queueImmediatelyOil.TabIndex = 25;
            queueImmediatelyOil.Text = "Queue Immediately";
            queueImmediatelyOil.UseVisualStyleBackColor = true;
            // 
            // queueImmediatelyBerryFerry
            // 
            queueImmediatelyBerryFerry.AutoSize = true;
            queueImmediatelyBerryFerry.Location = new Point(178, 159);
            queueImmediatelyBerryFerry.Name = "queueImmediatelyBerryFerry";
            queueImmediatelyBerryFerry.Size = new Size(130, 19);
            queueImmediatelyBerryFerry.TabIndex = 26;
            queueImmediatelyBerryFerry.Text = "Queue Immediately";
            queueImmediatelyBerryFerry.UseVisualStyleBackColor = true;
            // 
            // queueImmediatelyCrates
            // 
            queueImmediatelyCrates.AutoSize = true;
            queueImmediatelyCrates.Location = new Point(178, 183);
            queueImmediatelyCrates.Name = "queueImmediatelyCrates";
            queueImmediatelyCrates.Size = new Size(130, 19);
            queueImmediatelyCrates.TabIndex = 27;
            queueImmediatelyCrates.Text = "Queue Immediately";
            queueImmediatelyCrates.UseVisualStyleBackColor = true;
            // 
            // DispatchControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(queueImmediatelyCrates);
            Controls.Add(queueImmediatelyBerryFerry);
            Controls.Add(queueImmediatelyOil);
            Controls.Add(queueImmediatelyRender);
            Controls.Add(enableCratesJob);
            Controls.Add(enableBerryFerry);
            Controls.Add(enableOilJob);
            Controls.Add(enableRenderJob);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(localDispatchRadioBtn);
            Controls.Add(remoteDispatchRadioBtn);
            Controls.Add(button1);
            Controls.Add(pingResponseLbl);
            Controls.Add(label2);
            Name = "DispatchControl";
            Size = new Size(493, 265);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label pingResponseLbl;
        private Button button1;
        private RadioButton localDispatchRadioBtn;
        private RadioButton remoteDispatchRadioBtn;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private CheckBox enableRenderJob;
        private CheckBox enableOilJob;
        private CheckBox enableBerryFerry;
        private CheckBox enableCratesJob;
        private CheckBox queueImmediatelyRender;
        private CheckBox queueImmediatelyOil;
        private CheckBox queueImmediatelyBerryFerry;
        private CheckBox queueImmediatelyCrates;
    }
}
