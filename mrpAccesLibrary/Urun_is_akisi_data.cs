using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mrpAccesLibrary.Models;


namespace mrpAccesLibrary
{
    public class Urun_is_akisi_data : IUrun_is_akisi_data
    {
        private readonly ISqlDataAccess _db;


        public Urun_is_akisi_data(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task<List<urun_is_akisi>> urun_is_akisi_getir(int urunid)
        {
            string sql = "select up.process_yerid,up.process_bolumid,up.olcum_cihazid,up.processid,up.urun_processid,p.process_adi,o.urun_ozellik_adi,uk.urun_kart_ozellik_deger,b.process_bolum_adi,c.olcum_cihaz_adi,y.process_yer_adi from urun_process as up inner join urun_kart_ozellik as uk on uk.kart_ozid=up.kart_ozid inner join urun_ozellik as o on o.urun_ozellik_id=uk.urun_ozellikid inner join process as p on p.processid=up.processid inner join olcum_cihaz as c on c.olcum_cihazid=up.olcum_cihazid inner join process_bolum as b on b.process_bolumid=up.process_bolumid inner join process_yer as y on y.process_yerid=up.process_yerid where uk.urunid=" + urunid + ";";
            
            return _db.Loaddata<urun_is_akisi, dynamic>(sql, new { });
        }
        public Task<List<urun_is_akisi>> bolum_getir()
        {
            string sql = "select process_bolum_adi,process_bolumid from process_bolum";
            return _db.Loaddata<urun_is_akisi, dynamic>(sql, new { });
        }
        public Task<List<urun_is_akisi>> process_getir()
        {
            string sql = "SELECT processid,process_adi FROM process";
            return _db.Loaddata<urun_is_akisi, dynamic>(sql, new { });
        }
        public Task<List<urun_is_akisi>> yer_getir()
        {
            string sql = "SELECT process_yerid,process_yer_adi FROM process_yer;";
            return _db.Loaddata<urun_is_akisi, dynamic>(sql, new { });
        }
        public Task<List<urun_is_akisi>> olcum_cihaz_getir()
        {
            string sql = "SELECT olcum_cihazid,olcum_cihaz_adi FROM olcum_cihaz;";
            return _db.Loaddata<urun_is_akisi, dynamic>(sql, new { });
        }
        public Task akis_guncelle(urun_is_akisi urun)
        {

            string sql = @"update urun_process set process_yerid=@process_yerid, process_bolumid=@process_bolumid,olcum_cihazid=@olcum_cihazid where urun_processid=@urun_processid";
            return _db.SaveData(sql, urun);
        }
        public Task<List<urun_is_akisi>> ozellik_getir(int urunid)
        {
            string sql = "select uk.kart_ozid,u.urun_ozellik_adi  from urun_kart_ozellik as uk  inner join urun_ozellik as u on u.urun_ozellik_id=uk.urun_ozellikid where uk.urunid="+urunid+";";
            return _db.Loaddata<urun_is_akisi, dynamic>(sql, new { });
        }
        public Task akis_kaydet(urun_is_akisi urun)
        {

            string sql = @"insert into urun_process(processid,kart_ozid,process_yerid,process_bolumid,olcum_cihazid) values(@processid,@kart_ozid,@process_yerid,@process_bolumid,@olcum_cihazid)";
            return _db.SaveData(sql, urun);
        }

    }
}
