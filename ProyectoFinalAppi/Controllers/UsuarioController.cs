using Microsoft.AspNetCore.Mvc;
using ProyectoFinalApi.Controllers.ExecptionFilter;
using ProyectoFinalAppi.ADO_.NET;
using ProyectoFinalAppi.ADO_.NET.Error;
using ProyectoFinalAppi.Controllers.DTOS;
using ProyectoFinalAppi.Models;

namespace ProyectoFinalAppi.Controllers
{
    //Controlador Usuario.
    [ApiController]
    [Route("[controller]")]
    [TypeFilter(typeof(ExceptionManagerFilter))]

    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("GetUsuariosPorId/{id}")]
        public List<Usuario> GetUsuariosPorId([FromRoute] int id)
        {
            return UsuarioHandler.GetUsuariosPorId(id);                      
        }

        [HttpGet]
        [Route("VerificarUsuario/{id}")]
        public bool VerificarUsuario([FromRoute] string nombre, string contraseña) 
        {
            return UsuarioHandler.VerificarUsuario(nombre, contraseña);            
        }

        [HttpDelete]
        [Route("EliminarUsuario/{id}")]
        public bool EliminarUsuario([FromRoute]int id)
        {            
            return UsuarioHandler.EliminarUsuario(id);            
        }

        [HttpPut]
        [Route("ModificarUsuario/{usuario}")]
        public bool ModificarUsuario([FromRoute] PutUsuario usuario)
        {
            try
            {
                return UsuarioHandler.ModificarUsuario(new Usuario
                {                        
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    NombreUsuario = usuario.NombreUsuario,
                    Mail = usuario.Mail,
                    Contraseña = usuario.Contraseña,
                });                
            }
            catch (ModificarErrorException ex)
            {
                throw new ModificarErrorException(ex.Message);
            }
        }

        [HttpPost]
        [Route("CrearUsuario/{usuario}")]
        public bool CrearUsuario([FromRoute] PostUsuario usuario)
        {
            try
            {
                return UsuarioHandler.CreartUsuario(new Usuario
                {                    
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    NombreUsuario = usuario.NombreUsuario,
                    Mail = usuario.Mail,
                    Contraseña = usuario.Contraseña,
                });
            }
            catch (CrearErrorException ex)
            {
                throw new CrearErrorException(ex.Message);
            }
            
        }
    }
}
