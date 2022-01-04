
namespace PPM_project
{
    partial class Tax_bill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tax_bill));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnRe = new System.Windows.Forms.Button();
            this.lstView = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEtc = new System.Windows.Forms.TextBox();
            this.rdoState_1 = new System.Windows.Forms.RadioButton();
            this.rdoState_0 = new System.Windows.Forms.RadioButton();
            this.txtAmt = new System.Windows.Forms.TextBox();
            this.txtDd = new System.Windows.Forms.TextBox();
            this.cmbR_Month = new System.Windows.Forms.ComboBox();
            this.cmbR_Year = new System.Windows.Forms.ComboBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtEddt = new System.Windows.Forms.TextBox();
            this.txtStdt = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtNm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAmt = new System.Windows.Forms.Label();
            this.lblYM = new System.Windows.Forms.Label();
            this.lblR_State = new System.Windows.Forms.Label();
            this.lblDd = new System.Windows.Forms.Label();
            this.lblC_State = new System.Windows.Forms.Label();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNm = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCreateTax = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer2.Panel1.Controls.Add(this.btnRe);
            this.splitContainer2.Panel1.Controls.Add(this.lstView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer2.Panel2.Controls.Add(this.btnModify);
            this.splitContainer2.Size = new System.Drawing.Size(1543, 760);
            this.splitContainer2.SplitterDistance = 674;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnRe
            // 
            this.btnRe.Font = new System.Drawing.Font("굴림", 10F);
            this.btnRe.Location = new System.Drawing.Point(509, 708);
            this.btnRe.Name = "btnRe";
            this.btnRe.Size = new System.Drawing.Size(139, 45);
            this.btnRe.TabIndex = 26;
            this.btnRe.Text = "새로고침";
            this.btnRe.UseVisualStyleBackColor = true;
            this.btnRe.Click += new System.EventHandler(this.btnRe_Click);
            // 
            // lstView
            // 
            this.lstView.HideSelection = false;
            this.lstView.Location = new System.Drawing.Point(27, 15);
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(621, 679);
            this.lstView.TabIndex = 21;
            this.lstView.UseCompatibleStateImageBehavior = false;
            this.lstView.Click += new System.EventHandler(this.lstView_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtEtc);
            this.panel1.Controls.Add(this.rdoState_1);
            this.panel1.Controls.Add(this.rdoState_0);
            this.panel1.Controls.Add(this.txtAmt);
            this.panel1.Controls.Add(this.txtDd);
            this.panel1.Controls.Add(this.cmbR_Month);
            this.panel1.Controls.Add(this.cmbR_Year);
            this.panel1.Controls.Add(this.txtState);
            this.panel1.Controls.Add(this.txtEddt);
            this.panel1.Controls.Add(this.txtStdt);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.txtNm);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblAmt);
            this.panel1.Controls.Add(this.lblYM);
            this.panel1.Controls.Add(this.lblR_State);
            this.panel1.Controls.Add(this.lblDd);
            this.panel1.Controls.Add(this.lblC_State);
            this.panel1.Controls.Add(this.lblPeriod);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.lblNm);
            this.panel1.Location = new System.Drawing.Point(37, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 679);
            this.panel1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F);
            this.label2.Location = new System.Drawing.Point(370, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 76;
            this.label2.Text = "~";
            // 
            // txtEtc
            // 
            this.txtEtc.Font = new System.Drawing.Font("굴림", 10F);
            this.txtEtc.Location = new System.Drawing.Point(168, 496);
            this.txtEtc.Multiline = true;
            this.txtEtc.Name = "txtEtc";
            this.txtEtc.Size = new System.Drawing.Size(585, 158);
            this.txtEtc.TabIndex = 75;
            // 
            // rdoState_1
            // 
            this.rdoState_1.AutoSize = true;
            this.rdoState_1.Font = new System.Drawing.Font("굴림", 10F);
            this.rdoState_1.Location = new System.Drawing.Point(417, 440);
            this.rdoState_1.Name = "rdoState_1";
            this.rdoState_1.Size = new System.Drawing.Size(63, 21);
            this.rdoState_1.TabIndex = 74;
            this.rdoState_1.TabStop = true;
            this.rdoState_1.Text = "발행";
            this.rdoState_1.UseVisualStyleBackColor = true;
            // 
            // rdoState_0
            // 
            this.rdoState_0.AutoSize = true;
            this.rdoState_0.Font = new System.Drawing.Font("굴림", 10F);
            this.rdoState_0.Location = new System.Drawing.Point(168, 446);
            this.rdoState_0.Name = "rdoState_0";
            this.rdoState_0.Size = new System.Drawing.Size(80, 21);
            this.rdoState_0.TabIndex = 73;
            this.rdoState_0.TabStop = true;
            this.rdoState_0.Text = "미발행";
            this.rdoState_0.UseVisualStyleBackColor = true;
            // 
            // txtAmt
            // 
            this.txtAmt.Font = new System.Drawing.Font("굴림", 10F);
            this.txtAmt.Location = new System.Drawing.Point(168, 386);
            this.txtAmt.Multiline = true;
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.Size = new System.Drawing.Size(585, 33);
            this.txtAmt.TabIndex = 72;
            // 
            // txtDd
            // 
            this.txtDd.Font = new System.Drawing.Font("굴림", 10F);
            this.txtDd.Location = new System.Drawing.Point(168, 326);
            this.txtDd.Multiline = true;
            this.txtDd.Name = "txtDd";
            this.txtDd.Size = new System.Drawing.Size(585, 33);
            this.txtDd.TabIndex = 71;
            // 
            // cmbR_Month
            // 
            this.cmbR_Month.Font = new System.Drawing.Font("굴림", 12F);
            this.cmbR_Month.FormattingEnabled = true;
            this.cmbR_Month.Location = new System.Drawing.Point(417, 269);
            this.cmbR_Month.Name = "cmbR_Month";
            this.cmbR_Month.Size = new System.Drawing.Size(181, 28);
            this.cmbR_Month.TabIndex = 70;
            // 
            // cmbR_Year
            // 
            this.cmbR_Year.Font = new System.Drawing.Font("굴림", 12F);
            this.cmbR_Year.FormattingEnabled = true;
            this.cmbR_Year.Location = new System.Drawing.Point(168, 269);
            this.cmbR_Year.Name = "cmbR_Year";
            this.cmbR_Year.Size = new System.Drawing.Size(181, 28);
            this.cmbR_Year.TabIndex = 69;
            // 
            // txtState
            // 
            this.txtState.Enabled = false;
            this.txtState.Font = new System.Drawing.Font("굴림", 10F);
            this.txtState.Location = new System.Drawing.Point(168, 212);
            this.txtState.Multiline = true;
            this.txtState.Name = "txtState";
            this.txtState.ReadOnly = true;
            this.txtState.Size = new System.Drawing.Size(585, 33);
            this.txtState.TabIndex = 68;
            // 
            // txtEddt
            // 
            this.txtEddt.Enabled = false;
            this.txtEddt.Font = new System.Drawing.Font("굴림", 10F);
            this.txtEddt.Location = new System.Drawing.Point(417, 151);
            this.txtEddt.Multiline = true;
            this.txtEddt.Name = "txtEddt";
            this.txtEddt.ReadOnly = true;
            this.txtEddt.Size = new System.Drawing.Size(181, 33);
            this.txtEddt.TabIndex = 67;
            // 
            // txtStdt
            // 
            this.txtStdt.Enabled = false;
            this.txtStdt.Font = new System.Drawing.Font("굴림", 10F);
            this.txtStdt.Location = new System.Drawing.Point(168, 151);
            this.txtStdt.Multiline = true;
            this.txtStdt.Name = "txtStdt";
            this.txtStdt.ReadOnly = true;
            this.txtStdt.Size = new System.Drawing.Size(181, 33);
            this.txtStdt.TabIndex = 66;
            // 
            // txtTitle
            // 
            this.txtTitle.Enabled = false;
            this.txtTitle.Font = new System.Drawing.Font("굴림", 10F);
            this.txtTitle.Location = new System.Drawing.Point(168, 93);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(585, 33);
            this.txtTitle.TabIndex = 65;
            // 
            // txtNm
            // 
            this.txtNm.Enabled = false;
            this.txtNm.Font = new System.Drawing.Font("굴림", 10F);
            this.txtNm.Location = new System.Drawing.Point(168, 32);
            this.txtNm.Multiline = true;
            this.txtNm.Name = "txtNm";
            this.txtNm.ReadOnly = true;
            this.txtNm.Size = new System.Drawing.Size(585, 33);
            this.txtNm.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F);
            this.label1.Location = new System.Drawing.Point(28, 503);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 63;
            this.label1.Text = "비고";
            // 
            // lblAmt
            // 
            this.lblAmt.AutoSize = true;
            this.lblAmt.Font = new System.Drawing.Font("굴림", 12F);
            this.lblAmt.Location = new System.Drawing.Point(28, 393);
            this.lblAmt.Name = "lblAmt";
            this.lblAmt.Size = new System.Drawing.Size(89, 20);
            this.lblAmt.TabIndex = 62;
            this.lblAmt.Text = "발행금액";
            // 
            // lblYM
            // 
            this.lblYM.AutoSize = true;
            this.lblYM.Font = new System.Drawing.Font("굴림", 12F);
            this.lblYM.Location = new System.Drawing.Point(28, 273);
            this.lblYM.Name = "lblYM";
            this.lblYM.Size = new System.Drawing.Size(89, 20);
            this.lblYM.TabIndex = 61;
            this.lblYM.Text = "발행연월";
            // 
            // lblR_State
            // 
            this.lblR_State.AutoSize = true;
            this.lblR_State.Font = new System.Drawing.Font("굴림", 12F);
            this.lblR_State.Location = new System.Drawing.Point(28, 446);
            this.lblR_State.Name = "lblR_State";
            this.lblR_State.Size = new System.Drawing.Size(89, 20);
            this.lblR_State.TabIndex = 60;
            this.lblR_State.Text = "발행상태";
            // 
            // lblDd
            // 
            this.lblDd.AutoSize = true;
            this.lblDd.Font = new System.Drawing.Font("굴림", 12F);
            this.lblDd.Location = new System.Drawing.Point(28, 331);
            this.lblDd.Name = "lblDd";
            this.lblDd.Size = new System.Drawing.Size(89, 20);
            this.lblDd.TabIndex = 59;
            this.lblDd.Text = "발행일자";
            // 
            // lblC_State
            // 
            this.lblC_State.AutoSize = true;
            this.lblC_State.Font = new System.Drawing.Font("굴림", 12F);
            this.lblC_State.Location = new System.Drawing.Point(28, 216);
            this.lblC_State.Name = "lblC_State";
            this.lblC_State.Size = new System.Drawing.Size(89, 20);
            this.lblC_State.TabIndex = 58;
            this.lblC_State.Text = "계약상태";
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Font = new System.Drawing.Font("굴림", 12F);
            this.lblPeriod.Location = new System.Drawing.Point(28, 157);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(89, 20);
            this.lblPeriod.TabIndex = 57;
            this.lblPeriod.Text = "계약기간";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 12F);
            this.lblTitle.Location = new System.Drawing.Point(28, 99);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(89, 20);
            this.lblTitle.TabIndex = 56;
            this.lblTitle.Text = "계약항목";
            // 
            // lblNm
            // 
            this.lblNm.AutoSize = true;
            this.lblNm.Font = new System.Drawing.Font("굴림", 12F);
            this.lblNm.Location = new System.Drawing.Point(28, 39);
            this.lblNm.Name = "lblNm";
            this.lblNm.Size = new System.Drawing.Size(89, 20);
            this.lblNm.TabIndex = 55;
            this.lblNm.Text = "계약업체";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("굴림", 10F);
            this.btnDelete.Location = new System.Drawing.Point(688, 708);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(139, 45);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "삭 제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.Font = new System.Drawing.Font("굴림", 10F);
            this.btnModify.Location = new System.Drawing.Point(540, 708);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(139, 45);
            this.btnModify.TabIndex = 24;
            this.btnModify.Text = "저 장";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // cmbYear
            // 
            this.cmbYear.Font = new System.Drawing.Font("굴림", 10F);
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(27, 21);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(74, 25);
            this.cmbYear.TabIndex = 22;
            this.cmbYear.TabStop = false;
            // 
            // cmbMonth
            // 
            this.cmbMonth.Font = new System.Drawing.Font("굴림", 10F);
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbMonth.Location = new System.Drawing.Point(107, 21);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(74, 25);
            this.cmbMonth.TabIndex = 23;
            this.cmbMonth.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("굴림", 10F);
            this.txtSearch.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtSearch.Location = new System.Drawing.Point(187, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(257, 27);
            this.txtSearch.TabIndex = 24;
            this.txtSearch.TabStop = false;
            this.txtSearch.Text = "검색 - 고객사, 프로젝트명";
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(450, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(53, 35);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCreateTax
            // 
            this.btnCreateTax.Font = new System.Drawing.Font("굴림", 10F);
            this.btnCreateTax.Location = new System.Drawing.Point(509, 14);
            this.btnCreateTax.Name = "btnCreateTax";
            this.btnCreateTax.Size = new System.Drawing.Size(139, 35);
            this.btnCreateTax.TabIndex = 26;
            this.btnCreateTax.TabStop = false;
            this.btnCreateTax.Text = "발행대장 생성";
            this.btnCreateTax.UseVisualStyleBackColor = true;
            this.btnCreateTax.Click += new System.EventHandler(this.btnCreateTax_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.btnCreateTax);
            this.splitContainer1.Panel1.Controls.Add(this.cmbYear);
            this.splitContainer1.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel1.Controls.Add(this.cmbMonth);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1543, 828);
            this.splitContainer1.SplitterDistance = 64;
            this.splitContainer1.TabIndex = 1;
            // 
            // Tax_bill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1543, 828);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Tax_bill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "세금계산서 발행대장";
            this.Load += new System.EventHandler(this.Tax_bill_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnRe;
        private System.Windows.Forms.Button btnCreateTax;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.ListView lstView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEtc;
        private System.Windows.Forms.RadioButton rdoState_1;
        private System.Windows.Forms.RadioButton rdoState_0;
        private System.Windows.Forms.TextBox txtAmt;
        private System.Windows.Forms.TextBox txtDd;
        private System.Windows.Forms.ComboBox cmbR_Month;
        private System.Windows.Forms.ComboBox cmbR_Year;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtEddt;
        private System.Windows.Forms.TextBox txtStdt;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtNm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAmt;
        private System.Windows.Forms.Label lblYM;
        private System.Windows.Forms.Label lblR_State;
        private System.Windows.Forms.Label lblDd;
        private System.Windows.Forms.Label lblC_State;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNm;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}