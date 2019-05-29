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
    public partial class frm_dangnhap : Form
    {
        public frm_dangnhap()
        {
            InitializeComponent();
            ket_noi_csdl.ketnoi();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            ket_noi_csdl.ketnoi();
            string sql = "select COUNT(*) from NGUOISD where TENTN = @TEN and TENMK = @PWD";
            OleDbCommand cmd = new OleDbCommand(sql, ket_noi_csdl.cnn);
            cmd.Parameters.AddWithValue("@TEN",txt_name.Text);
            cmd.Parameters.AddWithValue("@PWD", txtpwd.Text);

            this.Hide();
            if (Convert.ToBoolean(cmd.ExecuteScalar()))
            {
                MessageBox.Show("bạn đã đăng nhập thành công");
                frm_doi_bong f2 = new frm_doi_bong();
                f2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("vui lòng xem lại tến đăng nhập hoặc mật khẩu");
            }
            ket_noi_csdl.cnn.Close();
        }
    }
}
