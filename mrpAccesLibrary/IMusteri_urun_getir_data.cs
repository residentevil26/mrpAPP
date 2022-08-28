using mrpAccesLibrary.Models;

namespace mrpAccesLibrary
{
    public interface IMusteri_urun_getir_data
    {
        Task<List<musteri_urun_getir>> Mus_urun_getir(int urunid);
        Task<List<musteri_getir>> mus_getir();
        Task mus_guncelle(musteri_urun_getir urun, int mus_urunid);
        Task mus_urun_kaydet(musteri_urun_getir urun, int urunid);
        Task<List<musteri_urun_getir>> mus_urun_getir(musteri_urun_getir urun);
        Task<List<musteri_urun_getir>> mus_urun_getir_guncel(musteri_urun_getir urun);
    }
}