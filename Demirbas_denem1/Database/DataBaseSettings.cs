﻿using System;
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



        //KULLANICI VERİTABANINDA VARMI? 
        public static bool ısThere(int userSifre,string userName)
        {
            bool isThere = false;
            string query = "SELECT COUNT(*) FROM Admin WHERE username = @username AND sifre = @sifre";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", userName);
                    cmd.Parameters.AddWithValue("@sifre", userSifre); // 'password' değişkeni, kullanıcıdan alınan şifreyi içermelidir

                    int kullanicisayisi = (int)cmd.ExecuteScalar();

                    if (kullanicisayisi > 0)
                    {
                        isThere = true;
                    }
                }
            }
            return isThere;

        }

        //Admin datasını sınıfa çekme
        public static bool LoadAdminData(string userName, string sifre)
        {
            string query = "SELECT * FROM Admin WHERE username = @userName AND sifre = @sifre";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@sifre", sifre);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CurrentAdmin.Admin.AdminId = reader.GetInt32(reader.GetOrdinal("id"));
                            CurrentAdmin.Admin.AdminAdi = reader.GetString(reader.GetOrdinal("ad"));
                            CurrentAdmin.Admin.AdminUserName = reader.GetString(reader.GetOrdinal("username"));
                            CurrentAdmin.Admin.AdminSifre = reader.GetString(reader.GetOrdinal("sifre"));
                            // Diğer alanları da okuyabilirsiniz.
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        //Grid doldur kısayol
       
            public static void GridDoldurKullanici(DataGridView dataGridView)
            {
                string query = "SELECT KullaniciAdi, KullaniciSoyadi, Email, BaslamaTarihi, Statu, Unvan,KullaniciKodu FROM Kullanicilar";

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
        //Grid Doldur Yetkiler

        public static void GridDoldurYetki(DataGridView dataGridView)
        {
            string query = "SELECT YetkiKodu, Yetki FROM Yetki";

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




    }
}
