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
using MetroFramework.Forms;
using MetroFramework.Controls;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Documents;


namespace Demirbas_denem1
{
    public partial class Giriş : MetroForm
    {
        public  Giriş()
        {
            InitializeComponent();
            this.Text = "Hoş Geldiniz";
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

            bool isUser = DataBaseSettings.ısThereUser(kullaniciKodu: textBox1.Text, userSifre: textBox2.Text,Rol:"User");
            bool isAdmin = DataBaseSettings.ısThereAdmin(kullaniciKodu: textBox1.Text, userSifre: textBox2.Text,Rol:"Admin");
            bool isManager = DataBaseSettings.ısThereManager(kullaniciKodu: textBox1.Text, userSifre: textBox2.Text, Rol: "Manager");

            if (isUser)
            {
                DataBaseSettings.LoadUserData(textBox1.Text, textBox2.Text);
 
                AnaEkran form2 = new AnaEkran(role:"User");
                griddoldur();
                form2.ShowDialog();
            }
           else if (isAdmin)
            {
                DataBaseSettings.LoadUserData(textBox1.Text, textBox2.Text);
                AdminEkran adminEkran = new AdminEkran(rol:"Admin");
                adminEkran.ShowDialog();
                return;

            }
            else if (isManager)
            {
                DataBaseSettings.LoadUserData(textBox1.Text, textBox2.Text);
                AdminEkran adminEkran = new AdminEkran(rol: "Manager");
                adminEkran.ShowDialog();
            }
       

            else
            {
                MessageBox.Show("Şifre veya Parola Hatalı Lütfen Daha Sonra Tekrar Deneyiniz");
            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
     
            AdminEkran adminEkran = new AdminEkran(rol:"Admin");
            adminEkran.ShowDialog();    
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
    
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Giriş_Load(object sender, EventArgs e)
        {
            
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
