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
                Entities.User newUser = new User();
                newUser.userName = textBox1.Text;
                newUser.sureName = textBox2.Text;
                newUser.userTitle = comboBox2.Text;
                newUser.userDepartment = textBox4.Text;
                newUser.userCode = textBox6.Text;
                newUser.userePassword = textBox7.Text;
                newUser.usereMail = textBox3.Text;
                newUser.userStartTime = dateTimePicker1.Value;
                newUser.userStatus = comboBox1.Text; 
                newUser.userRole = comboBox3.Text;   
            

                UserRepository Repository = new UserRepository();
                Repository.AddNewUser(newUser);
                MessageBox.Show("Kayıt başarıyla tamamlandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBaseSettings.GridDoldurKullanici(dataGridView1);

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
                comboBox2.Text = row.Cells["Unvan"].Value.ToString();
                textBox4.Text = row.Cells["Departman"].Value.ToString();
                textBox6.Text = row.Cells["KullaniciKodu"].Value.ToString();
                textBox7.Text = row.Cells["Sifre"].Value.ToString();
                textBox3.Text = row.Cells["Email"].Value.ToString();
                comboBox1.Text = row.Cells["Statu"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["BaslamaTarihi"].Value);
                comboBox1.Text = row.Cells["Statu"].Value.ToString();
                comboBox3.Text = row.Cells["Rol"].Value.ToString();
                textBox8.Text = row.Cells["KullaniciId"].Value.ToString();
           

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }

            
        }
        private void button5_Click(object sender, EventArgs e)
        {

        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void YeniKullanıcıEkle_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now; 
            DataBaseSettings.GridDoldurKullanici(dataGridView1);
            List<Role> roles = DataBaseSettings.LoadYetkiData();

            foreach (var role in roles)
            {
                comboBox3.Items.Add(role.yetki);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            // Seçili hücreyi kontrol et
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // İlk seçili hücreyi al
                DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];
                DataGridViewRow row = selectedCell.OwningRow;

                // Hücre değerlerini al
                string ad = row.Cells["KullaniciAdi"].Value?.ToString();
                string soyad = row.Cells["KullaniciSoyadi"].Value?.ToString();
                int ID = Convert.ToInt32(row.Cells["KullaniciId"].Value);
                string statu = row.Cells["Statu"].Value?.ToString();


                // Boş değer kontrolü
                if (ad == null || soyad == null)
                {
                    MessageBox.Show("Kullanıcı bilgileri eksik.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (statu == "PASİF")
                {
                    MessageBox.Show("Bu kullanıcı zaten PASİF durumda", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Uyarı mesajı
                DialogResult result = MessageBox.Show(
                    $"{ad} {soyad} bu kullanıcı pasife çekilecek. Emin misiniz?",
                    "Uyarı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    // Kullanıcı 'Evet' seçtiğinde yapılacak işlemler
                    // Örneğin, kullanıcıyı pasif hale getirme işlemi burada yapılabilir
                    UserRepository userRepository = new UserRepository();
                    userRepository.statuGuncelle(ID);
                }
                else
                {
                    // Kullanıcı 'Hayır' seçtiğinde yapılacak işlemler
                    // Eğer 'Hayır' seçildiyse, herhangi bir işlem yapılmaz
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir hücre seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            DataBaseSettings.GridDoldurKullanici(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
                Entities.User newUser = new User();
                newUser.KullaniciId = Convert.ToInt32(textBox8.Text);
                newUser.userName = textBox1.Text;
                newUser.sureName = textBox2.Text;
                newUser.userTitle = comboBox2.Text;
                newUser.userDepartment = textBox4.Text;
                newUser.userCode = textBox6.Text;
                newUser.userePassword = textBox7.Text;
                newUser.usereMail = textBox3.Text;
                newUser.userStartTime = dateTimePicker1.Value;
                newUser.userStatus = comboBox1.Text;
                newUser.userRole = comboBox3.Text;


                UserRepository Repository = new UserRepository();
                Repository.UpdateUser(newUser);
        
            DataBaseSettings.GridDoldurKullanici(dataGridView1);


        }
    }
}

