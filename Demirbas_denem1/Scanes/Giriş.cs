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
            dataGridView1.DataSource = DataBaseSettings.ds.Tables["Kullanicilar"];
        
            DataBaseSettings.con.Close();
           
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string silmeSorgusu = "DELETE FROM Urunler WHERE UrunKodu ="+urunKodu;
            DataBaseSettings.con.Open();

            SqlCommand verisil = new SqlCommand(silmeSorgusu, DataBaseSettings.con);
            verisil.ExecuteNonQuery();

            DataBaseSettings.con.Close();

            griddoldur();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            bool isThere = DataBaseSettings.ısThereUser(userName: textBox1.Text, userSifre: textBox2.Text);

            if (isThere)
            {
         
                string userPassword = textBox2.Text.ToString();
                DataBaseSettings.LoadAdminData(textBox1.Text, textBox2.Text);

                AnaEkran form2 = new AnaEkran();
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
            YeniKullanıcıEkle kayıtOl = new YeniKullanıcıEkle();
            kayıtOl.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            bool isThere = DataBaseSettings.ısThere(Convert.ToInt32(textBox3.Text),textBox4.Text);
            if (isThere)
            {
                UserRepository Repository = new UserRepository();
                string userName = textBox4.Text;
                string userPassword = textBox3.Text.ToString();
                DataBaseSettings.LoadAdminData(userName,userPassword);


                AnaEkran anaEkran = new AnaEkran();
                anaEkran.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Şifre veya Parola Hatalı Lütfen Daha Sonra Tekrar Deneyiniz");
            }
        }
    }
}
