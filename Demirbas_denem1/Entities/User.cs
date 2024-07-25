using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demirbas_denem1.Entities
{
    public class User
    {
  
        public string userName { get; set; }    
        public string sureName { get; set; }
        public string userCode { get; set; }
        public string usereMail { get; set; }   
        public string userDescription { get; set; } 
        public string userStatus { get; set; } 
        public string userUnvan { get; set; }
        public DateTime userStartTime{ get; set; } 
        public DateTime userFinishTime{ get; set; }
    
    }
   
    public class Admin
    {
        public int AdminId { get; set; }
        public string AdminAdi { get; set; }
        public string AdminUserName { get; set; }
        public string AdminSifre { get; set; }
        // Diğer alanları ekleyebilirsiniz.
    }

    public static class CurrentAdmin
    {
        public static Admin Admin { get; set; } = new Admin();
    }
}
