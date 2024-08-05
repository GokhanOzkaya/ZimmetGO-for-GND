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
    public partial class KullaniciZimmetleri : Form
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
            DataBaseFilters.DatabaseFilterUser(varaible:textBox1.Text,dataGridView1);  
            
        }

        private void KullaniciZimmetleri_Load(object sender, EventArgs e)
        {
            DataBaseSettings.GridDoldurKullanici(dataGridView1);
        }
    }
}
