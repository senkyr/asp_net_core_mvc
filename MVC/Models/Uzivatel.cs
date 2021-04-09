using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Uzivatel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Jmeno { get; set; }
        [Required]
        public string Heslo { get; set; }
    }
}
