using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BTLDotNet.View
{
    public partial class ThemDL : Form
    {
        public ThemDL()
        {
            InitializeComponent();
            Model.BoTruyen boTruyen = Model.Database.GetDsTruyen();
            List<Model.Truyen> list = boTruyen.GetDsTruyen();
            txtTruyen.DataSource = list;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int idTruyen = ((Model.Truyen)txtTruyen.SelectedItem).IdTruyen;
                int idChuong = Int32.Parse(txtChuong.Text);
                string noiDung = txtNoiDung.Text;
                Model.Database.AddChuong(idChuong, idTruyen, noiDung);
                MessageBox.Show("Thêm nội dung thành công", "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int idTruyen = ((Model.Truyen)txtTruyen.SelectedItem).IdTruyen;
                int idChuong = Int32.Parse(txtChuong.Text);
                string noiDung = txtNoiDung.Text;
                string sql = "UPDATE chuong SET noidung = N'" + noiDung + "' WHERE idchuong = " + idChuong + " AND idtruyen = " + idTruyen;
                Model.Database.Update(sql);
                MessageBox.Show("Sửa nội dung thành công", "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int idTruyen = ((Model.Truyen)txtTruyen.SelectedItem).IdTruyen;
                int idChuong = Int32.Parse(txtChuong.Text);
                string sql = "DELETE FROM chuong WHERE idchuong = " + idChuong + " AND idtruyen = " + idTruyen;
                Model.Database.Delete(sql);
                MessageBox.Show("Xóa thành công", "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
            this.Close();    
        }
    }
}
