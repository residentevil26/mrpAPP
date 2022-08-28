using mrpAccesLibrary.Models;

namespace mrpAccesLibrary
{
    public interface IUrun_is_akisi_data
    {
        Task<List<urun_is_akisi>> urun_is_akisi_getir(int urunid);
        Task<List<urun_is_akisi>> bolum_getir();
        Task<List<urun_is_akisi>> yer_getir();
        Task<List<urun_is_akisi>> olcum_cihaz_getir();
        Task akis_guncelle(urun_is_akisi urun);
        Task<List<urun_is_akisi>> ozellik_getir(int urunid);
        Task akis_kaydet(urun_is_akisi urun);
        Task<List<urun_is_akisi>> process_getir();
    }
}