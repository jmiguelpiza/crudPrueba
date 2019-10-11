using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcf_PorductosNetofice.Models
{
    public class ObjProducto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public bool Estado { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Usuario { get; set; }
        public string TransactionId { get; set; }


        // [Id], [Codigo], [Descripcion], [Cantidad], [Estado], [Fecha_Creacion], [Usuario], [TransactionId]
    }
}