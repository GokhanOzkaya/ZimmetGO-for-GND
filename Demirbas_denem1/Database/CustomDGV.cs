using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demirbas_denem1.Database
{
    public class CustomDGV
    {
        public void CustomizeDataGridView(DataGridView dataGridView)
        {
            // Font ayarları
            Font font = new Font("Verdana", 9);
            dataGridView.DefaultCellStyle.Font = font;

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSlateGray;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView.GridColor = Color.LightGray;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.RowHeadersVisible = false;

            dataGridView.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;

            // AutoSizeColumnsMode'u ayarla
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Tüm hücrelerin içeriğine göre otomatik boyutlandır

            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.ColumnHeadersHeight = 35;

            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
   

   

            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.RowTemplate.Height = (int)(font.Height * 2.0);

            // Yazıların sarmalanması için
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Yazıları sar
            }
        }


    }

}
