using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Demirbas_denem1.Entities;
using System.Windows.Forms;


namespace Demirbas_denem1.Database
{
    public static class DataBaseSettings
    {
        //VERİ TABANI KULLANIM İÇİN KISYOLLAR
        public static string ConnectionString = "server=DESKTOP-ICKNJ9V\\SQLEXPRESS; Initial Catalog=deneme;Integrated Security=True";

        public static SqlConnection con;
        public static SqlDataAdapter da;
        public static SqlCommand cmd;
        public static DataSet ds;

        //SQL KODUNU ÇALIŞTIR
        public static void ExecuteNonQuery(string query)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }




        public static bool LoadUserData(string userName, string sifre)
        {
           
            string query = "SELECT * FROM Kullanicilar WHERE KullaniciAdi = @KullaniciAdi AND Sifre= @Sifre";


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@KullaniciAdi", userName);
                    cmd.Parameters.AddWithValue("@Sifre", sifre);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CurrentUser.User.userName = reader.GetString(reader.GetOrdinal("KullaniciAdi"));
                            CurrentUser.User.sureName = reader.GetString(reader.GetOrdinal("KullaniciSoyadi"));
                            CurrentUser.User.userTitle = reader.GetString(reader.GetOrdinal("Unvan"));
                            CurrentUser.User.userDepartment = reader.GetString(reader.GetOrdinal("Departman"));
                            CurrentUser.User.userCode = reader.GetString(reader.GetOrdinal("KullaniciKodu"));
                            CurrentUser.User.usereMail = reader.GetString(reader.GetOrdinal("Email"));
                            CurrentUser.User.userePassword = reader.GetString(reader.GetOrdinal("Sifre"));
                            CurrentUser.User.userStartTime = reader.GetDateTime(reader.GetOrdinal("BaslamaTarihi"));
                            CurrentUser.User.userStatus = reader.GetString(reader.GetOrdinal("Statu"));
                            CurrentUser.User.userRole = reader.GetString(reader.GetOrdinal("Rol"));

                            // Diğer alanları da okuyabilirsiniz.
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        //user kontrol
        public static bool ısThereUser(string userName, string userSifre)
        {
            bool isThere = false;
            string query = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = @KullaniciAdi AND Sifre= @Sifre";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@KullaniciAdi", userName);
                    cmd.Parameters.AddWithValue("@Sifre", userSifre); // 'password' değişkeni, kullanıcıdan alınan şifreyi içermelidir

                    int kullanicisayisi = (int)cmd.ExecuteScalar();

                    if (kullanicisayisi > 0)
                    {
                        isThere = true;
                    }
                }
            }
            return isThere;

        }

        //Grid doldur kısayol

        public static void GridDoldurKullanici(DataGridView dataGridView)
            {
                string query = "SELECT * FROM Kullanicilar";

                DataTable dataTable = new DataTable();

                using (SqlConnection connection = new SqlConnection(DataBaseSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }

                dataGridView.DataSource = dataTable;
            }

        public static void GridDoldurDemirbas(DataGridView dataGridView)
        {
            string query = "SELECT * FROM Demirbaslar";

            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            dataGridView.DataSource = dataTable;
        }

        public static List<Role> LoadYetkiData()
        {
            List<Role> roles = new List<Role>();
      

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Yetki";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Role role = new Role();
                            role.yetki = reader["Yetki"].ToString();
                            role.kullaniciKodu = reader["KullaniciId"].ToString();
                            roles.Add(role);
                        }
                    }
                }
            }

            return roles;
        }

        public static void pasifeCek()
        { 
            
        
        }



    }
}
