using System;
using System.ComponentModel.DataAnnotations;

namespace AspPoznamky.Models
{
    public class Poznamka
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime DatumVytvoreni { get; set; }
        [Required]
        public virtual Uzivatel Autor { get; set; }
    }
}
