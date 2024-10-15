using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demirbas_denem1.Entities
{
    public class ZimmetGecmisi
    {
        public int GecmisID { get; set; }              // Geçmiş kayıt ID'si
        public int KullaniciID { get; set; }           // Kullanıcı ID'si
        public int DemirbasID { get; set; }            // Demirbaş ID'si
        public DateTime ZimmetTarihi { get; set; }    // Zimmet tarihi
        public DateTime? IadeTarihi { get; set; }     // İade tarihi (nullable)
        public int? ZimmetAlınanKisiID { get; set; }  // Zimmet alınan kişi ID'si (nullable)

       
    }

    public class SelectedZimmetGecmisi : ZimmetGecmisi 
    { 
    }


}
