﻿namespace ProyectoFinalAppi.Controllers.DTOS
{
    public class PutProducto
    {
        //Variables.
        public long Id { get; set; }
        public string Descripciones { get; set; } 
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public long IdUsuario { get; set; }
    }
}
