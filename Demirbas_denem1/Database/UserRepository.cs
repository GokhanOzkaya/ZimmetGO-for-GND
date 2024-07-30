using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Demirbas_denem1.Entities;
using Demirbas_denem1.Database;


namespace Demirbas_denem1.Entities
{

    public class UserRepository
    {
        public void UpdateUser(User updatedUser)
        {
            string updateQuery = "UPDATE Kullanicilar SET KullaniciAdi = @KullaniciAdi, KullaniciSoyadi = @KullaniciSoyadi, Unvan = @Unvan, Departman = @Departman, Email = @Email, Sifre = @Sifre, BaslamaTarihi = @BaslamaTarihi, Statu = @Statu, Rol = @Rol WHERE KullaniciId = @KullaniciId";

            try
            {
                using (SqlConnection connection = new SqlConnection(DataBaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@KullaniciId", updatedUser.KullaniciId);
                        command.Parameters.AddWithValue("@KullaniciAdi", updatedUser.userName);
                        command.Parameters.AddWithValue("@KullaniciSoyadi", updatedUser.sureName);
                        command.Parameters.AddWithValue("@Unvan", updatedUser.userTitle);
                        command.Parameters.AddWithValue("@Departman", updatedUser.userDepartment);
                        command.Parameters.AddWithValue("@Email", updatedUser.usereMail);
                        command.Parameters.AddWithValue("@Sifre", updatedUser.userePassword);
                        command.Parameters.AddWithValue("@BaslamaTarihi", updatedUser.userStartTime);
                        command.Parameters.AddWithValue("@Statu", updatedUser.userStatus);
                        command.Parameters.AddWithValue("@Rol", updatedUser.userRole);
                        command.Parameters.AddWithValue("@KullaniciKodu", updatedUser.userCode);

                        // Bağlantıyı aç
                        connection.Open();

                        // Sorguyu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();

                        // Sonuçlara göre mesaj göster
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kullanıcı bilgileri başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme başarısız oldu. Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // SQL hatalarını yakala ve kullanıcıya bildir
                MessageBox.Show($"Veritabanı hatası: {sqlEx.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Diğer genel hataları yakala ve kullanıcıya bildir
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void AddNewDemirbas(Demirbas newDemirbas)
        {
            string addQuery = @"
        INSERT INTO Demirbaslar (DemirbasAdi, DemirbasTuru, SatinAlmaTarihi, KayitTarihi, Durum, KullaniciID, Aciklama)
        VALUES (@DemirbasAdi, @DemirbasTuru, @SatinAlmaTarihi, @KayitTarihi, @Durum, @KullaniciID, @Aciklama)";

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(addQuery, connection))
                {
                    // Parametreleri ekle
                    command.Parameters.AddWithValue("@DemirbasAdi", newDemirbas.DemirbasAdi ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DemirbasTuru", newDemirbas.DemirbasTuru ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@SatinAlmaTarihi", newDemirbas.SatinAlmaTarihi ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@KayitTarihi", newDemirbas.KayitTarihi ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Durum", newDemirbas.Durum ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@KullaniciID", newDemirbas.KullaniciID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Aciklama", newDemirbas.Aciklama ?? (object)DBNull.Value);

                    // Bağlantıyı aç ve sorguyu çalıştır
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddNewUser(User newUser)
        {
            string addQuery = "INSERT INTO Kullanicilar (KullaniciAdi, KullaniciSoyadi, Unvan, Departman, KullaniciKodu, Email, Sifre, BaslamaTarihi, Statu, Rol) VALUES ('" + newUser.userName + "' , '" + newUser.sureName + "' ,'" + newUser.userTitle + "','" + newUser.userDepartment + "','" + newUser.userCode + "','" + newUser.usereMail + "','" + newUser.userePassword + "','" + newUser.userStartTime + "','" + newUser.userStatus + "','" + newUser.userRole + "')";
            DataBaseSettings.ExecuteNonQuery(addQuery);
        }

        public void AddNewYetki( string yetkiAdi )
        {
            string addQuery = "INSERT INTO Yetki (Yetki) VALUES ('" +yetkiAdi + "')";
            DataBaseSettings.ExecuteNonQuery(addQuery);
        }
        public void DeleteYetki(int userCode)
        {
            string addQuery = "DELETE FROM Kullanicilar WHERE ='"+userCode+"'";
            DataBaseSettings.ExecuteNonQuery(addQuery);
        }

        public void statuGuncelle(int kullaniciId)
        {
            // SQL sorgusunu oluştur
            string updateQuery = "UPDATE Kullanicilar SET Statu = @Statu WHERE KullaniciId = @KullaniciId";

            // Bağlantıyı oluştur
            using (SqlConnection connection = new SqlConnection(DataBaseSettings.ConnectionString))
            {
                // SQL sorgusunu çalıştır
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    // Parametreleri ekle
                    command.Parameters.AddWithValue("@Statu", "PASİF");
                    command.Parameters.AddWithValue("@KullaniciId", kullaniciId);

                    // Bağlantıyı aç
                    connection.Open();

                    // ExecuteNonQuery ile sorguyu çalıştır ve etkilenen satır sayısını al
                    int rowsAffected = command.ExecuteNonQuery();

                    // Güncelleme başarılı olduysa mesaj yazdır
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Kullanıcının statüsü başarıyla PASİF'e çekildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme başarısız oldu. Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


    }







}

