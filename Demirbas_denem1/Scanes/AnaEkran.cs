using Demirbas_denem1.Database;
using Demirbas_denem1.Entities;
using Demirbas_denem1.Scanes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using MetroFramework.Forms;
using MetroFramework.Controls;
namespace Demirbas_denem1
{
    public partial class AnaEkran : MetroForm
    {
        public AnaEkran(string role)
        {
            InitializeComponent();

                label1.Text = CurrentUser.User.userName;
                label2.Text = CurrentUser.User.usereMail;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Items items = new Items();
            items.btn_kapat(sender,e);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YeniKullanıcıEkle yeniKullanıcıEkle = new YeniKullanıcıEkle();
            yeniKullanıcıEkle.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
       
        }

        private void button4_Click(object sender, EventArgs e)
        {
            YetilendirmeEkranı ye = new YetilendirmeEkranı();
            ye.Show();  
        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            label4.Text = CurrentUser.User.userName;    
            label5.Text = CurrentUser.User.sureName;    
            label6.Text = CurrentUser.User.userTitle;    
            label7.Text = CurrentUser.User.userDepartment;    
            label8.Text = CurrentUser.User.userCode;    
            label9.Text = CurrentUser.User.usereMail;    
            label10.Text = CurrentUser.User.userePassword;    
            dateTimePicker1.Value = CurrentUser.User.userStartTime;    
            label11.Text = CurrentUser.User.userStatus;    
            label12.Text = CurrentUser.User.userRole;    
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void AnaEkran_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
