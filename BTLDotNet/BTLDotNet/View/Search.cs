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
    public partial class Search : Form
    {
        public Search(List<int> lsChuong, List<string> lsNoiDung)
        {
            InitializeComponent();

            for (int i = 0; i < lsChuong.Count; i++)
            {
                lsSearch.Items.Add("" + lsChuong[i]);//them vao tu
                lsSearch.Items[i].SubItems.Add(""+lsNoiDung[i].Length);//them vao sai
                lsSearch.Items[i].SubItems.Add(lsNoiDung[i]);//them vao sai
            }

        }
    }
}
