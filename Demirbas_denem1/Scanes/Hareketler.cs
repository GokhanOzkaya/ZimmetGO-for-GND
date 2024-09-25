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
            DataBaseFilters.ZimmetGemisLisetele(dataGridView:dataGridView1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBaseFilters.ZimmetGemisLisetele(dataGridView: dataGridView1);

        }
    }
}
