

namespace BookAPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class libroModel
    {
        public int codigo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        public string nombre { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        public string empresa { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        public int precio { get; set; }
        public int stock { get; set; }
        public int recarga { get; set; }
        public int reservas { get; set; }
        public Boolean prueba { get; set; }


    }
}

