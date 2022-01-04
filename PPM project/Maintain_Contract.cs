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
    public partial class Maintain_Contract : Form
    {
        #region 전역변수

        List<Dictionary<String, object>> listItem = new List<Dictionary<string, object>>();
        List<Dictionary<String, object>> listProject = new List<Dictionary<string, object>>();
        List<Dictionary<String, object>> listCompare = new List<Dictionary<string, object>>();      // 수정시마다 색상주기용
        List<Dictionary<String, object>> CheckDuplicate = new List<Dictionary<string, object>>();   // 중복키값 비교용

        #endregion

        #region 폼로드
        private void Maintain_Contract_Load(object sender, EventArgs e)
        {
            ListView1_option();
            ListView2_option();
            SetHeight(listView1);

            DBLoad();

            // 검색 분류 첫번째꺼
            cmbSelect.SelectedIndex = 0;
            

        }

        public Maintain_Contract()
        {
            InitializeComponent();
        }
        #endregion

        #region listview1 옵션
        private void ListView1_option()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("", "", 0, HorizontalAlignment.Center, 0);   // 공백
            listView1.Columns.Add("No", 30, HorizontalAlignment.Center); // No
            listView1.Columns.Add("계약항목", 140, HorizontalAlignment.Center); // 계약항목
            listView1.Columns.Add("계약시작일", 90, HorizontalAlignment.Center); // 계약기간 - 시작일
            listView1.Columns.Add("계약종료일", 90, HorizontalAlignment.Center); // 계약기간 - 종료일
            listView1.Columns.Add("계약상태", 65, HorizontalAlignment.Center); // 계약상태
            listView1.Columns.Add("CSEQ", 0, HorizontalAlignment.Center); // CSEQ 고정키 값
            listView1.Columns.Add("계약업체", 0, HorizontalAlignment.Center); // 계약업체명
            listView1.Columns.Add("갱신일", 0, HorizontalAlignment.Center); // 갱신일 
        }
        #endregion

        #region listView2 옵션
        private void ListView2_option()
        {
            listView2.View = View.Details;
            listView2.Columns.Add("", "", 0, HorizontalAlignment.Center, 0);   // 공백
            listView2.Columns.Add("No", 30, HorizontalAlignment.Center); // No
            listView2.Columns.Add("고객사", 120, HorizontalAlignment.Center); // 고객사
            listView2.Columns.Add("프로젝트명", 170, HorizontalAlignment.Center); // 프로젝트명
            listView2.Columns.Add("CSEQ", 0, HorizontalAlignment.Center);    // CSEQ 키
            listView2.Columns.Add("PSEQ", 0, HorizontalAlignment.Center);    // PSEQ 키
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

        #region DB로드 (DBLoad)
        public void DBLoad()
        {
            listView1.Items.Clear();
            listItem.Clear();

            string dateToday = DateTime.Now.ToString("yyyyMM");
            string[] dateUPDT;

            try
            {
                if (JHSDB.DB_Connect() == true)
                {
                    // DB MaintainShow 실행
                    listItem = JHSDB.MaintainShow();

                    string[] list;

                    for (int i = 0; i < listItem.Count; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.SubItems.Add((i + 1).ToString());                   // No
                        item.SubItems.Add(listItem[i]["C_TITLE"].ToString());    // 계약항목

                        list = listItem[i]["C_STDT"].ToString().Split(' ');      // 시작일 뒷부분 자르기
                        item.SubItems.Add(list[0].ToString());                   // 시작일
                        list = listItem[i]["C_EDDT"].ToString().Split(' ');      // 종료일 뒷부분 자르기
                        item.SubItems.Add(list[0].ToString());                   // 종료일

                        if (listItem[i]["C_STATE"].ToString() == "1")             // 계약상태
                        {
                            item.SubItems.Add("유효");
                        }
                        else if (listItem[i]["C_STATE"].ToString() == "2")
                        {
                            item.SubItems.Add("만료");
                        }
                        else if (listItem[i]["C_STATE"].ToString() == "3")
                        {
                            item.SubItems.Add("해지");
                        }

                        item.SubItems.Add(listItem[i]["CSEQ"].ToString());       // 고정값
                        item.SubItems.Add(listItem[i]["C_NM"].ToString());       // 계약업체 (검색용으로 넣어둠)
                        item.SubItems.Add(listItem[i]["C_UPDT"].ToString());     // 갱신일
                        
                        listView1.Items.Add(item);

                    }

                    // 갱신일 현재 일자 기준으로 한달전인거 색상표시
                    for(int i = 0; i < listView1.Items.Count; i++)
                    {
                        dateUPDT = listView1.Items[i].SubItems[8].Text.ToString().Split('-');
                        // 계약상태가 유효할때
                        if (listView1.Items[i].SubItems[5].Text.ToString() == "유효")
                        {
                            // 갱신일에서 현재날을 빼서 0,1,89 결과가나오면 갱신일까지 한달전이니깐 색상주기
                            // ex) 현재날 2021년12월 갱신일 2022년1월 202201 - 202112 = 89
                            if ((Convert.ToInt32(dateUPDT[0] + dateUPDT[1]) - Convert.ToInt32(dateToday)) == 1 || (Convert.ToInt32(dateUPDT[0] + dateUPDT[1]) - Convert.ToInt32(dateToday)) == 0 || (Convert.ToInt32(dateUPDT[0] + dateUPDT[1]) - Convert.ToInt32(dateToday)) == 89)
                            {
                                listView1.Items[i].BackColor = Color.LightGreen;
                            }
                        }
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

        #region 프로젝트 리스트뷰 DB불러오기 (ProjectLoad)
        public void ProjectLoad()
        {
            try
            {
                if (JHSDB.DB_Connect() == true)
                {
                    // DB에 키값 보내주기
                    string CSEQ = listView1.FocusedItem.SubItems[6].Text;
                    listProject = JHSDB.MainProjectShow(CSEQ);

                    for (int i = 0; i < listProject.Count; i++)
                    {
                        ListViewItem itemProject = new ListViewItem();

                        itemProject.SubItems.Add((i + 1).ToString());                      // No
                        itemProject.SubItems.Add(listProject[i]["CUST_NM"].ToString());    // 고객사
                        itemProject.SubItems.Add(listProject[i]["PRJ_NM"].ToString());     // 프로젝트명*/
                        itemProject.SubItems.Add(listProject[i]["CSEQ"].ToString());       // 외래키(유지보수관리)
                        itemProject.SubItems.Add(listProject[i]["PSEQ"].ToString());       // 외래키(프로젝트관리) 

                        listView2.Items.Add(itemProject);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ProjectLoad 오류", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        #endregion

        #region 리스트뷰 클릭시
        private void listView1_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            listCompare.Clear();
            try
            {
                if (JHSDB.DB_Connect() == true)
                {
                    string CSEQ = listView1.FocusedItem.SubItems[6].Text;   // 고정키값 주기
                    listItem = JHSDB.MaintainShowData(CSEQ);
                    listCompare = listItem;

                    string[] list;

                    for (int i = 0; i < listItem.Count; i++)
                    {
                        txtC_NM.Text = listItem[i]["C_NM"].ToString();                 // 계약업체
                        txtC_TITLE.Text = listItem[i]["C_TITLE"].ToString();           // 계약항목
                        if (listItem[i]["C_STATE"].ToString() == "1")                  // 계약상태
                        {
                            cmbC_STATE.Text = "유효";
                        }
                        else if (listItem[i]["C_STATE"].ToString() == "2")
                        {
                            cmbC_STATE.Text = "만료";
                        }
                        else if (listItem[i]["C_STATE"].ToString() == "3")
                        {
                            cmbC_STATE.Text = "해지";
                        }
                        list = listItem[i]["C_STDT"].ToString().Split(' ');      // 시작일 뒷부분 자르기
                        txtC_STDT.Text = list[0].ToString();             // 계약기간 - 시작일
                        list = listItem[i]["C_EDDT"].ToString().Split(' ');      // 종료일 뒷부분 자르기
                        txtC_EDDT.Text = list[0].ToString();             // 계약기간 - 종료일
                        list = listItem[i]["C_UPDT"].ToString().Split(' ');      // 갱신일자 뒷부분 자르기
                        txtC_UPDT.Text = list[0].ToString();             // 갱신일자
                        if (listItem[i]["C_UPTYPE"].ToString() == "1")                 // 갱신방식
                        {
                            cmbC_UPTYPE.Text = "자동";
                        }
                        else if (listItem[i]["C_UPTYPE"].ToString() == "2")
                        {
                            cmbC_UPTYPE.Text = "수동";
                        }
                        txtC_EMP.Text = listItem[i]["C_EMP"].ToString();                // 계약담당
                        txtC_ETC.Text = listItem[i]["C_ETC"].ToString();                // 비고 - 계약정보
                        txtTINV_TO.Text = listItem[i]["TINV_TO"].ToString();            // 발행처
                        txtTINV_AMT.Text = listItem[i]["TINV_AMT"].ToString();          // 발행금액
                        cmbTINV_CYCLE.Text = listItem[i]["TINV_CYCLE"].ToString();      // 발행주기
                        txtTINV_MM.Text = listItem[i]["TINV_MM"].ToString();            // 발행월
                        txtTINV_DD.Text = listItem[i]["TINV_DD"].ToString();            // 발행일자
                        txtTINV_ETC.Text = listItem[i]["TINV_ETC"].ToString();          // 비고 - 세금계산서
                        cmbCHK_TYPE.Text = listItem[i]["CHK_TYPE"].ToString();          // 점검방법
                        cmbCHK_CYCLE.Text = listItem[i]["CHK_CYCLE"].ToString();        // 점검주기
                        txtCHK_MM.Text = listItem[i]["CHK_MM"].ToString();              // 점검월
                        txtCHK_EMP.Text = listItem[i]["CHK_EMP"].ToString();            // 점검확인자
                        txtCHK_ETC.Text = listItem[i]["CHK_ETC"].ToString();            // 비고 - 유지보수 점검정보
                        txtNon.Text = listItem[i]["CSEQ"].ToString();
                    }

                    // 프로젝트 리스트뷰 불러오기
                    ProjectLoad();

                    JHSDB.DB_Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnSelect_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 추가버튼
        private void button2_Click(object sender, EventArgs e)
        {
            // 초기화
            Reset();
            button3.Text = "저장";
            listView2.Items.Clear();
        }
        #endregion

        #region 저장버튼
        private void button3_Click(object sender, EventArgs e)
        {
            int result = 0;
            try
            {
                if (button3.Text == "수정")
                {
                    if (listView1.SelectedItems.Count != 0)
                    {
                        if (JHSDB.DB_Connect())
                        {
                            if (MessageBox.Show("데이터를 저장하시겠습니까?", "데이터 저장", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                // 갱신방식 DB넣을때 숫자로 되어있어서 if문 작성
                                if (cmbC_UPTYPE.Text.ToString().Equals("자동"))
                                {
                                    cmbC_UPTYPE.Text = "1";
                                }
                                else
                                {
                                    cmbC_UPTYPE.Text = "2";
                                }

                                // 계약상태 DB넣을때 숫자로 되어있어서 if문 작성
                                if (cmbC_STATE.Text.ToString().Equals("유효"))
                                {
                                    cmbC_STATE.Text = "1";
                                }
                                else if (cmbC_STATE.Text.ToString().Equals("만료"))
                                {
                                    cmbC_STATE.Text = "2";
                                }
                                else
                                {
                                    cmbC_STATE.Text = "3";
                                }

                                result = JHSDB.MaintainUpdate(listView1.FocusedItem.SubItems[6].Text, txtC_NM.Text, txtC_TITLE.Text, Convert.ToDateTime(txtC_STDT.Text), Convert.ToDateTime(txtC_EDDT.Text),
                                    Convert.ToDateTime(txtC_UPDT.Text), cmbC_UPTYPE.Text, txtC_EMP.Text, cmbC_STATE.Text, txtC_ETC.Text, txtTINV_TO.Text, txtTINV_AMT.Text, cmbTINV_CYCLE.Text, txtTINV_MM.Text,
                                    txtTINV_DD.Text, txtTINV_ETC.Text, cmbCHK_TYPE.Text, cmbCHK_CYCLE.Text, txtCHK_MM.Text, txtCHK_EMP.Text, txtCHK_ETC.Text);

                                MessageBox.Show("데이터 수정완료", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // 수정완료후 
                                if (cmbC_UPTYPE.Text.ToString().Equals("1"))
                                {
                                    cmbC_UPTYPE.Text = "자동";
                                }
                                else
                                {
                                    cmbC_UPTYPE.Text = "수동";
                                }

                                if (cmbC_STATE.Text.ToString().Equals("1"))
                                {
                                    cmbC_STATE.Text = "유효";
                                }
                                else if (cmbC_STATE.Text.ToString().Equals("2"))
                                {
                                    cmbC_STATE.Text = "만료";
                                }
                                else
                                {
                                    cmbC_STATE.Text = "해지";
                                }

                                // 색상 하얀색으로 초기화
                                txtC_NM.BackColor = Color.White;
                                txtC_TITLE.BackColor = Color.White;
                                txtC_STDT.CalendarForeColor = Color.White;
                                txtC_EDDT.CalendarForeColor = Color.White;
                                txtC_UPDT.CalendarForeColor = Color.White;
                                cmbC_UPTYPE.BackColor = Color.White;
                                txtC_EMP.BackColor = Color.White;
                                cmbC_STATE.BackColor = Color.White;
                                txtC_ETC.BackColor = Color.White;
                                txtTINV_TO.BackColor = Color.White;
                                txtTINV_AMT.BackColor = Color.White;
                                cmbTINV_CYCLE.BackColor = Color.White;
                                txtTINV_MM.BackColor = Color.White;
                                txtTINV_DD.BackColor = Color.White;
                                txtTINV_ETC.BackColor = Color.White;
                                cmbCHK_TYPE.BackColor = Color.White;
                                cmbCHK_CYCLE.BackColor = Color.White;
                                txtCHK_MM.BackColor = Color.White;
                                txtCHK_EMP.BackColor = Color.White;
                                txtCHK_ETC.BackColor = Color.White;
                            }
                            else
                            {
                                MessageBox.Show("데이터 수정취소", "수정취소", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("유지보수목록을 클릭해주세요.", "클릭오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (button3.Text == "저장")
                {
                    if (JHSDB.DB_Connect())
                    {
                        if (listView1.SelectedIndices.Count != 0)
                        {
                            CheckDuplicate = JHSDB.InsertCheck(Convert.ToInt32(txtNon.Text.ToString()));
                        }
                        //리스트뷰의 선택된 인덱스가 존재하지 않을 경우
                        else if (listView1.SelectedIndices.Count == 0)
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
                        else if (CheckDuplicate[0]["have"].ToString() == "0")
                        {

                            if (MessageBox.Show("데이터를 추가하시겠습니까?", "데이터 추가", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                // 갱신방식 DB넣을때 숫자로 되어있어서 if문 작성
                                if (cmbC_UPTYPE.Text.ToString().Equals("자동"))
                                {
                                    cmbC_UPTYPE.Text = "1";
                                }
                                else
                                {
                                    cmbC_UPTYPE.Text = "2";
                                }

                                // 계약상태 DB넣을때 숫자로 되어있어서 if문 작성
                                if (cmbC_STATE.Text.ToString().Equals("유효"))
                                {
                                    cmbC_STATE.Text = "1";
                                }
                                else if (cmbC_STATE.Text.ToString().Equals("만료"))
                                {
                                    cmbC_STATE.Text = "2";
                                }
                                else
                                {
                                    cmbC_STATE.Text = "3";
                                }

                                result = JHSDB.MaintainInsert(txtC_NM.Text, txtC_TITLE.Text, Convert.ToDateTime(txtC_STDT.Text), Convert.ToDateTime(txtC_EDDT.Text), Convert.ToDateTime(txtC_UPDT.Text),
                                    cmbC_UPTYPE.Text, txtC_EMP.Text, cmbC_STATE.Text, txtC_ETC.Text, txtTINV_TO.Text, txtTINV_AMT.Text, cmbTINV_CYCLE.Text, txtTINV_MM.Text, txtTINV_DD.Text,
                                    txtTINV_ETC.Text, cmbCHK_TYPE.Text, cmbCHK_CYCLE.Text, txtCHK_MM.Text, txtCHK_EMP.Text, txtCHK_ETC.Text);

                                MessageBox.Show("데이터를 저장하였습니다", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // 초기화
                                Reset();
                                listView2.Items.Clear();
                            }
                            else
                            {
                                MessageBox.Show("데이터 저장를 취소하였습니다.", "데이터 저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

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

        #region 삭제버튼
        private void button4_Click(object sender, EventArgs e)
        {
            string strQuery = "";
            string strQuery2 = "";
            try
            {
                if (listView1.SelectedItems.Count != 0)
                {
                    if (JHSDB.DB_Connect())
                    {
                        if (MessageBox.Show("데이터를 삭제하시겠습니까?", "데이터 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            strQuery = "Delete from tb_contract where CSEQ = '" + listView1.FocusedItem.SubItems[6].Text + "'";   // contract 테이블 삭제
                            strQuery2 = "Delete from tb_cont_prj where CSEQ = '" + listView1.FocusedItem.SubItems[6].Text + "'";  // cont_prj 테이블 삭제
                            JHSDB.Delete(strQuery2); // 외래키로 연결되어있기때문에 먼저 삭제해야함
                            JHSDB.Delete(strQuery);  // 외래키가 삭제되었기때문에 삭제가 가능함

                            // 초기화
                            
                            listView2.Items.Clear();

                            Reset();

                            MessageBox.Show("데이터를 삭제하였습니다", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("데이터 삭제를 취소하였습니다.", "데이터 삭제", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("유지보수목록을 클릭해주세요.", "클릭오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            DBLoad();
        }
        #endregion

        #region listView1(유지보수조회목록) 검색
        private void btnSearch_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listItem.Clear();

            string dateToday = DateTime.Now.ToString("yyyyMM");
            string[] dateUPDT;

            try
            {
                if (JHSDB.DB_Connect() == true)
                {
                    // 계약상태
                    if (cmbSelect.Text == "유효")
                    {
                        cmbSelect.Text = "1";
                    }
                    else if (cmbSelect.Text == "만료")
                    {
                        cmbSelect.Text = "2";
                    }
                    else if (cmbSelect.Text == "해지")
                    {
                        cmbSelect.Text = "3";
                    }

                    listItem = JHSDB.MaintainShowSeacrh(txtSelect.Text, cmbSelect.Text);

                    string[] list;

                    // 계약상태
                    if (cmbSelect.Text == "1")
                    {
                        cmbSelect.Text = "유효";
                    }
                    else if (cmbSelect.Text == "2")
                    {
                        cmbSelect.Text = "만료";
                    }
                    else if (cmbSelect.Text == "3")
                    {
                        cmbSelect.Text = "해지";
                    }

                    for (int i = 0; i < listItem.Count; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.SubItems.Add((i + 1).ToString());                   // No
                        item.SubItems.Add(listItem[i]["C_TITLE"].ToString());    // 계약항목

                        list = listItem[i]["C_STDT"].ToString().Split(' ');      // 시작일 뒷부분 자르기
                        item.SubItems.Add(list[0].ToString());                   // 시작일
                        list = listItem[i]["C_EDDT"].ToString().Split(' ');      // 종료일 뒷부분 자르기
                        item.SubItems.Add(list[0].ToString());                   // 종료일

                        if (listItem[i]["C_STATE"].ToString() == "1")             // 계약상태
                        {
                            item.SubItems.Add("유효");
                        }
                        else if (listItem[i]["C_STATE"].ToString() == "2")
                        {
                            item.SubItems.Add("만료");
                        }
                        else if (listItem[i]["C_STATE"].ToString() == "3")
                        {
                            item.SubItems.Add("해지");
                        }

                        item.SubItems.Add(listItem[i]["CSEQ"].ToString());       // 고정값
                        item.SubItems.Add(listItem[i]["C_NM"].ToString());       // 계약업체 (검색용으로 넣어둠)
                        item.SubItems.Add(listItem[i]["C_UPDT"].ToString());     // 갱신일

                        listView1.Items.Add(item);
                    }

                    // 갱신일 현재 일자 기준으로 한달전인거 색상표시
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        dateUPDT = listView1.Items[i].SubItems[8].Text.ToString().Split('-');
                        // 계약상태가 유효할때
                        if (listView1.Items[i].SubItems[5].Text.ToString() == "유효")
                        {
                            // 갱신일에서 현재날을 빼서 0,1,89 결과가나오면 갱신일까지 한달전이니깐 색상주기
                            // ex) 현재날 2021년12월 갱신일 2022년1월 202201 - 202112 = 89
                            if ((Convert.ToInt32(dateUPDT[0] + dateUPDT[1]) - Convert.ToInt32(dateToday)) == 1 || (Convert.ToInt32(dateUPDT[0] + dateUPDT[1]) - Convert.ToInt32(dateToday)) == 0 || (Convert.ToInt32(dateUPDT[0] + dateUPDT[1]) - Convert.ToInt32(dateToday)) == 89)
                            {
                                listView1.Items[i].BackColor = Color.LightGreen;
                            }
                        }
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

        #region 검색창 공백일시 전체불러오기
        private void txtSelect_TextChanged(object sender, EventArgs e)
        {
            if (txtSelect.Text == "")
            {
                DBLoad();
            }
        }
        #endregion

        #region 검색 Enter키 누르면 보여질수있게하기
        private void txtSelect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSearch_Click(sender, e);
            }
        }
        #endregion

        #region 검색주석
        private void txtSelect_Click(object sender, EventArgs e)
        {
            txtSelect.Text = "";
            txtSelect.ForeColor = Color.Black;
        }
        #endregion

        #region 프로젝트 추가용 listView2 '+' 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            // 리스트뷰 선택된것이 있을경우
            if (listView1.SelectedItems.Count != 0)
            {
                Maintain_Contract_Plus mtp = new Maintain_Contract_Plus();
                mtp.Passvalue = listView1.FocusedItem.SubItems[6].Text;   // 프로젝트 추가용 쪽으로 클릭했던 유지보수 고정키값을 보냄
                mtp.ShowDialog();

                listView2.Items.Clear();
                ProjectLoad();
            }
            // 리스트뷰를 선택하지않았을경우
            else
            {
                MessageBox.Show("유지보수목록을 클릭해주세요.", "클릭오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 프로젝트 추가용 listView2 '-' 버튼
        private void button5_Click(object sender, EventArgs e)
        {
            string strQuery = "";
            try
            {
                if (listView1.SelectedItems.Count != 0)
                {
                    if (listView2.SelectedItems.Count != 0)
                    {
                        if (JHSDB.DB_Connect())
                        {
                            if (MessageBox.Show("데이터를 삭제하시겠습니까?", "데이터 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                strQuery = "Delete from tb_cont_prj where CSEQ = '" + listView2.FocusedItem.SubItems[4].Text + "' and PSEQ = '" + listView2.FocusedItem.SubItems[5].Text + "'";
                                JHSDB.Delete(strQuery);

                                MessageBox.Show("데이터를 삭제하였습니다", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                listView2.Items.Clear();
                                ProjectLoad();
                            }
                            else
                            {
                                MessageBox.Show("데이터 삭제를 취소하였습니다.", "데이터 삭제", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("프로젝트목록을 클릭해주세요.", "클릭오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("유지보수목록을 클릭해주세요.", "클릭오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            DBLoad();
        }
        #endregion

        #region 리셋(초기화)
        public void Reset()
        {
            if(listView1.SelectedItems.Count != 0)
            {
                listView1.SelectedItems[0].Selected = false;
            }

            // 초기화
            txtC_NM.Text = "";
            txtC_TITLE.Text = "";
            txtC_STDT.Text = "";
            txtC_EDDT.Text = "";
            txtC_UPDT.Text = "";
            cmbC_UPTYPE.Text = "";
            txtC_EMP.Text = "";
            cmbC_STATE.Text = "";
            txtC_ETC.Text = "";
            txtTINV_TO.Text = "";
            txtTINV_AMT.Text = "";
            cmbTINV_CYCLE.Text = "";
            txtTINV_MM.Text = "";
            txtTINV_DD.Text = "";
            txtTINV_ETC.Text = "";
            cmbCHK_TYPE.Text = "";
            cmbCHK_CYCLE.Text = "";
            txtCHK_MM.Text = "";
            txtCHK_EMP.Text = "";
            txtCHK_ETC.Text = "";
            txtNon.Text = "";

            txtC_NM.BackColor = Color.White;
            txtC_TITLE.BackColor = Color.White;
            txtC_STDT.CalendarForeColor = Color.White;
            txtC_EDDT.CalendarForeColor = Color.White;
            txtC_UPDT.CalendarForeColor = Color.White;
            cmbC_UPTYPE.BackColor = Color.White;
            txtC_EMP.BackColor = Color.White;
            cmbC_STATE.BackColor = Color.White;
            txtC_ETC.BackColor = Color.White;
            txtTINV_TO.BackColor = Color.White;
            txtTINV_AMT.BackColor = Color.White;
            cmbTINV_CYCLE.BackColor = Color.White;
            txtTINV_MM.BackColor = Color.White;
            txtTINV_DD.BackColor = Color.White;
            txtTINV_ETC.BackColor = Color.White;
            cmbCHK_TYPE.BackColor = Color.White;
            cmbCHK_CYCLE.BackColor = Color.White;
            txtCHK_MM.BackColor = Color.White;
            txtCHK_EMP.BackColor = Color.White;
            txtCHK_ETC.BackColor = Color.White;
        }
        #endregion 

        #region 수정시 색상구분해주는 유효성검사

        #region 수정된 텍스트박스 색상주기
        public void change(string name, TextBox box)
        {
            if (listView1.SelectedIndices.Count != 0)
            {
                if (listCompare[0][name].ToString() != box.Text)
                {
                    box.BackColor = Color.Yellow;
                    button3.Text = "수정";

                }
                else if (listCompare[0][name].ToString() == box.Text)
                {
                    box.BackColor = Color.White;
                    button3.Text = "저장";
                }
            }
            else
            {

            }
        }
        #endregion

        #region 수정된 콤보박스 색상주기
        public void changeCmb(string name, ComboBox cBox)
        {
            if (listView1.SelectedIndices.Count != 0)
            {
                if (listCompare[0][name].ToString() != cBox.Text)
                {
                    cBox.BackColor = Color.Yellow;
                    button3.Text = "수정";

                }
                else if (listCompare[0][name].ToString() == cBox.Text)
                {
                    cBox.BackColor = Color.White;
                    button3.Text = "저장";
                }
            }
            else
            {

            }
        }
        #endregion

        #region 수정된 데이트픽커 색상주기
        public void changeDate(string name, DateTimePicker dBox)
        {
            if (listView1.SelectedIndices.Count != 0)
            {
                if (listCompare[0][name].ToString() != dBox.Value.ToString())
                {
                    dBox.CalendarTitleBackColor = Color.Yellow;
                    button3.Text = "수정";

                }
                else if (listCompare[0][name].ToString() == dBox.Value.ToString())
                {
                    dBox.CalendarMonthBackground = Color.Black;
                    button3.Text = "저장";
                }
            }
            else
            {

            }
        }
        #endregion

        #region 계약업체
        private void txtC_NM_TextChanged(object sender, EventArgs e)
        {
            change("C_NM", txtC_NM);
        }
        #endregion

        #region 계약항목
        private void txtC_TITLE_TextChanged(object sender, EventArgs e)
        {
            change("C_TITLE", txtC_TITLE);
        }
        #endregion

        #region 계약상태
        private void cmbC_STATE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbC_STATE.Text == "유효")
            {
                cmbC_STATE.Text = "1";
            }
            else if(cmbC_STATE.Text == "만료")
            {
                cmbC_STATE.Text = "2";
            }
            else
            {
                cmbC_STATE.Text = "3";
            }

            changeCmb("C_STATE", cmbC_STATE);

            if (cmbC_STATE.Text == "1")
            {
                cmbC_STATE.Text = "유효";
            }
            else if (cmbC_STATE.Text == "2")
            {
                cmbC_STATE.Text = "만료";
            }
            else
            {
                cmbC_STATE.Text = "해지";
            }
        }

        #endregion

        #region 계약기간 - 시작일
        private void txtC_STDT_ValueChanged(object sender, EventArgs e)
        {
            changeDate("C_STDT", txtC_STDT);
        }
        #endregion

        #region 계약기간 - 종료일
        private void txtC_EDDT_ValueChanged(object sender, EventArgs e)
        {
            changeDate("C_EDDT", txtC_EDDT);
        }
        #endregion

        #region 계약일(갱신기간)
        private void txtC_UPDT_ValueChanged(object sender, EventArgs e)
        {
            changeDate("C_UPDT", txtC_UPDT);
        }
        #endregion

        #region 갱신방식
        private void cmbC_UPTYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbC_UPTYPE.Text == "자동")
            {
                cmbC_UPTYPE.Text = "1";
            }
            else
            {
                cmbC_UPTYPE.Text = "2";
            }

            changeCmb("C_UPTYPE", cmbC_UPTYPE);

            if (cmbC_UPTYPE.Text == "1")
            {
                cmbC_UPTYPE.Text = "자동";
            }
            else
            {
                cmbC_UPTYPE.Text = "수동";
            }
        }
        #endregion

        #region 계약담당
        private void txtC_EMP_TextChanged(object sender, EventArgs e)
        {
            change("C_EMP", txtC_EMP);
        }
        #endregion

        #region 비고 - 계약정보
        private void txtC_ETC_TextChanged(object sender, EventArgs e)
        {
            change("C_ETC", txtC_ETC);
        }

        #endregion

        #region 발행처
        private void txtTINV_TO_TextChanged(object sender, EventArgs e)
        {
            change("TINV_TO", txtTINV_TO);
        }
        #endregion

        #region 발행금액
        private void txtTINV_AMT_TextChanged(object sender, EventArgs e)
        {
            /*txtTINV_AMT.Text = String.Format("{0:#,0}", Convert.ToDouble(txtTINV_AMT.Text));*/ // 콤마주기때문에 자꾸 수정표시로뜸
            change("TINV_AMT", txtTINV_AMT);
        }
        #endregion

        #region 발행주기
        private void cmbTINV_CYCLE_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeCmb("TINV_CYCLE", cmbTINV_CYCLE);
        }

        #endregion

        #region 발행월
        private void txtTINV_MM_TextChanged(object sender, EventArgs e)
        {
            change("TINV_MM", txtTINV_MM);
        }
        #endregion

        #region 비고 - 세금계산서
        private void txtTINV_ETC_TextChanged(object sender, EventArgs e)
        {
            change("TINV_ETC", txtTINV_ETC);
        }

        #endregion

        #region 발행일자
        private void txtTINV_DD_TextChanged(object sender, EventArgs e)
        {
            change("TINV_DD", txtTINV_DD);
        }
        #endregion

        #region 점검방법
        private void cmbCHK_TYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeCmb("CHK_TYPE", cmbCHK_TYPE);
        }

        #endregion

        #region 점검주기
        private void cmbCHK_CYCLE_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeCmb("CHK_CYCLE", cmbCHK_CYCLE);
        }

        #endregion

        #region 점검월
        private void txtCHK_MM_TextChanged(object sender, EventArgs e)
        {
            change("CHK_MM", txtCHK_MM);
        }

        #endregion

        #region 점검확인자
        private void txtCHK_EMP_TextChanged(object sender, EventArgs e)
        {
            change("CHK_EMP", txtCHK_EMP);
        }
        #endregion

        #region 비고 - 유지보수 점검정보
        private void txtCHK_ETC_TextChanged(object sender, EventArgs e)
        {
            change("CHK_ETC", txtCHK_ETC);
        }
        #endregion

        #endregion
    }
}
