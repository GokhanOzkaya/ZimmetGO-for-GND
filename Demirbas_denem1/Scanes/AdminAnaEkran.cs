using Demirbas_denem1.Database;
using Demirbas_denem1.Entities;
using Demirbas_denem1.Scanes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Demirbas_denem1
{
    public partial class AdminAnaEkran : Form
    {
        public AdminAnaEkran()
        {
            InitializeComponent();
            label1.Text = CurrentAdmin.Admin.AdminUserName;
            label2.Text = CurrentAdmin.Admin.AdminSifre; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Items items = new Items();
            items.btn_kapat(sender,e);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YeniKullanıcıEkle yeniKullanıcıEkle = new YeniKullanıcıEkle();
            yeniKullanıcıEkle.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
       
        }

        private void button4_Click(object sender, EventArgs e)
        {
            YetilendirmeEkranı ye = new YetilendirmeEkranı();
            ye.Show();  
        }
    }
}
