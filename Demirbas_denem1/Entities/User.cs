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
        public string userTitle { get; set; }
        public string userDepartment { get; set; }
        public string userCode { get; set; }
        public string usereMail { get; set; }   
        public string userePassword { get; set; }   
        public DateTime userStartTime{ get; set; } 
        public string userStatus {  get; set; } 
        public string userRole { get; set; }
    
    }
    public static class CurrentUser
    {
        public static User User { get; set; } = new User();
    }

}
