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
           string addQuery = "INSERT INTO Kullanicilar (KullaniciAdi,KullaniciSoyadi, Email,BaslamaTarihi,Statu,Unvan,KullaniciKodu) VALUES ('"+newUser.userName+"' , '"+newUser.sureName+"' ,'" + newUser.usereMail+ "','" + newUser.userStartTime+ "','" + newUser.userStatus+ "','" + newUser.userUnvan+ "','" + newUser.userCode+ "')";
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
