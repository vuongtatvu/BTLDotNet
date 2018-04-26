using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLDotNet.Model
{
    class Chuong
    {
        private int idChuong;
        private int idTruyen;
        private string noiDung;

        public int IdChuong
        {
            get
            {
                return idChuong;
            }
            set
            {
                idChuong = value;
            }
        }

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

        public string NoiDung
        {
            get
            {
                return noiDung;
            }
            set
            {
                noiDung = value;
            }
        }

        public override string ToString()
        {
            return "Chương "+ IdChuong;
        } 
    }
}
