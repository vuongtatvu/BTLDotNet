using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BTLDotNet.Model
{
    class Database
    {
        private const string CONN = @"Server=DESKTOP-P9BAR4I\SQLEXPRESS;Database=truyenkimdung;Integrated Security=SSPI;MultipleActiveResultSets=True;";

        public static BoTruyen GetDsTruyen()
        {
            BoTruyen boTruyen = null;

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                string sqlTruyen = "SELECT * FROM truyen";
                SqlCommand cmdTruyen = new SqlCommand(sqlTruyen, conn);
                conn.Open();
                using (SqlDataReader reader = cmdTruyen.ExecuteReader())
                {
                    boTruyen = new BoTruyen();
                    Truyen truyen;
                    while (reader.Read())
                    {
                        truyen = new Truyen();
                        truyen.IdTruyen = Int32.Parse(reader["idtruyen"].ToString());
                        truyen.TenTruyen = reader["tentruyen"].ToString();
                        string sqlChuong = "SELECT * FROM chuong WHERE idtruyen = " + truyen.IdTruyen;
                        SqlCommand cmdChuong = new SqlCommand(sqlChuong, conn);
                        using (SqlDataReader readchap = cmdChuong.ExecuteReader())
                        {
                            Chuong chuong;
                            while (readchap.Read())
                            {
                                chuong = new Chuong();
                                chuong.IdChuong = Int32.Parse(readchap["idchuong"].ToString());
                                chuong.NoiDung = readchap["noidung"].ToString();
                                truyen.AddDsChuong(chuong);
                            }
                        }
                        boTruyen.AddDsTruyen(truyen);
                    }
                }
            }
            return boTruyen;
        }

        public static int AddChuong(int idChuong, int idTruyen, string noiDung)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(CONN))
            {
                string sqlTruyen = "INSERT INTO chuong (idchuong, idtruyen, noidung) VALUES (" + idChuong + ", " + idTruyen + ", N'" + noiDung + "')";
                SqlCommand cmdTruyen = new SqlCommand(sqlTruyen, conn);
                conn.Open();
                result = cmdTruyen.ExecuteNonQuery();
            }
            return result;
        }

        public static int Update(string sql)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(CONN))
            {
                SqlCommand cmdTruyen = new SqlCommand(sql, conn);
                conn.Open();
                result = cmdTruyen.ExecuteNonQuery();
            }
            return result;
        }

        public static int Delete(string sql)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(CONN))
            {
                SqlCommand cmdTruyen = new SqlCommand(sql, conn);
                conn.Open();
                result = cmdTruyen.ExecuteNonQuery();
            }
            return result;
        }

        public static string GetNoiDungChuong(int idTruyen,int idChuong)
        {
            string content = "";

            using (SqlConnection conn = new SqlConnection(CONN))
            {
                string sqlChuong = "SELECT noidung FROM chuong WHERE idchuong = " + idChuong + " AND idtruyen = " + idTruyen;
                SqlCommand cmdTruyen = new SqlCommand(sqlChuong, conn);
                conn.Open();
                using (SqlDataReader reader = cmdTruyen.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        content = reader["noidung"].ToString();
                    }
                }
            }
            return content;
        }

    }
}
