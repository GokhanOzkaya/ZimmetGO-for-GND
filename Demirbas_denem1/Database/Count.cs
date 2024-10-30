using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demirbas_denem1.Database
{
    public class Count
    {
        public int UrunSay(string aranacakTur)
        {
            int laptopSayisi = 0;
            string query = "SELECT COUNT(*) FROM Demirbaslar WHERE DemirbasTuru = @DemirbasTuru";
            string connectionString = DataBaseSettings.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DemirbasTuru", aranacakTur);

                    connection.Open();
                    laptopSayisi = (int)command.ExecuteScalar();
                }
            }
            return laptopSayisi;
        }

        public int UrunSayIT(string aranacakTur, int itKodu)
        {
            int urunSayisi = 0;
            string query = "SELECT COUNT(*) FROM Demirbaslar WHERE DemirbasTuru = @DemirbasTuru AND KullaniciID = @KullaniciID";
            string connectionString = DataBaseSettings.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DemirbasTuru", aranacakTur);
                    command.Parameters.AddWithValue("@KullaniciID", itKodu);

                    connection.Open();
                    urunSayisi = (int)command.ExecuteScalar();
                }
            }
            return urunSayisi;
        }


    }
}
