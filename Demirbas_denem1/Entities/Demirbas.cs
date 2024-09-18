using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demirbas_denem1.Entities
{
    public class Demirbas
    {
        public int DemirbasID { get; set; }            // Benzersiz kimlik
        public string DemirbasAdi { get; set; }        // Demirbaş adı
        public string DemirbasMarka { get; set; }        // Demirbaş adı
        public string DemirbasModel { get; set; }        // Demirbaş adı
        public int DemirbasUNIQKod { get; set; }        // Demirbaş adı
        public string DemirbasTuru { get; set; }       // Demirbaş türü (telefon, bilgisayar, vb.)
        public DateTime? SatinAlmaTarihi { get; set; } // Satın alma tarihi
        public DateTime? KayitTarihi { get; set; }     // Kayıt tarihi
        public string Durum { get; set; }              // Durum (aktif, pasif, tamirde, vb.)
        public int? KullaniciID { get; set; }          // Şu anki kullanan kişi ID'si
        public string Aciklama { get; set; }           // Ek açıklamalar

    }
}
