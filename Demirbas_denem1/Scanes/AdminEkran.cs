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
            label7.Text = count.LaptopSay("Elektronik").ToString();
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
    }
}
