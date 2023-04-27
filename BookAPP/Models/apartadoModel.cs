namespace BookAPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class apartadoModel
    {
        public int id { get; set; }
        public int fklibro { get; set; }
        public int fkcliente { get; set; }
        public bool estado { get; set; }
        public string nombre { get; set; }
        public Nullable<System.DateTime> fretiro { get; set; }
    }
}

