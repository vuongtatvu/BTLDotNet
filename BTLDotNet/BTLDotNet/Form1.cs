using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLDotNet
{
    public partial class Form1 : Form
    {
        private int idTruyen;
        private int idChuong;
        public Form1()
        {
            InitializeComponent();
            Model.BoTruyen boTruyen = Model.Database.GetDsTruyen();
            List<Model.Truyen> list = boTruyen.GetDsTruyen();
            txtTenTruyen.DataSource = list;
        }

        private void btnThemDL_Click(object sender, EventArgs e)
        {
            View.ThemDL form2 = new View.ThemDL();
            this.Hide();
            form2.ShowDialog();
            this.Close();
        }

        private void txtTenTruyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNoiDung.Text = "";
            Model.Truyen truyen = (Model.Truyen)txtTenTruyen.SelectedItem;
            idTruyen = truyen.IdTruyen;
            List<Model.Chuong> list = truyen.GetDsChuong();
            txtChuong.DataSource = list;
        }

        private void txtChuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.Chuong chuong = (Model.Chuong)txtChuong.SelectedItem;
            idChuong = chuong.IdChuong;
            txtNoiDung.Text = "\t" + chuong.NoiDung.Replace("\n\n", "\n\n\t") + "\n";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Model.Truyen truyen = (Model.Truyen)txtTenTruyen.SelectedItem;
            List<Model.Chuong> dsChuong = truyen.GetDsChuong();

            //Lấy chuỗi search
            string search = txtSearch.Text;
            if (search.Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập chuỗi cần tìm");
                return;
            }

            search = search.Trim();
            search = search.ToLower();
            string[] wordSearch = Controller.NoiDung.TachTu(search);
            search = "";
            foreach (string s in wordSearch)
            {
                if (s != "" && s != " ")
                    search += " " + s;
            }

            //Xử lý chuỗi chỉ còn từ thường và cách nhau bằng dấu _
            search = search.Trim();
            //Mảng các từ cần tìm
            wordSearch = search.Split(' ');
            search = " " + search + " ";

            int idtmp = 0;
            int demViTri = 0;
            int indexDau = 0;
            int indexCuoi = 0;
            string txtChuoiCanTim = "";
            string txtNoiDungtmp;

            List<string> lsSearch = new List<string>();
            List<int> lsChuong = new List<int>();
            List<int> lsIndex = new List<int>();

            foreach (Model.Chuong chuong in dsChuong)
            {
                List<String> arrKiemTra = new List<string>();
                txtNoiDungtmp = "\t" + chuong.NoiDung.Replace("\n\n", "\n\n\t") + "\n";
                string[] noiDung = Controller.NoiDung.TachTu(txtNoiDungtmp);
                string txttam = " " + txtNoiDungtmp.ToLower() + " ";

                //tim tu co chua trong chuoi search cho vang mang
                foreach (string tu in noiDung)
                {
                    string tu1 = tu.ToLower();
                    foreach (string s in wordSearch)
                    {
                        if (s.Equals(tu1))
                        {
                            arrKiemTra.Add(tu1);
                            break;
                        }
                    }
                }

                string xau = String.Join(" ", arrKiemTra.ToArray());
                xau = " " + xau + " ";

                int tam = -1;
                int[] vitricactu = new int[wordSearch.Length];

                while (1 == 1)
                {

                    //Tìm vị trí tìm thấy đầu tiên của từng từ trong search theo thứ tự
                    for (int i = 0; i < vitricactu.Length; i++)
                    {
                        tam = xau.IndexOf(" " + wordSearch[i] + " ", tam + 1);
                        vitricactu[i] = tam;

                    }

                    //Kiểm tra nếu không có thì sang chương khác
                    foreach (int x in vitricactu)
                    {
                        if (x == -1)
                        {
                            goto A;
                        }
                    }

                    int tam1;
                    //Dồn về gần nhau nhất
                    for (int i = vitricactu.Length - 2; i >= 0; )
                    {
                        tam1 = xau.IndexOf(" " + wordSearch[i] + " ", vitricactu[i] + 1);

                        if (tam1 < vitricactu[i + 1] && tam1 > -1)
                        {
                            vitricactu[i] = tam1;
                        }
                        else
                        {
                            i--;
                        }
                    }

                    //Tìm index đầu và cuối
                    tam1 = -1;
                    while (1 == 1)
                    {
                        tam1 = xau.IndexOf(" " + wordSearch[0] + " ", tam1 + 1);
                        if (tam1 < vitricactu[0])
                        {
                            demViTri++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    demViTri++;

                    tam1 = -1;
                    while (1 == 1)
                    {
                        tam1 = txttam.IndexOf(wordSearch[0], tam1 + 1);

                        if (Controller.NoiDung.BatDauKhongLaChuCai(txttam, tam1))
                        {
                            if (Controller.NoiDung.KetThucKhongLaChuCai(txttam, wordSearch[0], tam1))
                            {
                                demViTri--;
                            }
                        }


                        if (demViTri == 0)
                        {
                            indexDau = tam1;
                            if (wordSearch.Length == 1)
                            {
                                indexCuoi = indexDau;
                            }
                            else
                            {
                                indexCuoi = indexDau;
                                for (int i = 1; i < wordSearch.Length; i++)
                                {
                                    indexCuoi = txttam.IndexOf(wordSearch[i], indexCuoi + 1);
                                }
                            }
                            break;
                        }
                    }
                    txtChuoiCanTim = txtNoiDungtmp.Substring(indexDau - 1, indexCuoi - indexDau + wordSearch[wordSearch.Length - 1].Length);
                    lsSearch.Add(txtChuoiCanTim);
                    lsIndex.Add(indexDau);
                    lsChuong.Add(idtmp + 1);
                }

            A: idtmp++;
            }

            if (lsSearch.Count == 0)
            {
                MessageBox.Show("Không có chương nào có nội dung cần tìm?");
                return;
            }

            int min = lsSearch[0].Length;
            for (int i = 1; i < lsSearch.Count; i++)
            {
                if (min > lsSearch[i].Length)
                {
                    min = lsSearch[i].Length;
                }
            }

            for (int i = 0; i < lsSearch.Count; i++)
            {
                if (min == lsSearch[i].Length)
                {
                    indexDau = lsIndex[i];
                    idtmp = lsChuong[i] - 1;
                    break;
                }
            }

            txtChuong.SetSelected(idtmp, true);
            idChuong = idtmp + 1;

            //Hiển thị
            try
            {
                int wordStartIndex = indexDau - 2;
                foreach (string x in wordSearch)
                {
                    while (1 == 1)
                    {
                        wordStartIndex = txtNoiDung.Find(x, wordStartIndex + 1, RichTextBoxFinds.None);
                        if (Controller.NoiDung.BatDauKhongLaChuCai(txtNoiDung.Text, wordStartIndex))
                        {
                            if (Controller.NoiDung.KetThucKhongLaChuCai(txtNoiDung.Text, x, wordStartIndex))
                            {
                                txtNoiDung.SelectionStart = wordStartIndex;
                                txtNoiDung.SelectionBackColor = Color.Red;
                                txtNoiDung.ScrollToCaret();
                                break;
                            }
                        }
                    }
                }
                new View.Search(lsChuong, lsSearch).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnKTChinhTa_Click(object sender, EventArgs e)
        {
            new View.ChinhTa(idTruyen, idChuong).ShowDialog();
        }

        private void btnLight_Click(object sender, EventArgs e)
        {
            if (txtNoiDung.BackColor == Color.White)
            {
                txtNoiDung.BackColor = Color.Silver;
                txtNoiDung.ForeColor = Color.Black;
            }
            else if (txtNoiDung.BackColor == Color.Silver)
            {
                txtNoiDung.BackColor = Color.Pink;
                txtNoiDung.ForeColor = Color.Black;
            }
            else if (txtNoiDung.BackColor == Color.Pink)
            {
                txtNoiDung.BackColor = Color.Yellow;
                txtNoiDung.ForeColor = Color.Black;
            }
            else if (txtNoiDung.BackColor == Color.Yellow)
            {
                txtNoiDung.BackColor = Color.Blue;
                txtNoiDung.ForeColor = Color.White;
            }
            else if (txtNoiDung.BackColor == Color.Blue)
            {
                txtNoiDung.BackColor = Color.Green;
                txtNoiDung.ForeColor = Color.White;
            }
            else
            {
                txtNoiDung.BackColor = Color.White;
                txtNoiDung.ForeColor = Color.Black;
            }
            
        }
    }
}