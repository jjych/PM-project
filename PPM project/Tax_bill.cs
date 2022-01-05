using PPM_project.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPM_project
{
    public partial class Tax_bill : Form
    {
        #region 전역
        //세금계산서 발행대장 테이블 전체 출력을 위한 리스트
        List<Dictionary<String, object>> ShowTax = new List<Dictionary<string, object>>();
        // 세금계산서 발행대장 세부 데이터들 출력을 위한 리스트
        List<Dictionary<String, object>> ShowTaxInfo = new List<Dictionary<string, object>>();
        #endregion

        #region 폼
        public Tax_bill()
        {
            InitializeComponent();
            cmbYear.Text = DateTime.Now.ToString("yyyy");
            cmbMonth.Text = DateTime.Now.ToString("MM");
        }
        #endregion

        #region ListView 설정
        private void Set_ListView()
        {
            //화면 설정
            lstView.View = View.Details;
            //구분선 표시설정
            lstView.GridLines = true;
            //한줄씩 선택 설정
            lstView.FullRowSelect = true;
            //Clouumn 추가
            lstView.Columns.Add("CheckBox", "", 0, HorizontalAlignment.Center, 0);
            lstView.Columns.Add("No", 35, HorizontalAlignment.Center);
            lstView.Columns.Add("계약항목", 100, HorizontalAlignment.Center);
            lstView.Columns.Add("발행연도", 120, HorizontalAlignment.Center);
            lstView.Columns.Add("발행월", 80, HorizontalAlignment.Center);
            lstView.Columns.Add("발행일", 100, HorizontalAlignment.Center);
            lstView.Columns.Add("발행금액", 100, HorizontalAlignment.Center);
            lstView.Columns.Add("발행상태", 0, HorizontalAlignment.Center);
            lstView.Columns.Add("외래키", 0, HorizontalAlignment.Center);
        }
        #endregion

        #region ListView 높이 지정
        private void SetHeight(ListView LV)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 25);
            LV.SmallImageList = imgList;
        }
        #endregion

        #region 폼 로드
        public void Tax_bill_Load(object sender, EventArgs e)
        {
            Set_ListView();
            SetHeight(lstView);
            lstView.DoubleBuffered(true);
            DBLoad();

            string year = "";

            int cyear = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            try
            {
                if (MariaDB_Yee.DB_Connect() == true)
                {
                    string[] l_year;
                    string[] l_year2;

                    year = MariaDB_Yee.ShowYear();

                    l_year = year.ToString().Split(' ');
                    l_year2 = l_year[0].ToString().Split('-');

                    for (int i = Convert.ToInt32(l_year2[0].ToString()); i <= cyear; i++)
                    {
                        cmbYear.Items.Add(i);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnSelect_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 디비 로드
        public void DBLoad()
        {
            lstView.Items.Clear();
            ShowTax.Clear();
            string strQuery = "";
            try
            {
                if (MariaDB_Yee.DB_Connect() == true)
                {
                    ShowTax = MariaDB_Yee.Show_tax(strQuery);

                    for (int i = 0; i < ShowTax.Count; i++)
                    {
                        string[] Date;
                        Date = ShowTax[i]["R_DT"].ToString().Split(' ');

                        ListViewItem item = new ListViewItem();
                        item.SubItems.Add((i + 1).ToString());
                        item.SubItems.Add(ShowTax[i]["C_TITLE"].ToString());
                        item.SubItems.Add(ShowTax[i]["R_YEAR"].ToString());
                        item.SubItems.Add(ShowTax[i]["R_MONTH"].ToString());
                        item.SubItems.Add(Date[0].ToString());
                        item.SubItems.Add(string.Format("{0:n0}", ShowTax[i]["R_AMT"]) + "원");
                        item.SubItems.Add(ShowTax[i]["R_STATE"].ToString());
                        item.SubItems.Add(ShowTax[i]["CSEQ"].ToString());

                        lstView.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnSelect_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 리스트뷰 클릭
        private void lstView_Click(object sender, EventArgs e)
        {
            try
            {
                if (MariaDB_Yee.DB_Connect() == true)
                {
                    string num = lstView.FocusedItem.SubItems[8].Text;
                    ShowTaxInfo = MariaDB_Yee.ShowData_tax(num, lstView.FocusedItem.SubItems[3].Text, lstView.FocusedItem.SubItems[4].Text);
                    Console.WriteLine(num);
                    for (int i = 0; i < ShowTaxInfo.Count; i++)
                    {
                        string[] Date;
                        string[] Date2;
                        Date = ShowTaxInfo[i]["C_STDT"].ToString().Split(' ');
                        Date2 = ShowTaxInfo[i]["C_EDDT"].ToString().Split(' ');

                        txtNm.Text = ShowTaxInfo[i]["C_NM"].ToString();
                        txtTitle.Text = ShowTaxInfo[i]["C_TITLE"].ToString();
                        txtStdt.Text = Date[0].ToString();
                        txtEddt.Text = Date2[0].ToString();
                        txtState.Text = ShowTaxInfo[i]["C_STATE"].ToString();
                        if (ShowTaxInfo[i]["C_STATE"].ToString() == "1")
                        {
                            txtState.Text = "유효";
                        }
                        else if (ShowTaxInfo[i]["C_STATE"].ToString() == "2")
                        {
                            txtState.Text = "만료";
                        }
                        else if (ShowTaxInfo[i]["C_STATE"].ToString() == "3")
                        {
                            txtState.Text = "해지";
                        }
                        cmbR_Year.Text = ShowTaxInfo[i]["R_YEAR"].ToString();
                        cmbR_Month.Text = ShowTaxInfo[i]["R_MONTH"].ToString();
                        txtDd.Text = DateTime.Now.ToString("yyyy") + "년 " + DateTime.Now.ToString("MM") + "월 " + ShowTaxInfo[i]["TINV_DD"].ToString() + "일";
                        txtAmt.Text = ShowTaxInfo[i]["R_AMT"].ToString();

                        if (ShowTaxInfo[i]["R_STATE"].ToString() == "0")
                        {
                            rdoState_0.Checked = true;
                            rdoState_0.Text = "미발행";
                        }
                        else if (ShowTaxInfo[i]["R_STATE"].ToString() == "1")
                        {
                            rdoState_1.Checked = true;
                            rdoState_1.Text = "발행";
                        }
                        txtEtc.Text = ShowTaxInfo[i]["R_ETC"].ToString();
                    }
                    MariaDB_Yee.DB_Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnSelect_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 발행대장 생성버튼
        private void btnCreateTax_Click(object sender, EventArgs e)
        {
            Tax_info info = new Tax_info(this);
            List<Dictionary<string, string>> se = new List<Dictionary<string, string>>();
            Dictionary<string, string> sa = new Dictionary<string, string>();

            sa.Add("year", cmbYear.Text.ToString());
            sa.Add("month", cmbMonth.Text.ToString());
            se.Add(sa);

            info.Passvalue = se;
            info.Show();

        }
        #endregion

        #region 수정 버튼
        private void btnModify_Click(object sender, EventArgs e)
        {
            int result = 0;
            string str = txtAmt.Text.ToString();
            try
            {
                if (MariaDB_Yee.DB_Connect())
                {
                    if (MessageBox.Show(" 세금계산서 발행대장을 저장하시겠습니까?", "데이터 저장", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (rdoState_0.Checked == true) //미발행
                        {
                            // 콤마 제거후 DB에 넣기위해 쓰는 코드
                            if (txtAmt.Text.Contains(","))
                            {
                                txtAmt.Text = str.Replace(",", string.Empty);
                            }

                            result = MariaDB_Yee.Modify(cmbR_Year.Text, cmbR_Month.Text, Convert.ToInt32(txtAmt.Text), "0", txtEtc.Text, lstView.FocusedItem.SubItems[8].Text);
                            MessageBox.Show("세금계산서 발행대장을 저장하였습니다", "Modify", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // 콤마제거된거 다시 붙여주기
                            txtAmt.Text = string.Format("{0:n0}", str);
                        }
                        else if (rdoState_1.Checked == true) //발행
                        {
                            // 콤마 제거후 DB에 넣기위해 쓰는 코드
                            if (txtAmt.Text.Contains(","))
                            {
                                txtAmt.Text = str.Replace(",", string.Empty);
                            }

                            result = MariaDB_Yee.Modify(cmbR_Year.Text, cmbR_Month.Text, Convert.ToInt32(txtAmt.Text), "1", txtEtc.Text, lstView.FocusedItem.SubItems[8].Text);
                            MessageBox.Show("세금계산서 발행대장을 저장하였습니다", "Modify", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // 콤마제거된거 다시 붙여주기
                            txtAmt.Text = string.Format("{0:n0}", str);

                        }
                    }
                    else
                    {
                        MessageBox.Show("세금계산서 발행대장을 취소하였습니다.", "데이터 저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnModify", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            DBLoad();
        }
        #endregion

        #region 삭제 버튼
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MariaDB_Yee.DB_Connect())
                {
                    if (!lstView.FocusedItem.SubItems[8].Text.Equals(""))
                    {
                        if (MessageBox.Show("세금계산서 발행대장을 삭제하시겠습니까?", "데이터 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            MariaDB_Yee.Delete(cmbR_Year.Text, cmbR_Month.Text, lstView.FocusedItem.SubItems[8].Text);
                            MessageBox.Show("세금계산서 발행대장을 삭제하였습니다", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("삭제할 데이터를 선택해주세요.");
                    }

                }
                else
                {
                    MessageBox.Show("세금계산서 발행대장을 삭제를 취소하였습니다.", "데이터 삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnDelete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            DBLoad();
        }
        #endregion

        #region 검색
        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstView.Items.Clear();
            ShowTax.Clear();
            try
            {
                if (MariaDB_Yee.DB_Connect() == true)
                {


                    ShowTax = MariaDB_Yee.ShowSeacrh(cmbYear.Text, cmbMonth.Text, txtSearch.Text);

                    for (int i = 0; i < ShowTax.Count; i++)
                    {
                        string[] Date;
                        Date = ShowTax[i]["R_DT"].ToString().Split(' ');
                        ListViewItem item = new ListViewItem();
                        item.SubItems.Add((i + 1).ToString());
                        item.SubItems.Add(ShowTax[i]["C_TITLE"].ToString());
                        item.SubItems.Add(ShowTax[i]["R_YEAR"].ToString());
                        item.SubItems.Add(ShowTax[i]["R_MONTH"].ToString());
                        item.SubItems.Add(Date[0].ToString());
                        item.SubItems.Add(ShowTax[i]["R_AMT"].ToString());
                        item.SubItems.Add(ShowTax[i]["R_STATE"].ToString());
                        item.SubItems.Add(ShowTax[i]["CSEQ"].ToString());

                        lstView.Items.Add(item);
                    }
                    MariaDB_Yee.DB_Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnSearch_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 검색창 조건
        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtSearch.ForeColor = Color.Black;
        }
        #endregion

        #region 검색 enter키
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSearch_Click(sender, e);
            }
        }
        #endregion

        #region 검색어 없을시, 리스트뷰 재로드
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            if (txtSearch.Text == "")
            {
                DBLoad();
            }
        }
        #endregion

        #region 리스트뷰 새로고침 버튼
        public void btnRe_Click(object sender, EventArgs e)
        {
            DBLoad();
        }
        #endregion

    }
}