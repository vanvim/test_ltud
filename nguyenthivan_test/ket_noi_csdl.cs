using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace nguyenthivan_test
{
    class ket_noi_csdl
    {
        public static OleDbConnection cnn;
        public static DataTable tb;
        private static OleDbCommand cmd;
        public static OleDbDataAdapter ada;

        public static void ketnoi()
        {
            string chuoi = "Provider = Microsoft.Jet.OLEDB.4.0 ;" +
                "Data Source =" + Application.StartupPath + @"\CSDL_TEST.mdb;";
            cnn = new OleDbConnection(chuoi);
            cnn.Open();
        }
        public static void huy_ketnoi()
        {
            cnn.Close();
            cnn.Dispose();
        }

        public static DataTable laydl(string sql, string tablename)
        {
            ketnoi();
            DataTable ds = new DataTable();
            cmd = new OleDbCommand(sql, cnn);
            ada = new OleDbDataAdapter(cmd);
            ada.Fill(ds);
            huy_ketnoi();
            return ds;
        }
        public static void chendl(string txtmadb, string txttendb, string txtsansb)
        {
            ketnoi();
            tb = new DataTable("DOIBONG");
            OleDbDataAdapter data = new OleDbDataAdapter("select * from DOIBONG", cnn);
            data.Fill(tb);
            //insert dữ liệu
            DataRow r = tb.NewRow();
            r["MADB"] = txtmadb;
            r["TENDB"] = txttendb;
            r["SANDB"] = txtsansb;
            tb.Rows.Add(r);

            // tạo đối tượng
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into DOIBONG values(@madb,@tendb,@sandb)";
            cmd.Parameters.Add("@madb", OleDbType.VarChar, 20, "MADB");
            cmd.Parameters.Add("@tendb", OleDbType.VarChar, 20, "TENDB");
            cmd.Parameters.Add("@sansb", OleDbType.VarChar, 20, "SANDB");
            //Insert dữ liệu vào nguồn
            ada.InsertCommand = cmd;
            ada.Update(tb);

            //Hủy đối tượng
            cmd.Dispose();
            cmd = null;
            huy_ketnoi();
        }
        public static void XoaDL(string txtxoa)
        {
            //Tạo kết nối
            ketnoi();
            //Tạo Adpater
            OleDbDataAdapter ada = new OleDbDataAdapter("select * from DOIBONG", cnn);
            tb = new DataTable();
            ada.Fill(tb);
            //Xây dựng commandBuilder
            new OleDbCommandBuilder(ada);
            //Delete Record cần delete trong datatable

            DataRow[] objRow = tb.Select("MADB = '" + txtxoa + "'");
            objRow[0].Delete();
            //Delete dữ liệu nguồn
            ada.Update(tb);
            //Hủy đối tượng
            ada.Dispose();
            ada = null;
            tb.Dispose();
            tb = null;
            huy_ketnoi();
        }

        public static void LuuDL(string txttendb, string txtsandb, string txtmadb)
        {
            //Tạo kết nối tới file Access
            ketnoi();
            //Tạo đối tượng command
            OleDbCommand luu = new OleDbCommand();
            luu.Connection = cnn;
            luu.CommandType = CommandType.Text;
            luu.CommandText = "update DOIBONG " +
                                     "Set TENDB=@TENDB, SANDB=@SANDB " +
                                     "Where MADB=@MADB";

            luu.Parameters.Add("@TENDB", OleDbType.VarChar).Value = txttendb;
            luu.Parameters.Add("@SANDB", OleDbType.VarChar).Value = txtsandb;
            luu.Parameters.Add("@MADB", OleDbType.VarChar).Value = txtmadb;

            luu.ExecuteNonQuery();
            //Hủy đối tượng
            luu.Dispose();
            luu = null;
            huy_ketnoi();
        }
    }
}
