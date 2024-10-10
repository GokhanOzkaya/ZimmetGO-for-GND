using Demirbas_denem1.Database;
using Demirbas_denem1.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Demirbas_denem1.Scanes
{
    public partial class Transfer : Form
    {

        private int _xKullanicilarKullaniciId;

        private int _xDemirbaslarKullaniciId;

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

            TransferEkranı.ZimmetOnay zimmetOnay = new TransferEkranı.ZimmetOnay();
            zimmetOnay.Show();
            UserRepository ur = new UserRepository();
            try
            {
                if (_xKullanicilarKullaniciId == _xDemirbaslarKullaniciId)
                {
                    MessageBox.Show($"Seçtiğiniz Malzeme Zaten Seçtiğiniz Kullanıcı Üzerine Zimmetli", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    ur.UpdateDemirbasKullaniciID(demirbasId: Convert.ToInt32(textBox2.Text), kullaniciId: Convert.ToInt32(textBox1.Text), zimmetTarihi: DateTime.Now, iadeTarihi: DateTime.Now, zimmetAlınanKisiID: _xKullanicilarKullaniciId);
                    DataBaseSettings.GridDoldurDemirbas(dataGridView1);
                    DataBaseSettings.GridDoldurKullanici(dataGridView2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }


        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            // Verileri formdaki kontrollerle doldur
            textBox2.Text = selectedRow.Cells["KullaniciID"].Value.ToString();


            _xKullanicilarKullaniciId = Convert.ToInt32(selectedRow.Cells["KullaniciID"].Value);

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[rowIndex];
            // Verileri formdaki kontrollerle doldur
            textBox1.Text = selectedRow.Cells["KullaniciId"].Value.ToString();
            _xDemirbaslarKullaniciId = Convert.ToInt32(selectedRow.Cells["KullaniciID"].Value);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserRepository ur = new UserRepository();

            ur.UpdateDemirbasKullaniciID(demirbasId: Convert.ToInt32(textBox2.Text), kullaniciId: 26, zimmetTarihi: DateTime.Now, iadeTarihi: DateTime.Now);
            DataBaseSettings.GridDoldurDemirbas(dataGridView1);
            DataBaseSettings.GridDoldurKullanici(dataGridView2);

        }


    }
}
