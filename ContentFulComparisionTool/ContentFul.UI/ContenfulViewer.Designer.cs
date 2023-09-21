namespace ContentFulComparisionTool;

partial class ContenfulViewer
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
        components = new System.ComponentModel.Container();
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(ContenfulViewer));
        var dataGridViewCellStyle3 = new DataGridViewCellStyle();
        var dataGridViewCellStyle4 = new DataGridViewCellStyle();
        collection_dropdown = new ComboBox();
        label1 = new Label();
        groupBox1 = new GroupBox();
        comboBox2 = new ComboBox();
        label5 = new Label();
        label4 = new Label();
        radioButton2 = new RadioButton();
        radioButton1 = new RadioButton();
        label3 = new Label();
        env_dropdown = new ComboBox();
        groupBox2 = new GroupBox();
        search = new Button();
        searchText = new TextBox();
        comboBox1 = new ComboBox();
        label2 = new Label();
        pictureBox3 = new PictureBox();
        contextMenuStrip1 = new ContextMenuStrip(components);
        menuStrip1 = new MenuStrip();
        pictureBox1 = new PictureBox();
        richTextBox1 = new RichTextBox();
        Features = new GroupBox();
        button11 = new Button();
        label9 = new Label();
        btnNotifyTeams = new Button();
        label8 = new Label();
        label7 = new Label();
        pictureBox9 = new PictureBox();
        pictureBox8 = new PictureBox();
        pictureBox7 = new PictureBox();
        pictureBox6 = new PictureBox();
        button10 = new Button();
        button9 = new Button();
        button8 = new Button();
        button7 = new Button();
        button6 = new Button();
        button5 = new Button();
        button4 = new Button();
        button2 = new Button();
        button3 = new Button();
        dataGridView1 = new DataGridView();
        ProgressBar = new PictureBox();
        listView1 = new ListView();
        splitContainer1 = new SplitContainer();
        FundSelectionDropDown = new ComboBox();
        label6 = new Label();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        Features.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)ProgressBar).BeginInit();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        SuspendLayout();
        // 
        // collection_dropdown
        // 
        collection_dropdown.FormattingEnabled = true;
        collection_dropdown.Location = new Point(531, 34);
        collection_dropdown.Margin = new Padding(3, 2, 3, 2);
        collection_dropdown.Name = "collection_dropdown";
        collection_dropdown.Size = new Size(196, 23);
        collection_dropdown.TabIndex = 2;
        collection_dropdown.SelectedIndexChanged += CollectionSelectedIndexChangedAsync;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(417, 36);
        label1.Name = "label1";
        label1.Size = new Size(93, 15);
        label1.TabIndex = 3;
        label1.Text = "CollectionName";
        // 
        // groupBox1
        // 
        groupBox1.BackColor = Color.Silver;
        groupBox1.Controls.Add(comboBox2);
        groupBox1.Controls.Add(label5);
        groupBox1.Controls.Add(label4);
        groupBox1.Controls.Add(radioButton2);
        groupBox1.Controls.Add(radioButton1);
        groupBox1.Controls.Add(label3);
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(env_dropdown);
        groupBox1.Controls.Add(collection_dropdown);
        groupBox1.Location = new Point(115, 12);
        groupBox1.Margin = new Padding(3, 2, 3, 2);
        groupBox1.Name = "groupBox1";
        groupBox1.Padding = new Padding(3, 2, 3, 2);
        groupBox1.Size = new Size(736, 77);
        groupBox1.TabIndex = 6;
        groupBox1.TabStop = false;
        // 
        // comboBox2
        // 
        comboBox2.FormattingEnabled = true;
        comboBox2.Items.AddRange(new object[] { "Apply", "Transfer", "LifeEvents", "Cancel" });
        comboBox2.Location = new Point(531, 10);
        comboBox2.Margin = new Padding(3, 2, 3, 2);
        comboBox2.Name = "comboBox2";
        comboBox2.Size = new Size(200, 23);
        comboBox2.TabIndex = 8;
        comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(266, 20);
        label5.Name = "label5";
        label5.Size = new Size(26, 15);
        label5.TabIndex = 7;
        label5.Text = "Env";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(417, 14);
        label4.Name = "label4";
        label4.Size = new Size(59, 15);
        label4.TabIndex = 6;
        label4.Text = "Microsite ";
        // 
        // radioButton2
        // 
        radioButton2.AutoSize = true;
        radioButton2.Location = new Point(114, 37);
        radioButton2.Margin = new Padding(3, 2, 3, 2);
        radioButton2.Name = "radioButton2";
        radioButton2.Size = new Size(105, 19);
        radioButton2.TabIndex = 5;
        radioButton2.TabStop = true;
        radioButton2.Text = "Content Model";
        radioButton2.UseVisualStyleBackColor = true;
        radioButton2.CheckedChanged += radioButton2_CheckedChanged;
        // 
        // radioButton1
        // 
        radioButton1.AutoSize = true;
        radioButton1.Checked = true;
        radioButton1.Location = new Point(114, 20);
        radioButton1.Margin = new Padding(3, 2, 3, 2);
        radioButton1.Name = "radioButton1";
        radioButton1.Size = new Size(68, 19);
        radioButton1.TabIndex = 4;
        radioButton1.TabStop = true;
        radioButton1.Text = "Content";
        radioButton1.UseVisualStyleBackColor = true;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
        label3.Location = new Point(14, 14);
        label3.Name = "label3";
        label3.Size = new Size(93, 25);
        label3.TabIndex = 2;
        label3.Text = "Compare";
        // 
        // env_dropdown
        // 
        env_dropdown.FormattingEnabled = true;
        env_dropdown.Items.AddRange(new object[] { "All Environments", "Development", "UAT", "Demo" });
        env_dropdown.Location = new Point(309, 17);
        env_dropdown.Margin = new Padding(3, 2, 3, 2);
        env_dropdown.Name = "env_dropdown";
        env_dropdown.Size = new Size(100, 23);
        env_dropdown.TabIndex = 0;
        env_dropdown.SelectedIndexChanged += ComboBox2_SelectedIndexChangedAsync;
        // 
        // groupBox2
        // 
        groupBox2.BackColor = Color.Gainsboro;
        groupBox2.Controls.Add(search);
        groupBox2.Controls.Add(searchText);
        groupBox2.Controls.Add(comboBox1);
        groupBox2.Controls.Add(label2);
        groupBox2.Location = new Point(856, 12);
        groupBox2.Margin = new Padding(3, 2, 3, 2);
        groupBox2.Name = "groupBox2";
        groupBox2.Padding = new Padding(3, 2, 3, 2);
        groupBox2.Size = new Size(524, 51);
        groupBox2.TabIndex = 7;
        groupBox2.TabStop = false;
        // 
        // search
        // 
        search.Location = new Point(319, 26);
        search.Margin = new Padding(3, 2, 3, 2);
        search.Name = "search";
        search.Size = new Size(82, 25);
        search.TabIndex = 16;
        search.Text = "Search";
        search.UseVisualStyleBackColor = true;
        search.Click += search_Click;
        // 
        // searchText
        // 
        searchText.Location = new Point(83, 26);
        searchText.Margin = new Padding(3, 2, 3, 2);
        searchText.Name = "searchText";
        searchText.Size = new Size(225, 23);
        searchText.TabIndex = 15;
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new Point(83, 4);
        comboBox1.Margin = new Padding(3, 2, 3, 2);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(319, 23);
        comboBox1.Sorted = true;
        comboBox1.TabIndex = 14;
        comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChangedAsync;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
        label2.Location = new Point(0, 0);
        label2.Name = "label2";
        label2.Size = new Size(71, 25);
        label2.TabIndex = 1;
        label2.Text = "Search";
        // 
        // pictureBox3
        // 
        pictureBox3.BorderStyle = BorderStyle.Fixed3D;
        pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
        pictureBox3.Location = new Point(144, 340);
        pictureBox3.Margin = new Padding(3, 2, 3, 2);
        pictureBox3.Name = "pictureBox3";
        pictureBox3.Size = new Size(99, 30);
        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox3.TabIndex = 2;
        pictureBox3.TabStop = false;
        pictureBox3.Click += Reset;
        // 
        // contextMenuStrip1
        // 
        contextMenuStrip1.ImageScalingSize = new Size(20, 20);
        contextMenuStrip1.Name = "contextMenuStrip1";
        contextMenuStrip1.Size = new Size(61, 4);
        contextMenuStrip1.Opening += contextMenuStrip1_Opening;
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(20, 20);
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Padding = new Padding(5, 2, 0, 2);
        menuStrip1.Size = new Size(1428, 24);
        menuStrip1.TabIndex = 11;
        menuStrip1.Text = "menuStrip1";
        // 
        // pictureBox1
        // 
        pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
        pictureBox1.Location = new Point(0, 12);
        pictureBox1.Margin = new Padding(3, 2, 3, 2);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(109, 46);
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox1.TabIndex = 12;
        pictureBox1.TabStop = false;
        // 
        // richTextBox1
        // 
        richTextBox1.BackColor = Color.Black;
        richTextBox1.Dock = DockStyle.Fill;
        richTextBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
        richTextBox1.ForeColor = Color.Aquamarine;
        richTextBox1.Location = new Point(0, 0);
        richTextBox1.Margin = new Padding(3, 2, 3, 2);
        richTextBox1.Name = "richTextBox1";
        richTextBox1.Size = new Size(1162, 138);
        richTextBox1.TabIndex = 13;
        richTextBox1.Text = "Here all Errors and status of content comparision or sync will be shown. ";
        // 
        // Features
        // 
        Features.BackColor = Color.Snow;
        Features.Controls.Add(button11);
        Features.Controls.Add(label9);
        Features.Controls.Add(btnNotifyTeams);
        Features.Controls.Add(label8);
        Features.Controls.Add(label7);
        Features.Controls.Add(pictureBox9);
        Features.Controls.Add(pictureBox8);
        Features.Controls.Add(pictureBox7);
        Features.Controls.Add(pictureBox3);
        Features.Controls.Add(pictureBox6);
        Features.Controls.Add(button10);
        Features.Controls.Add(button9);
        Features.Controls.Add(button8);
        Features.Controls.Add(button7);
        Features.Controls.Add(button6);
        Features.Controls.Add(button5);
        Features.Controls.Add(button4);
        Features.Controls.Add(button2);
        Features.Controls.Add(button3);
        Features.Location = new Point(1158, 68);
        Features.Margin = new Padding(3, 2, 3, 2);
        Features.Name = "Features";
        Features.Padding = new Padding(3, 2, 3, 2);
        Features.Size = new Size(270, 501);
        Features.TabIndex = 6;
        Features.TabStop = false;
        Features.Text = "Features";
        // 
        // button11
        // 
        button11.Location = new Point(144, 445);
        button11.Margin = new Padding(3, 2, 3, 2);
        button11.Name = "button11";
        button11.Size = new Size(99, 22);
        button11.TabIndex = 20;
        button11.Text = "Go";
        button11.UseVisualStyleBackColor = true;
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(54, 452);
        label9.Name = "label9";
        label9.Size = new Size(71, 15);
        label9.TabIndex = 19;
        label9.Text = "Sync To UAT";
        // 
        // btnNotifyTeams
        // 
        btnNotifyTeams.Location = new Point(144, 390);
        btnNotifyTeams.Margin = new Padding(3, 2, 3, 2);
        btnNotifyTeams.Name = "btnNotifyTeams";
        btnNotifyTeams.Size = new Size(99, 22);
        btnNotifyTeams.TabIndex = 18;
        btnNotifyTeams.Text = "Post";
        btnNotifyTeams.UseVisualStyleBackColor = true;
        btnNotifyTeams.Click += btnNotifyTeams_ClickAsync;
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(52, 397);
        label8.Name = "label8";
        label8.Size = new Size(76, 15);
        label8.TabIndex = 17;
        label8.Text = "Notify Teams";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(47, 346);
        label7.Name = "label7";
        label7.Size = new Size(83, 15);
        label7.TabIndex = 16;
        label7.Text = "Reset Controls";
        label7.Click += label7_Click;
        // 
        // pictureBox9
        // 
        pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
        pictureBox9.Location = new Point(45, 197);
        pictureBox9.Margin = new Padding(3, 2, 3, 2);
        pictureBox9.Name = "pictureBox9";
        pictureBox9.Size = new Size(38, 26);
        pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox9.TabIndex = 15;
        pictureBox9.TabStop = false;
        // 
        // pictureBox8
        // 
        pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
        pictureBox8.Location = new Point(46, 166);
        pictureBox8.Margin = new Padding(3, 2, 3, 2);
        pictureBox8.Name = "pictureBox8";
        pictureBox8.Size = new Size(46, 22);
        pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox8.TabIndex = 14;
        pictureBox8.TabStop = false;
        // 
        // pictureBox7
        // 
        pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
        pictureBox7.Location = new Point(44, 66);
        pictureBox7.Margin = new Padding(3, 2, 3, 2);
        pictureBox7.Name = "pictureBox7";
        pictureBox7.Size = new Size(46, 28);
        pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox7.TabIndex = 13;
        pictureBox7.TabStop = false;
        // 
        // pictureBox6
        // 
        pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
        pictureBox6.Location = new Point(44, 30);
        pictureBox6.Margin = new Padding(3, 2, 3, 2);
        pictureBox6.Name = "pictureBox6";
        pictureBox6.Size = new Size(35, 32);
        pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox6.TabIndex = 12;
        pictureBox6.TabStop = false;
        // 
        // button10
        // 
        button10.BackColor = Color.BlueViolet;
        button10.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
        button10.Location = new Point(106, 244);
        button10.Margin = new Padding(3, 2, 3, 2);
        button10.Name = "button10";
        button10.Size = new Size(88, 22);
        button10.TabIndex = 11;
        button10.Text = "Export comparision";
        button10.UseVisualStyleBackColor = false;
        // 
        // button9
        // 
        button9.BackColor = Color.BlueViolet;
        button9.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
        button9.Location = new Point(106, 222);
        button9.Margin = new Padding(3, 2, 3, 2);
        button9.Name = "button9";
        button9.Size = new Size(88, 24);
        button9.TabIndex = 10;
        button9.Text = "Audit sync ";
        button9.UseVisualStyleBackColor = false;
        // 
        // button8
        // 
        button8.BackColor = Color.IndianRed;
        button8.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
        button8.Location = new Point(89, 135);
        button8.Margin = new Padding(3, 2, 3, 2);
        button8.Name = "button8";
        button8.Size = new Size(104, 24);
        button8.TabIndex = 9;
        button8.Text = "Create Content";
        button8.UseVisualStyleBackColor = false;
        // 
        // button7
        // 
        button7.BackColor = Color.IndianRed;
        button7.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
        button7.Location = new Point(89, 116);
        button7.Margin = new Padding(3, 2, 3, 2);
        button7.Name = "button7";
        button7.Size = new Size(104, 21);
        button7.TabIndex = 8;
        button7.Text = "Merge Content";
        button7.UseVisualStyleBackColor = false;
        button7.Click += button7_Click;
        // 
        // button6
        // 
        button6.BackColor = Color.IndianRed;
        button6.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
        button6.Location = new Point(89, 95);
        button6.Margin = new Padding(3, 2, 3, 2);
        button6.Name = "button6";
        button6.Size = new Size(104, 20);
        button6.TabIndex = 7;
        button6.Text = "Merge Model";
        button6.UseVisualStyleBackColor = false;
        // 
        // button5
        // 
        button5.BackColor = Color.BlueViolet;
        button5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        button5.Location = new Point(47, 196);
        button5.Margin = new Padding(3, 2, 3, 2);
        button5.Name = "button5";
        button5.Size = new Size(146, 27);
        button5.TabIndex = 6;
        button5.Text = " 4 Audit";
        button5.UseVisualStyleBackColor = false;
        // 
        // button4
        // 
        button4.BackColor = Color.Gold;
        button4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        button4.Location = new Point(47, 163);
        button4.Margin = new Padding(3, 2, 3, 2);
        button4.Name = "button4";
        button4.Size = new Size(146, 30);
        button4.TabIndex = 5;
        button4.Text = "     3 Validate";
        button4.UseVisualStyleBackColor = false;
        // 
        // button2
        // 
        button2.BackColor = Color.GreenYellow;
        button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        button2.Location = new Point(47, 30);
        button2.Margin = new Padding(3, 2, 3, 2);
        button2.Name = "button2";
        button2.Size = new Size(146, 32);
        button2.TabIndex = 3;
        button2.Text = "#1 Compare";
        button2.UseVisualStyleBackColor = false;
        // 
        // button3
        // 
        button3.BackColor = Color.IndianRed;
        button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        button3.Location = new Point(47, 66);
        button3.Margin = new Padding(3, 2, 3, 2);
        button3.Name = "button3";
        button3.Size = new Size(146, 28);
        button3.TabIndex = 4;
        button3.Text = " 2 Sync";
        button3.UseVisualStyleBackColor = false;
        // 
        // dataGridView1
        // 
        dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
        dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
        dataGridView1.BackgroundColor = Color.White;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.GridColor = SystemColors.ButtonHighlight;
        dataGridView1.Location = new Point(6, 46);
        dataGridView1.Margin = new Padding(3, 2, 3, 2);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowHeadersWidth = 200;
        dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
        dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
        dataGridView1.RowTemplate.Height = 29;
        dataGridView1.Size = new Size(1153, 274);
        dataGridView1.TabIndex = 13;
        dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        // 
        // ProgressBar
        // 
        ProgressBar.BackColor = Color.IndianRed;
        ProgressBar.Image = (Image)resources.GetObject("ProgressBar.Image");
        ProgressBar.Location = new Point(627, 16);
        ProgressBar.Margin = new Padding(3, 2, 3, 2);
        ProgressBar.Name = "ProgressBar";
        ProgressBar.Size = new Size(512, 18);
        ProgressBar.SizeMode = PictureBoxSizeMode.StretchImage;
        ProgressBar.TabIndex = 16;
        ProgressBar.TabStop = false;
        // 
        // listView1
        // 
        listView1.ContextMenuStrip = contextMenuStrip1;
        listView1.GridLines = true;
        listView1.Location = new Point(6, 324);
        listView1.Margin = new Padding(3, 2, 3, 2);
        listView1.Name = "listView1";
        listView1.ShowItemToolTips = true;
        listView1.Size = new Size(1154, 35);
        listView1.TabIndex = 1;
        listView1.TileSize = new Size(368, 400);
        listView1.UseCompatibleStateImageBehavior = false;
        listView1.View = View.Tile;
        listView1.MouseUp += listView1_MouseClick;
        // 
        // splitContainer1
        // 
        splitContainer1.Location = new Point(0, 68);
        splitContainer1.Margin = new Padding(3, 2, 3, 2);
        splitContainer1.Name = "splitContainer1";
        splitContainer1.Orientation = Orientation.Horizontal;
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(FundSelectionDropDown);
        splitContainer1.Panel1.Controls.Add(ProgressBar);
        splitContainer1.Panel1.Controls.Add(label6);
        splitContainer1.Panel1.Controls.Add(listView1);
        splitContainer1.Panel1.Controls.Add(dataGridView1);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(richTextBox1);
        splitContainer1.Size = new Size(1162, 503);
        splitContainer1.SplitterDistance = 362;
        splitContainer1.SplitterWidth = 3;
        splitContainer1.TabIndex = 8;
        // 
        // FundSelectionDropDown
        // 
        FundSelectionDropDown.FormattingEnabled = true;
        FundSelectionDropDown.Items.AddRange(new object[] { "-----Select Fund Name ----", "Aware", "GPM", "CBUS" });
        FundSelectionDropDown.Location = new Point(300, 20);
        FundSelectionDropDown.Margin = new Padding(3, 2, 3, 2);
        FundSelectionDropDown.Name = "FundSelectionDropDown";
        FundSelectionDropDown.Size = new Size(197, 23);
        FundSelectionDropDown.TabIndex = 19;
        FundSelectionDropDown.SelectedIndexChanged += FundSelectionDropDown_SelectedIndexChangedAsync;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(10, 22);
        label6.Name = "label6";
        label6.Size = new Size(249, 15);
        label6.TabIndex = 15;
        label6.Text = "Show Differnce for selected fund( DEV vs UAT)";
        // 
        // ContenfulViewer
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1428, 578);
        Controls.Add(Features);
        Controls.Add(splitContainer1);
        Controls.Add(pictureBox1);
        Controls.Add(groupBox1);
        Controls.Add(groupBox2);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Margin = new Padding(3, 2, 3, 2);
        Name = "ContenfulViewer";
        Text = "ContentFul - Comparision tool";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        Features.ResumeLayout(false);
        Features.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ((System.ComponentModel.ISupportInitialize)ProgressBar).EndInit();
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel1.PerformLayout();
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private ComboBox collection_dropdown;
    private Label label1;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private MenuStrip menuStrip1;
    private ContextMenuStrip contextMenuStrip1;
    private PictureBox pictureBox1;
    private RichTextBox richTextBox1;
    private Label label3;
    private ComboBox env_dropdown;
    private Label label2;
    private PictureBox pictureBox3;

    private ComboBox comboBox1;
    private RadioButton radioButton2;
    private RadioButton radioButton1;
    private ComboBox comboBox2;
    private Label label5;
    private Label label4;
    private GroupBox Features;
    private PictureBox pictureBox9;
    private PictureBox pictureBox8;
    private PictureBox pictureBox7;
    private PictureBox pictureBox6;
    private Button button10;
    private Button button9;
    private Button button8;
    private Button button7;
    private Button button6;
    private Button button5;
    private Button button4;
    private Button button2;
    private Button button3;
    private ListView listView1;
    private SplitContainer splitContainer1;
    private DataGridView dataGridView1;
    private Label label6;
    private PictureBox ProgressBar;
    private Button search;
    private TextBox searchText;
    private ComboBox FundSelectionDropDown;
    private Label label7;
    private Button btnNotifyTeams;
    private Label label8;
    private Label label9;
    private Button button11;
    //private EventHandler radioButton5_CheckedChangedAsync;
}
