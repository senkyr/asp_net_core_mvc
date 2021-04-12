using System;
using System.ComponentModel.DataAnnotations;

namespace MvcPoznamky.Models
{
    public class Poznamka
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Uzivatel Autor { get; set; }
        [Required]
        public DateTime DatumVytvoreni { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
