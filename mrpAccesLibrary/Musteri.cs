
using mrpAccesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrpAccesLibrary
{
    public class Musteri : IMusteri
    {
        private readonly ISqlDataAccess _db;
        public Musteri(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task<List<musteri_getir>> mus_getir()
        {
            string sql = "select musid,musadi,mus_vergino from musteri;";
            return _db.Loaddata<musteri_getir, dynamic>(sql, new { });
        }
        public Task<List<musteri_getir>> mus_getir(int musid)
        {
            string sql = "select musid,musadi,mus_vergino from musteri where musid=" + musid + ";";
            return _db.Loaddata<musteri_getir, dynamic>(sql, new { });
        }
        public Task<List<musteri_getir>> mus_getir(string musadi)
        {
            string sql = "select musid,musadi,mus_vergino from musteri where musadi=" + musadi + ";";
            return _db.Loaddata<musteri_getir, dynamic>(sql, new { });
        }
        public Task<List<musteri_getir>> iletisim_getir(int musid)
        {
            string sql = "SELECT i.iletisim_tipid,i.iletisim_bilgi,t.iletesim_tip_adi FROM musteri_iletisim as i inner join iletism_tip as t on t.iletesim_tipid=i.iletisim_tipid where musid=" + musid + ";";
            return _db.Loaddata<musteri_getir, dynamic>(sql, new { });
        }
        public Task mus_guncelle(musteri_getir urun, int musid)
        {

            string sql = @"UPDATE musteri SET musadi=@musadi,mus_vergino=@mus_vergino where musid =" + musid + ";";
            return _db.SaveData(sql, urun);
        }
        public Task mus_kaydet(musteri_getir urun)
        {

            string sql = @"insert into musteri (musadi,mus_vergino,kul_sirketid) values(@musadi,@mus_vergino,1);";
            return _db.SaveData(sql, urun);
        }
        public Task<List<mus_adres>> mus_adres_getir(int musid)
        {
            string sql = "SELECT adres,mus.musadi,mus_adres_id,il.il_adi,i.ilce_adi,s.semt_adi,m.mahalle_adi FROM mus_adres as mu inner join iller as il on il.ilid=mu.ilid inner join ilceler as i on i.ilceid=mu.ilceid inner join semtler as s on s.semtid=mu.semtid inner join mahalleler as m on m.mahalleid=mu.mahelleid inner join musteri as mus on mus.musid=mu.musid where mu.musid=" +musid + ";";
            
            return _db.Loaddata<mus_adres, dynamic>(sql, new { });
        }
        public Task<List<mus_adres>> ilgetir()
        {
            string sql = "Select il_adi,ilid from iller;";
            return _db.Loaddata<mus_adres, dynamic>(sql, new { });
        }
        public Task<List<mus_adres>> ilcegetir(int ilid)
        {
            string sql = "Select ilce_adi,ilceid from ilceler where ilid="+ilid+";";
            return _db.Loaddata<mus_adres, dynamic>(sql, new { });
        }
        public Task<List<mus_adres>> semtgetir(int ilceid)
        {
            string sql = "Select semt_adi,semtid from semtler where ilceid=" + ilceid + ";";
            return _db.Loaddata<mus_adres, dynamic>(sql, new { });
        }
        public Task<List<mus_adres>> mahallegetir(int semtid)
        {
            string sql = "Select mahalle_adi,mahalleid from mahalleler where semtid=" + semtid + ";";
            return _db.Loaddata<mus_adres, dynamic>(sql, new { });
        }
        public Task mus_adres_guncelle(mus_adres urun, int mus_adres_id)
        {

            string sql = @"UPDATE mus_adres SET ilid=@ilid,ilceid=@ilceid, musid=@musid,semtid=@semtid,mahelleid=@mahalleid,adres=@adres where mus_adres_id =" + mus_adres_id + ";";
            return _db.SaveData(sql, urun);
        }
        public Task mus_adres_kaydet(mus_adres urun)
        {

            string sql = @"insert into mus_adres (ilid,ilceid,musid,semtid,mahelleid,adres) values (@ilid,@ilceid,@musid,@semtid,@mahalleid,@adres);";
            return _db.SaveData(sql, urun);
        }

        public Task<List<mus_iletisim>> ilet_getir(int musid)
        {
            string sql = "SELECT musteri_iletisimid,iletesim_tipid,iletesim_tip_adi,iletisim_bilgi FROM musteri_iletisim as i inner join musteri as m on m.musid=i.musid inner join iletism_tip as t on iletesim_tipid=i.iletisim_tipid where m.musid=" + musid + ";";
            return _db.Loaddata<mus_iletisim, dynamic>(sql, new { });
        }
        public Task<List<mus_iletisim>> tip_getir()
        {
            string sql = "SELECT iletesim_tipid,iletesim_tip_adi FROM iletism_tip;";
            return _db.Loaddata<mus_iletisim, dynamic>(sql, new { });
        }
        public Task mus_ilet_guncelle(mus_iletisim urun, int musteri_iletisimid)
        {

            string sql = @"UPDATE musteri_iletisim SET iletisim_tipid=@iletesim_tipid,iletisim_bilgi=@iletisim_bilgi where musteri_iletisimid =" + musteri_iletisimid + ";";
            return _db.SaveData(sql, urun);
        }
        public Task mus_ilet_kaydet(mus_iletisim urun )
        {

            string sql = @"insert into musteri_iletisim  (iletisim_tipid,iletisim_bilgi,musid) values(@iletesim_tipid,@iletisim_bilgi,@musid) ;";
            return _db.SaveData(sql, urun);
        }


    }
}
