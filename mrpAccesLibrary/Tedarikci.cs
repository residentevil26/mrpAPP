using mrpAccesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrpAccesLibrary
{
    public class Tedarikci : ITedarikci
    {
        private readonly ISqlDataAccess _db;


        public Tedarikci(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task<List<tedarikci_getir>> ted_getir()
        {
            string sql = "select tedid,tedadi,tedvergino from tedarikci;";
            return _db.Loaddata<tedarikci_getir, dynamic>(sql, new { });
        }
        public Task<List<tedarikci_getir>> ted_getir(int tedid)
        {
            string sql = "select tedid,tedadi,tedvergino from tedarikci where tedid=" + tedid + ";";
            return _db.Loaddata<tedarikci_getir, dynamic>(sql, new { });
        }
        public Task<List<tedarikci_getir>> ted_getir(string tedadi)
        {
            string sql = "select tedid,tedadi,ted_vergino from tedatirikci where musadi=" + tedadi + ";";
            return _db.Loaddata<tedarikci_getir, dynamic>(sql, new { });
        }
        public Task ted_guncelle(tedarikci_getir urun, int tedid)
        {

            string sql = @"UPDATE tedarikci SET tedadi=@musadi,ted_vergino=@mus_vergino where musid =" + tedid + ";";
            return _db.SaveData(sql, urun);
        }
    }
}
