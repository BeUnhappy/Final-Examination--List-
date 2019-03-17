using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ZBinformation
    {
        public string ZBId { get; set; }
        public string ZBName { get; set; }
        public decimal ZBPrice { get; set; }
        public string ZBImage { get; set; }
        public int ZBType { get; set; }
        public string Xianshi
        {
            get
            {
                return this.ZBType == 1 ? "重型武器" : this.ZBType == 2 ? "轻型武器" : "其他";
            }
        }
    }
}
