using Microsoft.AspNetCore.Mvc;
using ProyectoFinalAppi.ADO_.NET;
using ProyectoFinalAppi.ADO_.NET.Error;
using ProyectoFinalAppi.Controllers.DTOS;
using ProyectoFinalAppi.Models;

namespace ProyectoFinalAppi.Controllers
{
    //Controlador Producto Vendido.
    [ApiController]
    [Route("[controller]")]

    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet]
        public List<ProductoVendido> GetProductosVendidosPorId([FromBody] int id)
        {
            try
            {
                return ProductoVendidoHandler.GetProductosVendidosPorId(id);
            }
            catch (GetErrorException ex)
            {
                throw new GetErrorException(ex.Message);
            }
        }

        [HttpDelete]
        public bool EliminarProductoVendido([FromBody] int id)
        {
            try
            {
                return ProductoVendidoHandler.EliminarProductoVendido(id);
            }
            catch (EliminarErrorException ex)
            {
                throw new EliminarErrorException(ex.Message);
            }
        }

        [HttpPut]
        public bool ModificarProductoVendido([FromBody] PutProductoVendido productoVendido)
        {
            try
            {
                return ProductoVendidoHandler.ModificarProductoVendido(new ProductoVendido
                {
                    productoVendido_IdProducto = productoVendido.IdProducto,
                    productoVendido_IdVenta = productoVendido.IdVenta,
                    productoVendido_Stock = productoVendido.Stock,                    
                });
            }
            catch (ModificarErrorException ex)
            {
                throw new ModificarErrorException(ex.Message);
            }
        }

        [HttpPost]
        public bool CrearProductoVendido([FromBody] PostProductoVendido productoVendido)
        {
            try
            {
                return ProductoVendidoHandler.CrearProductoVendido(new ProductoVendido
                {
                    productoVendido_Id = productoVendido.Id,
                    productoVendido_IdProducto = productoVendido.IdProducto,
                    productoVendido_IdVenta = productoVendido.IdVenta,
                    productoVendido_Stock = productoVendido.Stock,
                });
            }
            catch (CrearErrorException ex)
            {
                throw new CrearErrorException(ex.Message);
            }

        }
    }
}
