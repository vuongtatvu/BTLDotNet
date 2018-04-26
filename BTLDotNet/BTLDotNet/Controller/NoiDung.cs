using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLDotNet.Controller
{
    class NoiDung
    {
       
        public static string[] TachTu(string noidung)
        {
            char[] kitu = new char[] {
                ' ', ',', '.', ';', '(', ')', '[', ']', '{', '}', '/',
                '\\', '\'', '"', '-', '~', '!', '?', '*', '\n', '\t', 
                ':', '“', '”', '`', '@', '#', '$', '%', '^', '&', '+',
                '=', '|', '_', '>', '<', '‘', '’'};
            return noidung.Split(kitu);
        }

        public static bool KetThucKhongLaChuCai(string xau, string tuKiemTra, int vitri)
        {
            char[] kitu = new char[] {
                ' ', ',', '.', ';', '(', ')', '[', ']', '{', '}', '/',
                '\\', '\'', '"', '-', '~', '!', '?', '*', '\n', '\t', 
                ':', '“', '”', '`', '@', '#', '$', '%', '^', '&', '+',
                '=', '|', '_', '>', '<', '‘', '’'};
            foreach (char x in kitu)
            {
                if (x.Equals(xau[vitri + tuKiemTra.Length]))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool BatDauKhongLaChuCai(string xau, int vitri)
        {
            char[] kitu = new char[] {
                ' ', ',', '.', ';', '(', ')', '[', ']', '{', '}', '/',
                '\\', '\'', '"', '-', '~', '!', '?', '*', '\n', '\t', 
                ':', '“', '”', '`', '@', '#', '$', '%', '^', '&', '+',
                '=', '|', '_', '>', '<', '‘', '’'};
            foreach (char x in kitu)
            {
                if (x.Equals(xau[vitri - 1]))
                {
                    return true;
                }
            }
            return false;
        }

        public static string PhuAmDau(string x)
        {
            string phuAmDau = "";
            string phuAm = "qrtpsdghklxcvbnmđ";
            for (int i = 0; i < x.Length; i++)
            {
                if (!phuAm.Contains(x[i]))
                {
                    break;
                }
                phuAmDau += x[i];
            }
                return phuAmDau;
        }

        public static string Van(string x)
        {
            int dem = 0;
            string van = "";
            string phuAm = "qrtpsdghklxcvbnmđ";
            for (int i = 0; i < x.Length; i++)
            {
                if (!phuAm.Contains(x[i]))
                {
                    break;
                }
                dem++;
            }
            van = x.Substring(dem, x.Length - dem);
            return van;
        }
    }
}
