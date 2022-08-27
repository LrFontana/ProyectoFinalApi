using Microsoft.AspNetCore.Mvc;
using ProyectoFinalAppi.ADO_.NET;

namespace ProyectoFinalAppi.Controllers
{
    //Controlador Producto.
    [ApiController]
    [Route("[controller]")]

    public class NombreApiController : ControllerBase
    {
        [HttpGet]
        public string GetNombreApi()
        {
            return "LRF COMPRAS";
        }
    }
}
