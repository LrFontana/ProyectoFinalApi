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
        [Route("GetProductosPorId/{id}")]
        public List<Producto> GetProductosPorId([FromRoute] int id)
        {
            try
            {
                return ProductoHandler.GetProductosPorId(id);
            }
            catch (GetErrorException ex)
            {
                throw new GetErrorException(ex.Message);
                return new List<Producto>();
            }
        }

        [HttpDelete]
        [Route("EliminarProducto/{id}")]
        public bool EliminarProducto([FromRoute] int id)
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
        [Route("ModificarProducto/{producto}")]
        public bool ModificarProducto([FromRoute] PutProducto producto)
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
        [Route("CrearProducto/{producto}")]
        public bool CrearProducto([FromRoute] PostProducto producto)
        {
            try
            {
                return ProductoHandler.CrearProducto(new Producto
                {
                    Descripciones = producto.Descripciones,
                    Costo = producto.Costo,
                    Stock = producto.Stock,
                    IdUsuario = producto.IdUsuario,
                    PrecioVenta = producto.PrecioVenta,
                    
                });
            }
            catch (CrearErrorException ex)
            {
                throw new CrearErrorException(ex.Message);
            }

        }
    }
}
