using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
