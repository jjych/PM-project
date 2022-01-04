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
    public partial class Tax_info : Form
    {
        List<Dictionary<String, object>> listItem3 = new List<Dictionary<string, object>>();
        List<Dictionary<String, object>> listItem4 = new List<Dictionary<string, object>>();
        private List<Dictionary<string, string>> Tax_info_value;
        Tax_bill bill;

        #region PassValue
        public List<Dictionary<string, string>> Passvalue
        {
            get { return this.Tax_info_value; }
            set { this.Tax_info_value = value; }
        }

        #endregion

        public Tax_info(Tax_bill bills)
        {
            bill = bills;
            InitializeComponent();
        }

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
            lstView.Columns.Add("발행월", 100, HorizontalAlignment.Center);
            lstView.Columns.Add("발행일", 100, HorizontalAlignment.Center);
            lstView.Columns.Add("발행금액", 100, HorizontalAlignment.Center);
            lstView.Columns.Add("발행상태", 100, HorizontalAlignment.Center);
            lstView.Columns.Add("외래키", 0, HorizontalAlignment.Center);

        }
        #endregion

        #region 폼로드
        private void Tax_info_Load(object sender, EventArgs e)
        {
            Set_ListView();
            DbLaod();
        }
        #endregion

        #region 디비로드
        public void DbLaod()
        {
            lstView.Items.Clear();
            int count = 0;
            try
            {
                string year = Passvalue[0].Values.ElementAt<string>(0);
                string month = Passvalue[0].Values.ElementAt<string>(1);
                Console.WriteLine(year + month + "테스트");


                if (MariaDB_Yee.DB_Connect() == true)
                {
                    string date = year + month;
                    listItem3 = MariaDB_Yee.Show_Reg(DateTime.ParseExact(date, "yyyyMM", null), month);
                    label2.Text = year + "년" + month + "월";

                    for (int i = 0; i < listItem3.Count; i++)
                    {
                        listItem4 = MariaDB_Yee.InsertCheck(year, month, Convert.ToInt32(listItem3[i]["CSEQ"].ToString()));

                        if (listItem4[0]["have"].ToString() == "0")
                        {
                            Tax_bill tax = new Tax_bill();
                            List<Dictionary<string, string>> se = new List<Dictionary<string, string>>();
                            Dictionary<string, string> sa = new Dictionary<string, string>();

                            ListViewItem item = new ListViewItem();
                            item.SubItems.Add((lstView.Items.Count + 1).ToString());
                            item.SubItems.Add(listItem3[i]["C_TITLE"].ToString());
                            item.SubItems.Add(year);
                            item.SubItems.Add(month);
                            item.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd"));
                            item.SubItems.Add(listItem3[i]["TINV_AMT"].ToString());
                            item.SubItems.Add("0");
                            item.SubItems.Add(listItem3[i]["CSEQ"].ToString());

                            lstView.Items.Add(item);
                        }
                        else
                        {
                            count++;
                        }

                        if (count == listItem3.Count)
                        {
                            MessageBox.Show("이미 발행한 데이터가 존재 합니다");
                            this.Close();

                        }
                    }
                    if (listItem3.Count == 0)
                    {
                        MessageBox.Show("해당 기간내에 발행할 회사가 존재하지 않습니다");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnCreateTax", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 리스트뷰 관련
        private void lstView_DrawColumnHeader_1(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                {
                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics,
                    new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                    value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void lstView_DrawItem_1(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lstView_DrawSubItem_1(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        #endregion

        #region 확인버튼
        private void btnOk_Click(object sender, EventArgs e)
        {
            lstView.Items.Clear();
            int count = 0;
            try
            {
                string year = Passvalue[0].Values.ElementAt<string>(0);
                string month = Passvalue[0].Values.ElementAt<string>(1);

                if (MariaDB_Yee.DB_Connect() == true)
                {
                    Tax_bill tax = new Tax_bill();
                    string date = year + month;

                    for (int i = 0; i < listItem3.Count; i++)
                    {
                        listItem4 = MariaDB_Yee.InsertCheck(year, month, Convert.ToInt32(listItem3[i]["CSEQ"].ToString()));

                        if (listItem4[0]["have"].ToString() == "0")
                        {

                            MariaDB_Yee.Insert(year, month, Convert.ToInt32(listItem3[i]["CSEQ"].ToString()), Convert.ToInt32(listItem3[i]["TINV_AMT"].ToString()), "0");
                            //여기서 디비에 들어감

                            this.Close();
                            bill.DBLoad();

                        }
                        else
                        {
                            count++;
                        }
                        if (count == listItem3.Count)
                        {
                            MessageBox.Show("이미 발행한 데이터가 존재 합니다");
                        }
                    }
                    if (listItem3.Count == 0)
                    {
                        MessageBox.Show("해당 기간내에 발행할 회사가 존재하지 않습니다");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnCreateTax", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 취소버튼
        private void btnCancle_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

    }
}