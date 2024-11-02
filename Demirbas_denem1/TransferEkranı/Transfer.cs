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
            Entities.SelectedDemirbas selectedDemirbas = new Entities.SelectedDemirbas();
            Entities.SelectedUser selectedUser = new Entities.SelectedUser();
            Entities.OldUser oldUser = new Entities.OldUser();  
            
            if (dataGridView1.CurrentRow != null)
            {
                var selectedRow = dataGridView1.CurrentRow;

                selectedDemirbas = new SelectedDemirbas
                {
                    DemirbasID = selectedRow.Cells["DemirbasID"].Value != DBNull.Value
                                 ? Convert.ToInt32(selectedRow.Cells["DemirbasID"].Value)
                                 : 0, // Varsayılan bir değer verebilirsin

                    DemirbasAdi = selectedRow.Cells["DemirbasAdi"].Value != DBNull.Value
                                  ? selectedRow.Cells["DemirbasAdi"].Value.ToString()
                                  : string.Empty, // Boş bir değer verilebilir

                    DemirbasMarka = selectedRow.Cells["DemirbasMarka"].Value != DBNull.Value
                                    ? selectedRow.Cells["DemirbasMarka"].Value.ToString()
                                    : string.Empty,

                    DemirbasModel = selectedRow.Cells["DemirbasModel"].Value != DBNull.Value
                                    ? selectedRow.Cells["DemirbasModel"].Value.ToString()
                                    : string.Empty,

                    DemirbasUNIQKod = selectedRow.Cells["DemirbasUNIQKod"].Value != DBNull.Value
                                      ? selectedRow.Cells["DemirbasUNIQKod"].Value.ToString()
                                      : string.Empty,

                    DemirbasTuru = selectedRow.Cells["DemirbasTuru"].Value != DBNull.Value
                                   ? selectedRow.Cells["DemirbasTuru"].Value.ToString()
                                   : string.Empty,

                    SatinAlmaTarihi = selectedRow.Cells["SatinAlmaTarihi"].Value != DBNull.Value
                                      ? selectedRow.Cells["SatinAlmaTarihi"].Value as DateTime?
                                      : null,

                    KayitTarihi = selectedRow.Cells["KayitTarihi"].Value != DBNull.Value
                                  ? selectedRow.Cells["KayitTarihi"].Value as DateTime?
                                  : null,

                    Durum = selectedRow.Cells["Durum"].Value != DBNull.Value
                            ? selectedRow.Cells["Durum"].Value.ToString()
                            : string.Empty,

                    KullaniciID = selectedRow.Cells["KullaniciID"].Value != DBNull.Value
                                  ? selectedRow.Cells["KullaniciID"].Value as int?
                                  : null,

                    Aciklama = selectedRow.Cells["Aciklama"].Value != DBNull.Value
                               ? selectedRow.Cells["Aciklama"].Value.ToString()
                               : string.Empty,

                    FirmaKodu = selectedRow.Cells["FirmaKodu"].Value != DBNull.Value
                                ? selectedRow.Cells["FirmaKodu"].Value.ToString()
                                : null, // Varsayılan değer
                };

                if (dataGridView2.CurrentRow != null)
                {
                    var selectedRow2 = dataGridView2.CurrentRow;

                    // Seçili satırdaki hücrelerden User class'ına atamalar
                    selectedUser.KullaniciId = selectedRow2.Cells["KullaniciId"].Value != DBNull.Value
                                               ? Convert.ToInt32(selectedRow2.Cells["KullaniciId"].Value)
                                               : 0; // Varsayılan bir değer verebilirsin

                    selectedUser.userName = selectedRow2.Cells["KullaniciAdi"].Value != DBNull.Value
                                            ? selectedRow2.Cells["KullaniciAdi"].Value.ToString()
                                            : string.Empty;

                    selectedUser.sureName = selectedRow2.Cells["KullaniciSoyadi"].Value != DBNull.Value
                                            ? selectedRow2.Cells["KullaniciSoyadi"].Value.ToString()
                                            : string.Empty;

                    selectedUser.userTitle = selectedRow2.Cells["Unvan"].Value != DBNull.Value
                                             ? selectedRow2.Cells["Unvan"].Value.ToString()
                                             : string.Empty;

                    selectedUser.userDepartment = selectedRow2.Cells["Departman"].Value != DBNull.Value
                                                  ? selectedRow2.Cells["Departman"].Value.ToString()
                                                  : string.Empty;

                    selectedUser.userCode = selectedRow2.Cells["KullaniciKodu"].Value != DBNull.Value
                                            ? selectedRow2.Cells["KullaniciKodu"].Value.ToString()
                                            : string.Empty;

                    selectedUser.usereMail = selectedRow2.Cells["Email"].Value != DBNull.Value
                                             ? selectedRow2.Cells["Email"].Value.ToString()
                                             : string.Empty;

                    selectedUser.userePassword = selectedRow2.Cells["Sifre"].Value != DBNull.Value
                                                 ? selectedRow2.Cells["Sifre"].Value.ToString()
                                                 : string.Empty;

                    selectedUser.userStartTime = selectedRow2.Cells["BaslamaTarihi"].Value != DBNull.Value
                                                 ? Convert.ToDateTime(selectedRow2.Cells["BaslamaTarihi"].Value)
                                                 : DateTime.Now;

                    selectedUser.userStatus = selectedRow2.Cells["Statu"].Value != DBNull.Value
                                              ? selectedRow2.Cells["Statu"].Value.ToString()
                                              : string.Empty;

                    selectedUser.userRole = selectedRow2.Cells["Rol"].Value != DBNull.Value
                                            ? selectedRow2.Cells["Rol"].Value.ToString()
                                            : string.Empty;

                    selectedUser.FirmaKodu = selectedRow2.Cells["FirmaKodu"].Value != DBNull.Value
                                             ? selectedRow2.Cells["FirmaKodu"].Value.ToString()
                                             : string.Empty;

                }

            }


            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                TransferEkranı. ZimmetOnay zimmetOnay = new TransferEkranı. ZimmetOnay(selectedDemirbas,selectedUser,oldUser);
                zimmetOnay.Show();
            }


        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            // Verileri formdaki kontrollerle doldur
            textBox2.Text = selectedRow.Cells["KullaniciID"].Value.ToString();



        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[rowIndex];
            // Verileri formdaki kontrollerle doldur
            textBox1.Text = selectedRow.Cells["KullaniciId"].Value.ToString();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserRepository ur = new UserRepository();

            ur.UpdateDemirbasKullaniciID(demirbasId: Convert.ToInt32(textBox2.Text),yeniKullaniciId: 26, zimmetTarihi: DateTime.Now, iadeTarihi: DateTime.Now);
            DataBaseSettings.GridDoldurDemirbas(dataGridView1);
            DataBaseSettings.GridDoldurKullanici(dataGridView2);

        }


    }
}
