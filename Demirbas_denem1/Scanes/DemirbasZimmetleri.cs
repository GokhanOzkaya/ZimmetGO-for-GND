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
    }
}
