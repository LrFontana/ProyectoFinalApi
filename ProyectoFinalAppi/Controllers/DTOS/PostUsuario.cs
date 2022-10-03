using ProyectoFinalAppi.Models;

namespace ProyectoFinalAppi.Controllers.DTOS
{
    public class PostUsuario
    {
        //Variables.
        public long Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string NombreUsuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string Mail { get; set; } = null!;
    }
}
