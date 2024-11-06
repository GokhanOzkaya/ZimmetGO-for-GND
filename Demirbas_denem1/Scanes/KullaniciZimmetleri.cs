using Demirbas_denem1.Database;
using Demirbas_denem1.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
namespace Demirbas_denem1.Scanes
{
    public partial class KullaniciZimmetleri : MetroForm
    {
        public KullaniciZimmetleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Items items1 = new Items();
            items1.btn_kapat(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataBaseSettings.SearchInKullanicilar(textBox1.Text,dataGridView1);  
            
        }

        private void KullaniciZimmetleri_Load(object sender, EventArgs e)
        {
            CustomDGV customDGV = new CustomDGV();
            customDGV.CustomizeDataGridView(dataGridView1);
            customDGV.CustomizeDataGridView(dataGridView2);
            DataBaseSettings.GridDoldurKullanici(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataBaseFilters.UserZimmetleriLisetele(Convert.ToInt32(label4.Text), dataGridView2);
        }
   

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Seçili hücrenin satır indeksini al
            int selectedRowIndex = e.RowIndex;

            // Eğer indeks geçerliyse
            if (selectedRowIndex >= 0)
            {
                // Seçili satırdaki KullaniciAdi'ni al
                var kullaniciAdi = dataGridView1.Rows[selectedRowIndex].Cells["KullaniciAdi"].Value;
                var kullaniciSoyAdi = dataGridView1.Rows[selectedRowIndex].Cells["KullaniciSoyAdi"].Value;
                var kullaniciDepartman = dataGridView1.Rows[selectedRowIndex].Cells["Departman"].Value;
                var kullaniciID = dataGridView1.Rows[selectedRowIndex].Cells["KullaniciID"].Value;

                // KullaniciAdi'ni label1'e yazdır
                label1.Text = kullaniciAdi != null ? kullaniciAdi.ToString() : "Kullanıcı Adı Bulunamadı";
                label2.Text = kullaniciSoyAdi != null ? kullaniciSoyAdi.ToString() : "Kullanıcı Adı Bulunamadı";
                label3.Text = kullaniciDepartman != null ? kullaniciDepartman.ToString() : "Kullanıcı Adı Bulunamadı";
                label4.Text = kullaniciID != null ? kullaniciID.ToString() : "Kullanıcı Adı Bulunamadı";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataBaseFilters.ZimmetGemisLisetele(kullaniciID: Convert.ToInt32(label4.Text),dataGridView: dataGridView2);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
