using mrpAccesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrpAccesLibrary
{
    public class Musteri_urun_getir_data : IMusteri_urun_getir_data
    {
        private readonly ISqlDataAccess _db;
        public Musteri_urun_getir_data(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task<List<musteri_urun_getir>> Mus_urun_getir(int urunid)
        {
            string sql = "select mu.mus_urunid,m.musid,m.musadi,mu.mus_urunadi,mu.mus_urunkodu from  urun_kart as u inner join mus_ted_kart as mut on mut.urunid=u.urunid inner join musteri_urun as mu on mu.mus_urunid=mut.mus_urunid inner join musteri as m on m.musid=mu.musid where u.urunid="+urunid+" order by m.musadi ;";
            return _db.Loaddata<musteri_urun_getir, dynamic>(sql, new { });
        }
        public Task<List<musteri_getir>> mus_getir()
        {
            string sql = "SELECT musid,musadi,mus_vergino FROM musteri;";
            return _db.Loaddata<musteri_getir, dynamic>(sql, new { });
        }
        public Task mus_guncelle(musteri_urun_getir urun, int mus_urunid)
        {

            string sql = @"UPDATE musteri_urun SET mus_urunadi=@mus_urunadi,mus_urunkodu=@mus_urunkodu, musid=@musid where mus_urunid =" +mus_urunid+ ";";
            return _db.SaveData(sql, urun);
        }
        public Task mus_urun_kaydet(musteri_urun_getir urun,int urunid)
        {
            string sql = @"insert into musteri_urun(musid,mus_urunkodu,mus_urunadi,kul_sirket_id) values(@musid,@mus_urunkodu,@mus_urunadi,@kul_sirket_id);";
            sql = sql + "insert into mus_ted_kart(urunid,mus_urunid)values(" + urunid + "," + "(select mus_urunid from musteri_urun where mus_urunkodu='" + urun.mus_urunkodu + "' and musid=" + urun.musid + "));"; ;
            return _db.SaveData(sql, urun);
        }
        public Task<List<musteri_urun_getir>> mus_urun_getir(musteri_urun_getir urun)
        {
            string sql = @"SELECT musid,mus_urunkodu,mus_urunadi from musteri_urun where musid=" + urun.musid + " and (mus_urunkodu='" + urun.mus_urunkodu + "' or mus_urunadi='" + urun.mus_urunadi + "');";
            return _db.Loaddata<musteri_urun_getir, dynamic>(sql, new { });
        }
        public Task<List<musteri_urun_getir>> mus_urun_getir_guncel(musteri_urun_getir urun)
        {
            string sql = @"SELECT musid,mus_urunkodu,mus_urunadi from musteri_urun where musid=" + urun.musid + " and (mus_urunkodu='" + urun.mus_urunkodu + "' or mus_urunadi='" + urun.mus_urunadi + "');";
            return _db.Loaddata<musteri_urun_getir, dynamic>(sql, new { });
        }
    }
}
