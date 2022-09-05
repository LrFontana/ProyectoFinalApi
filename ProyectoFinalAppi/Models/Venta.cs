namespace ProyectoFinalAppi.Models
{
    public class Venta
    {
        //Variables.
        private int Id;
        private string Comentarios;

        //Constructores.
        public Venta()
        {
            this.Id = 0;
            this.Comentarios = String.Empty;
        }
        public Venta(int id, string comentarios)
        {
            this.Id = id;
            this.Comentarios = comentarios;
        }

        //Gets y Sets
        public int venta_Id
        {
            set { this.venta_Id = value; }
            get { return this.Id; }
        }
        public string venta_Comentarios
        {
            set { this.venta_Comentarios = value; }
            get { return this.Comentarios; }
        }
    }
}
