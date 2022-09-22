using Microsoft.Data.SqlClient;
using ProyectoFinalApi.ADO_.NET.Error.ValidatorErrors;
using ProyectoFinalAppi.Models;
using System.Data;

namespace ProyectoFinalApi.ADO_.NET.ModelsValidator
{
    public class ProductoVendidoValidator
    {
        //Variable.
        private const string ConnectionString = @"Server=DESKTOP-A2H9T9K\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True";


        //Logica producto vendido.

        //Get Id.
        public static List<ProductoVendido> GetIdProductoVendido(int id)
        {
            //Variable.
            List<ProductoVendido> listaIdProductoVendido = new List<ProductoVendido>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetValidarProductoVendido = "SELECT Id FROM [SistemaGestion].[dbo].[ProductoVendido] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetValidarProductoVendido, sqlConnection))
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
                                    ProductoVendido productoVendido = new ProductoVendido();
                                    productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                    listaIdProductoVendido.Add(productoVendido);
                                }
                            }
                            else
                            {
                                throw new ProductoVendidoValidatorError("ERROR AL INTENTAR OBTENER EL ID, POR FAVOR VERIFIQUE LA QUERY!");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (ProductoVendidoValidatorError ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return listaIdProductoVendido;
        }

        //Get id producto.
        public static List<ProductoVendido> GetIdProductoDeProductoVendido(int id)
        {
            //Variable.
            List<ProductoVendido> listaIdProductoVendido = new List<ProductoVendido>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetIdProductoVendido = "SELECT Id, IdProducto FROM [SistemaGestion].[dbo].[ProductoVendido] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetIdProductoVendido, sqlConnection))
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
                                    ProductoVendido productoVendido = new ProductoVendido();
                                    productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                    productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                    listaIdProductoVendido.Add(productoVendido);
                                }
                            }
                            else
                            {
                                throw new ProductoVendidoValidatorError("ERROR AL INTENTAR OBTENER EL ID PRODUCTO, POR FAVOR VERIFIQUE LA QUERY!");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (ProductoVendidoValidatorError ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return listaIdProductoVendido;
        }

        //Get id venta.
        public static List<ProductoVendido> GetIdVentaDeProductoVendido(int id)
        {
            //variable.
            List<ProductoVendido> listaIdVentaDeProductoVendio = new List<ProductoVendido>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetIdVentaDeProductoVendido = "SELECT Id, IdVenta FROM [SistemaGestion].[dbo].[ProductoVendido] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetIdVentaDeProductoVendido, sqlConnection))
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
                                    ProductoVendido productoVendido = new ProductoVendido();
                                    productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                    productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);
                                    listaIdVentaDeProductoVendio.Add(productoVendido);
                                }
                            }
                            else
                            {
                                throw new ProductoVendidoValidatorError("ERROR AL INTENTAR OBTENER EL ID VENTA, POR FAVOR VERIFIQUE LA QUERY!");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (ProductoVendidoValidatorError ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return listaIdVentaDeProductoVendio;
        }

        //Get stock.
        public static List<ProductoVendido> GetStockProductoVendido(int id)
        {
            //Variable.
            List<ProductoVendido> listaStockDeProductoVendido = new List<ProductoVendido>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetStockDeProductoVendido = "SELECT Id, Stock FROM [SistemaGestion].[dbo].[ProductoVendido] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetStockDeProductoVendido, sqlConnection))
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
                                    ProductoVendido productoVendido = new ProductoVendido();
                                    productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                    productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                    listaStockDeProductoVendido.Add(productoVendido);
                                }
                            }
                            else
                            {
                                throw new ProductoVendidoValidatorError("ERROR AL INTENTAR CAMBIAR EL STOCK, POR FAVOR VERIFIQUE LA QUERY!");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (ProductoVendidoValidatorError ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return listaStockDeProductoVendido;
        }

        //Set id producto.
        public static bool SetIdProductoDeProductoVendido(ProductoVendido productoVendido)
        {
            //Variable.
            bool idProductoSeateado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySetIdProducto = "UPDATE [SistemaGestion].[dbo].[ProductoVendido]" +
                    "SET " +
                        "IdProducto = @idProducto" +
                    "WHERE Codigo = @id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetIdProducto, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = productoVendido.Id });
                        sqlCommand.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt) { Value = productoVendido.IdProducto });
                        int filasAfectadasDeCostoProducto = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeCostoProducto > 1)
                        {
                            Console.WriteLine("EL ID PRODUCTO FUE MODIFICADO CON EXITO!");
                            idProductoSeateado = true;
                        }
                        else
                        {
                            throw new Exception("ERROR AL INTENTAR CAMBIAR EL ID PRODUCTO, POR FAVOR VERIFIQUE LA QUERY!");
                            idProductoSeateado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return idProductoSeateado;
        }

        //Set id venta.
        public static bool SetIdVentaDeProductoVendido(ProductoVendido productoVendido)
        {
            //Variable.
            bool idVentaSeateado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySetIdVenta = "UPDATE [SistemaGestion].[dbo].[ProductoVendido]" +
                    "SET " +
                        "IdVenta = @idVenta" +
                    "WHERE Codigo = @id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetIdVenta, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = productoVendido.Id });
                        sqlCommand.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.BigInt) { Value = productoVendido.IdVenta });
                        int filasAfectadasDeStockProducto = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeStockProducto > 1)
                        {
                            Console.WriteLine("EL ID VENTA CAMBIADO CON EXITO!!");
                            idVentaSeateado = true;
                        }
                        else
                        {
                            throw new ProductoVendidoValidatorError("ERROR AL INTENTAR CAMBIAR EL ID VENTA, POR FAVOR VERIFIQUE LA QUERY!");
                            idVentaSeateado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (ProductoVendidoValidatorError ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return idVentaSeateado;
        }

        //Set stock.
        public static bool SetStockProductoVendido (ProductoVendido productoVendido)
        {
            //Variable.
            bool stockDeProductoVendidoSeateado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySetStockDeProductoVendido = "UPDATE [SistemaGestion].[dbo].[ProductoVendido]" +
                    "SET " +
                        "Stock = @stock" +
                    "WHERE Codigo = @id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetStockDeProductoVendido, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = productoVendido.Id });
                        sqlCommand.Parameters.Add(new SqlParameter("Stock", SqlDbType.BigInt) { Value = productoVendido.Stock });
                        int filasAfectadasDePrecioVentaProducto = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDePrecioVentaProducto > 1)
                        {
                            Console.WriteLine("STOCK CAMBIADO CON EXITO!!");
                            stockDeProductoVendidoSeateado = true;
                        }
                        else
                        {
                            throw new ProductoVendidoValidatorError("ERROR AL INTENTAR CAMBIAR EL STOCK, POR FAVOR VERIFIQUE LA QUERY!");
                            stockDeProductoVendidoSeateado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (ProductoVendidoValidatorError ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return stockDeProductoVendidoSeateado;
        }
    }
}
