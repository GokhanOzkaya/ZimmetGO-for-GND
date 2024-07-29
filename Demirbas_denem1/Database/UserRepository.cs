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
        public void AddNewUser(User newUser) 
        {
           string addQuery = "INSERT INTO Kullanicilar (KullaniciAdi, KullaniciSoyadi, Unvan, Departman, KullaniciKodu, Email, Sifre, BaslamaTarihi, Statu, Rol) VALUES ('" + newUser.userName+"' , '"+newUser.sureName+"' ,'" + newUser.userTitle+ "','" + newUser.userDepartment+ "','" + newUser.userCode+ "','" + newUser.usereMail+ "','" + newUser.userePassword+ "','" + newUser.userStartTime+ "','" + newUser.userStatus+ "','" + newUser.userRole+ "')";
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
     
    }
}
