using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrpAccesLibrary.Models
{
    public class Urun_kart
    {

        public int urunid { get; set; }=0;
        public string urun_adi { get; set; } = "";
        public string urun_kodu { get; set; } = "";
        public string musadi { get; set; } = "";
        public string mus_urunkodu { get; set; } = "";

        public string tedadi { get; set; }   = "";
        public string ted_urunkodu { get; set; }= "";
        public string urun_tip_adi { get; set; } = "";
        public int urun_tipid { get; set; } = 0;
    }
}
