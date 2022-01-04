using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PPM_project
{
    class MariaDB
    {
        public static MySqlConnection con;

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        #region 디비 연결
        public static bool DB_Connect()
        {
            StringBuilder Server = new StringBuilder(1024);
            GetPrivateProfileString("Server","Server", "", Server, 10000000, Application.StartupPath + "\\Server.ini");
            string dbCon = Server.ToString();
            bool conStatus = false;
            try
            {
                con = new MySqlConnection(dbCon);
                con.Open();
                conStatus = true;
            }
            catch
            {
                conStatus = false;
            }
            return conStatus;
        }
        #endregion

        #region 디비 닫기
        public static void DB_Close()
        {
            con.Close();
        }
        #endregion

        #region 고객사 관리 리스트뷰 출력
        public static List<Dictionary<string, object>> Show()
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            try
            {
                string query = "SELECT * FROM tb_project order by PSEQ desc";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    //읽어드린 내용을 List에 저장해서 return
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("PSEQ", mdr["PSEQ"].ToString());
                    dic.Add("CUST_NM", mdr["CUST_NM"].ToString());
                    dic.Add("PRJ_NM", mdr["PRJ_NM"].ToString());
                    dic.Add("PRJ_STDT", mdr["PRJ_STDT"].ToString());
                    dic.Add("PRJ_EDDT", mdr["PRJ_EDDT"].ToString());
                    dic.Add("PACE_PRODUCT", mdr["PACE_PRODUCT"].ToString());
                    dic.Add("EXTERNAL_PRODUCT", mdr["EXTERNAL_PRODUCT"].ToString());
                    dic.Add("PRODUCT_TYPE", mdr["PRODUCT_TYPE"].ToString());
                    dic.Add("PRJ_DEPT", mdr["PRJ_DEPT"].ToString());
                    dic.Add("PRJ_EMP", mdr["PRJ_EMP"].ToString());
                    dic.Add("MAINT_STDT", mdr["MAINT_STDT"].ToString());
                    dic.Add("PRJ_ETC", mdr["PRJ_ETC"].ToString());
                    dic.Add("UPD_ID", mdr["UPD_ID"].ToString());
                    dic.Add("UPD_DT", mdr["UPD_DT"].ToString());


                    list.Add(dic);
                }
                mdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ShowData", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return list;
        }
        #endregion

        #region 검색
        public static List<Dictionary<string, object>> ShowSeacrh(string query)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    //읽어드린 내용을 List에 저장해서 return
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("PSEQ", mdr["PSEQ"].ToString());
                    dic.Add("CUST_NM", mdr["CUST_NM"].ToString());
                    dic.Add("PRJ_NM", mdr["PRJ_NM"].ToString());
                    dic.Add("PRJ_STDT", mdr["PRJ_STDT"].ToString());
                    dic.Add("PRJ_EDDT", mdr["PRJ_EDDT"].ToString());
                    dic.Add("PACE_PRODUCT", mdr["PACE_PRODUCT"].ToString());
                    dic.Add("EXTERNAL_PRODUCT", mdr["EXTERNAL_PRODUCT"].ToString());
                    dic.Add("PRODUCT_TYPE", mdr["PRODUCT_TYPE"].ToString());
                    dic.Add("PRJ_DEPT", mdr["PRJ_DEPT"].ToString());
                    dic.Add("PRJ_EMP", mdr["PRJ_EMP"].ToString());
                    dic.Add("MAINT_STDT", mdr["MAINT_STDT"].ToString());
                    dic.Add("PRJ_ETC", mdr["PRJ_ETC"].ToString());
                    dic.Add("UPD_ID", mdr["UPD_ID"].ToString());
                    dic.Add("UPD_DT", mdr["UPD_DT"].ToString());


                    list.Add(dic);
                }
                mdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ShowSearch", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return list;
        }
        #endregion

        #region 고객사 정보
        public static List<Dictionary<string, object>> ShowData(string PSEQ)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            try
            {

                string query = "SELECT * FROM tb_project WHERE PSEQ = @PSEQ";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PSEQ", PSEQ);

                MySqlDataReader mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    //읽어드린 내용을 List에 저장해서 return
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("PSEQ", mdr["PSEQ"].ToString());
                    dic.Add("CUST_NM", mdr["CUST_NM"].ToString());
                    dic.Add("PRJ_NM", mdr["PRJ_NM"].ToString());
                    dic.Add("PRJ_STDT", mdr["PRJ_STDT"].ToString());
                    dic.Add("PRJ_EDDT", mdr["PRJ_EDDT"].ToString());
                    dic.Add("PACE_PRODUCT", mdr["PACE_PRODUCT"].ToString());
                    dic.Add("EXTERNAL_PRODUCT", mdr["EXTERNAL_PRODUCT"].ToString());
                    dic.Add("PRODUCT_TYPE", mdr["PRODUCT_TYPE"].ToString());
                    dic.Add("PRJ_DEPT", mdr["PRJ_DEPT"].ToString());
                    dic.Add("PRJ_EMP", mdr["PRJ_EMP"].ToString());
                    dic.Add("MAINT_STDT", mdr["MAINT_STDT"].ToString());
                    dic.Add("PRJ_ETC", mdr["PRJ_ETC"].ToString());
                    dic.Add("UPD_ID", mdr["UPD_ID"].ToString());
                    dic.Add("UPD_DT", mdr["UPD_DT"].ToString());

                    list.Add(dic);
                }
                mdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Select", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return list;
        }
        #endregion

        #region 고객사 정보 등록
        public static int Insert(string CUST_NM, string PRJ_NM, DateTime PRJ_STDT, DateTime PRJ_EDDT, string PACE_PRODUCT, string EXTERNAL_PRODUCT, string PRODUCT_TYPE, string PRJ_DEPT, string PRJ_EMP,
               DateTime MAINT_STDT, string PRJ_ETC)
        {
            int result;
            try
            {
                string strQuery = "insert into tb_project(CUST_NM,PRJ_NM,PRJ_STDT,PRJ_EDDT,PACE_PRODUCT,EXTERNAL_PRODUCT,PRODUCT_TYPE,PRJ_DEPT,PRJ_EMP,MAINT_STDT,PRJ_ETC) " +
                    "values (@CUST_NM,@PRJ_NM,@PRJ_STDT,@PRJ_EDDT,@PACE_PRODUCT,@EXTERNAL_PRODUCT,@PRODUCT_TYPE,@PRJ_DEPT,@PRJ_EMP,@MAINT_STDT,@PRJ_ETC)";
                MySqlCommand cmd = new MySqlCommand(strQuery, con);

                cmd.Parameters.Add("@CUST_NM", MySqlDbType.VarChar).Value = CUST_NM;
                cmd.Parameters.Add("@PRJ_NM", MySqlDbType.VarChar).Value = PRJ_NM;
                cmd.Parameters.Add("@PRJ_STDT", MySqlDbType.Date).Value = PRJ_STDT;
                cmd.Parameters.Add("@PRJ_EDDT", MySqlDbType.Date).Value = PRJ_EDDT;
                cmd.Parameters.Add("@PACE_PRODUCT", MySqlDbType.VarChar).Value = PACE_PRODUCT;
                cmd.Parameters.Add("@EXTERNAL_PRODUCT", MySqlDbType.VarChar).Value = EXTERNAL_PRODUCT;
                cmd.Parameters.Add("@PRODUCT_TYPE", MySqlDbType.VarChar).Value = PRODUCT_TYPE;
                cmd.Parameters.Add("@PRJ_DEPT", MySqlDbType.VarChar).Value = PRJ_DEPT;
                cmd.Parameters.Add("@PRJ_EMP", MySqlDbType.VarChar).Value = PRJ_EMP;
                cmd.Parameters.Add("@MAINT_STDT", MySqlDbType.Date).Value = MAINT_STDT;
                cmd.Parameters.Add("@PRJ_ETC", MySqlDbType.VarChar).Value = PRJ_ETC;

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = 0;
            }
            return result;
        }
        #endregion

        #region 데이터 삭제
        public static int Delete(string PSEQ)
        {
            int result;
            try
            {
                string query = "Delete from tb_project where PSEQ = @PSEQ";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add("@PSEQ", MySqlDbType.Int32).Value = Convert.ToInt32(PSEQ);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("유지보수계약과 연동되어있는곳이 있는 프로젝트입니다.", "삭제오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = 0;
            }

            return result;
        }
        #endregion

        #region 고객사 정보 수정
        public static int Update(string CUST_NM, string PRJ_NM, DateTime PRJ_STDT, DateTime PRJ_EDDT, string PACE_PRODUCT, string EXTERNAL_PRODUCT, string PRODUCT_TYPE, string PRJ_DEPT, string PRJ_EMP,
               DateTime MAINT_STDT, string PRJ_ETC, int PSEQ)
        {
            int result;

            string[] list;
            string[] list2;
            string[] list3;

            list = PRJ_STDT.ToString().Split(' ');
            list2 = PRJ_EDDT.ToString().Split(' ');
            list3 = MAINT_STDT.ToString().Split(' ');

            string date1 = Regex.Replace(list[0], @"[^0-9]", "").ToString();
            string date2 = Regex.Replace(list2[0], @"[^0-9]", "").ToString();
            string date3 = Regex.Replace(list3[0], @"[^0-9]", "").ToString();

            Console.WriteLine(date1);

            try
            {
                string strQuery = "update tb_project set CUST_NM = @CUST_NM, PRJ_NM = @PRJ_NM, PRJ_STDT =@PRJ_STDT,PRJ_EDDT =@PRJ_EDDT,PACE_PRODUCT =@PACE_PRODUCT,EXTERNAL_PRODUCT = @EXTERNAL_PRODUCT, PRODUCT_TYPE = @PRODUCT_TYPE, PRJ_DEPT =@PRJ_DEPT, PRJ_EMP =@PRJ_EMP, MAINT_STDT =@MAINT_STDT,PRJ_ETC = @PRJ_ETC where PSEQ = @PSEQ ";
                MySqlCommand cmd = new MySqlCommand(strQuery, con);

                cmd.Parameters.Add("@CUST_NM", MySqlDbType.VarChar).Value = CUST_NM;
                cmd.Parameters.Add("@PRJ_NM", MySqlDbType.VarChar).Value = PRJ_NM;
                cmd.Parameters.Add("@PRJ_STDT", MySqlDbType.Date).Value = DateTime.ParseExact(date1, "yyyyMMdd", null);
                cmd.Parameters.Add("@PRJ_EDDT", MySqlDbType.Date).Value = DateTime.ParseExact(date2, "yyyyMMdd", null);
                cmd.Parameters.Add("@PACE_PRODUCT", MySqlDbType.VarChar).Value = PACE_PRODUCT;
                cmd.Parameters.Add("@EXTERNAL_PRODUCT", MySqlDbType.VarChar).Value = EXTERNAL_PRODUCT;
                cmd.Parameters.Add("@PRODUCT_TYPE", MySqlDbType.VarChar).Value = PRODUCT_TYPE;
                cmd.Parameters.Add("@PRJ_DEPT", MySqlDbType.VarChar).Value = PRJ_DEPT;
                cmd.Parameters.Add("@PRJ_EMP", MySqlDbType.VarChar).Value = PRJ_EMP;
                cmd.Parameters.Add("@MAINT_STDT", MySqlDbType.Date).Value = DateTime.ParseExact(date3, "yyyyMMdd", null);
                cmd.Parameters.Add("@PRJ_ETC", MySqlDbType.VarChar).Value = PRJ_ETC;
                cmd.Parameters.Add("@PSEQ", MySqlDbType.Int32).Value = PSEQ;

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = 0;
            }
            return result;
        }
        #endregion

        #region 고객사 정보 저장체크
        public static List<Dictionary<string, object>> InsertCheck(int PSEQ)
        {

            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            try
            {
                string strQuery = "SELECT EXISTS(SELECT * FROM tb_project where PSEQ =  @PSEQ) as have";
                MySqlCommand cmd = new MySqlCommand(strQuery, con);

                cmd.Parameters.Add("@PSEQ", MySqlDbType.Int32).Value = PSEQ;

                MySqlDataReader mdr = cmd.ExecuteReader();
               
                while (mdr.Read())
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("have", mdr["have"].ToString());

                    list.Add(dic);
                }
              
                mdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "InsertCheck", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            return list;
        }
        #endregion
    }
}