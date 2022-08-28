using mrpAccesLibrary.Models;

namespace mrpAccesLibrary
{
    public interface IUrun_oz_getir_data
    {
        Task<List<urun_oz_getir>> urunleri_getir(int urunid);
        Task<List<urun_oz_getir>> urunleri_getir();
        Task urun_ozellik_guncel(urun_oz_getir urun, int kart_ozid);
        Task urun_ozellik_kaydet(urun_oz_getir urun,int urunid);
    }
}