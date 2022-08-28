using mrpAccesLibrary;

using mrpAccesLibrary.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using Blazored.LocalStorage;
using System.Text;
using System.Threading;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace mrp.Controllers
{
    public class giris : Igiris
    {
        private ILogin _log;
        
       
        public giris(ILogin log)
        {
            _log = log;
            
        }
       
        public  List<kullanici> LoginAsync(kullanici kullanici)
        {
           
            List<kullanici> user = new List<kullanici>();
            
            user = _log.kullanici_getir(kullanici);

            return user;



        }
        public List<kullanici> kullanici_getir(int kulid)
        {
            List<kullanici> user = new List<kullanici>();
            user = _log.kullanici_getir(kulid);
            return user;

        }


        private  string GenerateRefreshToken()
        {
            string token = ""; 
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                token = Convert.ToBase64String(randomNumber);

            }

                return token;
        }
       
    }
    public class JWTSettings
    {
        public string SecretKey { get; set; }
    }

    public class auth : AuthenticationStateProvider
    {
        private Igiris _user;

       
        public ILocalStorageService _ls { get; }
        public auth(Igiris user,ILocalStorageService ls)
        {
            _user= user;
            _ls = ls;
           
        }

       

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsIdentity identity;
            try
            {
                
            List<kullanici> user = new List<kullanici>();
            string kulid = await _ls.GetItemAsync<string>("kulid");
                int kulid1=Convert.ToInt32(kulid);
            user= _user.kullanici_getir(kulid1);
            if (user.Count!=0)
            {
                identity = new ClaimsIdentity(new[]
                               {
                                    new Claim(ClaimTypes.Name, user[0].kuladi),
                                    new Claim(ClaimTypes.Role, user[0].yetkiadi),
                                   

                                });
               
            }
            else
            {
                identity = new ClaimsIdentity();
            }
            var claimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch (Exception)
            {

                identity = new ClaimsIdentity();
                var claimsPrincipal = new ClaimsPrincipal(identity);
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
           

            
        }
        public async Task kullanicigiris( kullanici user)
        {
           await _ls.SetItemAsync("kulid", user.kulid);
            ClaimsIdentity identity;
            var claimsIdentity = new ClaimsIdentity();
            identity = new ClaimsIdentity(new[]
                               {
                               new Claim(ClaimTypes.Name,user.kulid.ToString()),
                               new Claim(ClaimTypes.Role,user.yetkiadi)
                                    
                                });
            var claimsPrincipal = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        
    }
}
