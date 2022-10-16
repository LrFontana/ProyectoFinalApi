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
        [Route("GetUsuariosPorId")]
        public List<Usuario> GetUsuariosPorId([FromBody] int id)
        {
            return UsuarioHandler.GetUsuariosPorId(id);                      
        }

        [HttpGet]
        [Route("VerificarUsuario")]
        public bool VerificarUsuario([FromBody] string nombre, string contraseña) 
        {
            return UsuarioHandler.VerificarUsuario(nombre, contraseña);            
        }

        [HttpDelete]
        [Route("EliminarUsuario")]
        public bool EliminarUsuario([FromBody]int id)
        {            
            return UsuarioHandler.EliminarUsuario(id);            
        }

        [HttpPut]
        [Route("ModificarUsuario")]
        public bool ModificarUsuario([FromBody] PutUsuario usuario)
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
        [Route("CrearUsuario")]
        public bool CrearUsuario([FromBody] PostUsuario usuario)
        {
            try
            {
                return UsuarioHandler.CreartUsuario(new Usuario
                {
                    Id = usuario.Id,
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
