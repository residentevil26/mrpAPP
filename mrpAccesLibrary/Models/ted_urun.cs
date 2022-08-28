using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrpAccesLibrary.Models
{
    public class ted_urun
    {
        public int ted_id { get; set; }
        public string ted_urun_adi { get; set; } = "";
        public string ted_urun_kodu { get; set; } = "";
    }
    public class tedarikci
    {
        public int ted_id { get; set; }
        public string tedadi { get; set; } = "";
        public string tedvergino { get; set; } = "";
    }
}
