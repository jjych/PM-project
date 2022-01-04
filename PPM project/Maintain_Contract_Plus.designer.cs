
namespace PPM_project
{
    partial class Maintain_Contract_Plus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Maintain_Contract_Plus));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lstView = new System.Windows.Forms.ListView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtdateTimePicker4 = new System.Windows.Forms.TextBox();
            this.txtdateTimePicker5 = new System.Windows.Forms.TextBox();
            this.txtdateTimePicker6 = new System.Windows.Forms.TextBox();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.txtEtc = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtEmp = new System.Windows.Forms.TextBox();
            this.txtOtherProduct = new System.Windows.Forms.TextBox();
            this.txtPaceProduct = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearch.Font = new System.Drawing.Font("굴림", 12F);
            this.txtSearch.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtSearch.Location = new System.Drawing.Point(43, 27);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(469, 30);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TabStop = false;
            this.txtSearch.Text = "검색 - 고객사, 프로젝트명, 구축부서, 구축담당자";
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lstView
            // 
            this.lstView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstView.CheckBoxes = true;
            this.lstView.FullRowSelect = true;
            this.lstView.GridLines = true;
            this.lstView.HideSelection = false;
            this.lstView.Location = new System.Drawing.Point(12, 87);
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(630, 606);
            this.lstView.TabIndex = 2;
            this.lstView.UseCompatibleStateImageBehavior = false;
            this.lstView.View = System.Windows.Forms.View.Details;
            this.lstView.Click += new System.EventHandler(this.lstView_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(535, 27);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(69, 44);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel2.Controls.Add(this.txtdateTimePicker4);
            this.panel2.Controls.Add(this.txtdateTimePicker5);
            this.panel2.Controls.Add(this.txtdateTimePicker6);
            this.panel2.Controls.Add(this.txtDept);
            this.panel2.Controls.Add(this.txtProductType);
            this.panel2.Controls.Add(this.txtEtc);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.txtEmp);
            this.panel2.Controls.Add(this.txtOtherProduct);
            this.panel2.Controls.Add(this.txtPaceProduct);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtProject);
            this.panel2.Controls.Add(this.txtCustomer);
            this.panel2.Location = new System.Drawing.Point(663, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(537, 621);
            this.panel2.TabIndex = 4;
            // 
            // txtdateTimePicker4
            // 
            this.txtdateTimePicker4.Enabled = false;
            this.txtdateTimePicker4.Location = new System.Drawing.Point(336, 94);
            this.txtdateTimePicker4.Name = "txtdateTimePicker4";
            this.txtdateTimePicker4.ReadOnly = true;
            this.txtdateTimePicker4.Size = new System.Drawing.Size(135, 25);
            this.txtdateTimePicker4.TabIndex = 52;
            // 
            // txtdateTimePicker5
            // 
            this.txtdateTimePicker5.Enabled = false;
            this.txtdateTimePicker5.Location = new System.Drawing.Point(138, 94);
            this.txtdateTimePicker5.Name = "txtdateTimePicker5";
            this.txtdateTimePicker5.ReadOnly = true;
            this.txtdateTimePicker5.Size = new System.Drawing.Size(135, 25);
            this.txtdateTimePicker5.TabIndex = 51;
            // 
            // txtdateTimePicker6
            // 
            this.txtdateTimePicker6.Enabled = false;
            this.txtdateTimePicker6.Location = new System.Drawing.Point(138, 381);
            this.txtdateTimePicker6.Name = "txtdateTimePicker6";
            this.txtdateTimePicker6.ReadOnly = true;
            this.txtdateTimePicker6.Size = new System.Drawing.Size(172, 25);
            this.txtdateTimePicker6.TabIndex = 50;
            // 
            // txtDept
            // 
            this.txtDept.Enabled = false;
            this.txtDept.Location = new System.Drawing.Point(138, 305);
            this.txtDept.Name = "txtDept";
            this.txtDept.ReadOnly = true;
            this.txtDept.Size = new System.Drawing.Size(172, 25);
            this.txtDept.TabIndex = 49;
            // 
            // txtProductType
            // 
            this.txtProductType.Enabled = false;
            this.txtProductType.Location = new System.Drawing.Point(138, 274);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.ReadOnly = true;
            this.txtProductType.Size = new System.Drawing.Size(172, 25);
            this.txtProductType.TabIndex = 48;
            // 
            // txtEtc
            // 
            this.txtEtc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEtc.Enabled = false;
            this.txtEtc.Location = new System.Drawing.Point(138, 420);
            this.txtEtc.Multiline = true;
            this.txtEtc.Name = "txtEtc";
            this.txtEtc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEtc.Size = new System.Drawing.Size(391, 190);
            this.txtEtc.TabIndex = 47;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 420);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 15);
            this.label13.TabIndex = 46;
            this.label13.Text = "비고";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(23, 381);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 15);
            this.label14.TabIndex = 45;
            this.label14.Text = "유지보수시작일";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 344);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 15);
            this.label15.TabIndex = 44;
            this.label15.Text = "구축담당";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(23, 310);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 15);
            this.label16.TabIndex = 43;
            this.label16.Text = "구축부서";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(23, 277);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 15);
            this.label17.TabIndex = 42;
            this.label17.Text = "적용방식";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(23, 242);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 15);
            this.label18.TabIndex = 41;
            this.label18.Text = "외부제품";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(23, 140);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 15);
            this.label19.TabIndex = 40;
            this.label19.Text = "적용제품";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(23, 99);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 15);
            this.label20.TabIndex = 39;
            this.label20.Text = "구축기간";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(23, 61);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(82, 15);
            this.label21.TabIndex = 38;
            this.label21.Text = "프로젝트명";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(23, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 15);
            this.label22.TabIndex = 37;
            this.label22.Text = "고객사명";
            // 
            // txtEmp
            // 
            this.txtEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmp.Enabled = false;
            this.txtEmp.Location = new System.Drawing.Point(138, 339);
            this.txtEmp.Name = "txtEmp";
            this.txtEmp.Size = new System.Drawing.Size(391, 25);
            this.txtEmp.TabIndex = 35;
            // 
            // txtOtherProduct
            // 
            this.txtOtherProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOtherProduct.Enabled = false;
            this.txtOtherProduct.Location = new System.Drawing.Point(138, 237);
            this.txtOtherProduct.Name = "txtOtherProduct";
            this.txtOtherProduct.ReadOnly = true;
            this.txtOtherProduct.Size = new System.Drawing.Size(391, 25);
            this.txtOtherProduct.TabIndex = 32;
            // 
            // txtPaceProduct
            // 
            this.txtPaceProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaceProduct.Enabled = false;
            this.txtPaceProduct.Location = new System.Drawing.Point(138, 136);
            this.txtPaceProduct.Multiline = true;
            this.txtPaceProduct.Name = "txtPaceProduct";
            this.txtPaceProduct.ReadOnly = true;
            this.txtPaceProduct.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPaceProduct.Size = new System.Drawing.Size(391, 86);
            this.txtPaceProduct.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(297, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 15);
            this.label12.TabIndex = 29;
            this.label12.Text = "~";
            // 
            // txtProject
            // 
            this.txtProject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProject.Enabled = false;
            this.txtProject.Location = new System.Drawing.Point(138, 56);
            this.txtProject.Name = "txtProject";
            this.txtProject.ReadOnly = true;
            this.txtProject.Size = new System.Drawing.Size(391, 25);
            this.txtProject.TabIndex = 12;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomer.Enabled = false;
            this.txtCustomer.Location = new System.Drawing.Point(138, 19);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(391, 25);
            this.txtCustomer.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(866, 654);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 45);
            this.button1.TabIndex = 5;
            this.button1.Text = "추가";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1041, 654);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 45);
            this.button2.TabIndex = 6;
            this.button2.Text = "닫기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Maintain_Contract_Plus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1224, 705);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lstView);
            this.Controls.Add(this.txtSearch);
            this.MaximizeBox = false;
            this.Name = "Maintain_Contract_Plus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "프로젝트 추가창";
            this.Load += new System.EventHandler(this.Maintain_Contract_Plus_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        public System.Windows.Forms.ListView lstView;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtEtc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtEmp;
        private System.Windows.Forms.TextBox txtOtherProduct;
        private System.Windows.Forms.TextBox txtPaceProduct;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.TextBox txtProductType;
        private System.Windows.Forms.TextBox txtdateTimePicker6;
        private System.Windows.Forms.TextBox txtdateTimePicker4;
        private System.Windows.Forms.TextBox txtdateTimePicker5;
    }
}