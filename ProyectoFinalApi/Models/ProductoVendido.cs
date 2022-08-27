namespace ProyectoFinalAppi.Models
{
    public class ProductoVendido
    {
        //variables.
        private int Id;
        private int IdProducto;
        private int IdVenta;
        private int Stock;

        //Constructores.
        public ProductoVendido()
        {
            this.Id = 0;
            this.IdProducto = 0;
            this.IdVenta = 0;
            this.Stock = 0;
        }
        public ProductoVendido(int id, int idProducto, int idVenta, int stock)
        {
            this.Id = id;
            this.IdProducto = idProducto;
            this.IdVenta = idVenta;
            this.Stock = stock;
        }

        //Gets y Sets
        public int productoVendido_Id
        {
            set { this.productoVendido_Id = value; }
            get { return this.Id; }
        }
        public int productoVendido_IdProducto
        {
            set { this.productoVendido_IdProducto = value; }
            get { return this.IdProducto; }
        }
        public int productoVendido_IdVenta
        {
            set { this.productoVendido_IdVenta = value; }
            get { return this.IdVenta; }
        }
        public int productoVendido_Stock
        {
            set { this.productoVendido_Stock = value; }
            get { return this.Stock; }
        }
    }
}
