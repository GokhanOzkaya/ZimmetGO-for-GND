using Demirbas_denem1.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Demirbas_denem1.Scanes
{
    public partial class AdminEkran : Form
    {
        public AdminEkran()
        {
            InitializeComponent();
        }


        private void AdminEkran_Load(object sender, EventArgs e)
        {
            Count count = new Count();
            label7.Text = count.UrunSay("BİLGİSAYAR").ToString();
            label8.Text = count.UrunSay("TELEFON").ToString();
            label9.Text = count.UrunSay("MONİTÖR").ToString();
            label10.Text = count.UrunSay("LİSANS").ToString();
            label11.Text = count.UrunSay("TELEFON HATTI").ToString();
            label12.Text = count.UrunSay("ARAÇ").ToString();
           
            label40.Text = count.UrunSayIT("TELEFON",10).ToString();
            label22.Text = (Convert.ToInt32(label8.Text) - Convert.ToInt32(label40.Text)).ToString();


            chart1.Series["Kullanımda"].Points.AddXY("Bilgisayar",100); // İlk seriye 10 değeri ekleniyor
            chart1.Series["Depoda"].Points.AddY(20); // İkinci seriye 20 değeri ekleniyor
            chart1.Series["Toplam"].Points.AddY(30); // Üçüncü seriye 30 değeri ekleniyor
        }

   

        private void button2_Click_1(object sender, EventArgs e)
        {
            YeniKullanıcıEkle yeniKullanıcıEkle = new YeniKullanıcıEkle();
            yeniKullanıcıEkle.Show();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            Demirbasİslemleri demirbasİslemleri = new Demirbasİslemleri();
            demirbasİslemleri.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            KullaniciZimmetleri kz = new KullaniciZimmetleri();
            kz.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            DemirbasZimmetleri de = new DemirbasZimmetleri(); de.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Hareketler h = new Hareketler();
            h.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            YetilendirmeEkranı ye = new YetilendirmeEkranı();
            ye.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Transfer tr = new Transfer();
            tr.Show();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
