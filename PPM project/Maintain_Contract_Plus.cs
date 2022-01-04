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
    public partial class Maintain_Contract_Plus : Form
    {
        #region 전역변수

        List<Dictionary<String, object>> listItem = new List<Dictionary<string, object>>();

        private string Maintain_Contract_Plus_Value;

        #endregion

        #region 유지보수 관리쪽에서 고정키 받아올 PassValue
        public string Passvalue
        {
            get { return this.Maintain_Contract_Plus_Value; } // Form3에서 얻은(get) 값을 다른폼(Form1)으로 전달 목적
            set { this.Maintain_Contract_Plus_Value = value; }  // 다른폼(Form1)에서 전달받은 값을 쓰기
        }
        #endregion

        #region 폼로드
        public Maintain_Contract_Plus()
        {
            InitializeComponent();
        }

        private void Maintain_Contract_Plus_Load(object sender, EventArgs e)
        {
            Set_ListView();
            SetHeight(lstView);
            DBLoad();
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
            lstView.Columns.Add("", "", 0, HorizontalAlignment.Center, 0);
            lstView.Columns.Add("No", 30, HorizontalAlignment.Center);
            lstView.Columns.Add("고객사명", 80, HorizontalAlignment.Center);
            lstView.Columns.Add("프로젝트명", 100, HorizontalAlignment.Center);
            lstView.Columns.Add("구축기간", 150, HorizontalAlignment.Center);
            lstView.Columns.Add("구축부서", 90, HorizontalAlignment.Center);
            lstView.Columns.Add("유지보수시작일", 100, HorizontalAlignment.Center);
            lstView.Columns.Add("고정키", 0, HorizontalAlignment.Center);
        }
        #endregion

        #region 리스트 뷰 높낮이 조절
        private void SetHeight(ListView LV)
        {
            // listView 높이 지정
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 25);
            LV.SmallImageList = imgList;
        }
        #endregion

        #region 디비 로드
        public void DBLoad()
        {
            lstView.Items.Clear();
            listItem.Clear();
            try
            {
                if (JHSDB.DB_Connect() == true)
                {
                    // DB Show 실행
                    listItem = JHSDB.Show();

                    for (int i = 0; i < listItem.Count; i++)
                    {
                        string[] Date;
                        string[] Date2;
                        string[] Date3;
                        Date = listItem[i]["PRJ_STDT"].ToString().Split(' ');            // 구축기간 시작일
                        Date2 = listItem[i]["PRJ_EDDT"].ToString().Split(' ');           // 구축기간 종료일
                        Date3 = listItem[i]["MAINT_STDT"].ToString().Split(' ');         // 유지보수시작일
                        ListViewItem item = new ListViewItem();
                        item.SubItems.Add((i + 1).ToString());
                        item.SubItems.Add(listItem[i]["CUST_NM"].ToString());               // 고객사명
                        item.SubItems.Add(listItem[i]["PRJ_NM"].ToString());                // 프로젝트명
                        item.SubItems.Add(Date[0].ToString() + "~" + Date2[0].ToString());  // 구축기간
                        item.SubItems.Add(listItem[i]["PRJ_DEPT"].ToString());              // 구축부서
                        item.SubItems.Add(Date3[0].ToString());                             // 유지보수시작일
                        item.SubItems.Add(listItem[i]["PSEQ"].ToString());                  // 고정키

                        lstView.Items.Add(item);
                    }
                    JHSDB.DB_Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnSelect_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 리스트 뷰 클릭 이벤트
        private void lstView_Click(object sender, EventArgs e)
        {
            string[] list;
            try
            {
                if (JHSDB.DB_Connect() == true)
                {
                    string num = lstView.FocusedItem.SubItems[7].Text;
                    listItem = JHSDB.ShowData(num);
                    for (int i = 0; i < listItem.Count; i++)
                    {
                        txtCustomer.Text = listItem[i]["CUST_NM"].ToString();                // 고객사명
                        txtProject.Text = listItem[i]["PRJ_NM"].ToString();                  // 프로젝트명
                        txtPaceProduct.Text = listItem[i]["PACE_PRODUCT"].ToString();        // 적용제품
                        txtOtherProduct.Text = listItem[i]["EXTERNAL_PRODUCT"].ToString();   // 외부제품
                        txtEmp.Text = listItem[i]["PRJ_EMP"].ToString();                     // 구축담당자
                        txtEtc.Text = listItem[i]["PRJ_ETC"].ToString();                     // 비고
                        list = listItem[i]["PRJ_EDDT"].ToString().Split(' ');                // 구축기간 시작일 뒷부분 자르기
                        txtdateTimePicker4.Text = list[0].ToString();
                        list = listItem[i]["PRJ_STDT"].ToString().Split(' ');                // 구축기간 종료일 뒷부분 자르기
                        txtdateTimePicker5.Text = list[0].ToString();
                        list = listItem[i]["MAINT_STDT"].ToString().Split(' ');              // 유지보수시작일 뒷부분 자르기
                        txtdateTimePicker6.Text = list[0].ToString();
                        txtDept.Text = listItem[i]["PRJ_DEPT"].ToString();                   // 구축부서
                        txtProductType.Text = listItem[i]["PRODUCT_TYPE"].ToString();        // 적용방식
                    }
                    JHSDB.DB_Close();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnSelect_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 닫기버튼
        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        #endregion

        #region 검색으로 찾기 버튼
        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstView.Items.Clear();
            listItem.Clear();
            try
            {
                if (JHSDB.DB_Connect() == true)
                {
                    string search = txtSearch.Text;
                    // 텍스트박스 값 DB로 보내기
                    listItem = JHSDB.ShowSearch(search);

                    for (int i = 0; i < listItem.Count; i++)
                    {
                        string[] Date;
                        string[] Date2;
                        string[] Date3;
                        Date = listItem[i]["PRJ_STDT"].ToString().Split(' ');               // 구축기간 - 시작일
                        Date2 = listItem[i]["PRJ_EDDT"].ToString().Split(' ');              // 구축기간 - 종료일
                        Date3 = listItem[i]["MAINT_STDT"].ToString().Split(' ');            // 유지보수시작일
                        ListViewItem item = new ListViewItem(); 
                        item.SubItems.Add((i + 1).ToString());                              // No
                        item.SubItems.Add(listItem[i]["CUST_NM"].ToString());               // 고객사명
                        item.SubItems.Add(listItem[i]["PRJ_NM"].ToString());                // 프로젝트명
                        item.SubItems.Add(Date[0].ToString() + "~" + Date2[0].ToString());  // 시작일 ~ 종료일
                        item.SubItems.Add(listItem[i]["PRJ_DEPT"].ToString());              // 구축부서
                        item.SubItems.Add(Date3[0].ToString());                  
                        item.SubItems.Add(listItem[i]["PSEQ"].ToString());                  // 고정키
                        item.SubItems.Add(listItem[i]["PRJ_EMP"].ToString());               // 구축담당자
                        lstView.Items.Add(item);
                    }
                    JHSDB.DB_Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnSelect_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 검색 Enter키 누르면 보여질수있게하기
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSearch_Click(sender, e);
            }
        }
        #endregion

        #region 검색주석 클릭시 초기화
        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtSearch.ForeColor = Color.Black;
        }
        #endregion

        #region 검색창 공백이면 DB 전체로 바로 불러옴
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                DBLoad();
            }
        }
        #endregion

        #region 추가버튼
        private void button1_Click(object sender, EventArgs e)
        {
            int result = 0;
            // 유지보수 계약관리 불러오기
            Maintain_Contract mc = new Maintain_Contract();

            try
            {
                if (JHSDB.DB_Connect())
                {
                    if (MessageBox.Show("데이터를 추가하시겠습니까?", "데이터 추가", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if(lstView.SelectedItems.Count != 0)
                        {
                            // 불러온 PassValue 값 , 선택한 프로젝트 고정키값 넣어주기
                            result = JHSDB.MaintainPlusInsert(Passvalue, lstView.FocusedItem.SubItems[7].Text);

                            MessageBox.Show("프로젝트를 추가합니다.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("추가할 프로젝트를 선택해주세요", "선택오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("데이터 저장를 취소하였습니다.", "데이터 저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            DBLoad();
        }
        #endregion
    }
}
