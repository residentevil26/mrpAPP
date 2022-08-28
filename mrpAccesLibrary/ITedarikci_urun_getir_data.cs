using mrpAccesLibrary.Models;

namespace mrpAccesLibrary
{
    public interface ITedarikci_urun_getir_data
    {
        Task<List<tedarikci_urun_getir>> Ted_urun_getir(int urunid);
        Task<List<tedarikci_getir>> Ted_getir();
        Task ted_guncelle(tedarikci_urun_getir urun, int ted_urunid);
        Task ted_urun_kaydet(tedarikci_urun_getir urun, int urunid);
        Task<List<tedarikci_urun_getir>> Ted_urun_getir_isim(tedarikci_urun_getir urun);
        Task<List<tedarikci_urun_getir>> Ted_urun_getir_kod(tedarikci_urun_getir urun);
        Task<List<tedarikci_getir>> Ted_getir(int tedid);
    }
}