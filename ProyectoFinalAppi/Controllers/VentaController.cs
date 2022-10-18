using Microsoft.AspNetCore.Mvc;
using ProyectoFinalApi.Controllers.ExecptionFilter;
using ProyectoFinalAppi.ADO_.NET;
using ProyectoFinalAppi.ADO_.NET.Error;
using ProyectoFinalAppi.Controllers.DTOS;
using ProyectoFinalAppi.Models;

namespace ProyectoFinalAppi.Controllers
{
    //Controlador Producto Vendido.
    [ApiController]
    [Route("[controller]")]
    [TypeFilter(typeof(ExceptionManagerFilter))]

    public class VentaController : ControllerBase
    {
        [HttpGet]
        [Route("GetVentas/{id}")]
        public List<Venta> GetVentas([FromRoute] int id)
        {
            try
            {
                return VentaHandler.GetVentas(id);
            }
            catch (GetErrorException ex)
            {
                throw new GetErrorException(ex.Message);
            }
        }

        [HttpDelete]
        [Route("EliminarVenta/{id}")]
        public bool EliminarVenta([FromRoute] int id)
        {
            try
            {
                return VentaHandler.EliminarVenta(id);
            }
            catch (EliminarErrorException ex)
            {
                throw new EliminarErrorException(ex.Message);
            }
        }

        [HttpPut]
        [Route("ModificarVenta/{venta}")]
        public bool ModificarVenta([FromRoute] PutVenta venta)
        {
            try
            {
                return VentaHandler.ModificarVenta(new Venta
                {
                    Comentarios = venta.Comentarios,                    
                });
            }
            catch (ModificarErrorException ex)
            {
                throw new ModificarErrorException(ex.Message);
            }
        }

        [HttpPost]
        [Route("CrearVenta/{venta}")]
        public bool CrearVenta([FromRoute] PostVenta venta)
        {
            try
            {
                return VentaHandler.CrearVenta(new Venta
                {                    
                    Comentarios = venta.Comentarios,                    
                });
            }
            catch (CrearErrorException ex)
            {
                throw new CrearErrorException(ex.Message);
            }

        }

        [HttpPost]
        [Route("CargarVenta/{listaProducto}/{idUsuario}")]
        public bool CargarVenta([FromRoute] List<Producto> listaProducto, int idUsuario)
        {            
            return VentaHandler.CargarVenta(listaProducto, idUsuario);            
        }
    }
}
