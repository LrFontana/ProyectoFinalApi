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
        public List<Producto> GetProductosPorId([FromBody] long id)
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
        public bool EliminarProducto([FromBody] long id)
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
