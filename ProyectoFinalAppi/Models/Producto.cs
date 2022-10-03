﻿namespace ProyectoFinalAppi.Models
{
    public class Producto
    {
        //Variables.
        public long Id { get; set; }
        public string Descripciones { get; set; } = null!;
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public long IdUsuario { get; set; }

    }
}
