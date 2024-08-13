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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Demirbas_denem1.Scanes
{
    public partial class Transfer : Form
    {
        public Transfer()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Items items1 = new Items();
            items1.btn_kapat(sender, e);
        }

        private void Transfer_Load(object sender, EventArgs e)
        {
            DataBaseSettings.GridDoldurDemirbas(dataGridView1);
            DataBaseSettings.GridDoldurKullanici(dataGridView2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserRepository ur =new UserRepository();

            ur.UpdateDemirbasKullaniciID(demirbasId:Convert.ToInt32(textBox2.Text),kullaniciId: Convert.ToInt32(textBox1.Text));
            DataBaseSettings.GridDoldurDemirbas(dataGridView1);
            DataBaseSettings.GridDoldurKullanici(dataGridView2);
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            // Verileri formdaki kontrollerle doldur
            textBox2.Text = selectedRow.Cells["DemirbasID"].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[rowIndex];
            // Verileri formdaki kontrollerle doldur
            textBox1.Text = selectedRow.Cells["KullaniciId"].Value.ToString();
        }
    }
}
