using Demirbas_denem1.Entities;
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

        public ZimmetOnay(Entities.SelectedDemirbas selectedDemirbas,Entities.SelectedUser selectedUser)
        {
            InitializeComponent();
            _selectedDemirbas = selectedDemirbas;
            _selectedUser = selectedUser;
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



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Items items1 = new Items();
            items1.btn_kapat(sender, e);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
