using PPM_project.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PPM_project
{
    public partial class Project : Form
    {
        #region 전역
        //프로젝트 테이블 전체 출력을 위한 리스트
        List<Dictionary<String, object>> ShowProject = new List<Dictionary<string, object>>();

        // 입력 내역 중복 확인을 위한 리스트
        List<Dictionary<String, object>> CheckDuplicate = new List<Dictionary<string, object>>();
        #endregion

        #region 폼
        public Project()
        {
            InitializeComponent();
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
            lstView.Columns.Add("No", 30, HorizontalAlignment.Center);
            lstView.Columns.Add("고객사명", 60, HorizontalAlignment.Center);
            lstView.Columns.Add("프로젝트명", 120, HorizontalAlignment.Center);
            lstView.Columns.Add("구축기간", 150, HorizontalAlignment.Center);
            lstView.Columns.Add("적용제품", 0, HorizontalAlignment.Center);
            lstView.Columns.Add("외부제품", 0, HorizontalAlignment.Center);
            lstView.Columns.Add("적용방식", 0, HorizontalAlignment.Center);
            lstView.Columns.Add("구축부서", 70, HorizontalAlignment.Center);
            lstView.Columns.Add("구축담당", 0, HorizontalAlignment.Center);
            lstView.Columns.Add("유지보수시작일", 100, HorizontalAlignment.Center);
            lstView.Columns.Add("비고", 0, HorizontalAlignment.Center);
            lstView.Columns.Add("구분키", 0, HorizontalAlignment.Center);

        }
        #endregion

        #region 폼 로드
        private void Project_Load(object sender, EventArgs e)
        {
            // 리스트뷰 세팅
            Set_ListView();
            // 리스트뷰 높낮이 조절
            SetHeight(lstView);
            // 리스트뷰 더블 버퍼링 설정
            lstView.DoubleBuffered(true);
            // tb_project 테이블 내용 출력 메서드
            DBLoad();
        }
        #endregion

        #region 디비 로드(tb_project 내용 출력)
        public void DBLoad()
        {
            // 리스트 뷰 클리어
            lstView.Items.Clear();
            //ShowProject 리스트 내용 클리어
            ShowProject.Clear();

            try
            {
                // 디비 연결 성공시
                if (MariaDB.DB_Connect() == true)
                {
                    //리스트 안에 tb_project 내용을 넣고
                    ShowProject = MariaDB.Show();

                    //리스트 개수 만큼 출력
                    for (int i = 0; i < ShowProject.Count; i++)
                    {
                        string[] Date; 
                        string[] Date2; 
                        string[] Date3; 
                        // 날짜 만 나오게 자르기
                        Date = ShowProject[i]["PRJ_STDT"].ToString().Split(' ');
                        Date2 = ShowProject[i]["PRJ_EDDT"].ToString().Split(' ');
                        Date3 = ShowProject[i]["MAINT_STDT"].ToString().Split(' ');
                        // 리스트 뷰에 아이템 추가
                        ListViewItem item = new ListViewItem();
                        item.SubItems.Add((ShowProject.Count - i).ToString());
                        item.SubItems.Add(ShowProject[i]["CUST_NM"].ToString());
                        item.SubItems.Add(ShowProject[i]["PRJ_NM"].ToString());
                        item.SubItems.Add(Date[0].ToString() + "~" + Date2[0].ToString());
                        item.SubItems.Add(ShowProject[i]["PACE_PRODUCT"].ToString());
                        item.SubItems.Add(ShowProject[i]["EXTERNAL_PRODUCT"].ToString());
                        item.SubItems.Add(ShowProject[i]["PRODUCT_TYPE"].ToString());
                        item.SubItems.Add(ShowProject[i]["PRJ_DEPT"].ToString());
                        item.SubItems.Add(ShowProject[i]["PRJ_EMP"].ToString());
                        item.SubItems.Add(Date3[0].ToString());
                        item.SubItems.Add(ShowProject[i]["PRJ_ETC"].ToString());
                        item.SubItems.Add(ShowProject[i]["PSEQ"].ToString());

                        lstView.Items.Add(item);
                    }
                    //디비 닫기
                    MariaDB.DB_Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DBLoad", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 리스트 뷰 클릭 이벤트
        private void lstView_Click(object sender, EventArgs e)
        {
            try
            {
                // 디비 연결 성공시
                if (MariaDB.DB_Connect() == true)
                {
                    // 리스트 뷰에 선택되어진 아이템 구분키(PSEQ) 를 가져온다
                    string num = lstView.FocusedItem.SubItems[12].Text;
                    Console.WriteLine(num + "테스트");
                    // 선택한 구분키(PSEQ) 에 맞는 데이터를 출력
                    ShowProject = MariaDB.ShowData(num);
                    for (int i = 0; i < ShowProject.Count; i++)
                    {
                        txtCust_nm.Text = ShowProject[i]["CUST_NM"].ToString();
                        txtPrg_nm.Text = ShowProject[i]["PRJ_NM"].ToString();
                        txtPace_product.Text = ShowProject[i]["PACE_PRODUCT"].ToString();
                        txtEx_product.Text = ShowProject[i]["EXTERNAL_PRODUCT"].ToString();
                        txtPrj_emp.Text = ShowProject[i]["PRJ_EMP"].ToString();
                        txtPrj_etc.Text = ShowProject[i]["PRJ_ETC"].ToString();
                        datePrj_eddt.Value = Convert.ToDateTime(ShowProject[i]["PRJ_EDDT"].ToString());
                        datePrj_stdt.Value = Convert.ToDateTime(ShowProject[i]["PRJ_STDT"].ToString());
                        dateMaint_stdt.Value = Convert.ToDateTime(ShowProject[i]["MAINT_STDT"].ToString());
                        cmbPrj_dept.SelectedItem = ShowProject[i]["PRJ_DEPT"].ToString();
                        cmbProduct_type.SelectedItem = ShowProject[i]["PRODUCT_TYPE"].ToString();
                        txtNonVisableKey.Text = ShowProject[i]["PSEQ"].ToString();
                    }
                    // 디비 닫기
                    MariaDB.DB_Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "lstView_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 초기화 이벤트
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion

        #region 초기화 메서드
        private void Clear() 
        {
            txtCust_nm.Text = "";
            txtPrg_nm.Text = "";
            txtPace_product.Text = "";
            txtEx_product.Text = "";
            txtPrj_emp.Text = "";
            txtPrj_etc.Text = "";
            datePrj_eddt.Value = DateTime.Now;
            datePrj_stdt.Value = DateTime.Now;
            dateMaint_stdt.Value = DateTime.Now;
            cmbPrj_dept.SelectedIndex = 0;
            cmbProduct_type.SelectedIndex = 0;
            txtNonVisableKey.Text = "";

            this.lstView.BeginInvoke(new Action(() => { 
                this.lstView.SelectedIndices.Clear();
                this.lstView.SelectedItems.Clear();
            }));

            btnSave.Text = "저장";

            txtCust_nm.BackColor = Color.White;
            txtPrg_nm.BackColor = Color.White;
            txtPace_product.BackColor = Color.White;
            txtEx_product.BackColor = Color.White;
            txtPrj_emp.BackColor = Color.White;
            txtPrj_etc.BackColor = Color.White;
            txtNonVisableKey.BackColor = Color.White;
            cmbPrj_dept.BackColor = Color.White;
            cmbProduct_type.BackColor = Color.White;

        }
        #endregion

        #region 저장 이벤트
        private void btnSave_Click(object sender, EventArgs e)
        { 
            int result = 0;
            try
            {
                // txtCust_nm에 데이터가 들어가지 않을경우
                if (txtCust_nm.Text == "")
                {
                    MessageBox.Show("데이터가 존재하지 않습니다", "Non", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // 버튼의 텍스트가 저장일 경우
                    if (btnSave.Text == "저장")
                    {
                        //디비 연결 성공시
                        if (MariaDB.DB_Connect())
                        {
                            //CheckDuplicate 리스트 안에 중복 결과 값 넣기 (중복 = 1, 중복되지 않으면 = 0)
                            //리스트뷰의 선택된 인덱스가 존재할경우
                            if (lstView.SelectedIndices.Count != 0)
                            {
                                CheckDuplicate = MariaDB.InsertCheck(Convert.ToInt32(txtNonVisableKey.Text.ToString()));
                            }
                            //리스트뷰의 선택된 인덱스가 존재하지 않을 경우
                            else if(lstView.SelectedIndices.Count == 0)
                            {
                                Dictionary<string, object> dic = new Dictionary<string, object>();
                                dic.Add("have", "0");
                                CheckDuplicate.Add(dic);
                            }
                            // 중복 값이 존재할 경우
                            if (CheckDuplicate[0]["have"].ToString() == "1")
                            {
                                MessageBox.Show("중복 되는 데이터 입니다", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if(CheckDuplicate[0]["have"].ToString() == "0")
                            { 
                                if (MessageBox.Show("데이터를 저장하시겠습니까?", "데이터 저장", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    //tb_proejct 에 데이터 전송 
                                    result = MariaDB.Insert(txtCust_nm.Text, txtPrg_nm.Text, Convert.ToDateTime(datePrj_stdt.Text),
                                           Convert.ToDateTime(datePrj_eddt.Text), txtPace_product.Text, txtEx_product.Text, cmbProduct_type.SelectedItem.ToString(), cmbPrj_dept.SelectedItem.ToString(), txtPrj_emp.Text, Convert.ToDateTime(dateMaint_stdt.Text), txtPrj_etc.Text);
                                    MessageBox.Show("데이터를 저장하였습니다", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("데이터 저장를 취소하였습니다.", "데이터 저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    //btnSave 의 텍스트가 수정일 경우
                    else if (btnSave.Text == "수정")
                    {
                        //디비 연결 성공시
                        if (MariaDB.DB_Connect())
                        {
                            if (MessageBox.Show("데이터를 수정하시겠습니까?", "데이터 수정", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                //tb_proejct 에 데이터 수정
                                result = MariaDB.Update(txtCust_nm.Text, txtPrg_nm.Text, Convert.ToDateTime(datePrj_stdt.Text),
                                       Convert.ToDateTime(datePrj_eddt.Text), txtPace_product.Text, txtEx_product.Text, cmbProduct_type.SelectedItem.ToString(), cmbPrj_dept.SelectedItem.ToString(), txtPrj_emp.Text, Convert.ToDateTime(dateMaint_stdt.Text), txtPrj_etc.Text, Convert.ToInt32(txtNonVisableKey.Text.ToString()));
                                MessageBox.Show("데이터를 수정하였습니다", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("데이터 수정을 취소하였습니다.", "데이터 수정", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //등록후 디비 내용 재출력
            DBLoad();
        }
        #endregion

        #region 삭제 이벤트
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // 디비 연결시
                if (MariaDB.DB_Connect())
                {
                    if (!txtNonVisableKey.Text.Equals(""))
                    {
                        if (MessageBox.Show("데이터를 삭제하시겠습니까?", "데이터 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {

                            //tb_project 테이블에 txtCust_nm = CUST_NM 그리고 txtPrg_nm = PRJ_NM 인 PSEQ값 구하기
                            string PSEQ = txtNonVisableKey.Text.ToString();
                            //tb_project 에서 선택 데이터 삭제
                            MariaDB.Delete(PSEQ);
                            Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("삭제 할 데이터가 존재하지 않습니다", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("데이터 삭제를 취소하였습니다.", "데이터 삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "btnDelete_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // 삭제후 tb_project 내용 재출력
            DBLoad();
           
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

        #region 검색 메서드
        public void search()
        {
            lstView.Items.Clear();
            ShowProject.Clear();
            string strQuery = "";
            try
            {
                if (MariaDB.DB_Connect() == true)
                {
                    strQuery = "SELECT * FROM tb_project WHERE CUST_NM LIKE CONCAT('%','" + txtSearch.Text + "' , '%') or " + "PRJ_NM LIKE CONCAT('%','" + txtSearch.Text + "' , '%') or " + "PACE_PRODUCT LIKE CONCAT('%','" + txtSearch.Text + "' , '%')";

                    ShowProject = MariaDB.ShowSeacrh(strQuery);

                    for (int i = 0; i < ShowProject.Count; i++)
                    {
                        string[] Date;
                        string[] Date2;
                        string[] Date3;
                        // 날짜 만 나오게 자르기
                        Date = ShowProject[i]["PRJ_STDT"].ToString().Split(' ');
                        Date2 = ShowProject[i]["PRJ_EDDT"].ToString().Split(' ');
                        Date3 = ShowProject[i]["MAINT_STDT"].ToString().Split(' ');
                        // 리스트 뷰에 아이템 추가
                        ListViewItem item = new ListViewItem();
                        item.SubItems.Add((ShowProject.Count - i).ToString());
                        item.SubItems.Add(ShowProject[i]["CUST_NM"].ToString());
                        item.SubItems.Add(ShowProject[i]["PRJ_NM"].ToString());
                        item.SubItems.Add(Date[0].ToString() + "~" + Date2[0].ToString());
                        item.SubItems.Add(ShowProject[i]["PACE_PRODUCT"].ToString());
                        item.SubItems.Add(ShowProject[i]["EXTERNAL_PRODUCT"].ToString());
                        item.SubItems.Add(ShowProject[i]["PRODUCT_TYPE"].ToString());
                        item.SubItems.Add(ShowProject[i]["PRJ_DEPT"].ToString());
                        item.SubItems.Add(ShowProject[i]["PRJ_EMP"].ToString());
                        item.SubItems.Add(Date3[0].ToString());
                        item.SubItems.Add(ShowProject[i]["PRJ_ETC"].ToString());
                        item.SubItems.Add(ShowProject[i]["PSEQ"].ToString());
                        lstView.Items.Add(item);
                    }
                    MariaDB.DB_Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnSelect_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 검색버튼 이벤트
        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }
        #endregion

        #region 텍스트 박스 이벤트
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                DBLoad();
            }
        }
        #endregion

        #region 텍스트 박스 색깔 변경 메서드
        public void changeTxt(int num, string text, TextBox box) 
        {
            if (lstView.SelectedIndices.Count != 0)
            {
                if (lstView.FocusedItem.SubItems[num].Text != text)
                {
                    box.BackColor = Color.Yellow;
                    btnSave.Text = "수정";
                }
                else if (lstView.FocusedItem.SubItems[num].Text == text)
                {
                    box.BackColor = Color.White;
                    btnSave.Text = "저장";
                }
            }
            else 
            { 
            
            }
        }
        #endregion

        #region 콤보 박스 색깔 변경 메서드
        public void changeCmb(int num, string text, ComboBox cBox)
        {
            if (lstView.SelectedIndices.Count != 0)
            {
                if (lstView.FocusedItem.SubItems[num].Text != text)
                {
                    cBox.BackColor = Color.Yellow;
                }
                else if (lstView.FocusedItem.SubItems[num].Text == text)
                {
                    cBox.BackColor = Color.White;
                }
            }
            else 
            {
            
            }
        }
        #endregion

        #region 텍스트 박스 enter 키 입력시 이벤트
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //엔터키 이벤트 발생
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSearch_Click(sender, e);
            }
        }
        #endregion

        #region 텍스트 박스 수정시 색깔 변화(고객사명)
        private void txtCust_nm_TextChanged(object sender, EventArgs e)
        {
            changeTxt(2, txtCust_nm.Text, txtCust_nm);
        }
        #endregion

        #region 텍스트 박스 수정시 색깔 변화(프로젝트명)
        private void txtPrg_nm_TextChanged(object sender, EventArgs e)
        {
            changeTxt(3, txtPrg_nm.Text, txtPrg_nm);
        }
        #endregion

        #region 텍스트 박스 수정시 색깔 변화(적용제품)
        private void txtPace_product_TextChanged(object sender, EventArgs e)
        {
            changeTxt(5, txtPace_product.Text, txtPace_product);
        }
        #endregion

        #region 텍스트 박스 수정시 색깔 변화(외부제품)
        private void txtEx_product_TextChanged(object sender, EventArgs e)
        {
            changeTxt(6, txtEx_product.Text, txtEx_product);

        }
        #endregion

        #region 콤보 박스 수정시 색깔 변화(적용방식)
        private void cmbProduct_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeCmb(7, cmbProduct_type.Text, cmbProduct_type);
        }
        #endregion

        #region 콤보 박스 수정시 색깔 변화(구축부서)
        private void cmbPrj_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeCmb(8, cmbPrj_dept.Text, cmbPrj_dept);
        }
        #endregion

        #region 텍스트 박스 수정시 색깔 변화(구축담당자)
        private void txtPrj_emp_TextChanged(object sender, EventArgs e)
        {
            changeTxt(9, txtPrj_emp.Text, txtPrj_emp);
        }
        #endregion

        #region 텍스트 박스 수정시 색깔 변화(비고)
        private void txtPrj_etc_TextChanged(object sender, EventArgs e)
        {
            changeTxt(11, txtPrj_etc.Text, txtPrj_etc);
        }
        #endregion

        #region 클릭시 검색초기화
        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtSearch.ForeColor = Color.Black;
        }
        #endregion
    }
}
