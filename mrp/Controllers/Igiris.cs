using Microsoft.AspNetCore.Components.Authorization;
using mrpAccesLibrary.Models;

namespace mrp.Controllers
{
    public interface Igiris
    {



        
        List<kullanici> kullanici_getir(int kulid);
        List<kullanici> LoginAsync(kullanici kullanici);
    }
}