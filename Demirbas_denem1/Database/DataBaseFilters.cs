using Demirbas_denem1.Database;
using Demirbas_denem1.Entities;
using System;
using System.Data;
using System.Data.SqlClient;
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


        public static void ZimmetGemisLisetele(int? kullaniciID, DataGridView dataGridView)
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
                 "FROM ZimmetGecmisi " +  // Boşluk eklendi
                 "JOIN Kullanicilar ON Kullanicilar.KullaniciId = ZimmetGecmisi.KullaniciID " +  // Boşluk eklendi
                 "JOIN Demirbaslar ON Demirbaslar.DemirbasID = ZimmetGecmisi.DemirbasID ";  // Boşluk eklendi



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    if (kullaniciID != null )
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

    }
}

