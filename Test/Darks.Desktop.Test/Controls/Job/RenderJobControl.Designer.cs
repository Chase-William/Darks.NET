namespace Darks.Desktop.Test.Controls.Job;

partial class RenderJobControl
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
        runJobBtn = new Button();
        SuspendLayout();
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        label2.Location = new Point(13, 12);
        label2.Name = "label2";
        label2.Size = new Size(113, 25);
        label2.TabIndex = 6;
        label2.Text = "Render Job";
        // 
        // runJobBtn
        // 
        runJobBtn.Location = new Point(13, 40);
        runJobBtn.Name = "runJobBtn";
        runJobBtn.Size = new Size(75, 23);
        runJobBtn.TabIndex = 7;
        runJobBtn.Text = "Run";
        runJobBtn.UseVisualStyleBackColor = true;
        runJobBtn.Click += OnRunBtnClicked;
        // 
        // RenderJobControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(runJobBtn);
        Controls.Add(label2);
        Name = "RenderJobControl";
        Size = new Size(526, 291);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label2;
    private Button runJobBtn;
}
