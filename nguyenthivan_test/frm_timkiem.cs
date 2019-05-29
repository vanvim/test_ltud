using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace nguyenthivan_test
{
    public partial class frm_timkiem : Form
    {
        public frm_timkiem()
        {
            InitializeComponent();
            ket_noi_csdl.ketnoi();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            ket_noi_csdl.ketnoi();
            dataGridView1.DataSource = null;
            string sql1 = "Select * from DOIBONG where MADB ='"+txt_madoibong.Text +"'";
            dataGridView1.DataSource = ket_noi_csdl.laydl(sql1, "DOIBONG");
        }
    }
}
