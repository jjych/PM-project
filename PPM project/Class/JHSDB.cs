using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PPM_project
{
    class JHSDB
    {
        public static MySqlConnection con;

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        #region 디비 연결
        public static bool DB_Connect()
        {
            // string dbCon = "Server=127.0.0.1;Port=3306;Database=pmm;Uid=root;Password=1234;allow user variables=true;CHARSET=utf8";
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
        #endregion

        #region 디비 닫기
        public static void DB_Close()
        {
            con.Close();
        }
        #endregion

        #region 유지보수 계약관리 리스트뷰 출력
        public static List<Dictionary<string, object>> MaintainShow()
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            try
            {
                string strQuery = "SELECT CSEQ, C_TITLE, C_STDT, C_EDDT, C_STATE, C_NM, C_UPDT FROM tb_contract order by C_UPDT ASC";
                MySqlCommand cmd = new MySqlCommand(strQuery, con);
                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    //읽어드린 내용을 List에 저장해서 return
                    Dictionary<string, object> dic = new Dictionary<string, object>();

                    dic.Add("C_TITLE", mdr["C_TITLE"].ToString());          // 계약항목
                    dic.Add("C_STDT", mdr["C_STDT"].ToString());            // 시작일
                    dic.Add("C_EDDT", mdr["C_EDDT"].ToString());            // 종료일
                    dic.Add("C_STATE", mdr["C_STATE"].ToString());          // 계약상태
                    dic.Add("CSEQ", mdr["CSEQ"].ToString());                // 고정값
                    dic.Add("C_NM", mdr["C_NM"].ToString());                // 계약업체
                    dic.Add("C_UPDT", mdr["C_UPDT"].ToString());            // 갱신일

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

        #region 유지보수 계약관리 리스트뷰 클릭시
        public static List<Dictionary<string, object>> MaintainShowData(string CSEQ)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            try
            {
                Console.WriteLine(CSEQ);
                string query = "SELECT * FROM tb_contract WHERE CSEQ = @CSEQ";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CSEQ", CSEQ);

                MySqlDataReader mdr = cmd.ExecuteReader();

                while (mdr.Read())
                {
                    //읽어드린 내용을 List에 저장해서 return
                    Dictionary<string, object> dic = new Dictionary<string, object>();

                    dic.Add("CSEQ", mdr["CSEQ"].ToString());                    // 고정키값
                    dic.Add("C_NM", mdr["C_NM"].ToString());                    // 계약업체
                    dic.Add("C_TITLE", mdr["C_TITLE"].ToString());              // 계약항목
                    dic.Add("C_STDT", mdr["C_STDT"].ToString());                // 시작일
                    dic.Add("C_EDDT", mdr["C_EDDT"].ToString());                // 종료일
                    dic.Add("C_UPDT", mdr["C_UPDT"].ToString());                // 계약일(갱신)
                    dic.Add("C_UPTYPE", mdr["C_UPTYPE"].ToString());            // 갱신방식
                    dic.Add("C_EMP", mdr["C_EMP"].ToString());                  // 계약담당
                    dic.Add("C_STATE", mdr["C_STATE"].ToString());              // 계약상태
                    dic.Add("C_ETC", mdr["C_ETC"].ToString());                  // 비고 - 계약관련
                    dic.Add("TINV_TO", mdr["TINV_TO"].ToString());              // 발행처
                    dic.Add("TINV_AMT", string.Format("{0:n0}",mdr["TINV_AMT"]));  // 발행금액
                    dic.Add("TINV_CYCLE", mdr["TINV_CYCLE"].ToString());        // 발행주기
                    dic.Add("TINV_MM", mdr["TINV_MM"].ToString());              // 발행월
                    dic.Add("TINV_TM", mdr["TINV_TM"].ToString());              // 발행시기
                    dic.Add("TINV_DD", mdr["TINV_DD"].ToString());              // 발행일자
                    dic.Add("TINV_ETC", mdr["TINV_ETC"].ToString());            // 비고 - 세금계산서 발행
                    dic.Add("CHK_TYPE", mdr["CHK_TYPE"].ToString());            // 점검방법
                    dic.Add("CHK_CYCLE", mdr["CHK_CYCLE"].ToString());          // 점검주기
                    dic.Add("CHK_MM", mdr["CHK_MM"].ToString());                // 점검월
                    dic.Add("CHK_PLACE", mdr["CHK_PLACE"].ToString());          // 방문위치
                    dic.Add("CHK_EMP", mdr["CHK_EMP"].ToString());              // 확인담당
                    dic.Add("CHK_ETC", mdr["CHK_ETC"].ToString());              // 비고 - 점검관련
                    dic.Add("UPD_ID", mdr["UPD_ID"].ToString());                // 수정자
                    dic.Add("UPD_DT", mdr["UPD_DT"].ToString());                // 수정일시

                    list.Add(dic);
                }
                mdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return list;
        }
        #endregion

        #region 유지보수 계약관리 등록(INSERT 문)
        public static int MaintainInsert(string C_NM, string C_TITLE, DateTime C_STDT, DateTime C_EDDT, DateTime C_UPDT, string C_UPTYPE, string C_EMP, 
            string C_STATE, string C_ETC, string TINV_TO, string TINV_AMT, string TINV_CYCLE, string TINV_MM, string TINV_DD,
            string TINV_ETC, string CHK_TYPE, string CHK_CYCLE, string CHK_MM, string CHK_EMP, string CHK_ETC)
        {
            int result;

            try
            {
                string strQuery = "insert into tb_contract" +
                    "(C_NM, C_TITLE, C_STDT, C_EDDT, C_UPDT, C_UPTYPE, C_EMP, C_STATE, C_ETC, TINV_TO, TINV_AMT, TINV_CYCLE, TINV_MM, TINV_DD, TINV_ETC, CHK_TYPE, CHK_CYCLE, CHK_MM, CHK_EMP, CHK_ETC) " +
                    "values (@C_NM,@C_TITLE,@C_STDT,@C_EDDT,@C_UPDT,@C_UPTYPE,@C_EMP,@C_STATE,@C_ETC,@TINV_TO,@TINV_AMT,@TINV_CYCLE,@TINV_MM,@TINV_DD,@TINV_ETC,@CHK_TYPE,@CHK_CYCLE,@CHK_MM,@CHK_EMP,@CHK_ETC)";
                MySqlCommand cmd = new MySqlCommand(strQuery, con);

                cmd.Parameters.Add("@C_NM", MySqlDbType.VarChar).Value = C_NM;              // 계약업체
                cmd.Parameters.Add("@C_TITLE", MySqlDbType.VarChar).Value = C_TITLE;        // 계약항목
                cmd.Parameters.Add("@C_STDT", MySqlDbType.Date).Value = C_STDT;             // 계약기간 - 시작일
                cmd.Parameters.Add("@C_EDDT", MySqlDbType.Date).Value = C_EDDT;             // 계약기간 - 종료일
                cmd.Parameters.Add("@C_UPDT", MySqlDbType.Date).Value = C_UPDT;             // 계약일 (갱신)
                cmd.Parameters.Add("@C_UPTYPE", MySqlDbType.VarChar).Value = C_UPTYPE;      // 갱신방식
                cmd.Parameters.Add("@C_EMP", MySqlDbType.VarChar).Value = C_EMP;            // 계약담당
                cmd.Parameters.Add("@C_STATE", MySqlDbType.VarChar).Value = C_STATE;        // 계약상태
                cmd.Parameters.Add("@C_ETC", MySqlDbType.VarChar).Value = C_ETC;            // 비고 - 계약정보
                cmd.Parameters.Add("@TINV_TO", MySqlDbType.VarChar).Value = TINV_TO;        // 발행처
                cmd.Parameters.Add("@TINV_AMT", MySqlDbType.VarChar).Value = TINV_AMT;      // 발행금액
                cmd.Parameters.Add("@TINV_CYCLE", MySqlDbType.VarChar).Value = TINV_CYCLE;  // 발행주기
                cmd.Parameters.Add("@TINV_MM", MySqlDbType.VarChar).Value = TINV_MM;        // 발행월
                cmd.Parameters.Add("@TINV_DD", MySqlDbType.VarChar).Value = TINV_DD;        // 발행일자
                cmd.Parameters.Add("@TINV_ETC", MySqlDbType.VarChar).Value = TINV_ETC;      // 비고 - 세금계산서
                cmd.Parameters.Add("@CHK_TYPE", MySqlDbType.VarChar).Value = CHK_TYPE;      // 점검방법
                cmd.Parameters.Add("@CHK_CYCLE", MySqlDbType.VarChar).Value = CHK_CYCLE;    // 점검주기
                cmd.Parameters.Add("@CHK_MM", MySqlDbType.VarChar).Value = CHK_MM;          // 점검월
                cmd.Parameters.Add("@CHK_EMP", MySqlDbType.VarChar).Value = CHK_EMP;        // 점검확인자
                cmd.Parameters.Add("@CHK_ETC", MySqlDbType.VarChar).Value = CHK_ETC;        // 비고 - 유지보수 점검정보

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

        #region 유지보수 계약관리 수정(UPDATE 문)
        public static int MaintainUpdate(string CSEQ,string C_NM, string C_TITLE, DateTime C_STDT, DateTime C_EDDT, DateTime C_UPDT, string C_UPTYPE, string C_EMP,
            string C_STATE, string C_ETC, string TINV_TO, string TINV_AMT, string TINV_CYCLE, string TINV_MM, string TINV_DD,
            string TINV_ETC, string CHK_TYPE, string CHK_CYCLE, string CHK_MM, string CHK_EMP, string CHK_ETC)
        {
            int result = 1;

            try
            {
                string strQuery = "update tb_contract set C_NM=@C_NM, C_TITLE=@C_TITLE, C_STDT=@C_STDT,  C_EDDT=@C_EDDT, C_UPDT=@C_UPDT, " +
                    "C_UPTYPE=@C_UPTYPE, C_EMP=@C_EMP, C_STATE=@C_STATE, C_ETC=@C_ETC, TINV_TO=@TINV_TO, TINV_AMT=@TINV_AMT, TINV_CYCLE=@TINV_CYCLE, " +
                    "TINV_MM=@TINV_MM, TINV_DD=@TINV_DD, TINV_ETC=@TINV_ETC, CHK_TYPE=@CHK_TYPE, CHK_CYCLE=@CHK_CYCLE, CHK_MM=@CHK_MM, CHK_EMP=@CHK_EMP," +
                    " CHK_ETC=@CHK_ETC where CSEQ = @CSEQ";

                MySqlCommand cmd = new MySqlCommand(strQuery, con);

                cmd.Parameters.AddWithValue("@CSEQ", CSEQ);                 // 고정키
                cmd.Parameters.AddWithValue("@C_NM", C_NM);                 // 계약업체
                cmd.Parameters.AddWithValue("@C_TITLE", C_TITLE);           // 계약항목
                cmd.Parameters.AddWithValue("@C_STDT", C_STDT);             // 계약기간 - 시작일
                cmd.Parameters.AddWithValue("@C_EDDT", C_EDDT);             // 계약기간 - 종료일
                cmd.Parameters.AddWithValue("@C_UPDT", C_UPDT);             // 갱신일
                cmd.Parameters.AddWithValue("@C_UPTYPE", C_UPTYPE);         // 갱신방식
                cmd.Parameters.AddWithValue("@C_EMP", C_EMP);               // 계약담당
                cmd.Parameters.AddWithValue("@C_STATE", C_STATE);           // 계약상태
                cmd.Parameters.AddWithValue("@C_ETC", C_ETC);               // 비고 - 계약정보
                cmd.Parameters.AddWithValue("@TINV_TO", TINV_TO);           // 발행처
                cmd.Parameters.AddWithValue("@TINV_AMT", TINV_AMT);         // 발행금액
                cmd.Parameters.AddWithValue("@TINV_CYCLE", TINV_CYCLE);     // 발행주기
                cmd.Parameters.AddWithValue("@TINV_MM", TINV_MM);           // 발행월
                cmd.Parameters.AddWithValue("@TINV_DD", TINV_DD);           // 발행일자
                cmd.Parameters.AddWithValue("@TINV_ETC", TINV_ETC);         // 비고 - 세금계산서
                cmd.Parameters.AddWithValue("@CHK_TYPE", CHK_TYPE);         // 점검방법
                cmd.Parameters.AddWithValue("@CHK_CYCLE", CHK_CYCLE);       // 점검주기
                cmd.Parameters.AddWithValue("@CHK_MM", CHK_MM);             // 점검월
                cmd.Parameters.AddWithValue("@CHK_EMP", CHK_EMP);           // 점검확인자
                cmd.Parameters.AddWithValue("@CHK_ETC", CHK_ETC);           // 비고 - 유지보수점검정보

                result = cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                result = 0;
            }

            return result;
        }
        #endregion

        #region 유지보수 계약관리 검색기능
        public static List<Dictionary<string, object>> MaintainShowSeacrh(string search, string C_STATE)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

            string strQuery = "";
            try
            {
                // 검색창(textBox가 공백이면서 comboBox는 계약상태가 아닐경우)
                if (search.Equals("검색 - 고객사, 계약항목") || search.Equals("") && !C_STATE.Equals("계약상태"))
                {
                    strQuery = "SELECT * FROM tb_contract WHERE C_STATE LIKE CONCAT('%', @C_STATE , '%')";
                }
                // 검색창(textBox가 공백이고, comboBox는 계약상태일 경우)
                else if (search.Equals("") && C_STATE.Equals("계약상태"))
                {
                    strQuery = "SELECT * FROM tb_contract WHERE C_NM LIKE CONCAT('%', @C_NM , '%') or " + "C_TITLE LIKE CONCAT('%',@C_TITLE , '%')";
                }
                // 검색창(textBox가 공백이 아니면서 comboBox는 계약상태일 경우)
                else if (!search.Equals("") && C_STATE.Equals("계약상태"))
                {
                    strQuery = "SELECT * FROM tb_contract WHERE C_NM LIKE CONCAT('%', @C_NM , '%') or " + "C_TITLE LIKE CONCAT('%',@C_TITLE , '%')";
                }
                // 검색창(textBox 가 공백이 아니면서 comboBox는 계약상태도 아닐경우)
                else if (!search.Equals("") && !C_STATE.Equals("계약상태"))
                {
                    strQuery = "SELECT * FROM tb_contract WHERE ( C_NM LIKE CONCAT('%', @C_NM , '%') && C_STATE LIKE CONCAT('%',@C_STATE , '%') ) or "
                        + "( C_TITLE LIKE CONCAT('%', @C_TITLE , '%') && C_STATE LIKE CONCAT('%', @C_STATE , '%') )";
                }

                MySqlCommand cmd = new MySqlCommand(strQuery, con);
                cmd.Parameters.AddWithValue("@C_STATE", C_STATE); // 콤보박스 내용 담기
                cmd.Parameters.AddWithValue("@C_NM", search);     // 텍스트박스 내용담기 
                cmd.Parameters.AddWithValue("@C_TITLE", search);  // 텍스트박스 내용담기

                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    //읽어드린 내용을 List에 저장해서 return
                    Dictionary<string, object> dic = new Dictionary<string, object>();

                    dic.Add("C_TITLE", mdr["C_TITLE"].ToString());          // 계약항목
                    dic.Add("C_STDT", mdr["C_STDT"].ToString());            // 시작일
                    dic.Add("C_EDDT", mdr["C_EDDT"].ToString());            // 종료일
                    dic.Add("C_STATE", mdr["C_STATE"].ToString());          // 계약상태
                    dic.Add("CSEQ", mdr["CSEQ"].ToString());                // 고정값
                    dic.Add("C_NM", mdr["C_NM"].ToString());                // 계약업체
                    dic.Add("C_UPDT", mdr["C_UPDT"].ToString());            // 갱신일

                    list.Add(dic);
                }
                mdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "검색완료.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return list;
        }
        #endregion

        #region 유지보수 계약관리 쪽에서 프로젝트 리스트뷰 출력
        public static List<Dictionary<string, object>> MainProjectShow(string CSEQ)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            try
            {
                // tb_cont_prj 를 c 로 임명 , tb_project 를 p 로 임명, tb_contract 를 t 로 임명
                string strQuery = "SELECT * FROM tb_cont_prj as c inner join tb_project as p on c.PSEQ = p.PSEQ INNER JOIN tb_contract AS t on c.CSEQ = t.CSEQ WHERE t.CSEQ = @CSEQ";
                MySqlCommand cmd = new MySqlCommand(strQuery, con);

                cmd.Parameters.AddWithValue("@CSEQ", CSEQ);

                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    //읽어드린 내용을 List에 저장해서 return
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("CUST_NM", mdr["CUST_NM"].ToString());              // 고객사명
                    dic.Add("PRJ_NM", mdr["PRJ_NM"].ToString());                // 프로젝트명
                    dic.Add("CSEQ", mdr["CSEQ"].ToString());                    // 고정키(유지보수관리)
                    dic.Add("PSEQ", mdr["PSEQ"].ToString());                    // 고정키(프로젝트관리)

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

        #region 외래키 번호
        public static string Foreign(string CUST_NM, string PRJ_NM)
        {
            string PSEQ = "";
            string query = "SELECT PSEQ FROM tb_project Where CUST_NM = @CUST_NM and PRJ_NM = @PRJ_NM";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.Add("@CUST_NM", MySqlDbType.VarChar).Value = CUST_NM;
                cmd.Parameters.Add("@PRJ_NM", MySqlDbType.VarChar).Value = PRJ_NM;

                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    PSEQ = mdr["PSEQ"].ToString();
                }
                mdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Foreign", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return PSEQ;
        }
        #endregion

        #region 프로젝트 관리 추가용 리스트뷰
        public static List<Dictionary<string, object>> Show()
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            try
            {
                string strQuery = "SELECT CUST_NM,PRJ_NM,PRJ_STDT,PRJ_EDDT,MAINT_STDT,PRJ_DEPT,PSEQ,PRJ_DEPT FROM tb_project";

                MySqlCommand cmd = new MySqlCommand(strQuery, con);
                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    //읽어드린 내용을 List에 저장해서 return
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("CUST_NM", mdr["CUST_NM"].ToString());              // 고객사명
                    dic.Add("PRJ_NM", mdr["PRJ_NM"].ToString());                // 프로젝트명 
                    dic.Add("PRJ_STDT", mdr["PRJ_STDT"].ToString());            // 구축기간 - 시작일
                    dic.Add("PRJ_EDDT", mdr["PRJ_EDDT"].ToString());            // 구축기간 - 종료일
                    dic.Add("PRJ_DEPT", mdr["PRJ_DEPT"].ToString());            // 구축부서
                    dic.Add("MAINT_STDT", mdr["MAINT_STDT"].ToString());        // 유지보수시작일
                    dic.Add("PSEQ", mdr["PSEQ"].ToString());                    // 고정키

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

        #region 프로젝트 관리 추가용 리스트뷰 클릭이벤트
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
                    dic.Add("CUST_NM", mdr["CUST_NM"].ToString());                   // 고객사명
                    dic.Add("PRJ_NM", mdr["PRJ_NM"].ToString());                     // 프로젝트명
                    dic.Add("PRJ_STDT", mdr["PRJ_STDT"].ToString());                 // 구축기간 - 시작일
                    dic.Add("PRJ_EDDT", mdr["PRJ_EDDT"].ToString());                 // 구축기간 - 종료일
                    dic.Add("PACE_PRODUCT", mdr["PACE_PRODUCT"].ToString());         // 적용제품
                    dic.Add("EXTERNAL_PRODUCT", mdr["EXTERNAL_PRODUCT"].ToString()); // 외부제품
                    dic.Add("PRODUCT_TYPE", mdr["PRODUCT_TYPE"].ToString());         // 적용방식
                    dic.Add("PRJ_DEPT", mdr["PRJ_DEPT"].ToString());                 // 구축부서
                    dic.Add("PRJ_EMP", mdr["PRJ_EMP"].ToString());                   // 구축담당자
                    dic.Add("MAINT_STDT", mdr["MAINT_STDT"].ToString());             // 유지보수시작일
                    dic.Add("PRJ_ETC", mdr["PRJ_ETC"].ToString());                   // 비고
                    dic.Add("UPD_ID", mdr["UPD_ID"].ToString());                     // 수정자
                    dic.Add("UPD_DT", mdr["UPD_DT"].ToString());                     // 수정일시

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

        #region 프로젝트 관리 검색기능
        public static List<Dictionary<string, object>> ShowSearch(string search)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            try
            {
                string strQuery = "SELECT * FROM tb_project WHERE CUST_NM LIKE CONCAT('%', @CUST_NM , '%') or " + "PRJ_NM LIKE CONCAT('%', @PRJ_NM , '%') or "
                       + "PACE_PRODUCT LIKE CONCAT('%',@PACE_PRODUCT , '%') or " + "PRJ_DEPT LIKE CONCAT('%', @PRJ_DEPT , '%') or " + "PRJ_EMP LIKE CONCAT('%', @PRJ_EMP , '%')";

                MySqlCommand cmd = new MySqlCommand(strQuery, con);

                cmd.Parameters.AddWithValue("@CUST_NM", search);
                cmd.Parameters.AddWithValue("@PRJ_NM", search);
                cmd.Parameters.AddWithValue("@PACE_PRODUCT", search);
                cmd.Parameters.AddWithValue("@PRJ_DEPT", search);
                cmd.Parameters.AddWithValue("@PRJ_EMP", search);

                MySqlDataReader mdr = cmd.ExecuteReader();
                while (mdr.Read())
                {
                    //읽어드린 내용을 List에 저장해서 return
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("CUST_NM", mdr["CUST_NM"].ToString());              // 고객사명
                    dic.Add("PRJ_NM", mdr["PRJ_NM"].ToString());                // 프로젝트명
                    dic.Add("PRJ_STDT", mdr["PRJ_STDT"].ToString());            // 구축기간 - 시작일
                    dic.Add("PRJ_EDDT", mdr["PRJ_EDDT"].ToString());            // 구축기간 - 종료일
                    dic.Add("PRJ_DEPT", mdr["PRJ_DEPT"].ToString());            // 구축부서
                    dic.Add("MAINT_STDT", mdr["MAINT_STDT"].ToString());        // 유지보수시작일
                    dic.Add("PSEQ", mdr["PSEQ"].ToString());                    // 고정키
                    dic.Add("PRJ_EMP", mdr["PRJ_EMP"].ToString());              // 구축담당자

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

        #region 프로젝트 관리 추가용 (INSERT 문)
        public static int MaintainPlusInsert(string CSEQ, string PSEQ)
        {
            int result;

            try
            {
                string strQuery = "insert into tb_cont_prj (CSEQ, PSEQ) values (@CSEQ, @PSEQ)";
                MySqlCommand cmd = new MySqlCommand(strQuery, con);

                cmd.Parameters.Add("@CSEQ", MySqlDbType.VarChar).Value = CSEQ;        // 유지보수 관리 key값
                cmd.Parameters.Add("@PSEQ", MySqlDbType.VarChar).Value = PSEQ;        // 프로젝트 관리 key값

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
        public static int Delete(string strQuery)
        {
            int result;
            try
            {
                MySqlCommand cmd = new MySqlCommand(strQuery, con);
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

        #region 중복체크
        public static List<Dictionary<string, object>> InsertCheck(int CSEQ)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            try
            {
                string strQuery = "SELECT EXISTS(SELECT * FROM tb_contract where CSEQ =  @CSEQ) as have";
                MySqlCommand cmd = new MySqlCommand(strQuery, con);

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
                MessageBox.Show(ex.Message, "InsertCheck", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            return list;
        }
        #endregion
    }
}