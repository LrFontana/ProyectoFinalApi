namespace ProyectoFinalAppi.Models
{
    public class Producto
    {
        //Variables.
        private int Id;
        private int Costo;
        private int Stock;
        private int IdUsuario;
        private double PrecioDeVenta;
        private string Descripcion;       

        //Constructor.
        public Producto()
        {
            this.Id = 0;
            this.Costo = 0;            
            this.Stock = 0;
            this.IdUsuario = 0;
            this.PrecioDeVenta = 0;
            this.Descripcion = String.Empty;            
        }
        public Producto(int codigo, int costo, int stock, int idUsuario, double precioDeVenta, string descripcion)
        {
            this.Id = codigo;
            this.Costo = costo;
            this.Stock = stock;
            this.IdUsuario = idUsuario;
            this.PrecioDeVenta = precioDeVenta;
            this.Descripcion= descripcion;                       
        }

        //Geters y Seters
        public int producto_Id
        {
            set { this.producto_Id = value; }
            get { return this.Id; }
        }
        public double producto_Costo
        {
            set { this.producto_Costo = value; }
            get { return this.Costo; }
        }        public int producto_Stock
        {
            set { this.producto_Stock = value; }
            get { return this.Stock; }
        }        public int producto_IdUsuario
        {
            set { this.producto_IdUsuario = value; }
            get { return this.IdUsuario; }
        }
        public double producto_PrecioDeVenta
        {
            set { this.producto_PrecioDeVenta = value; }
            get { return this.PrecioDeVenta; }
        }
        public string producto_Descipcion
        {
            set { this.producto_Descipcion = value; }
            get { return this.Descripcion; }
        }             
    }
}
