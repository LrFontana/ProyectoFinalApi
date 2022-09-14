using Microsoft.Data.SqlClient;
using ProyectoFinalAppi.ADO_.NET.Error;
using ProyectoFinalAppi.Models;
using System.Data;


namespace ProyectoFinalAppi.ADO_.NET
{
    public static class ProductoHandler
    {
        //Variable.
        public const string ConnectionString = "Server=DESKTOP-A2H9T9K\\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True";

        //Funciones.

        //Eliminar producto.
        public static bool EliminarProducto(int id)
        {
            //variable.
            bool productoEliminado = false;
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @Id;";               

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = id });

                        int cantidadDeProductosEliminados = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeProductosEliminados > 1)
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
                string queryAdd = "INSERT INTO [SistemaGestion].[dbo].[Producto] (Descripcion, Costo, PrecioDeVenta, Stock, IdUsuario)" +
                    "VALUES(@descripncion, @costo, @precioDeVenta, @stock, @idUsuario)";

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Descripcion", SqlDbType.VarChar) { Value = producto.Descripcion });
                        sqlCommand.Parameters.Add(new SqlParameter("Costo", SqlDbType.BigInt) { Value = producto.Costo });
                        sqlCommand.Parameters.Add(new SqlParameter("PrecioDeVenta", SqlDbType.BigInt) { Value = producto.PrecioDeVenta });
                        sqlCommand.Parameters.Add(new SqlParameter("Stock", SqlDbType.BigInt) { Value = producto.Stock });
                        sqlCommand.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.VarChar) { Value = producto.IdUsuario });

                        int cantidadDeProductosCreados = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeProductosCreados > 1)
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
                        "Descripciones = @descripcion," +
                        "Costo = @id," +
                        "PrecioVenta = @precioDeVenta," +
                        "Stock = @stock," +
                        "Categorias = @idUsuario" +
                    "WHERE Codigo = @id";

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommando = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommando.Parameters.Add(new SqlParameter("Descripcion", SqlDbType.VarChar) { Value = producto.Descripcion });
                        sqlCommando.Parameters.Add(new SqlParameter("Costo", SqlDbType.BigInt) { Value = producto.Costo });
                        sqlCommando.Parameters.Add(new SqlParameter("PrecioDeVenta", SqlDbType.BigInt) { Value = producto.PrecioDeVenta });
                        sqlCommando.Parameters.Add(new SqlParameter("Stock", SqlDbType.BigInt) { Value = producto.Stock });
                        sqlCommando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.VarChar) { Value = producto.IdUsuario });

                        int cantidadDeProductosModificados = sqlCommando.ExecuteNonQuery();

                        if (cantidadDeProductosModificados > 1)
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
            Console.WriteLine("*****************************************");
            Console.WriteLine("      MOSTRANDO TODOS LOS PRODUCTOS      ");
            Console.WriteLine("*****************************************\n");

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
                                    producto.PrecioDeVenta = Convert.ToInt32(dataReader["PrecioVenta"]);
                                    producto.Descripcion = dataReader["Descripciones"].ToString();
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
            Console.WriteLine("*****************************************");
            Console.WriteLine("        MOSTRANDO PRODUCTOS POR ID       ");
            Console.WriteLine("*****************************************\n");

            //Variable.
            List<Producto> listaObtenerProductosPorId = new List<Producto>();
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetProductoPorId = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM [SistemaGestion].[dbo].[Producto]" +
                    "WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetProductoPorId, sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = id });

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
                                    producto.PrecioDeVenta = Convert.ToInt32(dataReader["PrecioVenta"]);
                                    producto.Descripcion = dataReader["Descripciones"].ToString();
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
