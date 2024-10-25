using Demirbas_denem1.Database;
using Demirbas_denem1.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace Demirbas_denem1
{
    public class DataBaseFilters
    {
        public static void DatabaseFilterDemirbas(object demirbasId, DataGridView dataGridView)
        {
            string connectionString = DataBaseSettings.ConnectionString;
            string query = "SELECT * FROM Demirbaslar";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    if (demirbasId is int id)
                    {
                        // Eğer demirbasId bir tam sayı ise
                        query += " WHERE DemirbasID = @DemirbasID";
                        command.Parameters.AddWithValue("@DemirbasID", id);
                    }
                    else if (demirbasId is string name && !string.IsNullOrWhiteSpace(name))
                    {
                        // Eğer demirbasId bir string ise ve boş değilse
                        query += " WHERE DemirbasAdi LIKE @DemirbasAdi";
                        command.Parameters.AddWithValue("@DemirbasAdi", "%" + name + "%");
                    }

                    command.CommandText = query;

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView.DataSource = dataTable;
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show($"Veritabanı hatası: {sqlEx.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public static void DatabaseFilterUser(object varaible, DataGridView dataGridView)
        {
            string connectionString = DataBaseSettings.ConnectionString;
            string query = "SELECT * FROM Kullanicilar";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;


                    if (varaible is string name && !string.IsNullOrWhiteSpace(name))
                    {
                        // Eğer demirbasId bir string ise ve boş değilse
                        query += " WHERE KullaniciKodu LIKE @KullaniciKodu OR KullaniciAdi LIKE @KullaniciAdi";
                        command.Parameters.AddWithValue("@KullaniciKodu", "%" + name + "%");
                        command.Parameters.AddWithValue("@KullaniciAdi", "%" + name + "%");
                    }

                    command.CommandText = query;

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView.DataSource = dataTable;
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show($"Veritabanı hatası: {sqlEx.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public static void UserZimmetleriLisetele(int kullaniciID, DataGridView dataGridView)
        {
            string connectionString = DataBaseSettings.ConnectionString;
            string query = "SELECT * FROM Demirbaslar";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;


                    if (kullaniciID is int name)
                    {
                        // Eğer demirbasId bir string ise ve boş değilse
                        query += " WHERE KullaniciID LIKE @KullaniciID ";
                        command.Parameters.AddWithValue("@KullaniciID", "%" + name + "%");

                    }

                    command.CommandText = query;

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView.DataSource = dataTable;
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show($"Veritabanı hatası: {sqlEx.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }


        public static void ZimmetGemisLisetele(DataGridView dataGridView, DateTime? zimmetAlisTar = null, DateTime? iadeEdisTar = null, int? kullaniciID = null)
        {
            string connectionString = DataBaseSettings.ConnectionString;
            string query = "SELECT Kullanicilar.KullaniciAdi, " +
                 "Kullanicilar.KullaniciSoyadi, " +
                 "Kullanicilar.Unvan, " +
                 "Kullanicilar.Departman, " +
                 "ZimmetGecmisi.ZimmetTarihi, " +
                 "ZimmetGecmisi.IadeTarihi, " +
                 "ZimmetGecmisi.DemirbasID, " +
                 "Demirbaslar.DemirbasMarka, " +
                 "Demirbaslar.DemirbasModel, " +
                 "Demirbaslar.Durum, " +
                 "Demirbaslar.DemirbasUNIQKod " +
                 "FROM ZimmetGecmisi " +  // Boşluk eklendi
                 "JOIN Kullanicilar ON Kullanicilar.KullaniciId = ZimmetGecmisi.KullaniciID " +  // Boşluk eklendi
                 "JOIN Demirbaslar ON Demirbaslar.DemirbasID = ZimmetGecmisi.DemirbasID ";  // Boşluk eklendi



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    if (kullaniciID != null)
                    {
                        // Eğer demirbasId bir string ise ve boş değilse
                        query += " WHERE ZimmetGecmisi.KullaniciID = @KullaniciID ";
                        command.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                    }
                    if (zimmetAlisTar != null)
                    {
                        // Eğer demirbasId bir string ise ve boş değilse
                        query += " WHERE ZimmetGecmisi.KullaniciID = @KullaniciID ";
                        command.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                    }
                    if (iadeEdisTar != null)
                    {
                        // Eğer demirbasId bir string ise ve boş değilse
                        query += " WHERE ZimmetGecmisi.KullaniciID = @KullaniciID ";
                        command.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                    }

                    command.CommandText = query;

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView.DataSource = dataTable;
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show($"Veritabanı hatası: {sqlEx.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        public static void SearchInZimmetGecmisi(DataGridView dataGridView, DateTime baslangicTarihi, DateTime bitisTarihi, string filtreTuru)
        {
            string connectionString = DataBaseSettings.ConnectionString;
            string query = "SELECT Kullanicilar.KullaniciAdi, " +
                           "Kullanicilar.KullaniciSoyadi, " +
                           "Kullanicilar.Unvan, " +
                           "Kullanicilar.Departman, " +
                           "ZimmetGecmisi.ZimmetTarihi, " +
                           "ZimmetGecmisi.IadeTarihi, " +
                           "ZimmetGecmisi.DemirbasID, " +
                           "Demirbaslar.DemirbasAdi, " +
                           "Demirbaslar.DemirbasMarka, " +
                           "Demirbaslar.DemirbasModel, " +
                           "Demirbaslar.Durum, " +
                           "Demirbaslar.DemirbasUNIQKod " +
                           "FROM ZimmetGecmisi " +
                           "JOIN Kullanicilar ON Kullanicilar.KullaniciId = ZimmetGecmisi.KullaniciID " +
                           "JOIN Demirbaslar ON Demirbaslar.DemirbasID = ZimmetGecmisi.DemirbasID ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    string upperFiltreTuru = filtreTuru.ToUpper();

                    // Tarih aralığına göre filtreleme işlemi
                    if (filtreTuru == "TESLİMTARİHİNEGÖRE")
                    {
                        query += "WHERE ZimmetGecmisi.ZimmetTarihi BETWEEN @BaslangicTarihi AND @BitisTarihi";
                    }
                    else if (filtreTuru == "İADETARİHİNEGÖRE")
                    {
                        query += "WHERE ZimmetGecmisi.IadeTarihi BETWEEN @BaslangicTarihi AND @BitisTarihi";
                    }
                    else if (baslangicTarihi == bitisTarihi)
                    {
                        query += "WHERE ZimmetGecmisi.ZimmetTarihi = @BaslangicTarihi";
                    }
                    // Parametreleri ekliyoruz
                    command.Parameters.AddWithValue("@BaslangicTarihi", baslangicTarihi);
                    command.Parameters.AddWithValue("@BitisTarihi", bitisTarihi);

                    command.CommandText = query;

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView.DataSource = dataTable;
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show($"Veritabanı hatası: {sqlEx.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public static OldUser DemirbasKimeAit(string demirbasUNIQKod, DataGridView? dgv = null)
        {
            Entities.OldUser ou = new Entities.OldUser();
            string query = @"
        select Kullanicilar.KullaniciAdi, 
               Kullanicilar.KullaniciSoyadi, 
               Kullanicilar.Unvan, 
               Kullanicilar.Departman,
               Demirbaslar.DemirbasAdi, 
               Demirbaslar.DemirbasMarka, 
               Demirbaslar.DemirbasModel,
               Demirbaslar.Durum,
               Demirbaslar.DemirbasUNIQKod
        from Demirbaslar 
        JOIN Kullanicilar ON Kullanicilar.KullaniciId = Demirbaslar.KullaniciID ";

            if (!string.IsNullOrEmpty(demirbasUNIQKod)) // Parametre varsa WHERE ekle
            {
                query += " WHERE Demirbaslar.DemirbasUNIQKod = @DemirbasUNIQKod";
            }

            string connectionString = DataBaseSettings.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(demirbasUNIQKod))
                    {

                        command.Parameters.AddWithValue("@DemirbasUNIQKod", demirbasUNIQKod);
                    }

                    // SQL Reader ile kullanıcı bilgilerini oku ve label'lara yazdır
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            ou.userName = reader["KullaniciAdi"].ToString();
                            Debug.WriteLine($"Kullanıcı Adı: {ou.userName}");
                        }

                    }

                    // Eğer DataGridView sağlanmışsa tabloya verileri doldur
                    if (dgv != null)
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgv.DataSource = table;
                    }
                }
            }
            return ou;
        }



        public static void DemirbasZimmetGecmisiniGör(string demirbasUNIQKod, DataGridView dgv)
        {
            string query = @"--Malzemenin kişi geçmişini gör--
                     SELECT Kullanicilar.KullaniciAdi, 
                            Kullanicilar.KullaniciSoyadi, 
                            Kullanicilar.Departman, 
                            ZimmetGecmisi.ZimmetTarihi, 
                            ZimmetGecmisi.IadeTarihi, 
                            Demirbaslar.DemirbasAdi, 
                            Demirbaslar.DemirbasMarka, 
                            Demirbaslar.DemirbasModel, 
                            Demirbaslar.Durum, 
                            Demirbaslar.DemirbasUNIQKod
                     FROM ZimmetGecmisi
                     JOIN Demirbaslar ON Demirbaslar.DemirbasID = ZimmetGecmisi.DemirbasID
                     JOIN Kullanicilar ON Kullanicilar.KullaniciId = ZimmetGecmisi.KullaniciID ";

            if (!string.IsNullOrEmpty(demirbasUNIQKod)) // TextBox boş değilse sorguya WHERE ekle
            {
                query += " WHERE Demirbaslar.DemirbasUNIQKod = @DemirbasUNIQKod";
            }

            string connectionString = DataBaseSettings.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(demirbasUNIQKod)) // Parametreyi yalnızca boş değilse ekle
                    {
                        command.Parameters.AddWithValue("@DemirbasUNIQKod", demirbasUNIQKod);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgv.DataSource = table;
                }
            }
        }


    }
}

