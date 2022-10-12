using Microsoft.Data.SqlClient;
using ProyectoFinalAppi.ADO_.NET.Error;
using ProyectoFinalAppi.Models;
using System.Data;


namespace ProyectoFinalAppi.ADO_.NET
{
    public static class ProductoHandler
    {
        //Variable.
        public const string ConnectionString = "Server=DESKTOP-A2H9T9K\\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True;TrustServerCertificate=True;";

        //Funciones.

        //Eliminar producto.
        public static bool EliminarProducto(int id)
        {
            //variable.
            bool productoEliminado = false;
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @id;";               

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@id", id);
                        int filasAfectadasDeProductosEliminado = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeProductosEliminado > 1)
                        {
                            Console.WriteLine("PRODUCTO ELIMINADO CON EXITO!");
                            return productoEliminado = true;
                        }
                        else
                        {
                            throw new EliminarErrorException("ERROR AL ELIMINAR EL PRODUCTO! POR FAVOR VERIFIQUE LA QUERY");
                            return productoEliminado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (EliminarErrorException ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }
            return productoEliminado = true;                     
        }

        //Crear producto.
        public static bool CrearProducto(Producto producto)
        {
            //Variable
            bool productoCreado = false;
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryAdd = "INSERT INTO [SistemaGestion].[dbo].[Producto] (Descripciones, Costo, PrecioVenta, Stock, IdUsuario)" +
                    "VALUES(@Descripnciones, @Costo, @PrecioVenta, @Stock, @IdUsuario)";

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Descripciones", producto.Descripciones);
                        sqlCommand.Parameters.AddWithValue("@Costo", producto.Costo);
                        sqlCommand.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                        sqlCommand.Parameters.AddWithValue("@Stock", producto.Stock);
                        sqlCommand.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                        int filasAfectadasDeProductosCreado = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeProductosCreado > 1)
                        {
                            Console.WriteLine("PRODUCTO CREADO CON EXITO!");
                            return productoCreado = true;
                        }
                        else
                        {
                            throw new CrearErrorException("ERROR AL CREAR EL PRODUCTO! POR FAVOR VERIFIQUE LA QUERY");
                            return productoCreado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (CrearErrorException ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }
            return productoCreado;                  
        }

        //Modificar producto.
        public static bool ModificarProducto(Producto producto)
        {
            //Variable
            bool productoModificado = false;
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryUpdate = "UPDATE [SistemaGestion].[dbo].[Producto]" +
                    "SET " +
                        "Descripciones = @Descripciones," +
                        "Costo = @Id," +
                        "PrecioVenta = @PrecioVenta," +
                        "Stock = @Stock," +
                        "Categorias = @IdUsuario" +
                    "WHERE Codigo = @Id";

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Descripciones", producto.Descripciones);
                        sqlCommand.Parameters.AddWithValue("@Costo", producto.Costo);
                        sqlCommand.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                        sqlCommand.Parameters.AddWithValue("@Stock", producto.Stock);
                        sqlCommand.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                        int filasAfectadasDeProductosModificado = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeProductosModificado > 1)
                        {
                            Console.WriteLine("PRODUCTO MODIFICADO CON EXITO!");
                            return productoModificado = true;
                        }
                        else
                        {
                            throw new ModificarErrorException("ERROR AL CREAR EL PRODUCTO! POR FAVOR VERIFIQUE LA QUERY");
                            return productoModificado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (ModificarErrorException ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }
            return productoModificado;              
        }

        //Obtener productos.
        public static List<Producto> GetProductos()
        {
            //Variable.
            List<Producto> listaObtenerProductos = new List<Producto>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryGetProductos = "SELECT * FROM [SistemaGestion].[dbo].[Producto]";

                    using (SqlCommand sqlCommand = new SqlCommand(queryGetProductos, sqlConnection))
                    {
                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    Producto producto = new Producto();
                                    producto.Id = Convert.ToInt32(dataReader["Id"]);
                                    producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                    producto.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                                    producto.Costo = Convert.ToInt32(dataReader["Costo"]);
                                    producto.PrecioVenta = Convert.ToInt32(dataReader["PrecioVenta"]);
                                    producto.Descripciones = dataReader["Descripciones"].ToString();
                                    listaObtenerProductos.Add(producto);
                                }
                            }
                            else
                            {
                                throw new GetErrorException("ERROR AL OBTENER LOS PRODUCTOS! POR FAVOR VERIFIQUE LA QUERY");
                            }                            
                            dataReader.Close();                            
                        }                        
                        sqlConnection.Close();                       
                    }                      
                }
            }
            catch (GetErrorException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return listaObtenerProductos;
        }

        //Obtener Productos por id.
        public static List<Producto> GetProductosPorId(int id)
        {
            //Variable.
            List<Producto> listaObtenerProductosPorId = new List<Producto>();
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetProductoPorId = "SELECT * FROM [SistemaGestion].[dbo].[Producto]" +
                    "WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetProductoPorId, sqlConnection))
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
                                    Producto producto = new Producto();
                                    producto.Id = Convert.ToInt32(dataReader["Id"]);
                                    producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                    producto.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                                    producto.Costo = Convert.ToInt32(dataReader["Costo"]);
                                    producto.PrecioVenta = Convert.ToInt32(dataReader["PrecioVenta"]);
                                    producto.Descripciones = dataReader["Descripciones"].ToString();
                                    listaObtenerProductosPorId.Add(producto);
                                }
                            }
                            else
                            {
                                throw new GetErrorException("ERROR AL OBTENER LOS PRODUCTOS POR ID! POR FAVOR VERIFIQUE LA QUERY");
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
            return listaObtenerProductosPorId;
        }        
    }
}
