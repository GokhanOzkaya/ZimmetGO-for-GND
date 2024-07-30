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
using Demirbas_denem1.Scanes;


namespace Demirbas_denem1
{
    public partial class Giriş : Form
    {
        public  Giriş()
        {
            InitializeComponent();
        }


        public void griddoldur()
        {
            DataBaseSettings.con= new SqlConnection(DataBaseSettings.ConnectionString);
            DataBaseSettings.da = new SqlDataAdapter("Select * From Kullanicilar", DataBaseSettings.con);
            DataBaseSettings.ds = new DataSet();
            DataBaseSettings.con.Open();
            DataBaseSettings.da.Fill(DataBaseSettings.ds, "Kullanicilar");
            DataBaseSettings.con.Close();
           
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
         
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

            bool isUser = DataBaseSettings.ısThereUser(userName: textBox1.Text, userSifre: textBox2.Text);

            if (isUser)
            {
                DataBaseSettings.LoadUserData(textBox1.Text, textBox2.Text);

                String role = CurrentUser.User.userRole;   
                AnaEkran form2 = new AnaEkran(role:"User");
                griddoldur();
                form2.ShowDialog();
            }


            else
            {
                MessageBox.Show("Şifre veya Parola Hatalı Lütfen Daha Sonra Tekrar Deneyiniz");
            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
     
            AdminEkran adminEkran = new AdminEkran();
            adminEkran.ShowDialog();    
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
    
        }
    }
}
