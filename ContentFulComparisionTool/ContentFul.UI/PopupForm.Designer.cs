namespace ContentFulComparisionTool;

partial class PopupForm
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TaskDropDown = new System.Windows.Forms.ComboBox();
            this.sourcelabel = new System.Windows.Forms.Label();
            this.destinationlabel = new System.Windows.Forms.Label();
            this.SourceDropDown = new System.Windows.Forms.ComboBox();
            this.DestinationDropDown = new System.Windows.Forms.ComboBox();
            this.GoButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ContentModel_dropdown = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(599, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 410);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contentful Sync summary";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(190, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "35 Fields";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "UAT Environment: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "40 Fields";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Dev Environment";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "transferTooltipModelCollection";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Merge Content Model";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Operation:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected Model Id";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Sync Options";
            // 
            // TaskDropDown
            // 
            this.TaskDropDown.FormattingEnabled = true;
            this.TaskDropDown.Items.AddRange(new object[] {
            "Merge Model to UAT (This will Merge only the Model in UAT)",
            "Create Content in UAT (pick a source content from )",
            "Merge Content to UAT (pick source & destination contents )",
            "Delete Content(s) from UAT"});
            this.TaskDropDown.Location = new System.Drawing.Point(122, 51);
            this.TaskDropDown.Name = "TaskDropDown";
            this.TaskDropDown.Size = new System.Drawing.Size(455, 28);
            this.TaskDropDown.TabIndex = 9;
            this.TaskDropDown.SelectedIndexChanged += new System.EventHandler(this.TaskDropDown_SelectedIndexChanged);
            // 
            // sourcelabel
            // 
            this.sourcelabel.AutoSize = true;
            this.sourcelabel.Location = new System.Drawing.Point(10, 32);
            this.sourcelabel.Name = "sourcelabel";
            this.sourcelabel.Size = new System.Drawing.Size(94, 20);
            this.sourcelabel.TabIndex = 10;
            this.sourcelabel.Text = "Source (Dev)";
            // 
            // destinationlabel
            // 
            this.destinationlabel.AutoSize = true;
            this.destinationlabel.Location = new System.Drawing.Point(10, 66);
            this.destinationlabel.Name = "destinationlabel";
            this.destinationlabel.Size = new System.Drawing.Size(133, 20);
            this.destinationlabel.TabIndex = 11;
            this.destinationlabel.Text = "Destination (UAT): ";
            // 
            // SourceDropDown
            // 
            this.SourceDropDown.DropDownHeight = 60;
            this.SourceDropDown.FormattingEnabled = true;
            this.SourceDropDown.IntegralHeight = false;
            this.SourceDropDown.ItemHeight = 20;
            this.SourceDropDown.Items.AddRange(new object[] {
            "Merge Model to UAT (This will Merge only the Model in UAT)",
            "Create Content in UAT (pick a source content from below selection)",
            "Merge Content to UAT (pick source & destination contents from below selection)",
            "Delete Content(s) from UAT"});
            this.SourceDropDown.Location = new System.Drawing.Point(161, 180);
            this.SourceDropDown.Name = "SourceDropDown";
            this.SourceDropDown.Size = new System.Drawing.Size(410, 28);
            this.SourceDropDown.TabIndex = 12;
            // 
            // DestinationDropDown
            // 
            this.DestinationDropDown.DropDownHeight = 60;
            this.DestinationDropDown.FormattingEnabled = true;
            this.DestinationDropDown.IntegralHeight = false;
            this.DestinationDropDown.Items.AddRange(new object[] {
            "Merge Model to UAT (This will Merge only the Model in UAT)",
            "Create Content in UAT (pick a source content from below selection)",
            "Merge Content to UAT (pick source & destination contents from below selection)",
            "Delete Content(s) from UAT"});
            this.DestinationDropDown.Location = new System.Drawing.Point(161, 214);
            this.DestinationDropDown.Name = "DestinationDropDown";
            this.DestinationDropDown.Size = new System.Drawing.Size(410, 28);
            this.DestinationDropDown.TabIndex = 13;
            // 
            // GoButton
            // 
            this.GoButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.GoButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GoButton.Location = new System.Drawing.Point(198, 303);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(94, 29);
            this.GoButton.TabIndex = 14;
            this.GoButton.Text = "Go";
            this.GoButton.UseVisualStyleBackColor = false;
            this.GoButton.Click += new System.EventHandler(this.GoButton_ClickAsync);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.CancelButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CancelButton.Location = new System.Drawing.Point(310, 303);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 29);
            this.CancelButton.TabIndex = 15;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(429, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 16;
            this.button1.Text = "Report";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.sourcelabel);
            this.groupBox2.Controls.Add(this.destinationlabel);
            this.groupBox2.Location = new System.Drawing.Point(12, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(565, 119);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Fund ";
            // 
            // ContentModel_dropdown
            // 
            this.ContentModel_dropdown.FormattingEnabled = true;
            this.ContentModel_dropdown.ItemHeight = 20;
            this.ContentModel_dropdown.Items.AddRange(new object[] {
            "Merge Model to UAT (This will Merge only the Model in UAT)",
            "Create Content in UAT (pick a source content from below selection)",
            "Merge Content to UAT (pick source & destination contents from below selection)",
            "Delete Content(s) from UAT"});
            this.ContentModel_dropdown.Location = new System.Drawing.Point(122, 98);
            this.ContentModel_dropdown.Name = "ContentModel_dropdown";
            this.ContentModel_dropdown.Size = new System.Drawing.Size(455, 28);
            this.ContentModel_dropdown.TabIndex = 18;
            this.ContentModel_dropdown.SelectedIndexChanged += new System.EventHandler(this.ContentModel_dropdown_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "ContentModel";
            // 
            // PopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 450);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ContentModel_dropdown);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.DestinationDropDown);
            this.Controls.Add(this.SourceDropDown);
            this.Controls.Add(this.TaskDropDown);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "PopupForm";
            this.Text = "Contentful UAT Sync";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private GroupBox groupBox1;
    private Label label4;
    private Label label3;
    private Label label2;
    private Label label1;
    private Label label8;
    private Label label7;
    private Label label6;
    private Label label5;
    private Label label9;
    //private ComboBox comboBox1;
    private Label sourcelabel;
    private Label destinationlabel;
    //private ComboBox comboBox2;
    //private ComboBox comboBox3;
   // private Button button1;
   // private Button button2;
    private ComboBox TaskDropDown;
    private ComboBox SourceDropDown;
    private ComboBox DestinationDropDown;
    private Button GoButton;
    private new Button CancelButton;
    private Button button1;
    private GroupBox groupBox2;
    private ComboBox ContentModel_dropdown;
    private Label label10;
}
