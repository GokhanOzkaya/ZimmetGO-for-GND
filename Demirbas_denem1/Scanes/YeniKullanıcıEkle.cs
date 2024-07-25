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

namespace Demirbas_denem1
{
    public partial class YeniKullanıcıEkle : Form
    {
        public YeniKullanıcıEkle()
        {
            InitializeComponent();
        }


        
        private void button2_Click(object sender, EventArgs e)
        {
            Items items = new Items();
            items.btn_kapat(sender, e);
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            Items items1 = new Items();
            items1.btn_kapat(sender,e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Entities.User newUser = new Entities.User();
                newUser.userName = textBox1.Text;
                newUser.sureName = textBox2.Text;
                newUser.usereMail = textBox3.Text;
                newUser.userStatus = comboBox1.Text.ToString();
                newUser.userStartTime = dateTimePicker1.Value;
                newUser.userCode = textBox6.Text;
                newUser.userUnvan = textBox5.Text;

                UserRepository Repository = new UserRepository();
                Repository.AddNewUser(newUser);
                MessageBox.Show("Kayıt Başarılı");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}\n\nDetaylar: {ex.StackTrace}");
            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataBaseSettings.GridDoldurKullanici(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["KullaniciAdi"].Value.ToString();
                textBox2.Text = row.Cells["KullaniciSoyadi"].Value.ToString();
                textBox3.Text = row.Cells["Email"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["BaslamaTarihi"].Value);
                comboBox1.Text = row.Cells["Statu"].Value.ToString();
                textBox5.Text = row.Cells["Unvan"].Value.ToString();
                textBox6.Text = row.Cells["KullaniciKodu"].Value.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserRepository userRepository = new UserRepository();
            
            DataBaseSettings.GridDoldurYetki(dataGridView1);
        }
    }
}
