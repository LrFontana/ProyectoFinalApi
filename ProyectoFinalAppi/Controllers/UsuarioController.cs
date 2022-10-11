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
        public List<Usuario> GetUsuariosPorId([FromBody] int id)
        {
            try
            {
                return UsuarioHandler.GetUsuariosPorId(id);
            }
            catch (GetErrorException ex)
            {
                throw new GetErrorException(ex.Message);
            }            
        }

        [HttpGet]
        [Route("VerificarUsuario")]
        public bool VerificarUsuario([FromBody] string nombre, string contraseña) 
        {
            try
            {
                return UsuarioHandler.VerificarUsuario(nombre, contraseña);
            }
            catch (GetErrorException ex)
            {

                throw new GetErrorException(ex.Message);
            }
        }

        [HttpDelete]
        public bool EliminarUsuario([FromBody]int id)
        {
            try
            {
                return UsuarioHandler.EliminarUsuario(id);
                
            }
            catch (EliminarErrorException ex)
            {
                throw new EliminarErrorException(ex.Message);
            }
        }

        [HttpPut]
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
