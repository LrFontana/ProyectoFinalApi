using Microsoft.Data.SqlClient;
using ProyectoFinalAppi.Models;
using System.Data;

namespace ProyectoFinalAppi.ADO_.NET
{
    public static class ProductoVendidoHandler 
    {
        //Variable DataBase.
        public const string ConnectionString = "Server=DESKTOP-A2H9T9K\\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True";

        //Funciones.

        //Borrar Producto Vendido.
        public static bool EliminarProductoVendido(int id)
        {
            bool productoVendidoBorrado = false;           
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[ProductoVendido] WHERE Id = @Id;";

                SqlParameter sqlParameter = new SqlParameter("Id", SqlDbType.BigInt) { Value = id};

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(sqlParameter);

                        int cantidadDeProductoVendidoBorrado = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeProductoVendidoBorrado > 1)
                        {
                            Console.WriteLine("ProDucto Vendido eliminad.");
                            return productoVendidoBorrado = true;
                        }
                        else
                        {
                            Console.WriteLine("ERROR! No se puedo eliminar el producto vendido, por favor velva a intentarlo.");
                            return productoVendidoBorrado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Query definition error" + ex.Message);
                }                
            }
            return productoVendidoBorrado;            
        }

        //Agregar Producto vendido.
        public static bool CrearProductoVendido(ProductoVendido productoVentadido)
        {
            bool productoVendidoCreado = false;

            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryAdd = "INSERT INTO [SistemaGestion].[dbo].[ProductoVendido] (Stock, IdProducto, IdVenta)" +
                    "VALUES(@stock, @idProducto, @idVenta)";

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = productoVentadido.productoVendido_Stock });
                        sqlCommand.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.VarChar) { Value = productoVentadido.productoVendido_IdProducto });
                        sqlCommand.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.VarChar) { Value = productoVentadido.productoVendido_IdVenta });

                        int cantidadDeProductoVendidoCreado = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeProductoVendidoCreado > 1)
                        {
                            Console.WriteLine("Producto Vendido Creado con ¡EXITO!");
                            return productoVendidoCreado = true;
                        }
                        else
                        {
                            Console.WriteLine("ERRO! No se pudo crear el Producto Vendido, por favor intentelo de nuevo.");
                            return productoVendidoCreado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Querry definition error " + ex.Message);
                }                
            }
            return productoVendidoCreado;          
        }

        //Actualizar Producto Vendido.
        public static bool ModificarProductoVendido(ProductoVendido productoVendido)
        {
            bool productoVendidoModificado = false;
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryUpdate = "UPDATE [SistemaGestion].[dbo].[ProductoVendido ]" +
                    "SET " +
                        "Stock = @stock," +
                        "IdProducto = @idProducto," +
                        "IdVenta = @idVenta," +
                    "WHERE Id = @id";

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Stock", SqlDbType.BigInt) { Value = productoVendido.productoVendido_Stock });
                        sqlCommand.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.VarChar) { Value = productoVendido.productoVendido_IdProducto });
                        sqlCommand.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.VarChar) { Value = productoVendido.productoVendido_IdVenta });

                        int cantidadDeProductoVendidoModificado = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeProductoVendidoModificado > 1)
                        {
                            Console.WriteLine("Producto Vendido Modificado con ¡EXITO!");
                            return productoVendidoModificado = true;
                        }
                        else
                        {
                            Console.WriteLine("ERRO! No se pudo crear el Producto Vendido, por favor intentelo de nuevo.");
                            return productoVendidoModificado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Querry definition error " + ex.Message); ;
                }                
            }
            return productoVendidoModificado;            
        }

        //Obtener Productos Vendidos.
        public static List<ProductoVendido> GetProductosVendidos()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine(" MOSTRANDO TODOS LOS PRODUCTOS VENDIDOS  ");
            Console.WriteLine("*****************************************\n");

            List<ProductoVendido> listaProductoVendidos = new List<ProductoVendido>();
            
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
                                    productoVendido.productoVendido_Id = Convert.ToInt32(dataReader["Id"]);
                                    productoVendido.productoVendido_Stock = Convert.ToInt32(dataReader["Stock"]);
                                    productoVendido.productoVendido_IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                    productoVendido.productoVendido_IdVenta = Convert.ToInt32(dataReader["IdVenta"]);
                                    listaProductoVendidos.Add(productoVendido);
                                }
                            }

                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Query error definition " + ex.Message);
                    }                    
                }
            }           

            foreach (ProductoVendido productoVenta in listaProductoVendidos)
            {
                Console.WriteLine($"Id: {productoVenta.productoVendido_Id}\n" +
                    $"Stock: {productoVenta.productoVendido_Stock}\n" +
                    $"IdProducto: {productoVenta.productoVendido_IdProducto}\n" +
                    $"IdVenta: {productoVenta.productoVendido_IdProducto}");
            }
            return listaProductoVendidos;
        }

        //Obtener productos vendidos por id.
        public static List<ProductoVendido> GetProductosVendidosPorId (int id)
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("   MOSTRANDO TODOS LOS PRODUCTOS VENDIDOS POR ID  ");
            Console.WriteLine("**************************************************\n");

            List<ProductoVendido> listaProductosVendidosPorId = new List<ProductoVendido>();

            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString)) 
            {
                string queryGetProductosVendidosPorId = "SELECT Id, Stock, IdProducto, IdVenta FROM [SistemaGestion].[dbo].[ProductoVendido]" +
                    "WHERE Id = @id";                    

                using (SqlCommand sqlCommand = new SqlCommand(queryGetProductosVendidosPorId, sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = id});

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
                                    productoVendido.productoVendido_Id = Convert.ToInt32(dataReader["Id"]);
                                    productoVendido.productoVendido_Stock = Convert.ToInt32(dataReader["Stock"]);
                                    productoVendido.productoVendido_IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                    productoVendido.productoVendido_IdVenta = Convert.ToInt32(dataReader["IdVenta"]);
                                    listaProductosVendidosPorId.Add(productoVendido);
                                }
                            }
                            dataReader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Query definition error " + ex.Message);
                    }                 
                }
                sqlConnection.Close();
            }
            return listaProductosVendidosPorId;            
        }
    }
}
