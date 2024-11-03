using Demirbas_denem1.Database;
using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;


namespace Demirbas_denem1.Scanes
{
    public partial class Hareketler : MetroForm
    {
        public Hareketler()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Items items1 = new Items();
            items1.btn_kapat(sender, e);
        }

        private void Hareketler_Load(object sender, EventArgs e)
        {
            CustomDGV customDGV = new CustomDGV();
            customDGV.CustomizeDataGridView(dataGridView1);
            DataBaseFilters.ZimmetGemisLisetele(dataGridView: dataGridView1);
            
            // CustomDGV sınıfının bir örneğini oluşturun
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseFilters.SearchInZimmetGecmisi(dataGridView:dataGridView1,baslangicTarihi:dateTimePicker1.Value,bitisTarihi:dateTimePicker2.Value,filtreTuru:comboBox1.Text);
        }
    }
}
