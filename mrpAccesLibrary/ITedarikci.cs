using mrpAccesLibrary.Models;

namespace mrpAccesLibrary
{
    public interface ITedarikci
    {
        Task<List<tedarikci_getir>> ted_getir();
        Task<List<tedarikci_getir>> ted_getir(int tedid);
        Task<List<tedarikci_getir>> ted_getir(string tedadi);
        Task ted_guncelle(tedarikci_getir urun, int tedid);
    }
}