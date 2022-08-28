using mrpAccesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrpAccesLibrary
{
    public class Tedarikci_urun_getir_data : ITedarikci_urun_getir_data
    {
        private readonly ISqlDataAccess _db;


        public Tedarikci_urun_getir_data(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task<List<tedarikci_urun_getir>> Ted_urun_getir(int urunid)
        {
            string sql = "select tu.ted_urunid,t.tedid,t.tedadi,tu.ted_urunkodu,tu.ted_urunadi from urun_kart as u inner join mus_ted_kart as mut on u.urunid=mut.urunid inner join " +
                "tedarikci_urun as tu on tu.ted_urunid=mut.ted_urunid inner join tedarikci as t on t.tedid=tu.tedid where u.urunid=" + urunid + " order by t.tedadi ;";
            return _db.Loaddata<tedarikci_urun_getir, dynamic>(sql, new { });
        }
        public Task<List<tedarikci_getir>> Ted_getir()
        {
            string sql = "SELECT tedid,tedadi,tedvergino FROM tedarikci;";
            return _db.Loaddata<tedarikci_getir, dynamic>(sql, new { });
        }
        public Task<List<tedarikci_getir>> Ted_getir(int tedid)
        {
            string sql = "SELECT tedid,tedadi,tedvergino FROM tedarikci where tedid !="+tedid+";";
            return _db.Loaddata<tedarikci_getir, dynamic>(sql, new { });
        }
        public Task ted_guncelle(tedarikci_urun_getir urun, int ted_urunid)
        {

            string sql = @"UPDATE tedarikci_urun SET ted_urunadi=@ted_urunadi,ted_urunkodu=@ted_urunkodu, tedid=@tedid where ted_urunid =" + ted_urunid + ";";
            return _db.SaveData(sql, urun);
        }
        public Task ted_urun_kaydet(tedarikci_urun_getir urun,int urunid)
        {

            string sql = @"insert into tedarikci_urun(tedid,ted_urunkodu,ted_urunadi,kul_sirketid) values(@tedid,@ted_urunkodu,@ted_urunadi,@kul_sirketid);";
            sql = sql + "insert into mus_ted_kart(urunid,ted_urunid)values("+urunid+","+"(select ted_urunid from tedarikci_urun where ted_urunkodu='"+urun.ted_urunkodu+"' and tedid="+urun.tedid+"));";
             return _db.SaveData(sql, urun);
            
           
        }

        public Task<List<tedarikci_urun_getir>> Ted_urun_getir_isim(tedarikci_urun_getir urun)
        {
            string sql = @"SELECT t.ted_urunid,m.urunid ,tedid,ted_urunkodu,ted_urunadi from tedarikci_urun as t inner join mus_ted_kart as m on m.ted_urunid=t.ted_urunid where tedid=" + urun.tedid +  " and ted_urunadi='" + urun.ted_urunadi + "';";
            return  _db.Loaddata<tedarikci_urun_getir, dynamic>(sql, new { });
        }
        public Task<List<tedarikci_urun_getir>> Ted_urun_getir_kod(tedarikci_urun_getir urun)
        {
            string sql = @"SELECT t.ted_urunid,m.urunid,tedid,ted_urunkodu,ted_urunadi from tedarikci_urun as t inner join mus_ted_kart as m on m.ted_urunid=t.ted_urunid  where tedid=" + urun.tedid+" and ted_urunkodu='"+urun.ted_urunkodu+"' ;";
            return _db.Loaddata<tedarikci_urun_getir, dynamic>(sql, new { });
        }



    }

}
