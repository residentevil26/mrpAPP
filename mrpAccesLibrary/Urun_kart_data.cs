using mrpAccesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrpAccesLibrary
{
    public class Urun_kart_data : IUrun_kart_data
    {
        private readonly ISqlDataAccess _db;


        public Urun_kart_data(ISqlDataAccess db)
        {
            _db = db;
        }

        

        public Task<List<Urun_kart>> urunleri_getir()
        {
            string sql = "select u.urunid,u.urun_adi,u.urun_kodu,m.musadi,mu.mus_urunkodu,t.tedadi,tu.ted_urunkodu,ut.urun_tip_adi,u.urun_tipid from urun_kart as u left join mus_ted_kart as k on k.urunid=u.urunid left join musteri_urun as mu on mu.mus_urunid=k.mus_urunid left join tedarikci_urun as tu on tu.ted_urunid=k.ted_urunid left join tedarikci as t on t.tedid=tu.tedid left join musteri as m on m.musid=mu.musid inner join urun_tip as ut on ut.urun_tipid=u.urun_tipid order by u.urunid;";
            return _db.Loaddata<Urun_kart, dynamic>(sql, new { });
        }
        public async Task<List<Urun_kart>> urunleri_getir(int urunid)
        {
            string sql = "select u.urunid,u.urun_adi,u.urun_kodu,m.musadi,mu.mus_urunkodu,t.tedadi,tu.ted_urunkodu,ut.urun_tip_adi,u.urun_tipid from urun_kart as u left join mus_ted_kart as k on k.urunid=u.urunid left join musteri_urun as mu on mu.mus_urunid=k.mus_urunid left join tedarikci_urun as tu on tu.ted_urunid=k.ted_urunid left join tedarikci as t on t.tedid=tu.tedid left join musteri as m on m.musid=mu.musid inner join urun_tip as ut on ut.urun_tipid=u.urun_tipid where u.urunid= " + urunid + " order by u.urunid;";
            return await _db.Loaddata<Urun_kart, dynamic>(sql, new { });
        }
        public Task kart_guncelle(urun_kart_ana urun, int urunid)
        {

            string sql = @"UPDATE urun_kart SET urun_adi=@urun_adi,urun_kodu=@urun_kodu, urun_tipid=@urun_tipid where urunid =" + urunid + ";";
            return _db.SaveData(sql, urun);
        }
        public Task kart_kaydet(urun_kart_ana urun)
        {

            string sql = @"insert into urun_kart (urun_adi,urun_kodu, urun_tipid,kul_sirketid) values(@urun_adi,@urun_kodu, @urun_tipid,1);";
            return _db.SaveData(sql, urun);
        }

        public Task<List<urun_tip>> urun_tip_getir()
        {
            string sql = "SELECT urun_tipid,urun_tip_adi FROM urun_tip;";
            return _db.Loaddata<urun_tip, dynamic>(sql, new { });
        }
        public async Task<List<Urun_kart>> urunleri_getir(string urunkodu)
        {
            string sql = "select urunid from urun_kart where urun_kodu='"+urunkodu+"';";
            return await _db.Loaddata<Urun_kart, dynamic>(sql, new { });
        }
        
        


    }
}
