namespace ProyectoFinalAppi.Controllers.DTOS
{
    public class PutProductoVendido
    {
        //variables.
        public long Id { get; set; }
        public int Stock { get; set; }
        public long IdProducto { get; set; }
        public long IdVenta { get; set; }
    }
}
