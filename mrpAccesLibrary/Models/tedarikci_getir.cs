using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrpAccesLibrary.Models
{
    public class tedarikci_getir
    {
        public int tedid { get; set; } = 0;
        public string tedadi { get; set; } = "";
        public string tedvergino { get; set; } = "";
        public int kul_sirket_id { get; set; } = 0;

        public int iletisim_tipid { get; set; } = 0;
        public string iletisim_bilgi { get; set; } = "";
        public string iletsim_tip_adi { get; set; } = "";
        public string adi { get; set; } = "";
        public string soyadi { get; set; } = "";
        public string telefonu { get; set; } = "";
        public string email { get; set; } = "";
    }
}
