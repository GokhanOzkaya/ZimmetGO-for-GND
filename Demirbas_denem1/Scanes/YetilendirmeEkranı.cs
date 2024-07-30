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
    public partial class YetilendirmeEkranı : Form
    {
        public YetilendirmeEkranı()
        {
            InitializeComponent();
        }

        private void YetilendirmeEkranı_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Items items = new Items();
            items.btn_kapat(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells["YetkiKodu"].Value.ToString();
            textBox2.Text = row.Cells["Yetki"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserRepository userRepository = new UserRepository();
            userRepository.AddNewYetki(yetkiAdi:textBox1.Text);
         
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            UserRepository userRepo = new UserRepository();
            userRepo.DeleteYetki(Convert.ToInt32(textBox1.Text));

        }

        //UserRepository userRepository = new UserRepository();
        //userRepository.DeleteUser(Convert.ToInt32( textBox1.Text));
        //DataBaseSettings.GridDoldurKullanici(dataGridView1);
    }
}
