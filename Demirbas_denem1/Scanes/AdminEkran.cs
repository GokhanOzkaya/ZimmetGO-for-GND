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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            YeniKullanıcıEkle yeniKullanıcıEkle = new YeniKullanıcıEkle();
            yeniKullanıcıEkle.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            YetilendirmeEkranı ye = new YetilendirmeEkranı();
            ye.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Demirbasİslemleri demirbasİslemleri = new Demirbasİslemleri();
            demirbasİslemleri.Show();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hareketler h = new Hareketler();
            h.Show();   
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Transfer tr = new Transfer();   
            tr.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            KullaniciZimmetleri kz = new KullaniciZimmetleri();
            kz.Show();  
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DemirbasZimmetleri de = new DemirbasZimmetleri(); de.Show();    
        }

        private void AdminEkran_Load(object sender, EventArgs e)
        {
            int value1 = Convert.ToInt32(label1.Text);
            int value2 = Convert.ToInt32(label2.Text);
            int value3 = Convert.ToInt32(label3.Text);

            // Pie Chart serisini temizliyoruz (varsa)
            chart1.Series.Clear();

            // Yeni bir seri oluşturuyoruz
            Series series = new Series
            {
                Name = "PieSeries",
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Pie
            };

            // Chart'a seriyi ekliyoruz
            chart1.Series.Add(series);

            // Seriye verileri ekliyoruz
            series.Points.AddXY(value1.ToString(), value1);
            series.Points.AddXY(value2.ToString(), value2);
            series.Points.AddXY(value3.ToString(), value3);

            // Grafiğin görsel ayarlarını yapalım (isteğe bağlı)
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true; // 3D görünüm isteniyorsa
            chart1.Legends[0].Enabled = true; // Legend'i etkinleştiriyoruz
        }
    }
}
