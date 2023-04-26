namespace BookAPP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class clienteModel
    {
        public int codigo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        public string nombre { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        public string id { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        [Required(ErrorMessage = "DOB is Required")]
        [DataType(DataType.Date, ErrorMessage = "DOB is Required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime fnacimiento { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es requerido")]
        public string correo { get; set; }
    }
}