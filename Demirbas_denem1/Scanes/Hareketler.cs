using Demirbas_denem1.Database;
using System;
using System.Windows.Forms;

namespace Demirbas_denem1.Scanes
{
    public partial class Hareketler : Form
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
            DataBaseFilters.ZimmetGemisLisetele(null,dataGridView1);

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
    }
}
