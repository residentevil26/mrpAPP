using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrpAccesLibrary.Models
{
    public class urun_is_akisi
    {
        public int urun_processid { get; set; } = 0;
        public int processid { get; set; } = 0;
        public string process_adi { get; set; } = "";
        public string urun_ozellik_adi { get; set; } = "";
        public string urun_kart_ozellik_deger { get; set; } = "";
        public string process_bolum_adi { get; set; } = "";
        public string olcum_cihaz_adi { get; set; } = "";
        public string process_yer_adi { get; set; } = "";
        public int process_bolumid { get; set; } = 0;
        public int process_yerid { get; set; } = 0;
        public int olcum_cihazid { get; set; } = 0;
        public int kart_ozid { get; set; } = 0;

    }
}
