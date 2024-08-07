using Demirbas_denem1.Database;
using System;
using System.Data;
using System.Data.SqlClient;
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

    }
}

