
using System;

namespace PPM_project
{
    partial class Project
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Project));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lstView = new System.Windows.Forms.ListView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.datePrj_stdt = new System.Windows.Forms.DateTimePicker();
            this.txtNonVisableKey = new System.Windows.Forms.TextBox();
            this.txtPrj_etc = new System.Windows.Forms.TextBox();
            this.dateMaint_stdt = new System.Windows.Forms.DateTimePicker();
            this.txtPrj_emp = new System.Windows.Forms.TextBox();
            this.cmbPrj_dept = new System.Windows.Forms.ComboBox();
            this.cmbProduct_type = new System.Windows.Forms.ComboBox();
            this.txtEx_product = new System.Windows.Forms.TextBox();
            this.txtPace_product = new System.Windows.Forms.TextBox();
            this.datePrj_eddt = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPrg_nm = new System.Windows.Forms.TextBox();
            this.txtCust_nm = new System.Windows.Forms.TextBox();
            this.lblPrj_etc = new System.Windows.Forms.Label();
            this.lblMaint_stdt = new System.Windows.Forms.Label();
            this.lblPrj_emp = new System.Windows.Forms.Label();
            this.lblPrj_dept = new System.Windows.Forms.Label();
            this.lblProduct_type = new System.Windows.Forms.Label();
            this.lblEx_product = new System.Windows.Forms.Label();
            this.lblPace_product = new System.Windows.Forms.Label();
            this.lblPrj_stdt = new System.Windows.Forms.Label();
            this.lblPrj_nm = new System.Windows.Forms.Label();
            this.lblCust_nm = new System.Windows.Forms.Label();
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
            this.splitContainer1.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1544, 828);
            this.splitContainer1.SplitterDistance = 69;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(548, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 50);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("굴림", 12F);
            this.txtSearch.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtSearch.Location = new System.Drawing.Point(79, 21);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(463, 30);
            this.txtSearch.TabIndex = 26;
            this.txtSearch.TabStop = false;
            this.txtSearch.Text = "검색 - 고객사,프로젝트명";
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
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
            this.splitContainer2.Panel1.Controls.Add(this.lstView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.splitContainer2.Panel2.Controls.Add(this.btnClear);
            this.splitContainer2.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer2.Panel2.Controls.Add(this.btnSave);
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(1544, 755);
            this.splitContainer2.SplitterDistance = 651;
            this.splitContainer2.TabIndex = 0;
            // 
            // lstView
            // 
            this.lstView.CheckBoxes = true;
            this.lstView.FullRowSelect = true;
            this.lstView.GridLines = true;
            this.lstView.HideSelection = false;
            this.lstView.Location = new System.Drawing.Point(21, 27);
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(611, 716);
            this.lstView.TabIndex = 2;
            this.lstView.UseCompatibleStateImageBehavior = false;
            this.lstView.View = System.Windows.Forms.View.Details;
            this.lstView.Click += new System.EventHandler(this.lstView_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("굴림", 10F);
            this.btnClear.Location = new System.Drawing.Point(31, 674);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(139, 45);
            this.btnClear.TabIndex = 28;
            this.btnClear.Text = "추 가";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("굴림", 10F);
            this.btnDelete.Location = new System.Drawing.Point(727, 674);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(139, 45);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "삭 제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("굴림", 10F);
            this.btnSave.Location = new System.Drawing.Point(176, 674);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 45);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "저 장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.datePrj_stdt);
            this.panel1.Controls.Add(this.txtNonVisableKey);
            this.panel1.Controls.Add(this.txtPrj_etc);
            this.panel1.Controls.Add(this.dateMaint_stdt);
            this.panel1.Controls.Add(this.txtPrj_emp);
            this.panel1.Controls.Add(this.cmbPrj_dept);
            this.panel1.Controls.Add(this.cmbProduct_type);
            this.panel1.Controls.Add(this.txtEx_product);
            this.panel1.Controls.Add(this.txtPace_product);
            this.panel1.Controls.Add(this.datePrj_eddt);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtPrg_nm);
            this.panel1.Controls.Add(this.txtCust_nm);
            this.panel1.Controls.Add(this.lblPrj_etc);
            this.panel1.Controls.Add(this.lblMaint_stdt);
            this.panel1.Controls.Add(this.lblPrj_emp);
            this.panel1.Controls.Add(this.lblPrj_dept);
            this.panel1.Controls.Add(this.lblProduct_type);
            this.panel1.Controls.Add(this.lblEx_product);
            this.panel1.Controls.Add(this.lblPace_product);
            this.panel1.Controls.Add(this.lblPrj_stdt);
            this.panel1.Controls.Add(this.lblPrj_nm);
            this.panel1.Controls.Add(this.lblCust_nm);
            this.panel1.Location = new System.Drawing.Point(30, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(836, 631);
            this.panel1.TabIndex = 0;
            // 
            // datePrj_stdt
            // 
            this.datePrj_stdt.Font = new System.Drawing.Font("굴림", 10F);
            this.datePrj_stdt.Location = new System.Drawing.Point(180, 125);
            this.datePrj_stdt.Name = "datePrj_stdt";
            this.datePrj_stdt.Size = new System.Drawing.Size(225, 27);
            this.datePrj_stdt.TabIndex = 69;
            // 
            // txtNonVisableKey
            // 
            this.txtNonVisableKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNonVisableKey.Font = new System.Drawing.Font("굴림", 10F);
            this.txtNonVisableKey.Location = new System.Drawing.Point(179, 437);
            this.txtNonVisableKey.Name = "txtNonVisableKey";
            this.txtNonVisableKey.ReadOnly = true;
            this.txtNonVisableKey.Size = new System.Drawing.Size(309, 27);
            this.txtNonVisableKey.TabIndex = 68;
            this.txtNonVisableKey.Visible = false;
            // 
            // txtPrj_etc
            // 
            this.txtPrj_etc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrj_etc.Font = new System.Drawing.Font("굴림", 10F);
            this.txtPrj_etc.Location = new System.Drawing.Point(180, 542);
            this.txtPrj_etc.Multiline = true;
            this.txtPrj_etc.Name = "txtPrj_etc";
            this.txtPrj_etc.Size = new System.Drawing.Size(610, 71);
            this.txtPrj_etc.TabIndex = 67;
            this.txtPrj_etc.TextChanged += new System.EventHandler(this.txtPrj_etc_TextChanged);
            // 
            // dateMaint_stdt
            // 
            this.dateMaint_stdt.Font = new System.Drawing.Font("굴림", 10F);
            this.dateMaint_stdt.Location = new System.Drawing.Point(180, 502);
            this.dateMaint_stdt.Name = "dateMaint_stdt";
            this.dateMaint_stdt.Size = new System.Drawing.Size(225, 27);
            this.dateMaint_stdt.TabIndex = 66;
            // 
            // txtPrj_emp
            // 
            this.txtPrj_emp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrj_emp.Font = new System.Drawing.Font("굴림", 10F);
            this.txtPrj_emp.Location = new System.Drawing.Point(180, 462);
            this.txtPrj_emp.Name = "txtPrj_emp";
            this.txtPrj_emp.Size = new System.Drawing.Size(610, 27);
            this.txtPrj_emp.TabIndex = 65;
            this.txtPrj_emp.TextChanged += new System.EventHandler(this.txtPrj_emp_TextChanged);
            // 
            // cmbPrj_dept
            // 
            this.cmbPrj_dept.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrj_dept.Font = new System.Drawing.Font("굴림", 10F);
            this.cmbPrj_dept.FormattingEnabled = true;
            this.cmbPrj_dept.Items.AddRange(new object[] {
            "솔루션",
            "모바일",
            "연구소"});
            this.cmbPrj_dept.Location = new System.Drawing.Point(180, 393);
            this.cmbPrj_dept.Name = "cmbPrj_dept";
            this.cmbPrj_dept.Size = new System.Drawing.Size(366, 25);
            this.cmbPrj_dept.TabIndex = 64;
            this.cmbPrj_dept.SelectedIndexChanged += new System.EventHandler(this.cmbPrj_dept_SelectedIndexChanged);
            // 
            // cmbProduct_type
            // 
            this.cmbProduct_type.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProduct_type.Font = new System.Drawing.Font("굴림", 10F);
            this.cmbProduct_type.FormattingEnabled = true;
            this.cmbProduct_type.Items.AddRange(new object[] {
            "PC",
            "서버",
            "모바일",
            "모듈"});
            this.cmbProduct_type.Location = new System.Drawing.Point(179, 345);
            this.cmbProduct_type.Name = "cmbProduct_type";
            this.cmbProduct_type.Size = new System.Drawing.Size(366, 25);
            this.cmbProduct_type.TabIndex = 63;
            this.cmbProduct_type.SelectedIndexChanged += new System.EventHandler(this.cmbProduct_type_SelectedIndexChanged);
            // 
            // txtEx_product
            // 
            this.txtEx_product.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEx_product.Font = new System.Drawing.Font("굴림", 10F);
            this.txtEx_product.Location = new System.Drawing.Point(179, 291);
            this.txtEx_product.Name = "txtEx_product";
            this.txtEx_product.Size = new System.Drawing.Size(611, 27);
            this.txtEx_product.TabIndex = 62;
            this.txtEx_product.TextChanged += new System.EventHandler(this.txtEx_product_TextChanged);
            // 
            // txtPace_product
            // 
            this.txtPace_product.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPace_product.Font = new System.Drawing.Font("굴림", 10F);
            this.txtPace_product.Location = new System.Drawing.Point(179, 181);
            this.txtPace_product.Multiline = true;
            this.txtPace_product.Name = "txtPace_product";
            this.txtPace_product.Size = new System.Drawing.Size(611, 86);
            this.txtPace_product.TabIndex = 61;
            this.txtPace_product.TextChanged += new System.EventHandler(this.txtPace_product_TextChanged);
            // 
            // datePrj_eddt
            // 
            this.datePrj_eddt.Font = new System.Drawing.Font("굴림", 10F);
            this.datePrj_eddt.Location = new System.Drawing.Point(468, 125);
            this.datePrj_eddt.Name = "datePrj_eddt";
            this.datePrj_eddt.Size = new System.Drawing.Size(224, 27);
            this.datePrj_eddt.TabIndex = 60;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(425, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 15);
            this.label12.TabIndex = 59;
            this.label12.Text = "~";
            // 
            // txtPrg_nm
            // 
            this.txtPrg_nm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrg_nm.Font = new System.Drawing.Font("굴림", 10F);
            this.txtPrg_nm.Location = new System.Drawing.Point(180, 75);
            this.txtPrg_nm.Name = "txtPrg_nm";
            this.txtPrg_nm.Size = new System.Drawing.Size(610, 27);
            this.txtPrg_nm.TabIndex = 58;
            this.txtPrg_nm.TextChanged += new System.EventHandler(this.txtPrg_nm_TextChanged);
            // 
            // txtCust_nm
            // 
            this.txtCust_nm.Font = new System.Drawing.Font("굴림", 10F);
            this.txtCust_nm.Location = new System.Drawing.Point(179, 24);
            this.txtCust_nm.Name = "txtCust_nm";
            this.txtCust_nm.Size = new System.Drawing.Size(611, 27);
            this.txtCust_nm.TabIndex = 57;
            this.txtCust_nm.TextChanged += new System.EventHandler(this.txtCust_nm_TextChanged);
            // 
            // lblPrj_etc
            // 
            this.lblPrj_etc.AutoSize = true;
            this.lblPrj_etc.Font = new System.Drawing.Font("굴림", 12F);
            this.lblPrj_etc.Location = new System.Drawing.Point(40, 552);
            this.lblPrj_etc.Name = "lblPrj_etc";
            this.lblPrj_etc.Size = new System.Drawing.Size(49, 20);
            this.lblPrj_etc.TabIndex = 56;
            this.lblPrj_etc.Text = "비고";
            // 
            // lblMaint_stdt
            // 
            this.lblMaint_stdt.AutoSize = true;
            this.lblMaint_stdt.Font = new System.Drawing.Font("굴림", 12F);
            this.lblMaint_stdt.Location = new System.Drawing.Point(30, 491);
            this.lblMaint_stdt.Name = "lblMaint_stdt";
            this.lblMaint_stdt.Size = new System.Drawing.Size(89, 40);
            this.lblMaint_stdt.TabIndex = 55;
            this.lblMaint_stdt.Text = "유지보수\r\n 시작일";
            // 
            // lblPrj_emp
            // 
            this.lblPrj_emp.AutoSize = true;
            this.lblPrj_emp.Font = new System.Drawing.Font("굴림", 12F);
            this.lblPrj_emp.Location = new System.Drawing.Point(28, 438);
            this.lblPrj_emp.Name = "lblPrj_emp";
            this.lblPrj_emp.Size = new System.Drawing.Size(89, 20);
            this.lblPrj_emp.TabIndex = 54;
            this.lblPrj_emp.Text = "구축담당";
            // 
            // lblPrj_dept
            // 
            this.lblPrj_dept.AutoSize = true;
            this.lblPrj_dept.Font = new System.Drawing.Font("굴림", 12F);
            this.lblPrj_dept.Location = new System.Drawing.Point(28, 396);
            this.lblPrj_dept.Name = "lblPrj_dept";
            this.lblPrj_dept.Size = new System.Drawing.Size(89, 20);
            this.lblPrj_dept.TabIndex = 53;
            this.lblPrj_dept.Text = "구축부서";
            // 
            // lblProduct_type
            // 
            this.lblProduct_type.AutoSize = true;
            this.lblProduct_type.Font = new System.Drawing.Font("굴림", 12F);
            this.lblProduct_type.Location = new System.Drawing.Point(30, 345);
            this.lblProduct_type.Name = "lblProduct_type";
            this.lblProduct_type.Size = new System.Drawing.Size(89, 20);
            this.lblProduct_type.TabIndex = 52;
            this.lblProduct_type.Text = "적용방식";
            // 
            // lblEx_product
            // 
            this.lblEx_product.AutoSize = true;
            this.lblEx_product.Font = new System.Drawing.Font("굴림", 12F);
            this.lblEx_product.Location = new System.Drawing.Point(30, 294);
            this.lblEx_product.Name = "lblEx_product";
            this.lblEx_product.Size = new System.Drawing.Size(89, 20);
            this.lblEx_product.TabIndex = 51;
            this.lblEx_product.Text = "외부제품";
            // 
            // lblPace_product
            // 
            this.lblPace_product.AutoSize = true;
            this.lblPace_product.Font = new System.Drawing.Font("굴림", 12F);
            this.lblPace_product.Location = new System.Drawing.Point(28, 181);
            this.lblPace_product.Name = "lblPace_product";
            this.lblPace_product.Size = new System.Drawing.Size(89, 20);
            this.lblPace_product.TabIndex = 50;
            this.lblPace_product.Text = "적용제품";
            // 
            // lblPrj_stdt
            // 
            this.lblPrj_stdt.AutoSize = true;
            this.lblPrj_stdt.Font = new System.Drawing.Font("굴림", 12F);
            this.lblPrj_stdt.Location = new System.Drawing.Point(28, 132);
            this.lblPrj_stdt.Name = "lblPrj_stdt";
            this.lblPrj_stdt.Size = new System.Drawing.Size(89, 20);
            this.lblPrj_stdt.TabIndex = 49;
            this.lblPrj_stdt.Text = "구축기간";
            // 
            // lblPrj_nm
            // 
            this.lblPrj_nm.AutoSize = true;
            this.lblPrj_nm.Font = new System.Drawing.Font("굴림", 12F);
            this.lblPrj_nm.Location = new System.Drawing.Point(28, 82);
            this.lblPrj_nm.Name = "lblPrj_nm";
            this.lblPrj_nm.Size = new System.Drawing.Size(109, 20);
            this.lblPrj_nm.TabIndex = 48;
            this.lblPrj_nm.Text = "프로젝트명";
            // 
            // lblCust_nm
            // 
            this.lblCust_nm.AutoSize = true;
            this.lblCust_nm.Font = new System.Drawing.Font("굴림", 12F);
            this.lblCust_nm.Location = new System.Drawing.Point(28, 31);
            this.lblCust_nm.Name = "lblCust_nm";
            this.lblCust_nm.Size = new System.Drawing.Size(89, 20);
            this.lblCust_nm.TabIndex = 47;
            this.lblCust_nm.Text = "고객사명";
            // 
            // Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1544, 828);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "Project";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "프로젝트 관리";
            this.Load += new System.EventHandler(this.Project_Load);
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

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ListView lstView;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblPrj_etc;
        private System.Windows.Forms.Label lblMaint_stdt;
        private System.Windows.Forms.Label lblPrj_emp;
        private System.Windows.Forms.Label lblPrj_dept;
        private System.Windows.Forms.Label lblProduct_type;
        private System.Windows.Forms.Label lblEx_product;
        private System.Windows.Forms.Label lblPace_product;
        private System.Windows.Forms.Label lblPrj_stdt;
        private System.Windows.Forms.Label lblPrj_nm;
        private System.Windows.Forms.Label lblCust_nm;
        private System.Windows.Forms.DateTimePicker datePrj_stdt;
        private System.Windows.Forms.TextBox txtNonVisableKey;
        private System.Windows.Forms.TextBox txtPrj_etc;
        private System.Windows.Forms.DateTimePicker dateMaint_stdt;
        private System.Windows.Forms.TextBox txtPrj_emp;
        private System.Windows.Forms.ComboBox cmbPrj_dept;
        private System.Windows.Forms.ComboBox cmbProduct_type;
        private System.Windows.Forms.TextBox txtEx_product;
        private System.Windows.Forms.TextBox txtPace_product;
        private System.Windows.Forms.DateTimePicker datePrj_eddt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPrg_nm;
        private System.Windows.Forms.TextBox txtCust_nm;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
    }
}
#endregion