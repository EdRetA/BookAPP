using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookAPP.Models
{
    public class vlibrousuarioModel
    {
        public int idapartado { get; set; }
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string id { get; set; }
        public int CodLibro { get; set; }
        public string titulo { get; set; }
        public int precio { get; set; }
        public Nullable<bool> asignado { get; set; }
    }
}