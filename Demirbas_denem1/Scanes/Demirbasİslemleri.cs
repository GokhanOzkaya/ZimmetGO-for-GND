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
    public partial class Demirbasİslemleri : Form
    {
        public Demirbasİslemleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Items items = new Items();
            items.btn_kapat(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Demirbas db = new Demirbas();   
                db.DemirbasID= Convert.ToInt32( textBox1.Text);
                db.DemirbasAdi = textBox2.Text;
                db.DemirbasTuru = comboBox2.Text;
                db.SatinAlmaTarihi = dateTimePicker1.Value;
                db.KayitTarihi= dateTimePicker2.Value;
                db.Durum = comboBox2.Text;
                db.Aciklama = richTextBox1.Text;


                UserRepository Repository = new UserRepository();
                Repository.AddNewDemirbas(db);
                MessageBox.Show("Kayıt başarıyla tamamlandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBaseSettings.GridDoldurKullanici(dataGridView1);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}\n\nDetaylar: {ex.StackTrace}");
            }
        }
    }
}
