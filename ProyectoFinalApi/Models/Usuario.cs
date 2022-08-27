namespace ProyectoFinalAppi.Models
{
    public class Usuario
    {
        //Variables.
        private int Id;
        private string Nombre;
        private string Apellido;
        private string NombreUsuario;
        private string Mail;
        private string Password;
        

        //Constructores.
        public Usuario()
        {
            this.Id = 0;
            this.Nombre = String.Empty;
            this.Apellido = String.Empty;
            this.NombreUsuario = String.Empty;
            this.Mail = String.Empty;    
            this.Password = String.Empty;
        }
        public Usuario(int id, string nombre, string apellido, string nombreUsuario, string mail, string password)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NombreUsuario = nombreUsuario;
            this.Mail = mail; 
            this.Password = password;
        }

        //Gets y Sets
        public int usuario_Id
        {
            set { this.usuario_Id = value; }
            get { return this.Id; }
        }
        public string usuario_Nombre
        {
            set { this.usuario_Nombre = value; }
            get { return this.Nombre; }
        }
        public string usuario_Apellido
        {
            set { this.usuario_Apellido = value; }
            get { return this.Apellido; }
        }
        public string usuario_NombreUsuario
        {
            set { this.usuario_NombreUsuario = value; }
            get { return this.NombreUsuario; }
        }
        public string usuario_Mail
        {
            set { this.usuario_Mail = value; }
            get { return this.Mail; }
        }     
        public string usuario_Password
        {
            set { this.usuario_Password = value; }
            get { return this.Password; }
        }
    }
}
