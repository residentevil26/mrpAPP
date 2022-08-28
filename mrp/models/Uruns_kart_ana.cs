using System.ComponentModel.DataAnnotations;

namespace mrp.models
{
    public class Uruns_kart_ana
    {
        

       

        [Required]
        [StringLength(50,ErrorMessage ="Ürün Adı 50 Karakterden fazla olamaz")]
        [MinLength(5,ErrorMessage ="Ürün Adı 5 karakterden az olamaz")]


        public string urun_adi { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "Ürün kodu 50 Karakterden fazla olamaz")]
        [MinLength(5, ErrorMessage = "Ürün kodu 5 karakterden az olamaz")]
        
        public string urun_kodu { get; set; }

        [Required]
        public int urun_tipid { get; set; }
        
        [Required]
        [urunkodu_validator]
        public string  ad_kod { get; set; }
    }
}
