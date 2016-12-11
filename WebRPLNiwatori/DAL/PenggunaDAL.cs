using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebRPLNiwatori.Models;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace WebRPLNiwatori.DAL
{
    public class PenggunaDAL
    {
        private string GetConnStr()
        {
            return @"Data Source=ERNANDA-PC\SQLEXPRESS;
                     Initial Catalog=Niwatori;
                     Integrated Security=True";
        }

        public string GetMD5Hash(string password)
        {
            UnicodeEncoding unicode = new UnicodeEncoding();
            var dataHash = unicode.GetBytes(password);
            MD5 md5 = new MD5CryptoServiceProvider();
            var hasil = md5.ComputeHash(dataHash);
            return Convert.ToBase64String(hasil);
        }

        public void Registrasi(Pengguna pengguna)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into Pengguna(Nama_pengguna,Username,Password,Role) 
                                  values(@Nama_pengguna,@Username,@Password,@Role)";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("Nama_pengguna", pengguna.Nama_pengguna);
                cmd.Parameters.AddWithValue("Username", pengguna.Username);
                cmd.Parameters.AddWithValue("Password", GetMD5Hash(pengguna.Password));
                cmd.Parameters.AddWithValue("Role", pengguna.Role);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Number.ToString() + " - " + sqlEx.Message);
                }
            }
        }

        public Pengguna Login(Pengguna pengguna)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Pengguna 
                                  where Username=@Username, Password=@Password, Role=@Role";

                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("Username", pengguna.Username);
                cmd.Parameters.AddWithValue("Password", GetMD5Hash(pengguna.Password));
                cmd.Parameters.AddWithValue("Role", pengguna.Role);

                Pengguna objPengguna = new Pengguna();
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        objPengguna.Nama_pengguna = dr["Nama_pengguna"].ToString();
                        objPengguna.Username = dr["Username"].ToString();
                        objPengguna.Password = dr["Password"].ToString();
                        objPengguna.Role = dr["Role"].ToString();
                    }
                }
                else
                {
                    objPengguna = null;
                }

                return objPengguna;
            }
        }

    }
}