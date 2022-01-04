
namespace PPM_project
{
    partial class Maintain_Contract
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Maintain_Contract));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtSelect = new System.Windows.Forms.TextBox();
            this.cmbSelect = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNon = new System.Windows.Forms.TextBox();
            this.txtCHK_ETC = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCHK_MM = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTINV_DD = new System.Windows.Forms.TextBox();
            this.txtTINV_MM = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTINV_AMT = new System.Windows.Forms.TextBox();
            this.txtTINV_ETC = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbTINV_CYCLE = new System.Windows.Forms.ComboBox();
            this.txtTINV_TO = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtC_UPDT = new System.Windows.Forms.DateTimePicker();
            this.cmbC_UPTYPE = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbC_STATE = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtC_TITLE = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtC_EDDT = new System.Windows.Forms.DateTimePicker();
            this.txtC_STDT = new System.Windows.Forms.DateTimePicker();
            this.txtC_ETC = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtC_EMP = new System.Windows.Forms.TextBox();
            this.txtC_NM = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbCHK_CYCLE = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbCHK_TYPE = new System.Windows.Forms.ComboBox();
            this.txtCHK_EMP = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.txtSelect);
            this.splitContainer1.Panel1.Controls.Add(this.cmbSelect);
            this.splitContainer1.Panel1.Controls.Add(this.btnSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1542, 827);
            this.splitContainer1.SplitterDistance = 60;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtSelect
            // 
            this.txtSelect.Font = new System.Drawing.Font("굴림", 13F);
            this.txtSelect.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtSelect.Location = new System.Drawing.Point(139, 14);
            this.txtSelect.Name = "txtSelect";
            this.txtSelect.Size = new System.Drawing.Size(324, 32);
            this.txtSelect.TabIndex = 29;
            this.txtSelect.TabStop = false;
            this.txtSelect.Text = "검색 - 고객사, 계약항목";
            this.txtSelect.Click += new System.EventHandler(this.txtSelect_Click);
            this.txtSelect.TextChanged += new System.EventHandler(this.txtSelect_TextChanged);
            this.txtSelect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSelect_KeyDown);
            // 
            // cmbSelect
            // 
            this.cmbSelect.Font = new System.Drawing.Font("굴림", 15F);
            this.cmbSelect.FormattingEnabled = true;
            this.cmbSelect.Items.AddRange(new object[] {
            "계약상태",
            "유효",
            "만료",
            "해지"});
            this.cmbSelect.Location = new System.Drawing.Point(12, 12);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.Size = new System.Drawing.Size(121, 33);
            this.cmbSelect.TabIndex = 27;
            this.cmbSelect.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(469, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 49);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.TabStop = false;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.splitContainer2.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.splitContainer2.Panel2.Controls.Add(this.button4);
            this.splitContainer2.Panel2.Controls.Add(this.button2);
            this.splitContainer2.Panel2.Controls.Add(this.button3);
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(1542, 763);
            this.splitContainer2.SplitterDistance = 530;
            this.splitContainer2.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Window;
            this.listView1.CheckBoxes = true;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(22, 17);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(483, 722);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("굴림", 10F);
            this.button4.Location = new System.Drawing.Point(841, 694);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(139, 45);
            this.button4.TabIndex = 28;
            this.button4.Text = "삭 제";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("굴림", 10F);
            this.button2.Location = new System.Drawing.Point(26, 694);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 45);
            this.button2.TabIndex = 29;
            this.button2.Text = "추 가";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("굴림", 10F);
            this.button3.Location = new System.Drawing.Point(181, 694);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 45);
            this.button3.TabIndex = 27;
            this.button3.Text = "저 장";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.txtNon);
            this.panel1.Controls.Add(this.txtCHK_ETC);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtCHK_MM);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtTINV_DD);
            this.panel1.Controls.Add(this.txtTINV_MM);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtTINV_AMT);
            this.panel1.Controls.Add(this.txtTINV_ETC);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.cmbTINV_CYCLE);
            this.panel1.Controls.Add(this.txtTINV_TO);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.listView2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtC_UPDT);
            this.panel1.Controls.Add(this.cmbC_UPTYPE);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbC_STATE);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtC_TITLE);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtC_EDDT);
            this.panel1.Controls.Add(this.txtC_STDT);
            this.panel1.Controls.Add(this.txtC_ETC);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.txtC_EMP);
            this.panel1.Controls.Add(this.txtC_NM);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.cmbCHK_CYCLE);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.cmbCHK_TYPE);
            this.panel1.Controls.Add(this.txtCHK_EMP);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(26, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(954, 644);
            this.panel1.TabIndex = 0;
            // 
            // txtNon
            // 
            this.txtNon.Font = new System.Drawing.Font("굴림", 9F);
            this.txtNon.Location = new System.Drawing.Point(840, 467);
            this.txtNon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNon.Name = "txtNon";
            this.txtNon.ReadOnly = true;
            this.txtNon.Size = new System.Drawing.Size(82, 25);
            this.txtNon.TabIndex = 121;
            this.txtNon.TabStop = false;
            this.txtNon.Visible = false;
            // 
            // txtCHK_ETC
            // 
            this.txtCHK_ETC.Location = new System.Drawing.Point(519, 541);
            this.txtCHK_ETC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCHK_ETC.Multiline = true;
            this.txtCHK_ETC.Name = "txtCHK_ETC";
            this.txtCHK_ETC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCHK_ETC.Size = new System.Drawing.Size(405, 77);
            this.txtCHK_ETC.TabIndex = 20;
            this.txtCHK_ETC.TextChanged += new System.EventHandler(this.txtCHK_ETC_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(476, 550);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(37, 15);
            this.label23.TabIndex = 119;
            this.label23.Text = "비고";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(584, 501);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 15);
            this.label10.TabIndex = 118;
            this.label10.Text = "점검월";
            // 
            // txtCHK_MM
            // 
            this.txtCHK_MM.Font = new System.Drawing.Font("굴림", 9F);
            this.txtCHK_MM.Location = new System.Drawing.Point(642, 496);
            this.txtCHK_MM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCHK_MM.Name = "txtCHK_MM";
            this.txtCHK_MM.Size = new System.Drawing.Size(280, 25);
            this.txtCHK_MM.TabIndex = 18;
            this.txtCHK_MM.TextChanged += new System.EventHandler(this.txtCHK_MM_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(698, 362);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 15);
            this.label12.TabIndex = 116;
            this.label12.Text = "발행일자";
            // 
            // txtTINV_DD
            // 
            this.txtTINV_DD.Font = new System.Drawing.Font("굴림", 9F);
            this.txtTINV_DD.Location = new System.Drawing.Point(773, 355);
            this.txtTINV_DD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTINV_DD.Name = "txtTINV_DD";
            this.txtTINV_DD.Size = new System.Drawing.Size(151, 25);
            this.txtTINV_DD.TabIndex = 14;
            this.txtTINV_DD.TextChanged += new System.EventHandler(this.txtTINV_DD_TextChanged);
            // 
            // txtTINV_MM
            // 
            this.txtTINV_MM.Font = new System.Drawing.Font("굴림", 9F);
            this.txtTINV_MM.Location = new System.Drawing.Point(374, 354);
            this.txtTINV_MM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTINV_MM.Name = "txtTINV_MM";
            this.txtTINV_MM.Size = new System.Drawing.Size(277, 25);
            this.txtTINV_MM.TabIndex = 13;
            this.txtTINV_MM.TextChanged += new System.EventHandler(this.txtTINV_MM_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 113;
            this.label5.Text = "발행월";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(699, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 112;
            this.label6.Text = "발행금액";
            // 
            // txtTINV_AMT
            // 
            this.txtTINV_AMT.Font = new System.Drawing.Font("굴림", 9F);
            this.txtTINV_AMT.Location = new System.Drawing.Point(773, 321);
            this.txtTINV_AMT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTINV_AMT.Name = "txtTINV_AMT";
            this.txtTINV_AMT.Size = new System.Drawing.Size(151, 25);
            this.txtTINV_AMT.TabIndex = 11;
            this.txtTINV_AMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTINV_AMT.TextChanged += new System.EventHandler(this.txtTINV_AMT_TextChanged);
            // 
            // txtTINV_ETC
            // 
            this.txtTINV_ETC.Location = new System.Drawing.Point(113, 391);
            this.txtTINV_ETC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTINV_ETC.Multiline = true;
            this.txtTINV_ETC.Name = "txtTINV_ETC";
            this.txtTINV_ETC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTINV_ETC.Size = new System.Drawing.Size(809, 48);
            this.txtTINV_ETC.TabIndex = 15;
            this.txtTINV_ETC.TextChanged += new System.EventHandler(this.txtTINV_ETC_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(28, 397);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 15);
            this.label16.TabIndex = 109;
            this.label16.Text = "비고";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(28, 360);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 15);
            this.label17.TabIndex = 108;
            this.label17.Text = "발행주기";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(28, 326);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 15);
            this.label18.TabIndex = 107;
            this.label18.Text = "발행처";
            // 
            // cmbTINV_CYCLE
            // 
            this.cmbTINV_CYCLE.Font = new System.Drawing.Font("굴림", 9F);
            this.cmbTINV_CYCLE.FormattingEnabled = true;
            this.cmbTINV_CYCLE.ItemHeight = 15;
            this.cmbTINV_CYCLE.Items.AddRange(new object[] {
            "매월",
            "분기",
            "반기"});
            this.cmbTINV_CYCLE.Location = new System.Drawing.Point(113, 357);
            this.cmbTINV_CYCLE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTINV_CYCLE.Name = "cmbTINV_CYCLE";
            this.cmbTINV_CYCLE.Size = new System.Drawing.Size(181, 23);
            this.cmbTINV_CYCLE.TabIndex = 12;
            this.cmbTINV_CYCLE.SelectedIndexChanged += new System.EventHandler(this.cmbTINV_CYCLE_SelectedIndexChanged);
            // 
            // txtTINV_TO
            // 
            this.txtTINV_TO.Font = new System.Drawing.Font("굴림", 9F);
            this.txtTINV_TO.Location = new System.Drawing.Point(113, 321);
            this.txtTINV_TO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTINV_TO.Name = "txtTINV_TO";
            this.txtTINV_TO.Size = new System.Drawing.Size(538, 25);
            this.txtTINV_TO.TabIndex = 10;
            this.txtTINV_TO.TextChanged += new System.EventHandler(this.txtTINV_TO_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 11F);
            this.label11.Location = new System.Drawing.Point(4, 281);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(211, 19);
            this.label11.TabIndex = 104;
            this.label11.Text = "◈ 세금계산서 발행정보";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(888, 129);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(34, 22);
            this.button5.TabIndex = 103;
            this.button5.Text = "-";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(847, 129);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 22);
            this.button1.TabIndex = 102;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView2
            // 
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(519, 160);
            this.listView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(405, 107);
            this.listView2.TabIndex = 101;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(516, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 100;
            this.label7.Text = "프로젝트";
            // 
            // txtC_UPDT
            // 
            this.txtC_UPDT.CustomFormat = "yyyy-MM-dd";
            this.txtC_UPDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtC_UPDT.Location = new System.Drawing.Point(625, 87);
            this.txtC_UPDT.Name = "txtC_UPDT";
            this.txtC_UPDT.Size = new System.Drawing.Size(116, 25);
            this.txtC_UPDT.TabIndex = 6;
            this.txtC_UPDT.ValueChanged += new System.EventHandler(this.txtC_UPDT_ValueChanged);
            // 
            // cmbC_UPTYPE
            // 
            this.cmbC_UPTYPE.Font = new System.Drawing.Font("굴림", 9F);
            this.cmbC_UPTYPE.FormattingEnabled = true;
            this.cmbC_UPTYPE.Items.AddRange(new object[] {
            "자동",
            "수동"});
            this.cmbC_UPTYPE.Location = new System.Drawing.Point(847, 91);
            this.cmbC_UPTYPE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbC_UPTYPE.Name = "cmbC_UPTYPE";
            this.cmbC_UPTYPE.Size = new System.Drawing.Size(77, 23);
            this.cmbC_UPTYPE.TabIndex = 7;
            this.cmbC_UPTYPE.SelectedIndexChanged += new System.EventHandler(this.cmbC_UPTYPE_SelectedIndexChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(770, 95);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(67, 15);
            this.label24.TabIndex = 97;
            this.label24.Text = "갱신방식";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(516, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 15);
            this.label9.TabIndex = 96;
            this.label9.Text = "계약일(갱신)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(770, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 95;
            this.label3.Text = "계약상태";
            // 
            // cmbC_STATE
            // 
            this.cmbC_STATE.Font = new System.Drawing.Font("굴림", 9F);
            this.cmbC_STATE.FormattingEnabled = true;
            this.cmbC_STATE.Items.AddRange(new object[] {
            "유효",
            "만료",
            "해지"});
            this.cmbC_STATE.Location = new System.Drawing.Point(847, 51);
            this.cmbC_STATE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbC_STATE.Name = "cmbC_STATE";
            this.cmbC_STATE.Size = new System.Drawing.Size(77, 23);
            this.cmbC_STATE.TabIndex = 3;
            this.cmbC_STATE.SelectedIndexChanged += new System.EventHandler(this.cmbC_STATE_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(381, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 93;
            this.label1.Text = "계약항목";
            // 
            // txtC_TITLE
            // 
            this.txtC_TITLE.Font = new System.Drawing.Font("굴림", 9F);
            this.txtC_TITLE.Location = new System.Drawing.Point(461, 49);
            this.txtC_TITLE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtC_TITLE.Name = "txtC_TITLE";
            this.txtC_TITLE.Size = new System.Drawing.Size(280, 25);
            this.txtC_TITLE.TabIndex = 2;
            this.txtC_TITLE.TextChanged += new System.EventHandler(this.txtC_TITLE_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 15);
            this.label2.TabIndex = 91;
            this.label2.Text = "~";
            // 
            // txtC_EDDT
            // 
            this.txtC_EDDT.CustomFormat = "yyyy-MM-dd";
            this.txtC_EDDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtC_EDDT.Location = new System.Drawing.Point(266, 86);
            this.txtC_EDDT.Name = "txtC_EDDT";
            this.txtC_EDDT.Size = new System.Drawing.Size(95, 25);
            this.txtC_EDDT.TabIndex = 5;
            this.txtC_EDDT.ValueChanged += new System.EventHandler(this.txtC_EDDT_ValueChanged);
            // 
            // txtC_STDT
            // 
            this.txtC_STDT.CustomFormat = "yyyy-MM-dd";
            this.txtC_STDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtC_STDT.Location = new System.Drawing.Point(113, 86);
            this.txtC_STDT.Name = "txtC_STDT";
            this.txtC_STDT.Size = new System.Drawing.Size(104, 25);
            this.txtC_STDT.TabIndex = 4;
            this.txtC_STDT.ValueChanged += new System.EventHandler(this.txtC_STDT_ValueChanged);
            // 
            // txtC_ETC
            // 
            this.txtC_ETC.Location = new System.Drawing.Point(113, 182);
            this.txtC_ETC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtC_ETC.Multiline = true;
            this.txtC_ETC.Name = "txtC_ETC";
            this.txtC_ETC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtC_ETC.Size = new System.Drawing.Size(335, 85);
            this.txtC_ETC.TabIndex = 9;
            this.txtC_ETC.TextChanged += new System.EventHandler(this.txtC_ETC_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(28, 185);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 15);
            this.label19.TabIndex = 88;
            this.label19.Text = "비고";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(28, 129);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 15);
            this.label20.TabIndex = 87;
            this.label20.Text = "계약담당";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(28, 93);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 15);
            this.label21.TabIndex = 86;
            this.label21.Text = "계약기간";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(28, 54);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 15);
            this.label22.TabIndex = 85;
            this.label22.Text = "계약업체";
            // 
            // txtC_EMP
            // 
            this.txtC_EMP.Location = new System.Drawing.Point(113, 126);
            this.txtC_EMP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtC_EMP.Multiline = true;
            this.txtC_EMP.Name = "txtC_EMP";
            this.txtC_EMP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtC_EMP.Size = new System.Drawing.Size(335, 45);
            this.txtC_EMP.TabIndex = 8;
            this.txtC_EMP.TextChanged += new System.EventHandler(this.txtC_EMP_TextChanged);
            // 
            // txtC_NM
            // 
            this.txtC_NM.Font = new System.Drawing.Font("굴림", 9F);
            this.txtC_NM.Location = new System.Drawing.Point(113, 49);
            this.txtC_NM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtC_NM.Name = "txtC_NM";
            this.txtC_NM.Size = new System.Drawing.Size(248, 25);
            this.txtC_NM.TabIndex = 1;
            this.txtC_NM.TextChanged += new System.EventHandler(this.txtC_NM_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(303, 500);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 15);
            this.label15.TabIndex = 81;
            this.label15.Text = "점검주기";
            // 
            // cmbCHK_CYCLE
            // 
            this.cmbCHK_CYCLE.Font = new System.Drawing.Font("굴림", 9F);
            this.cmbCHK_CYCLE.FormattingEnabled = true;
            this.cmbCHK_CYCLE.Items.AddRange(new object[] {
            "매월",
            "분기",
            "반기"});
            this.cmbCHK_CYCLE.Location = new System.Drawing.Point(374, 496);
            this.cmbCHK_CYCLE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCHK_CYCLE.Name = "cmbCHK_CYCLE";
            this.cmbCHK_CYCLE.Size = new System.Drawing.Size(181, 23);
            this.cmbCHK_CYCLE.TabIndex = 17;
            this.cmbCHK_CYCLE.SelectedIndexChanged += new System.EventHandler(this.cmbCHK_CYCLE_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(28, 499);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 15);
            this.label14.TabIndex = 79;
            this.label14.Text = "점검방법";
            // 
            // cmbCHK_TYPE
            // 
            this.cmbCHK_TYPE.Font = new System.Drawing.Font("굴림", 9F);
            this.cmbCHK_TYPE.FormattingEnabled = true;
            this.cmbCHK_TYPE.ItemHeight = 15;
            this.cmbCHK_TYPE.Items.AddRange(new object[] {
            "방문",
            "원격",
            "장애시"});
            this.cmbCHK_TYPE.Location = new System.Drawing.Point(113, 496);
            this.cmbCHK_TYPE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCHK_TYPE.Name = "cmbCHK_TYPE";
            this.cmbCHK_TYPE.Size = new System.Drawing.Size(181, 23);
            this.cmbCHK_TYPE.TabIndex = 16;
            this.cmbCHK_TYPE.SelectedIndexChanged += new System.EventHandler(this.cmbCHK_TYPE_SelectedIndexChanged);
            // 
            // txtCHK_EMP
            // 
            this.txtCHK_EMP.Location = new System.Drawing.Point(99, 541);
            this.txtCHK_EMP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCHK_EMP.Multiline = true;
            this.txtCHK_EMP.Name = "txtCHK_EMP";
            this.txtCHK_EMP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCHK_EMP.Size = new System.Drawing.Size(349, 77);
            this.txtCHK_EMP.TabIndex = 19;
            this.txtCHK_EMP.TextChanged += new System.EventHandler(this.txtCHK_EMP_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 547);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 30);
            this.label13.TabIndex = 76;
            this.label13.Text = " 점검\r\n확인자";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 11F);
            this.label8.Location = new System.Drawing.Point(4, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 19);
            this.label8.TabIndex = 74;
            this.label8.Text = "◈ 계약정보";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 11F);
            this.label4.Location = new System.Drawing.Point(4, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 19);
            this.label4.TabIndex = 75;
            this.label4.Text = "◈ 유지보수 점검정보";
            // 
            // Maintain_Contract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1542, 827);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Maintain_Contract";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "유지보수 계약관리";
            this.Load += new System.EventHandler(this.Maintain_Contract_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtSelect;
        private System.Windows.Forms.ComboBox cmbSelect;
        private System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbCHK_CYCLE;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbCHK_TYPE;
        private System.Windows.Forms.TextBox txtCHK_EMP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbC_STATE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtC_TITLE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtC_EDDT;
        private System.Windows.Forms.DateTimePicker txtC_STDT;
        private System.Windows.Forms.TextBox txtC_ETC;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtC_EMP;
        private System.Windows.Forms.TextBox txtC_NM;
        private System.Windows.Forms.DateTimePicker txtC_UPDT;
        private System.Windows.Forms.ComboBox cmbC_UPTYPE;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTINV_ETC;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbTINV_CYCLE;
        private System.Windows.Forms.TextBox txtTINV_TO;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTINV_DD;
        private System.Windows.Forms.TextBox txtTINV_MM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTINV_AMT;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCHK_MM;
        private System.Windows.Forms.TextBox txtCHK_ETC;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtNon;
    }
}