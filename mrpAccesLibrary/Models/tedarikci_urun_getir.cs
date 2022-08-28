using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrpAccesLibrary.Models
{
    public class tedarikci_urun_getir
    {
        public int urunid { get; set; }
        public int ted_urunid { get; set; }
        public int tedid { get; set; }

        public string tedadi { get; set; } = "";
        public string ted_urunadi { get; set; } = "";
        public string ted_urunkodu { get; set; } = "";
        public int kul_sirketid { get; set; } = 1;
    }
}
