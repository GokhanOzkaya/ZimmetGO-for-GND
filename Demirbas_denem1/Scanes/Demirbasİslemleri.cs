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
using MetroFramework.Forms;
using MetroFramework.Controls;
namespace Demirbas_denem1.Scanes
{
    public partial class Demirbasİslemleri : MetroForm
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
           
            Demirbas db = new Demirbas();
            db.DemirbasAdi = textBox2.Text;
            db.DemirbasMarka = textBox3.Text;
            db.DemirbasModel = textBox4.Text;   
            db.DemirbasUNIQKod =textBox5.Text;
            db.DemirbasTuru = comboBox1.Text;
            db.SatinAlmaTarihi = dateTimePicker1.Value;
            db.KayitTarihi= dateTimePicker2.Value;
            db.KullaniciID = 1;    
            db.Durum = comboBox2.Text;
            db.Aciklama = richTextBox1.Text;
            db.FirmaKodu = comboBox3.Text.ToString();


            UserRepository Repository = new UserRepository();
            Repository.AddNewDemirbas(db);
            MessageBox.Show("Kayıt başarıyla tamamlandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataBaseSettings.GridDoldurDemirbas(dataGridView1);

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Demirbas db = new Demirbas();
            db.DemirbasModel= textBox4.Text;
            db.DemirbasMarka = textBox3.Text;
            db.DemirbasID = Convert.ToInt32( textBox1.Text);
            db.DemirbasAdi = textBox2.Text;
            db.DemirbasTuru = comboBox2.Text;
            db.SatinAlmaTarihi = dateTimePicker1.Value;
            db.KayitTarihi = dateTimePicker2.Value;
            db.KullaniciID = 10;
            db.Durum = comboBox2.Text;
            db.Aciklama = richTextBox1.Text;
            db.FirmaKodu =comboBox3.Text.ToString();

            UserRepository Repository = new UserRepository();
            Repository.UpdateDemirbas(db);
         
            MessageBox.Show("Kayıt başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataBaseSettings.GridDoldurDemirbas(dataGridView1);
        }

        private void Demirbasİslemleri_Load(object sender, EventArgs e)
        {
            CustomDGV customDGV = new CustomDGV();
            customDGV.CustomizeDataGridView(dataGridView1);
            DataBaseSettings.GridDoldurDemirbas(dataGridView1);
            dateTimePicker1.Value = DateTime.Now; 
            dateTimePicker2.Value = DateTime.Now; 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçili satırın indeksini al
            int rowIndex = e.RowIndex;

            // Geçerli satırı kontrol et
            if (rowIndex >= 0)
            {
                // Seçili satırdan verileri al
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
                Demirbas db = new Demirbas();
                // Verileri formdaki kontrollerle doldur
                textBox1.Text = selectedRow.Cells["DemirbasId"].Value.ToString();
                textBox3.Text = selectedRow.Cells["DemirbasMarka"].Value.ToString();
                textBox4.Text = selectedRow.Cells["DemirbasModel"].Value.ToString();
                textBox5.Text = selectedRow.Cells["DemirbasUNIQKod"].Value.ToString();
                comboBox2.Text = selectedRow.Cells["Durum"].Value.ToString();
                textBox2.Text = selectedRow.Cells["DemirbasAdi"].Value.ToString();
                comboBox1.Text = selectedRow.Cells["DemirbasTuru"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(selectedRow.Cells["SatinAlmaTarihi"].Value);
                dateTimePicker2.Value = Convert.ToDateTime(selectedRow.Cells["KayitTarihi"].Value);
                richTextBox1.Text = selectedRow.Cells["Aciklama"].Value.ToString();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Demirbas db = new Demirbas();
            db.DemirbasID = Convert.ToInt32(textBox1.Text);
            db.Durum = comboBox2.Text;
  
            UserRepository Repository = new UserRepository();
            Repository.DemirbasHurdayaCikar(db.DemirbasID);
            DataBaseSettings.GridDoldurDemirbas(dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataBaseSettings.SearchInDemirbaslar(textBox6.Text,dataGridView1);
        }
    }
}
