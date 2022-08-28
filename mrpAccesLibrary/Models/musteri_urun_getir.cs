using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrpAccesLibrary.Models
{
    public class musteri_urun_getir
    {
        public int mus_urunid { get; set; }
        public int musid  { get; set; }

        public string musadi { get; set; } = "";
        public string mus_urunadi { get; set; } = "";
        public string mus_urunkodu { get; set; } = "";
        public int kul_sirket_id { get; set; } = 1;
    }
}
