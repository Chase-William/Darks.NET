namespace Darks.Desktop.Test.Controls.Job;

partial class BerryFerryJobControl
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
        runJobBtn = new Button();
        label2 = new Label();
        SuspendLayout();
        // 
        // runJobBtn
        // 
        runJobBtn.Location = new Point(12, 41);
        runJobBtn.Name = "runJobBtn";
        runJobBtn.Size = new Size(75, 23);
        runJobBtn.TabIndex = 9;
        runJobBtn.Text = "Run";
        runJobBtn.UseVisualStyleBackColor = true;
        runJobBtn.Click += OnRunBtnClicked;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        label2.Location = new Point(12, 13);
        label2.Name = "label2";
        label2.Size = new Size(150, 25);
        label2.TabIndex = 8;
        label2.Text = "Berry Ferry Job";
        // 
        // BerryFerryJobControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(runJobBtn);
        Controls.Add(label2);
        Name = "BerryFerryJobControl";
        Size = new Size(524, 239);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button runJobBtn;
    private Label label2;
}
