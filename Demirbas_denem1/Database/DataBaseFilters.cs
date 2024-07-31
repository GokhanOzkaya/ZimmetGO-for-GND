using Demirbas_denem1.Database;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Demirbas_denem1
{
    public class DataBaseFilters
    {
        public static void DatabaseFilter(int demirbasId, DataGridView dataGridView)
        {
            string connectionString = DataBaseSettings.ConnectionString; // Veritabanı bağlantı dizesi
            string query = "SELECT * FROM Demirbaslar WHERE DemirbasID = @DemirbasID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DemirbasID", demirbasId);

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
