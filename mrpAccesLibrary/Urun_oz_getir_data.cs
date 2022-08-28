using mrpAccesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrpAccesLibrary
{
    public class Urun_oz_getir_data : IUrun_oz_getir_data
    {
        private readonly ISqlDataAccess _db;


        public Urun_oz_getir_data(ISqlDataAccess db)
        {
            _db = db;
        }
        public async Task<List<urun_oz_getir>> urunleri_getir(int urunid)
        {
            string sql = "SELECT  uk.kart_ozid,uk.urun_ozellikid, o.urun_ozellik_adi||'('||(select  birimadi from birimler where birimid=CAST (o.urun_ozellik_birim AS INTEGER))||')' as urun_oz_deger,uk.urun_kart_ozellik_deger FROM(( urun_kart_ozellik as uk inner join urun_kart as u on u.urunid=uk.urunid) inner join urun_ozellik as o on o.urun_ozellik_id=uk.urun_ozellikid) where u.urunid="+urunid+";";
            return await _db.Loaddata<urun_oz_getir, dynamic>(sql, new { });
        }
        public async Task<List<urun_oz_getir>> urunleri_getir()
        {
            string sql = "SELECT uk.kart_ozid,uk.urun_ozellikid,concat( o.urun_ozellik_adi,' (',(select  birimadi from birimler where birimid=CAST (o.urun_ozellik_birim AS INTEGER)),')') urun_oz_deger,uk.urun_kart_ozellik_deger FROM(( urun_kart_ozellik as uk inner join urun_kart as u on u.urunid=uk.urunid) inner join urun_ozellik as o on o.urun_ozellik_id=uk.urun_ozellikid) ;";

            return await _db.Loaddata<urun_oz_getir, dynamic>(sql, new { });
        }
        public Task urun_ozellik_guncel(urun_oz_getir urun,int kart_ozid) 
        {
            string sql = @"UPDATE urun_kart_ozellik SET urun_ozellikid=@urun_ozellik_id,urun_kart_ozellik_deger=@urun_kart_ozellik_deger,birimid=(select u.urun_ozellik_birim from urun_ozellik as u where u.urun_ozellik_id =" + urun.urun_ozellikid+") where kart_ozid="+kart_ozid+";";

            return _db.SaveData(sql, urun);
        }
        public Task urun_ozellik_kaydet(urun_oz_getir urun,int urunid)
        {
            string sql = @"insert into urun_kart_ozellik(urun_ozellikid,urun_kart_ozellik_deger,birimid,urunid) 
values(@urun_ozellikid,@urun_kart_ozellik_deger,CAST ((select u.urun_ozellik_birim from urun_ozellik as u where u.urun_ozellik_id =@urun_ozellikid) as integer)," + urunid+"); ";
            return _db.SaveData(sql, urun);
        }
    }
}
