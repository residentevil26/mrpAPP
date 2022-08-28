using System.ComponentModel.DataAnnotations;
using System.Data;
using mrpAccesLibrary;
using mrpAccesLibrary.Models;
using MySql.Data.MySqlClient;

namespace mrp.models
{
    public class urunkodu_validator:ValidationAttribute
    {
        

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            
            List<string> kod;
            string[] urunkodu;
           
                urunkodu=value.ToString().Split('?');
            if (urunkodu[2]=="guncel")
            {
                kod = Loaddata1("select urun_kodu,urun_adi from urun_kart where urun_kodu='" + urunkodu[0] + "'or urun_adi='" + urunkodu[1] + "';");
                if (kod.Count == 0)
                {
                    return null;
                }
                else if (kod[0]==urunkodu[0]||kod[1]==urunkodu[1])
                {
                    return null;
                }
                  
                
               
                
            }
            else if (urunkodu[2] == "kaydet")
            {
                kod = Loaddata1("select urun_kodu,urun_adi from urun_kart where urun_kodu='" + urunkodu[0] + "'or urun_adi='" + urunkodu[1] + "';");
                if(kod.Count==0)
                {
                    return null;
                }
            }
            
           
            return new ValidationResult("Bu ürünkoduyla veya ürün adıyla kaydedilmiş bir ürün var");
        }
        public List< string> Loaddata1(string sql)
        {
            MySqlConnection baglantim = new MySqlConnection("server=127.0.0.1; user id=root; password=12345; database= yasselcuk_mrp;");

            MySqlCommand cmd = new MySqlCommand(sql, baglantim);
            if (baglantim.State == ConnectionState.Closed)
            {
                baglantim.Open();

            }
           List< string> s=new List<string>() ;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                s.Add ( dr.GetValue(0).ToString());
                s.Add(dr.GetValue(1).ToString());   
            }
            if (baglantim.State == ConnectionState.Open)
            {
                baglantim.Close();
            }
            return s;
        }
    }
}
