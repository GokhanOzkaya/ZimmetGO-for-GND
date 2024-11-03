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
using MetroFramework.Forms;
using MetroFramework.Controls;
namespace Demirbas_denem1.Scanes
{
    public partial class AdminEkran : MetroForm
    {
        public AdminEkran()
        {
            InitializeComponent();
            this.Text = "Ana Menü";
        }


        private void AdminEkran_Load(object sender, EventArgs e)
        {
            Count count = new Count();
            label7.Text = count.UrunSay("BİLGİSAYAR").ToString();
            label37.Text = count.UrunSayIT("BİLGİSAYAR",1).ToString();
            label19.Text = (Convert.ToInt32(label7.Text) - Convert.ToInt32(label37.Text)).ToString();


            label8.Text = count.UrunSay("TELEFON").ToString();
            label40.Text = count.UrunSayIT("TELEFON", 1).ToString();
            label22.Text = (Convert.ToInt32(label8.Text) - Convert.ToInt32(label40.Text)).ToString();

            label9.Text = count.UrunSay("MONİTÖR").ToString();
            label43.Text = count.UrunSayIT("MONİTÖR", 1).ToString();
            label25.Text = (Convert.ToInt32(label9.Text) - Convert.ToInt32(label43.Text)).ToString();

            label10.Text = count.UrunSay("LİSANS").ToString();
            label46.Text = count.UrunSayIT("LİSANS", 1).ToString();
            label28.Text = (Convert.ToInt32(label10.Text) - Convert.ToInt32(label46.Text)).ToString();

            label11.Text = count.UrunSay("TELEFON HATTI").ToString();
            label49.Text = count.UrunSayIT("TELEFON HATTI", 1).ToString();
            label31.Text = (Convert.ToInt32(label11.Text) - Convert.ToInt32(label49.Text)).ToString();

            label12.Text = count.UrunSay("ARAÇ").ToString();
            label52.Text = count.UrunSayIT("ARAÇ",1).ToString();
            label34.Text = (Convert.ToInt32(label12.Text) - Convert.ToInt32(label52.Text)).ToString();

            chart1.Series["Kullanımda"].IsValueShownAsLabel = true;
            chart1.Series["Depoda"].IsValueShownAsLabel = true;
            chart1.Series["Toplam"].IsValueShownAsLabel = true;


            // Telefon
            chart1.Series["Kullanımda"].Points.AddXY("Telefon", Convert.ToInt32(label22.Text));
            chart1.Series["Depoda"].Points.AddXY("Telefon", Convert.ToInt32(label40.Text));
            chart1.Series["Toplam"].Points.AddXY("Telefon", Convert.ToInt32(label8.Text));

            // Bilgisayar
            chart1.Series["Kullanımda"].Points.AddXY("Bilgisayar", Convert.ToInt32(label19.Text));
            chart1.Series["Depoda"].Points.AddXY("Bilgisayar", Convert.ToInt32(label37.Text));
            chart1.Series["Toplam"].Points.AddXY("Bilgisayar", Convert.ToInt32(label7.Text));

            // Monitör
            chart1.Series["Kullanımda"].Points.AddXY("Monitör", Convert.ToInt32(label25.Text));
            chart1.Series["Depoda"].Points.AddXY("Monitör", Convert.ToInt32(label43.Text));
            chart1.Series["Toplam"].Points.AddXY("Monitör", Convert.ToInt32(label9.Text));

            // Lisans
            chart1.Series["Kullanımda"].Points.AddXY("Lisans", Convert.ToInt32(label28.Text));
            chart1.Series["Depoda"].Points.AddXY("Lisans", Convert.ToInt32(label46.Text));
            chart1.Series["Toplam"].Points.AddXY("Lisans", Convert.ToInt32(label10.Text));

            // Telefon Hattı
            chart1.Series["Kullanımda"].Points.AddXY("Telefon Hattı", Convert.ToInt32(label31.Text));
            chart1.Series["Depoda"].Points.AddXY("Telefon Hattı", Convert.ToInt32(label49.Text));
            chart1.Series["Toplam"].Points.AddXY("Telefon Hattı", Convert.ToInt32(label11.Text));

            // Araç
            chart1.Series["Kullanımda"].Points.AddXY("Araç", Convert.ToInt32(label34.Text));
            chart1.Series["Depoda"].Points.AddXY("Araç", Convert.ToInt32(label52.Text));
            chart1.Series["Toplam"].Points.AddXY("Araç", Convert.ToInt32(label12.Text));



            // Seri türlerini ayarla
            chart1.Series["Kullanımda"].ChartType = SeriesChartType.Column;
            chart1.Series["Depoda"].ChartType = SeriesChartType.Column;
            chart1.Series["Toplam"].ChartType = SeriesChartType.Column;

            // X ekseninin yana yana görünmesi için ayar
            chart1.ChartAreas[0].AxisX.IsMarginVisible = true;

            // Grafik arka plan ve alan renkleri
            chart1.BackColor = Color.WhiteSmoke;
            chart1.ChartAreas[0].BackColor = Color.White;



            // Değerlerin çubukların üstünde görünmesi için
            chart1.Series["Kullanımda"].IsValueShownAsLabel = true;
            chart1.Series["Depoda"].IsValueShownAsLabel = true;
            chart1.Series["Toplam"].IsValueShownAsLabel = true;

            // Etiketlerin yazı tipi ve rengi
            chart1.Series["Kullanımda"].LabelForeColor = Color.DimGray;
            chart1.Series["Depoda"].LabelForeColor = Color.DimGray;
            chart1.Series["Toplam"].LabelForeColor = Color.DimGray;

            // Eksen çizgi ve etiket ayarları
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Verdana", 9, FontStyle.Regular);
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Verdana", 9, FontStyle.Regular);

            // Başlık ekleyin ve stilini ayarlayın
            chart1.Titles.Add("Demirbaş Durumları");
            chart1.Titles[0].Font = new Font("Arial", 12, FontStyle.Bold);
            chart1.Titles[0].ForeColor = Color.DarkSlateGray;


          
           
           
           



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
