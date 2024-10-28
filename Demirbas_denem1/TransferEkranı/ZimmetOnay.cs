﻿using Demirbas_denem1.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demirbas_denem1.TransferEkranı
{
    public partial class ZimmetOnay : Form
    {
        private Entities.SelectedDemirbas _selectedDemirbas;
        private Entities.SelectedUser _selectedUser;
        private Entities.OldUser _oldUser;


        private int _xKullanicilarKullaniciId;

        private int _xDemirbaslarKullaniciId;
        public ZimmetOnay(Entities.SelectedDemirbas selectedDemirbas, Entities.SelectedUser selectedUser, OldUser oldUser)
        {
            InitializeComponent();
            _selectedDemirbas = selectedDemirbas;
            _selectedUser = selectedUser;
            _oldUser = oldUser;
        }

        private void ZimmetOnay_Load(object sender, EventArgs e)
        {
            label2.Text = _selectedDemirbas.DemirbasID.ToString();      // Demirbaş ID
            label3.Text = _selectedDemirbas.DemirbasAdi;                // Demirbaş Adı
            label4.Text = _selectedDemirbas.DemirbasMarka;              // Demirbaş Marka
            label5.Text = _selectedDemirbas.DemirbasModel;              // Demirbaş Model
            label6.Text = _selectedDemirbas.DemirbasUNIQKod;            // Demirbaş UNIQ Kod
            label7.Text = _selectedDemirbas.DemirbasTuru;               // Demirbaş Türü
            label8.Text = _selectedDemirbas.SatinAlmaTarihi.HasValue
                          ? _selectedDemirbas.SatinAlmaTarihi.Value.ToString("yyyy-MM-dd")
                          : "Tarih Yok";                                // Satın Alma Tarihi
            label9.Text = _selectedDemirbas.KayitTarihi.HasValue
                          ? _selectedDemirbas.KayitTarihi.Value.ToString("yyyy-MM-dd")
                          : "Tarih Yok";                                // Kayıt Tarihi
            label10.Text = _selectedDemirbas.Durum;                     // Durum
            label11.Text = _selectedDemirbas.KullaniciID.HasValue
                           ? _selectedDemirbas.KullaniciID.Value.ToString()
                           : "Kullanıcı Yok";                           // Kullanıcı ID
            label12.Text = _selectedDemirbas.Aciklama;                  // Açıklama
            label13.Text = _selectedDemirbas.FirmaKodu.ToString();      // Firma Kodu



            label14.Text = _selectedUser.KullaniciId.ToString();             // Kullanıcı ID
            label15.Text = _selectedUser.userName;                           // Kullanıcı Adı
            label16.Text = _selectedUser.sureName;                           // Kullanıcı Soyadı
            label17.Text = _selectedUser.userTitle;                          // Kullanıcı Unvanı
            label18.Text = _selectedUser.userDepartment;                     // Kullanıcı Departmanı
            label19.Text = _selectedUser.userCode;                           // Kullanıcı Kodu
            label20.Text = _selectedUser.usereMail;                          // Kullanıcı E-mail
            label21.Text = _selectedUser.userStartTime.ToString("yyyy-MM-dd");  // Kullanıcı Başlama Tarihi
            label22.Text = _selectedUser.userStatus;                         // Kullanıcı Durumu
            label23.Text = _selectedUser.userRole;                           // Kullanıcı Rolü
            label24.Text = _selectedUser.FirmaKodu;



            //DataBaseFilters.DemirbasKimeAit(_selectedDemirbas.DemirbasUNIQKod, null);
            _oldUser = DataBaseFilters.DemirbasKimeAit(_selectedDemirbas.DemirbasUNIQKod, null);

            label26.Text = _oldUser.userName;
            label27.Text = _oldUser.sureName;
            label28.Text = _oldUser.userStatus;
            label29.Text = _oldUser.userRole;
            label30.Text = _oldUser.userCode;
            label31.Text = _oldUser.FirmaKodu;
            label32.Text = _oldUser.userDepartment;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Items items1 = new Items();
            items1.btn_kapat(sender, e);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _xDemirbaslarKullaniciId = Convert.ToInt32(label11.Text);
            _xKullanicilarKullaniciId = Convert.ToInt32(label14.Text);
            UserRepository ur = new UserRepository();
            try
            {

                if (_xKullanicilarKullaniciId == _xDemirbaslarKullaniciId)
                {
                    MessageBox.Show($"Seçtiğiniz Malzeme Zaten Seçtiğiniz Kullanıcı Üzerine Zimmetli", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              
                else
                {
                    DialogResult dialogResult;

                    if (label24.Text != label13.Text)
                    {
                        dialogResult = MessageBox.Show("Yapacağınız zimmet farklı iki firma arasındadır onaylıyor musunuz?", "Zimmet Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        dialogResult = MessageBox.Show("Bu demirbaşı zimmet etmek istediğinize emin misiniz?", "Zimmet Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }

                    if (dialogResult == DialogResult.Yes)
                    {
                        ur.UpdateDemirbasKullaniciID(
                            demirbasId: Convert.ToInt32(label2.Text),
                            kullaniciId: Convert.ToInt32(label14.Text),
                            zimmetTarihi: DateTime.Now,
                            iadeTarihi: DateTime.Now,
                            zimmetAlınanKisiID: _xKullanicilarKullaniciId,
                            firmaKodu:_selectedUser.FirmaKodu
                        );
                    }
                    else
                    {
                        MessageBox.Show("Zimmet işlemi iptal edildi.", "İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
