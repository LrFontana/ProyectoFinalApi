using Microsoft.AspNetCore.Mvc;
using ProyectoFinalApi.Controllers.ExecptionFilter;
using ProyectoFinalAppi.ADO_.NET;
using ProyectoFinalAppi.ADO_.NET.Error;
using ProyectoFinalAppi.Controllers.DTOS;
using ProyectoFinalAppi.Models;

namespace ProyectoFinalAppi.Controllers
{
    //Controlador Producto.
    [ApiController]
    [Route("[controller]")]
    [TypeFilter(typeof(ExceptionManagerFilter))]

    public class ProductoController : ControllerBase
    {
        [HttpGet]
        [Route("GetProductosPorId")]
        public List<Producto> GetProductosPorId([FromBody] int id)
        {
            try
            {
                return ProductoHandler.GetProductosPorId(id);
            }
            catch (GetErrorException ex)
            {
                throw new GetErrorException(ex.Message);
            }
        }

        [HttpDelete]
        [Route("EliminarProducto")]
        public bool EliminarProducto([FromBody] int id)
        {
            try
            {
                return ProductoHandler.EliminarProducto(id);
            }
            catch (EliminarErrorException ex)
            {
                throw new EliminarErrorException(ex.Message);
            }
        }

        [HttpPut]
        [Route("ModificarProducto")]
        public bool ModificarProducto([FromBody] PutProducto producto)
        {
            try
            {
                return ProductoHandler.ModificarProducto(new Producto
                {
                    Costo = producto.Costo,
                    Stock = producto.Stock,
                    IdUsuario = producto.IdUsuario,
                    PrecioVenta = producto.PrecioVenta,
                    Descripciones = producto.Descripciones,
                });
            }
            catch (ModificarErrorException ex)
            {
                throw new ModificarErrorException(ex.Message);
            }
        }

        [HttpPost]
        [Route("CrearProducto")]
        public bool CrearProducto([FromBody] PostProducto producto)
        {
            try
            {
                return ProductoHandler.CrearProducto(new Producto
                {
                    Id = producto.Id,
                    Costo = producto.Costo,
                    Stock = producto.Stock,
                    IdUsuario = producto.IdUsuario,
                    PrecioVenta = producto.PrecioVenta,
                    Descripciones = producto.Descripciones,
                });
            }
            catch (CrearErrorException ex)
            {
                throw new CrearErrorException(ex.Message);
            }

        }
    }
}
