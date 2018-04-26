using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLDotNet.Model
{
    class Truyen
    {
        private int idTruyen;
        private string tenTruyen;
        private List<Chuong> dsChuong = new List<Chuong>();

        public int IdTruyen
        {
            get
            {
                return idTruyen;
            }
            set
            {
                idTruyen = value;
            }
        }

        public string TenTruyen
        {
            get
            {
                return tenTruyen;
            }
            set
            {
                tenTruyen = value;
            }
        }

        public List<Chuong> GetDsChuong()
        {
            return dsChuong;
        }

        public void AddDsChuong(Chuong chuong)
        {
            dsChuong.Add(chuong);
        }

        public override string ToString()
        {
            return IdTruyen + ". " + TenTruyen;
        }
    }
}
