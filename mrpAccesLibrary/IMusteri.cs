using mrpAccesLibrary.Models;

namespace mrpAccesLibrary
{
    public interface IMusteri
    {
        Task<List<musteri_getir>> iletisim_getir(int musid);
        Task<List<musteri_getir>> mus_getir();
        Task<List<musteri_getir>> mus_getir(int musid);
        Task mus_guncelle(musteri_getir urun, int musid);
        Task<List<mus_adres>> mus_adres_getir(int musid);
        Task<List<mus_adres>> ilgetir();
        Task<List<mus_adres>> ilcegetir(int ilid);
        Task<List<mus_adres>> semtgetir(int ilceid);
        Task<List<mus_adres>> mahallegetir(int semtid);
        Task mus_adres_guncelle(mus_adres urun, int mus_adres_id);
        Task mus_adres_kaydet(mus_adres urun);
        Task<List<mus_iletisim>> ilet_getir(int musid);
        Task<List<mus_iletisim>> tip_getir();
        Task mus_ilet_guncelle(mus_iletisim urun, int musteri_iletisimid);
        Task mus_ilet_kaydet(mus_iletisim urun);
        Task mus_kaydet(musteri_getir urun);
        Task<List<musteri_getir>> mus_getir(string musadi);
    }
        
}