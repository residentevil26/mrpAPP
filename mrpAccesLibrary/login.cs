using mrpAccesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrpAccesLibrary
{
    public class Login : ILogin
    {
        private readonly ISqlDataAccess _db;
        public Login(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task<List<kullanici>> urunleri_getir(kullanici kullanici)
        {
            string sql = "select adi,soyadi,kuladi,yetkiadi,kulid from kullanici as k inner join yetki as y on y.yetki_id=k.yetki_id where kuladi='" + kullanici.kuladi + "' and kulsifre='" + kullanici.kulsifre + "';";
            return _db.Loaddata<kullanici, dynamic>(sql, new { });
        }
        public List<kullanici> kullanici_getir(kullanici kullanici)
        {
            string sql = "select adi,soyadi,kuladi,yetkiadi,kulid from kullanici as k inner join yetki as y on y.yetki_id=k.yetki_id where kuladi='" + kullanici.kuladi + "' and kulsifre='" + kullanici.kulsifre + "';";
            return _db.veri_getir<kullanici, dynamic>(sql, new { });
        }
        public Task token_kayit(kullanici kullanici)
        {

            string sql = @"insert into anahtarlar(kulid,token,gec_sure) values(@kulid,@token,@gec_sure) ";
            return _db.SaveData(sql, kullanici);
        }

        public List<kullanici> kullanici_getir(int kulid)
        {
            string sql = "select adi,soyadi,kuladi,yetkiadi from kullanici as k inner join yetki as y on y.yetki_id=k.yetki_id where kulid=" + kulid+";";
            return _db.veri_getir<kullanici, dynamic>(sql, new { });
        }

    }
}
