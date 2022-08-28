using mrpAccesLibrary.Models;

namespace mrpAccesLibrary
{
    public interface IUrun_kart_data
    {
        Task kart_guncelle(urun_kart_ana urun, int urunid);
        Task<List<Urun_kart>> urunleri_getir();
        Task<List<Urun_kart>> urunleri_getir(int urunid);
        Task<List<urun_tip>> urun_tip_getir();
        Task kart_kaydet(urun_kart_ana urun);
        Task<List<Urun_kart>> urunleri_getir(string urunkodu);
        
    }
}