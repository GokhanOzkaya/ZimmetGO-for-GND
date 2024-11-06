using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Demirbas_denem1.Entities;
using System.Windows.Forms;
using DataGridViewAutoFilter;
using Demirbas_denem1.Database;


namespace Demirbas_denem1.Database
{
    public static class DataBaseSettings
    {
        //VERİ TABANI KULLANIM İÇİN KISYOLLAR
        public static string ConnectionString = "server=DESKTOP-7HOCOM2\\SQLEXPRESS; Initial Catalog=deneme;Integrated Security=True";

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




        public static bool LoadUserData(string kullaniciKodu, string sifre)
        {
           
            string query = "SELECT * FROM Kullanicilar WHERE KullaniciKodu = @KullaniciKodu AND Sifre= @Sifre";


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@KullaniciKodu", kullaniciKodu);
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
        public static bool ısThereUser(string kullaniciKodu, string userSifre,string Rol)
        {
            bool isThere = false;
            string query = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciKodu = @KullaniciKodu AND Sifre= @Sifre AND Rol=@Rol";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@KullaniciKodu", kullaniciKodu);
                    cmd.Parameters.AddWithValue("@Rol", Rol);
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
        public static bool ısThereAdmin(string kullaniciKodu, string userSifre,string Rol)
        {
            bool isThere = false;
            string query = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciKodu = @KullaniciKodu AND Sifre= @Sifre AND Rol=@Rol";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@KullaniciKodu", kullaniciKodu);
                    cmd.Parameters.AddWithValue("@Sifre", userSifre); // 'password' değişkeni, kullanıcıdan alınan şifreyi içermelidir
                    cmd.Parameters.AddWithValue("@Rol", Rol); // 'password' değişkeni, kullanıcıdan alınan şifreyi içermelidir

                    int kullanicisayisi = (int)cmd.ExecuteScalar();

                    if (kullanicisayisi > 0)
                    {
                        isThere = true;
                    }
                }
            }
            return isThere;

        }

        public static bool ısThereManager(string kullaniciKodu, string userSifre, string Rol)
        {
            bool isThere = false;
            string query = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciKodu = @KullaniciKodu AND Sifre= @Sifre AND Rol=@Rol";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@KullaniciKodu", kullaniciKodu);
                    cmd.Parameters.AddWithValue("@Sifre", userSifre); // 'password' değişkeni, kullanıcıdan alınan şifreyi içermelidir
                    cmd.Parameters.AddWithValue("@Rol", Rol); // 'password' değişkeni, kullanıcıdan alınan şifreyi içermelidir

                    int kullanicisayisi = (int)cmd.ExecuteScalar();

                    if (kullanicisayisi > 0)
                    {
                        isThere = true;
                    }
                }
            }
            return isThere;

        }

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

        public static void SearchInKullanicilar(string searchText, DataGridView dataGridView)
        {
            string query = @"
            SELECT * 
            FROM Kullanicilar
            WHERE 
                KullaniciAdi LIKE @searchText OR 
                KullaniciSoyadi LIKE @searchText OR 
                Unvan LIKE @searchText OR 
                Departman LIKE @searchText OR 
                KullaniciKodu LIKE @searchText OR 
                Email LIKE @searchText OR 
                Sifre LIKE @searchText OR 
                Statu LIKE @searchText OR 
                Rol LIKE @searchText";

            // DataTable to hold the results
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Parametreyi ekliyoruz ve LIKE operatörü için wildcard kullanıyoruz
                    command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // Sonuçları DataTable'a doldur
                        adapter.Fill(dataTable);
                    }
                }
            }

            // DataGridView'e sonuçları göster
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

        public static void SearchInDemirbaslar(string searchText, DataGridView dataGridView)
        {
            string query = @"
        SELECT * 
        FROM Demirbaslar
        WHERE 
            DemirbasAdi LIKE @searchText OR 
            DemirbasTuru LIKE @searchText OR 
            Durum LIKE @searchText OR
            DemirbasMarka LIKE @searchText OR 
            DemirbasModel LIKE @searchText OR 
            DemirbasUNIQKod LIKE @searchText OR
            Aciklama LIKE @searchText";

            // Önce id değişkenini tanımla
            int id;

            // Eğer girilen değer bir tam sayıysa, DemirbasID ve KullaniciID üzerinde de arama yap
            if (int.TryParse(searchText, out id))
            {
                query += " OR DemirbasID = @Id OR KullaniciID = @Id";
            }

            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // LIKE operatörü için wildcard kullanarak parametre ekliyoruz
                    command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                    // Eğer girilen değer bir tam sayıysa, DemirbasID ve KullaniciID parametresi ekliyoruz
                    if (int.TryParse(searchText, out id))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // Sonuçları DataTable'a doldur
                        adapter.Fill(dataTable);
                    }
                }
            }

            // Sonuçları DataGridView'de göster
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

        internal static void ExecuteNonQuery(SqlCommand command)
        {
            throw new NotImplementedException();
        }
    }
}

