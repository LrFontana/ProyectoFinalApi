namespace ProyectoFinalAppi.Models
{
    public class ProductoVendido
    {
        //variables.
        public long Id { get; set; }
        public int Stock { get; set; }
        public long IdProducto { get; set; }
        public long IdVenta { get; set; }

    }
}
