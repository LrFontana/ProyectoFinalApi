namespace ProyectoFinalAppi.Controllers.DTOS
{
    public class PostProductoVendido
    {
        //variables.
        public long Id { get; set; }
        public int Stock { get; set; }
        public long IdProducto { get; set; }
        public long IdVenta { get; set; }
    }
}
