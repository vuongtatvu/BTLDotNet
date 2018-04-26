using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLDotNet.Model
{
    class BoTruyen
    {
        private List<Truyen> dsTruyen = new List<Truyen>();

        public List<Truyen> GetDsTruyen()
        {
            return dsTruyen;
        }

        public void AddDsTruyen(Truyen truyen)
        {
            dsTruyen.Add(truyen);
        }
    }
}
