using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PPM_project
{
    class MariaDB2
    {
        public static MySqlConnection con;
        public static bool DB_Connect()
        {
            string dbCon = "Server=127.0.0.1;Port=3306;Database=pmms;Uid=root;Password=1234;allow user variables=true;CHARSET=utf8";
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

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("실패");
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

        public static void DB_Close()
        {
            con.Close();
        }


    }
}
