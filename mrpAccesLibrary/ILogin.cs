using mrpAccesLibrary.Models;

namespace mrpAccesLibrary
{
    public interface ILogin
    {
        Task<List<kullanici>> urunleri_getir(kullanici kullanici);
        List<kullanici> kullanici_getir(kullanici kullanici);
        Task token_kayit(kullanici kullanici);
        List<kullanici> kullanici_getir(int kulid);
    }
}