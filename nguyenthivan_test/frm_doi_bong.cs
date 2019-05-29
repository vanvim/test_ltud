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
    public partial class frm_doi_bong : Form
    {
        public frm_doi_bong()
        {
            InitializeComponent();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void load(object sender, EventArgs e)
        {
            string sql = "SELECT * from DOIBONG";
            grdview.DataSource = null;
            grdview.DataSource = ket_noi_csdl.laydl(sql, "DOIBONG");
        }
        private void HienThi_DL()
        {
            txt_madb.DataBindings.Clear();
            txt_madb.DataBindings.Add("Text", grdview.DataSource, "MADB");
            txt_tendb.DataBindings.Clear();
            txt_tendb.DataBindings.Add("Text", grdview.DataSource, "TENDB");
            txt_sandb.DataBindings.Clear();
            txt_sandb.DataBindings.Add("Text", grdview.DataSource, "SANDB");
            

        }
        private void btn_taomoi_Click(object sender, EventArgs e)
        {
            txt_madb.Text = "";
            txt_sandb.Text = "";
            txt_tendb.Text = "";
        }

        private void btn_chen_Click(object sender, EventArgs e)
        {
            try
            {
                string a = txt_madb.Text;
                string b = txt_tendb.Text;
                string c = txt_sandb.Text;
                

                ket_noi_csdl.chendl(a, b, c);
                load(null, null);
            }
            catch (OleDbException Exception)
            {
                String a = Convert.ToString(Exception.ErrorCode);
                MessageBox.Show(a);

            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            ket_noi_csdl.XoaDL(txt_madb.Text);
            load(null, null);
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            ket_noi_csdl.LuuDL(txt_tendb.Text,txt_sandb.Text, txt_madb.Text);
            load(null, null);
            HienThi_DL();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            frm_timkiem f1 = new frm_timkiem();
            f1.Show();
        }

        private void frm_doi_bong_Load(object sender, EventArgs e)
        {
            load(null, null);
            HienThi_DL();
        }
    }
}
