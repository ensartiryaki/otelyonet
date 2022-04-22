using System.ComponentModel.DataAnnotations;

namespace otelyonet.Models
{
    public class Cinsiyet
    {
        [Key]
        public int CinsiyetID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"),Display(Name = "Cinsiyet Adı"),StringLength(12, MinimumLength = 3, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string CinsiyetAdı { get; set; }
    }
}