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
    public partial class main : Form
    {
        List<Dictionary<String, object>> listItem = new List<Dictionary<string, object>>();

        public main()
        {
            InitializeComponent();
            //label1.Text = DateTime.Now.ToString("yyyy") + "년 " + DateTime.Now.ToString("MM") + "월 " + DateTime.Now.ToString("dd") + "일";
            label3.Text = DateTime.Now.ToString("yyyy") + "년 " + DateTime.Now.ToString("MM") + "월 " + DateTime.Now.ToString("dd") + "일";
            //label2.Text = DateTime.Now.ToString("HH") + "시 " + DateTime.Now.ToString("ss") + "분";

        }

        #region 폼로드
        private void main_Load(object sender, EventArgs e)
        {
            Set_ListView();
            Set_TaxListView();
            DBLoad();
            this.WindowState = FormWindowState.Maximized;
            btnProject.Text = "     프로젝트     " + "\r\n관리";
            btnMaintain.Text = "     유지보수     " + "\r\n계약관리";
            btnTax.Text = "     세금계산서     " + "\r\n발행대장";
            btnInspect.Text = "     유지보수     " + "\r\n점검대장";
        }
        #endregion

        #region 디비 로드
        public void DBLoad()
        {
            lstView.Items.Clear();
            TaxListView.Items.Clear();
            listItem.Clear();

            //점검회사 리스트뷰
            try
            {
                if (MariaDB_Yee.DB_Connect() == true)
                {
                    listItem = MariaDB_Yee.Show_Main();

                    for (int i = 0; i < listItem.Count; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.SubItems.Add((i + 1).ToString());
                        item.SubItems.Add(listItem[i]["CHK_CYCLE"].ToString());
                        item.SubItems.Add(listItem[i]["C_NM"].ToString());
                        item.SubItems.Add(listItem[i]["C_TITLE"].ToString());
                        item.SubItems.Add(listItem[i]["CHK_TYPE"].ToString());
                        item.SubItems.Add(listItem[i]["CHK_MM"].ToString());

                        lstView.Items.Add(item);
                    }
                    MariaDB_Yee.DB_Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnSelect_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //세금관련 리스트뷰
            string strQuery = "";
            try
            {
                if (MariaDB_Yee.DB_Connect() == true)
                {
                    listItem = MariaDB_Yee.Show_TaxList(strQuery);

                    for (int i = 0; i < listItem.Count; i++)
                    {
                        string[] Date;
                        Date = listItem[i]["R_DT"].ToString().Split(' ');

                        ListViewItem item = new ListViewItem();
                        item.SubItems.Add((i + 1).ToString());
                        item.SubItems.Add(listItem[i]["C_NM"].ToString());
                        item.SubItems.Add(String.Format("{0:#,0}", Convert.ToInt32(listItem[i]["R_AMT"].ToString()))); // 콤마주기
                        item.SubItems.Add(Date[0].ToString());
                        if (listItem[i]["R_STATE"].ToString() == "1")             // 납부여부
                        {
                            item.SubItems.Add("납부");
                        }
                        else if (listItem[i]["R_STATE"].ToString() == "0")
                        {
                            item.SubItems.Add("미납");
                        }
                        item.SubItems.Add(listItem[i]["CSEQ"].ToString());

                        TaxListView.Items.Add(item);
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
            lstView.Columns.Add("점검주기", 100, HorizontalAlignment.Center);
            lstView.Columns.Add("업체명", 160, HorizontalAlignment.Center);
            lstView.Columns.Add("시스템명", 160, HorizontalAlignment.Center);
            lstView.Columns.Add("점검방식", 100, HorizontalAlignment.Center);
            lstView.Columns.Add("점검월", 230, HorizontalAlignment.Center);
        }
        #endregion

        #region TaxListView 설정
        private void Set_TaxListView()
        {
            //화면 설정
            TaxListView.View = View.Details;
            //구분선 표시설정
            TaxListView.GridLines = true;
            //한줄씩 선택 설정
            TaxListView.FullRowSelect = true;
            //Clouumn 추가
            TaxListView.Columns.Add("CheckBox", "", 0, HorizontalAlignment.Center, 0);
            TaxListView.Columns.Add("No", 35, HorizontalAlignment.Center);
            TaxListView.Columns.Add("업체명", 260, HorizontalAlignment.Center);
            TaxListView.Columns.Add("발행금액", 180, HorizontalAlignment.Center);
            TaxListView.Columns.Add("발행날짜", 180, HorizontalAlignment.Center);
            TaxListView.Columns.Add("납부여부", 160, HorizontalAlignment.Center);
            TaxListView.Columns.Add("외래키", 0, HorizontalAlignment.Center);
        }
        #endregion

        #region 회사 새로고침 버튼
        private void btnComRefresh_Click(object sender, EventArgs e)
        {
            DBLoad();
        }
        #endregion

        #region 세금 새로고침 버튼
        private void btnTaxRefresh_Click(object sender, EventArgs e)
        {
            DBLoad();
        }
        #endregion

        #region 버튼모음

        #region 프로젝트 관리 버튼
        private void btnProject_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "WBrowser") // 열린 폼의 이름 검사
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {  // 폼을 최소화시켜 하단에 내려놓았는지 검사
                        openForm.WindowState = FormWindowState.Normal;

                        openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                    }
                    openForm.Activate();
                    return;
                }
            }

            Project project = new Project();

            //project.StartPosition = FormStartPosition.Manual;  // 원하는 위치를 직접 지정해서 띄우기 위해
            //project.Location = new Point(this.Location.X + this.Width, this.Location.Y); // 메인폼의 오른쪽에 위치토록
            project.Show();
        }
        #endregion

        #region 유지보수 계약관리 버튼
        private void btnMaintain_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "WBrowser") // 열린 폼의 이름 검사
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {  // 폼을 최소화시켜 하단에 내려놓았는지 검사
                        openForm.WindowState = FormWindowState.Normal;

                        openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                    }
                    openForm.Activate();
                    return;
                }
            }

            Maintain_Contract mc = new Maintain_Contract();
            mc.Show();
        }
        #endregion

        #region 세금계산서 발행대장 버튼
        private void btnTax_Click_1(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "WBrowser") // 열린 폼의 이름 검사
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {  // 폼을 최소화시켜 하단에 내려놓았는지 검사
                        openForm.WindowState = FormWindowState.Normal;

                        openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                    }
                    openForm.Activate();
                    return;
                }
            }

            Tax_bill tb = new Tax_bill();
            tb.Show();
        }
        #endregion

        #region 유지보수 점검대장 버튼
        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 홈 버튼
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            main main = new main();
            main.Show();
        }
        #endregion

        #endregion
    }
}