using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrpAccesLibrary.Models
{
    public class mus_iletisim
    {
        public int musteri_iletisimid { get; set; } = 0;
        public int iletesim_tipid { get; set; } = 0;
        public string iletesim_tip_adi { get; set; } = "";
        public int musid { get; set; } = 0;
        public string iletisim_bilgi { get; set; } = "";
    }
   
}
