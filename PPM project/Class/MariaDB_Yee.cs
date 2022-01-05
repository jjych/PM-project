using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PPM_project
{
    class MariaDB_Yee
    {
        public static MySqlConnection con;

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static bool DB_Connect()
        {
            StringBuilder Server = new StringBuilder(1024);
            GetPrivateProfileString("Server", "Server", "", Server, 10000000, Application.StartupPath + "\\Server.ini");
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
        public static void DB_Close()
        {
            con.Close();
        }

        #region 로그인
        public static int login(string id, string pw)
        {
            int result;
            try
            {
                string sql = "select * from pacesystem_login where pId=@pId AND pPw=@pPw";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@pId", id);
                cmd.Parameters.AddWithValue("@pPw", pw);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() && reader["pId"].ToString() == id && reader["pPw"].ToString() == pw)
                {
                    Console.WriteLine("성공");
                    result = 1;
                }
                else
                {
                    Console.WriteLine("실패");
                    result = 0;
                }
                reader.Close();

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                result = 0;
                return result;
            }
        }
        #endregion

        #region 회원가입
        public static int signup(string id, string pw, string name)
        {
            int result;
            try
            {
                string sql = "insert into  pacesystem_login (pId,pPw,pName) values(@pid, @pPw, @pName)";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@pId", id);
                cmd.Parameters.AddWithValue("@pPw", pw);
                cmd.Parameters.AddWithValue("@pName", name);


                cmd.ExecuteNonQuery();
                result = 1;

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                result = 0;

                return result;
            }

        }
        #endregion

        #region 세금계산서 발행대장 리스트뷰
        public static List<Dictionary<string, object>> Show_tax(string CSEQ)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            try
            {
                string query = "SELECT* FROM tb_tax_invoice_redger t inner join tb_contract c on t.CSEQ = c.CSEQ WHERE R_STATE LIKE CONCAT('%' '0' '%') ORDER BY R_YEAR DESC, R_MONTH DESC";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CSEQ", CSEQ);

                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("C_TITLE", mdr["C_TITLE"].ToString());
                    dic.Add("R_YEAR", mdr["R_YEAR"].ToString());
                    dic.Add("R_MONTH", mdr["R_MONTH"].ToString());
                    dic.Add("R_DT", mdr["R_DT"].ToString());
                    dic.Add("R_AMT", mdr["R_AMT"]);
                    dic.Add("R_STATE", mdr["R_STATE"].ToString());
                    dic.Add("CSEQ", mdr["CSEQ"].ToString());

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

        #region 세금계산서 발행대장 데이터 추리기
        public static List<Dictionary<string, object>> Show_Reg(DateTime date, string month)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            try
            {
                string[] date1;
                string[] date2;
                date1 = date.ToString().Split(' ');
                date2 = date1[0].ToString().Split('-');
                string realdate = date2[0].ToString() + date2[1].ToString(); //발행연도 + 발행월

                string query = "SELECT * FROM tb_contract WHERE C_STATE LIKE CONCAT('%' '1' '%')";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@C_EDDT", realdate);
                cmd.Parameters.AddWithValue("@TINV_MM", month);

                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    //읽어드린 내용을 List에 저장해서 return
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("TINV_AMT", mdr["TINV_AMT"].ToString());
                    dic.Add("C_TITLE", mdr["C_TITLE"].ToString());
                    dic.Add("CSEQ", mdr["CSEQ"].ToString());

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

        #region 세금 발행대장 저장
        public static int Insert(string R_YEAR, string R_MONTH, int CSEQ, int R_AMT, string R_STATE)
        {
            int result;
            try
            {
                string strQuery = "insert into tb_tax_invoice_redger(R_YEAR,R_MONTH,CSEQ,R_AMT,R_STATE) values (@R_YEAR,@R_MONTH,@CSEQ,@R_AMT,@R_STATE)";
                MySqlCommand cmd = new MySqlCommand(strQuery, con);

                cmd.Parameters.Add("@R_YEAR", MySqlDbType.VarChar).Value = R_YEAR;
                cmd.Parameters.Add("@R_MONTH", MySqlDbType.VarChar).Value = R_MONTH;
                cmd.Parameters.Add("@CSEQ", MySqlDbType.Int32).Value = CSEQ;
                cmd.Parameters.Add("@R_AMT", MySqlDbType.Int32).Value = R_AMT;
                cmd.Parameters.Add("@R_STATE", MySqlDbType.VarChar).Value = R_STATE;

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

        #region 세금 발행대장 
        public static List<Dictionary<string, object>> InsertCheck(string R_YEAR, string R_MONTH, int CSEQ)
        {

            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            try
            {
                string strQuery = "SELECT EXISTS(SELECT * FROM tb_tax_invoice_redger where R_YEAR =  @R_YEAR AND R_MONTH = @R_MONTH AND CSEQ = @CSEQ ) as have";
                MySqlCommand cmd = new MySqlCommand(strQuery, con);

                cmd.Parameters.Add("@R_YEAR", MySqlDbType.VarChar).Value = R_YEAR;
                cmd.Parameters.Add("@R_MONTH", MySqlDbType.VarChar).Value = R_MONTH;
                cmd.Parameters.Add("@CSEQ", MySqlDbType.Int32).Value = CSEQ;

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
                MessageBox.Show(ex.Message, "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            return list;
        }
        #endregion

        #region 세금계산서 발행대장 세부사항
        public static List<Dictionary<string, object>> ShowData_tax(string CSEQ, string R_YEAR, string R_MONTH)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            try
            {
                Console.WriteLine(CSEQ);
                string query = "SELECT *  FROM tb_tax_invoice_redger t inner join tb_contract c on t.CSEQ = c.CSEQ where t.CSEQ = @CSEQ and c.CSEQ = @CSEQ and R_YEAR=@R_YEAR and R_MONTH=@R_MONTH";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CSEQ", CSEQ);
                cmd.Parameters.AddWithValue("@R_YEAR", R_YEAR);
                cmd.Parameters.AddWithValue("@R_MONTH", R_MONTH);

                MySqlDataReader mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    Console.WriteLine("리스트");
                    //읽어드린 내용을 List에 저장해서 return
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("C_NM", mdr["C_NM"].ToString());
                    dic.Add("C_TITLE", mdr["C_TITLE"].ToString());
                    dic.Add("C_STDT", mdr["C_STDT"].ToString());
                    dic.Add("C_EDDT", mdr["C_EDDT"].ToString());
                    dic.Add("C_STATE", mdr["C_STATE"].ToString());
                    dic.Add("R_YEAR", mdr["R_YEAR"].ToString());
                    dic.Add("R_MONTH", mdr["R_MONTH"].ToString());
                    dic.Add("TINV_DD", mdr["TINV_DD"].ToString());
                    dic.Add("R_AMT", string.Format("{0:n0}", mdr["R_AMT"]));
                    dic.Add("R_STATE", mdr["R_STATE"].ToString());
                    dic.Add("R_ETC", mdr["R_ETC"].ToString());

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

        #region 발행연도
        public static string ShowYear()
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            string year = "";
            try
            {
                string query = "SELECT * FROM  tb_contract where C_STDT = (select min(C_STDT) from tb_contract)";
                MySqlCommand cmd = new MySqlCommand(query, con);

                MySqlDataReader mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    /*  Dictionary<string, object> dic = new Dictionary<string, object>();
                      dic.Add("C_STDT", mdr["C_STDT"].ToString());

                      list.Add(dic);*/
                    year = mdr["C_STDT"].ToString();
                }
                mdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Select", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return year;
        }
        #endregion

        #region 검색
        public static List<Dictionary<string, object>> ShowSeacrh(string cmbYear, string cmbMonth, string txtSearch)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            try
            {
                string query = "SELECT * FROM tb_tax_invoice_redger t inner join tb_contract c on t.CSEQ = c.CSEQ  WHERE R_YEAR LIKE CONCAT('%' @cmbYear '%') AND R_MONTH LIKE CONCAT('%' @cmbMonth '%') AND C_TITLE LIKE CONCAT('%' @txtSearch '%')";
                /* string query = "SELECT * FROM tb_tax_invoice_redger t inner join tb_contract c on t.CSEQ = c.CSEQ  WHERE R_YEAR LIKE CONCAT('%' @cmbYear '%') AND "
                                 + "R_MONTH LIKE CONCAT('%' @cmbMonth '%') and " + "C_NM LIKE CONCAT('%' @txtSearch  '%') OR " + "C_TITLE LIKE CONCAT('%' @txtSearch  '%')";*/

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@cmbYear", cmbYear);
                cmd.Parameters.AddWithValue("@cmbMonth", cmbMonth); //mon
                cmd.Parameters.AddWithValue("@txtSearch", txtSearch);

                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    //읽어드린 내용을 List에 저장해서 return
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("C_TITLE", mdr["C_TITLE"].ToString());
                    dic.Add("R_YEAR", mdr["R_YEAR"].ToString());
                    dic.Add("R_MONTH", mdr["R_MONTH"].ToString());
                    dic.Add("R_DT", mdr["R_DT"].ToString());
                    dic.Add("R_AMT", mdr["R_AMT"].ToString());
                    dic.Add("R_STATE", mdr["R_STATE"].ToString());
                    dic.Add("CSEQ", mdr["CSEQ"].ToString());

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

        #region 수정
        public static int Modify(string R_YEAR, string R_MONTH, int R_AMT, string R_STATE, string R_ETC, string CSEQ)
        {
            int result;
            try
            {
                string query = "UPDATE tb_tax_invoice_redger SET R_YEAR=@R_YEAR, R_MONTH=@R_MONTH, R_AMT=@R_AMT, R_STATE=@R_STATE, R_ETC=@R_ETC WHERE CSEQ=@CSEQ AND R_YEAR=@R_YEAR AND R_MONTH=@R_MONTH";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@R_YEAR", R_YEAR);
                cmd.Parameters.AddWithValue("@R_MONTH", R_MONTH);
                cmd.Parameters.AddWithValue("@R_AMT", R_AMT);
                cmd.Parameters.AddWithValue("@R_STATE", R_STATE);
                cmd.Parameters.AddWithValue("@R_ETC", R_ETC);
                cmd.Parameters.AddWithValue("@CSEQ", CSEQ);

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = 0;
            }
            return result;
        }
        #endregion

        #region 삭제
        public static int Delete(string R_YEAR, string R_MONTH, string CSEQ)
        {
            int result;
            try
            {
                string query = "DELETE FROM tb_tax_invoice_redger WHERE R_YEAR=@R_YEAR AND R_MONTH=@R_MONTH AND CSEQ=@CSEQ";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@R_YEAR", R_YEAR);
                cmd.Parameters.AddWithValue("@R_MONTH", R_MONTH);
                cmd.Parameters.AddWithValue("@CSEQ", CSEQ);

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = 0;
            }
            return result;
        }
        #endregion

        #region  점검회사 리스트
        public static List<Dictionary<string, object>> Show_Main()
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

            try
            {
                string date = DateTime.Now.ToString("yyyyMM");
                string month = DateTime.Now.ToString("MM");


                string query = "SELECT * FROM tb_contract WHERE DATE_FORMAT(C_STDT, '%Y%m') <= @C_STDT AND DATE_FORMAT(C_EDDT, '%Y%m') >= @C_EDDT AND CHK_MM LIKE CONCAT('%', @CHK_MM,'%')";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@C_STDT", date);
                cmd.Parameters.AddWithValue("@C_EDDT", date);
                cmd.Parameters.AddWithValue("@CHK_MM", month);

                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("CHK_CYCLE", mdr["CHK_CYCLE"].ToString());
                    dic.Add("C_NM", mdr["C_NM"].ToString());
                    dic.Add("C_TITLE", mdr["C_TITLE"].ToString());
                    dic.Add("CHK_TYPE", mdr["CHK_TYPE"].ToString());
                    dic.Add("CHK_MM", mdr["CHK_MM"].ToString());

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

        #region  세금관련 리스트
        public static List<Dictionary<string, object>> Show_TaxList(string CSEQ)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            try
            {
                string date = DateTime.Now.ToString("yyyyMM");
                string month = DateTime.Now.ToString("MM");

                string query = "SELECT * FROM tb_tax_invoice_redger t inner join tb_contract c on t.CSEQ = c.CSEQ WHERE DATE_FORMAT(C_STDT, '%Y%m') <= @C_STDT AND DATE_FORMAT(C_EDDT, '%Y%m') >= @C_EDDT AND CHK_MM LIKE CONCAT('%', @CHK_MM ,'%') AND R_STATE LIKE CONCAT('%', '0' ,'%') ORDER BY R_DT ASC";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@C_STDT", date);
                cmd.Parameters.AddWithValue("@C_EDDT", date);
                cmd.Parameters.AddWithValue("@CHK_MM", month);
                cmd.Parameters.AddWithValue("@CSEQ", CSEQ);

                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("C_NM", mdr["C_NM"].ToString());
                    dic.Add("R_AMT", mdr["R_AMT"].ToString());
                    dic.Add("R_DT", mdr["R_DT"].ToString());
                    dic.Add("R_STATE", mdr["R_STATE"].ToString());
                    dic.Add("CSEQ", mdr["CSEQ"].ToString());

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

    }
}