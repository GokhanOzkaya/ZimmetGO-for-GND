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
            string addQuery = @"INSERT INTO Demirbaslar (DemirbasAdi,DemirbasMarka,DemirbasModel,DemirbasUNIQKod, DemirbasTuru, SatinAlmaTarihi, KayitTarihi, Durum, KullaniciID, Aciklama,FirmaKodu)
        VALUES (@DemirbasAdi,@DemirbasMarka,@DemirbasModel,@DemirbasUNIQKod, @DemirbasTuru, @SatinAlmaTarihi, @KayitTarihi, @Durum, @KullaniciID, @Aciklama,@FirmaKodu)";
           
                using (SqlConnection connection = new SqlConnection(DataBaseSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(addQuery, connection))
                {
                    // Parametreleri ekle
                    command.Parameters.AddWithValue("@DemirbasAdi", newDemirbas.DemirbasAdi ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DemirbasMarka", newDemirbas.DemirbasMarka ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DemirbasModel", newDemirbas.DemirbasModel ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DemirbasUNIQKod", newDemirbas.DemirbasUNIQKod );
                    command.Parameters.AddWithValue("@DemirbasTuru", newDemirbas.DemirbasTuru ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@SatinAlmaTarihi", newDemirbas.SatinAlmaTarihi ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@KayitTarihi", newDemirbas.KayitTarihi ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Durum", newDemirbas.Durum ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@KullaniciID", newDemirbas.KullaniciID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Aciklama", newDemirbas.Aciklama ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@FirmaKodu",newDemirbas.FirmaKodu ?? (object)DBNull.Value);

                    // Bağlantıyı aç ve sorguyu çalıştır
                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }


        }
        public void UpdateDemirbas(Demirbas updatedDemirbas)
        {
            string updateQuery = @"UPDATE Demirbaslar SET DemirbasAdi = @DemirbasAdi,DemirbasMarka = @DemirbasMarka,DemirbasModel = @DemirbasModel,  DemirbasTuru = @DemirbasTuru,SatinAlmaTarihi = @SatinAlmaTarihi,KayitTarihi = @KayitTarihi, Durum = @Durum,KullaniciID = @KullaniciID, Aciklama = @Aciklama,FirmaKodu = @FirmaKodu WHERE DemirbasID = @DemirbasID";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataBaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@DemirbasAdi", updatedDemirbas.DemirbasAdi ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@DemirbasMarka", updatedDemirbas.DemirbasMarka ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@DemirbasModel", updatedDemirbas.DemirbasModel ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@DemirbasTuru", updatedDemirbas.DemirbasTuru ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@SatinAlmaTarihi", updatedDemirbas.SatinAlmaTarihi ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@KayitTarihi", updatedDemirbas.KayitTarihi ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Durum", updatedDemirbas.Durum ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@KullaniciID", updatedDemirbas.KullaniciID ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Aciklama", updatedDemirbas.Aciklama ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@FirmaKodu", updatedDemirbas.FirmaKodu ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@DemirbasID", updatedDemirbas.DemirbasID );
                       

                        connection.Open();
                        command.ExecuteNonQuery();
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

        public void UpdateDemirbasKullaniciID(int demirbasId, int kullaniciId, DateTime? zimmetTarihi = null, DateTime? iadeTarihi = null, int? zimmetAlınanKisiID= null)
        {
            string updateQuery = @"UPDATE Demirbaslar SET KullaniciID = @KullaniciID WHERE DemirbasID = @DemirbasID";
            string addQuery = "INSERT INTO [dbo].[ZimmetGecmisi] (KullaniciID, DemirbasID, ZimmetTarihi, IadeTarihi,ZimmetAlınanKisiID) " +
                              "VALUES (@KullaniciID, @DemirbasID, @ZimmetTarihi, @IadeTarihi,@ZimmetAlınanKisiID)";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataBaseSettings.ConnectionString))
                {
                    // Update command run
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                        command.Parameters.AddWithValue("@DemirbasID", demirbasId);

                        // Bağlantıyı aç ve sorguyu çalıştır
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();  // Tekrar çağrı yapma

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kullanıcı ID başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme yapılacak kayıt bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    // Zimmet Gecmis Ekle Run
                    using (SqlCommand command = new SqlCommand(addQuery, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@KullaniciID", kullaniciId);
                        command.Parameters.AddWithValue("@DemirbasID", demirbasId);
                        command.Parameters.AddWithValue("@ZimmetTarihi", zimmetTarihi ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@IadeTarihi", iadeTarihi ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@ZimmetAlınanKisiID", zimmetAlınanKisiID ?? (object)DBNull.Value);

                        int rowsAffected = command.ExecuteNonQuery();  // Tekrar çağrı yapma

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Zimmet geçmişi başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Zimmet geçmişi eklenirken sorun oluştu.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        public void KullaniciDemirbasIade(int demirbasId) 
        {
            string ıadeQuery = @"UPDATE Demirbaslar SET KullaniciID = @KullaniciID WHERE DemirbasID = @DemirbasID";

            using (SqlConnection nc = new SqlConnection(DataBaseSettings.ConnectionString))
            {
                using (SqlCommand sc = new SqlCommand(ıadeQuery)) 
                {
                    sc.Parameters.AddWithValue("@DemirbasID", demirbasId);
                    int rowsAffected = sc.ExecuteNonQuery();

                    if (rowsAffected > 0) 
                    {
                        MessageBox.Show("Zimmet geçmişi başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }

            }

        }

        public void DemirbasHurdayaCikar(int demirbasID)
        {
            string updateQuery = @"UPDATE Demirbaslar SET Durum = @Durum WHERE DemirbasID = @DemirbasID";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataBaseSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@Durum", "HURDA");
                        command.Parameters.AddWithValue("@DemirbasID", demirbasID);
                        // Bağlantıyı aç ve sorguyu çalıştır
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Ürün başarıyla hurdaya ayrılmıştır", "İşlem Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

       

        public void AddNewUser(User newUser)
        {
            string addQuery = @"INSERT INTO Kullanicilar (KullaniciAdi, KullaniciSoyadi, Unvan, Departman, KullaniciKodu, Email, Sifre, BaslamaTarihi, Statu, Rol,FirmaKodu)
                    VALUES (@KullaniciAdi, @KullaniciSoyadi, @Unvan, @Departman, @KullaniciKodu, @Email, @Sifre, @BaslamaTarihi, @Statu, @Rol,@FirmaKodu)";

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(addQuery, connection))
                {
                    command.Parameters.AddWithValue("@KullaniciAdi", newUser.userName);
                    command.Parameters.AddWithValue("@KullaniciSoyadi", newUser.sureName);
                    command.Parameters.AddWithValue("@Unvan", newUser.userTitle);
                    command.Parameters.AddWithValue("@Departman", newUser.userDepartment);
                    command.Parameters.AddWithValue("@KullaniciKodu", newUser.userCode);
                    command.Parameters.AddWithValue("@Email", newUser.usereMail);
                    command.Parameters.AddWithValue("@Sifre", newUser.userePassword);
                    command.Parameters.AddWithValue("@BaslamaTarihi", newUser.userStartTime);  // DateTime ise direkt kullanılır
                    command.Parameters.AddWithValue("@Statu", newUser.userStatus);
                    command.Parameters.AddWithValue("@Rol", newUser.userRole);
                    command.Parameters.AddWithValue("@FirmaKodu", newUser.FirmaKodu);

                    connection.Open();
                    command.ExecuteNonQuery();
                   
                }
            }
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

