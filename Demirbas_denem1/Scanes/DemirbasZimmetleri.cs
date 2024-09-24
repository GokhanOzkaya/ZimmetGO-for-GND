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

namespace Demirbas_denem1.Scanes
{
    public partial class DemirbasZimmetleri : Form
    {
        public DemirbasZimmetleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            if (int.TryParse(input, out int demirbasId))
            {
                // Girilen değer bir sayı ise
                DataBaseFilters.DatabaseFilterDemirbas(demirbasId, dataGridView1);
            }
            else
            {
                // Girilen değer sayı değilse, string olarak işlem yap
                DataBaseFilters.DatabaseFilterDemirbas(input, dataGridView1);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            if (int.TryParse(input, out int demirbasId))
            {
                // Girilen değer bir sayı ise
                DataBaseFilters.DatabaseFilterDemirbas(demirbasId, dataGridView1);
            }
            else
            {
                // Girilen değer sayı değilse, string olarak işlem yap
                DataBaseFilters.DatabaseFilterDemirbas(input, dataGridView1);
            }


        }

        private void DemirbasZimmetleri_Load(object sender, EventArgs e)
        {
            DataBaseSettings.GridDoldurDemirbas(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçili hücrenin satır indeksini al
            int selectedRowIndex = e.RowIndex;

            // Eğer indeks geçerliyse
            if (selectedRowIndex >= 0)
            {
                // Seçili satırdaki KullaniciAdi'ni al
                var demirbasAdi = dataGridView1.Rows[selectedRowIndex].Cells["DemirbasAdi"].Value;
                var demirbasMarka = dataGridView1.Rows[selectedRowIndex].Cells["DemirbasMarka"].Value;
                var demirbasModel = dataGridView1.Rows[selectedRowIndex].Cells["DemirbasModel"].Value;
                var DemirbasUNIQKod= dataGridView1.Rows[selectedRowIndex].Cells["DemirbasUNIQKod"].Value;

                // KullaniciAdi'ni label1'e yazdır
                label1.Text = demirbasAdi != null ? demirbasAdi.ToString() : "Kullanıcı Adı Bulunamadı";
                label2.Text = demirbasMarka!= null ? demirbasMarka.ToString() : "Kullanıcı Adı Bulunamadı";
                label3.Text = demirbasModel != null ? demirbasModel.ToString() : "Kullanıcı Adı Bulunamadı";
                label4.Text = DemirbasUNIQKod != null ? DemirbasUNIQKod.ToString() : "Kullanıcı Adı Bulunamadı";

                textBox1.Text = DemirbasUNIQKod != null ? DemirbasUNIQKod.ToString() : "Kullanıcı Adı Bulunamadı";
            }
        }
    }
}
