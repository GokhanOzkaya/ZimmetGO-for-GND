using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demirbas_denem1
{
    public class Items
    {
        public void btn_kapat(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Form form = button.FindForm();
                form.Close();
            }
        }
    }
}
