using Microsoft.AspNetCore.Mvc;
using ProyectoFinalAppi.ADO_.NET;

namespace ProyectoFinalAppi.Controllers
{
    //Controlador Producto.
    [ApiController]
    [Route("[controller]")]

    public class InicioDeSesionController : ControllerBase
    {       
        public bool VerificarUsuario([FromBody] string nombre, string password)
        {
            try
            {
                return InicioDeSesionHandler.VerificarUsuario(nombre, password);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
