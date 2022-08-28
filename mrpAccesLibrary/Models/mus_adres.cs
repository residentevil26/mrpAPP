using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrpAccesLibrary.Models
{
    public class mus_adres
    {
        public int mus_adres_id { get; set; } = 0;
        public int ilid { get; set; } = 0;
        public int ilceid { get; set; } = 0;
        public int semtid { get; set; } = 0;
        public int mahalleid { get; set; } = 0;
        public int musid { get; set; } = 0;
        public string adres { get; set; } = "";
        public string il_adi { get; set; } = "";
        public string ilce_adi { get; set; } = "";
        public string semt_adi { get; set; } = "";
        public string mahalle_adi { get; set; } = "";
        public string musadi { get; set; } = "";
    }
}
