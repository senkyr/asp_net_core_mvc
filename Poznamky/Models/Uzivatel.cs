using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspPoznamky.Models
{
    public class Uzivatel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Jmeno { get; set; }
        [Required]
        public string Heslo { get; set; }
        
        public virtual List<Poznamka> Poznamky { get; set; }

        public bool NemaPoznamky => Poznamky == null || Poznamky.Count == 0;
    }
}
