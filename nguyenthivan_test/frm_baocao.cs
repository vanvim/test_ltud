using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nguyenthivan_test
{
    public partial class frm_baocao : Form
    {
        public frm_baocao()
        {
            InitializeComponent();
        }

        private void frm_baocao_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.DOIBONG' table. You can move, or remove it, as needed.
            this.DOIBONGTableAdapter.Fill(this.DataSet1.DOIBONG);

            this.reportViewer1.RefreshReport();
        }
    }
}
