using System.ComponentModel.DataAnnotations;

namespace mrp.models
{
    public class musteri
    {
        public int musid { get; set; }
        [Required(ErrorMessage ="Müşteri Adı Zorunludur")]
        [StringLength(50, ErrorMessage ="Müşteri Adı 50 Karakterden Fazla olamaz")]
        public string musadi { get; set; }
        [Required(ErrorMessage ="vergi numarası Zorunludur")]
        [StringLength(10)]
        [MinLength(10)]
        public string mus_vergi_no { get; set; }
    }
}
