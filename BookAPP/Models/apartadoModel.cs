namespace BookAPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class apartadoModel
    {
        public int id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        public int fklibro { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        public int fkcliente { get; set; }
        public bool estado { get; set; }
        public Nullable<System.DateTime> fretiro { get; set; }
    }
}

