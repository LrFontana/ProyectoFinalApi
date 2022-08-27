using Microsoft.AspNetCore.Mvc;
using ProyectoFinalAppi.ADO_.NET;
using ProyectoFinalAppi.ADO_.NET.Error;
using ProyectoFinalAppi.Controllers.DTOS;
using ProyectoFinalAppi.Models;

namespace ProyectoFinalAppi.Controllers
{
    //Controlador Usuario.
    [ApiController]
    [Route("[controller]")]

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
                    usuario_Nombre = usuario.Nombre,
                    usuario_Apellido = usuario.Apellido,
                    usuario_NombreUsuario = usuario.NombreUsuario,
                    usuario_Mail = usuario.Mail,
                    usuario_Password = usuario.Password,
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
                    usuario_Id = usuario.Id,
                    usuario_Nombre = usuario.Nombre,
                    usuario_Apellido = usuario.Apellido,
                    usuario_NombreUsuario = usuario.NombreUsuario,
                    usuario_Mail = usuario.Mail,
                    usuario_Password = usuario.Password,
                });
            }
            catch (CrearErrorException ex)
            {
                throw new CrearErrorException(ex.Message);
            }
            
        }
    }
}
