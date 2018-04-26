using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLDotNet.View
{
    public partial class ChinhTa : Form
    {

        public ChinhTa(int idTruyen, int idChuong)
        {
            InitializeComponent();
            HienThiDanhSach(idTruyen, idChuong);
        }

        public void HienThiDanhSach(int idTruyen, int idChuong)
        {
            string[] arrNoiDung = Controller.NoiDung.TachTu(Model.Database.GetNoiDungChuong(idTruyen, idChuong));
            List<String> noiDung = new List<string>();
            foreach (string x in arrNoiDung)
            {
                if (!x.Equals(""))
                {
                    noiDung.Add(x);
                }
            }
            Controller.Rule[] allRulles = {new Controller.Rule1(),new Controller.Rule2(),
                                          new Controller.Rule3(),new Controller.Rule4(),
                                          new Controller.Rule5(),new Controller.Rule6(),
                                          new Controller.Rule7(),new Controller.Rule8(),
                                          new Controller.Rule9(),new Controller.Rule10(),
                                          new Controller.Rule11(),new Controller.Rule12(),
                                          new Controller.Rule13(),new Controller.Rule14(),
                                          new Controller.Rule15(),new Controller.Rule16(),
                                          new Controller.Rule17(),new Controller.Rule18(),
                                          new Controller.Rule19(),new Controller.Rule20()};
            int add = 0;
            foreach (string x in noiDung)
            {
                for (int j = 0; j < allRulles.Length; j++)
                {
                    if (!allRulles[j].IsValid(x.ToLower()))
                    {
                        lsChinhTa.Items.Add(x);//them vao tu
                        lsChinhTa.Items[add].SubItems.Add(allRulles[j].Explain());//them vao sai
                        add++;
                        break;
                    }
                }

            }
        }
    }
}
