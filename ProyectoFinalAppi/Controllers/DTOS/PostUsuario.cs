using ProyectoFinalAppi.Models;

namespace ProyectoFinalAppi.Controllers.DTOS
{
    public class PostUsuario
    {
        //Variables.
        public long Id { get; set; }
        public string Nombre { get; set; } 
        public string Apellido { get; set; } 
        public string NombreUsuario { get; set; } 
        public string Contraseña { get; set; } 
        public string Mail { get; set; } 
    }
}
