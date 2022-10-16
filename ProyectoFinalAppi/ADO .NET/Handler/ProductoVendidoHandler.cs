using Microsoft.Data.SqlClient;
using ProyectoFinalAppi.ADO_.NET.Error;
using ProyectoFinalAppi.Models;
using System.Data;

namespace ProyectoFinalAppi.ADO_.NET
{
    public static class ProductoVendidoHandler 
    {
        //Variable.
        public const string ConnectionString = "Server=DESKTOP-A2H9T9K\\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True;TrustServerCertificate=True;";

        //Funciones.

        //Eliminar Producto Vendido.
        public static bool EliminarProductoVendido(int id)
        {
            //Variable.
            bool productoVendidoEliminado = false;           
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[ProductoVendido] WHERE Id = @id;";                               

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@id", id);
                        int filasAfectadasDeProductosVendidosBorrado = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeProductosVendidosBorrado > 1)
                        {
                            Console.WriteLine("PRODUCTO VENDIDO ELIMINADO CON EXITO!");
                            return productoVendidoEliminado = true;
                        }
                        else
                        {
                            throw new EliminarErrorException("ERROR AL ELIMINAR EL PRODUCTO VENDIDO! POR FAVOR VERIFIQUE LA QUERY");
                            return productoVendidoEliminado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (EliminarErrorException ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }
            return productoVendidoEliminado;            
        }

        //Crear Producto vendido.
        public static bool CrearProductoVendido(ProductoVendido productoVentadido)
        {
            //Variable.
            bool productoVendidoCreado = false;
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryAdd = "INSERT INTO [SistemaGestion].[dbo].[ProductoVendido] (Stock, IdProducto, IdVenta)" +
                    "VALUES(@Stock, @IdProducto, @IdVenta)";

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Stock", productoVentadido.Stock);
                        sqlCommand.Parameters.AddWithValue("@IdProducto", productoVentadido.IdProducto);
                        sqlCommand.Parameters.AddWithValue("@IdVenta", productoVentadido.IdVenta);
                        int filasAfectadasDeProductosVendidosCreado = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeProductosVendidosCreado > 1)
                        {
                            Console.WriteLine("RODUCTO VENDIDO CREADO CON EXITO!");
                            return productoVendidoCreado = true;
                        }
                        else
                        {
                            throw new CrearErrorException("ERROR AL CREAR EL PRODUCTO VENDIDO! POR FAVOR VERIFIQUE LA QUERY");
                            return productoVendidoCreado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (CrearErrorException ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }
            return productoVendidoCreado;          
        }

        //Modificar Producto Vendido.
        public static bool ModificarProductoVendido(ProductoVendido productoVendido)
        {
            //Variable.
            bool productoVendidoModificado = false;
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryUpdate = "UPDATE [SistemaGestion].[dbo].[ProductoVendido ]" +
                    "SET " +
                        "Stock = @Stock," +
                        "IdProducto = @IdProducto," +
                        "IdVenta = @IdVenta," +
                    "WHERE Id = @Id";

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Stock", productoVendido.Stock);
                        sqlCommand.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
                        sqlCommand.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);
                        int filasAfectadasDeProductoVendidosModificado = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeProductoVendidosModificado > 1)
                        {
                            Console.WriteLine("PRODUCTO VENDIDO MODIFICADO CON EXITO!");
                            return productoVendidoModificado = true;
                        }
                        else
                        {
                            throw new ModificarErrorException("ERROR AL CREAR EL PRODUCTO VENDIDO! POR FAVOR VERIFIQUE LA QUERY");
                            return productoVendidoModificado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (ModificarErrorException ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }
            return productoVendidoModificado;            
        }

        //Obtener Productos Vendidos.
        public static List<ProductoVendido> GetProductosVendidos()
        {
            //Variable.
            List<ProductoVendido> listaObtenerProductosVendidos = new List<ProductoVendido>();
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetProductosVendidos = "SELECT * FROM [SistemaGestion].[dbo].[ProductoVendido]";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetProductosVendidos, sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    ProductoVendido productoVendido = new ProductoVendido();                                    
                                    productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                    productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                    productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                    productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);
                                    listaObtenerProductosVendidos.Add(productoVendido);
                                }
                            }
                            else
                            {
                                throw new GetErrorException("ERROR AL OBTENER LOS PRODUCTOS VENDIDOS! POR FAVOR VERIFIQUE LA QUERY");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (GetErrorException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }                    
                }
            }
            return listaObtenerProductosVendidos;
        }

        //Obtener productos vendidos por id.
        public static List<ProductoVendido> GetProductosVendidosPorId (int id)
        {           
            //Variable.
            List<ProductoVendido> listaObtenerProductosVendidosPorId = new List<ProductoVendido>();
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString)) 
            {
                string queryGetProductosVendidosPorId = "SELECT Stock, IdProducto, IdVenta FROM [SistemaGestion].[dbo].[ProductoVendido]" +
                    "WHERE Id = @id";                    

                using (SqlCommand sqlCommand = new SqlCommand(queryGetProductosVendidosPorId, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);

                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    ProductoVendido productoVendido = new ProductoVendido();                                    
                                    productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                    productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                    productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);
                                    listaObtenerProductosVendidosPorId.Add(productoVendido);
                                }
                            }
                            else
                            {
                                throw new GetErrorException("ERROR AL OBTENER LOS PRODUCTOS VENDIDOS POR ID! POR FAVOR VERIFIQUE LA QUERY");
                            }
                            dataReader.Close();
                        }
                    }
                    catch (GetErrorException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }                 
                }
                sqlConnection.Close();
            }
            return listaObtenerProductosVendidosPorId;            
        }
    }
}
