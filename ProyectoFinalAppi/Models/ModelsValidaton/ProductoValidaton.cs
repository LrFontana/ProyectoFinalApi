using Microsoft.Data.SqlClient;
using ProyectoFinalAppi.ADO_.NET.Error;
using ProyectoFinalAppi.Models;
using System.Data;

namespace ProyectoFinalApi.Models.GetModels
{
    public static class ProductoValidaton
    {
        //Variable.
        public const string ConnectionString = @"Server=DESKTOP-A2H9T9K\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True";
        

        //Logica Producto.

        //Obtener costo.
        public static List<Producto> GetCostoProducto(int id)
        {
            //Variable.
            List<Producto> listaCostoProducto = new List<Producto>();

            using(SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryObtenerCostoProducto = "SELECT Id, Costo, Descripciones FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryObtenerCostoProducto, sqlConnection)) 
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
                                    producto.Costo = Convert.ToInt32(dataReader["Costo"]);                                    
                                    listaCostoProducto.Add(producto);
                                }
                            }
                            else
                            {
                                throw new Exception("ERROR EN LA QUERY");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return listaCostoProducto;
        }           

        //Obtener stock.
        public static List<Producto> GetStockProducto(int id) 
        {
            //variable.
            List<Producto> listaStockProducto = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryObtenerStockProducto = "SELECT Id, Stock FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryObtenerStockProducto, sqlConnection))
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

                                    if (producto.Stock < 5)
                                    {
                                        Console.WriteLine("EL STOCK DE ESTE PRODUCTO ESTA MUY BAJO, DESEA AGREGAR MAS STOCK DE ESTE PRODUCTO?");
                                        Console.WriteLine("PRESIONE 'Y' PARA AGREGAR O 'N' PARA CONTINUAR: ");
                                        string confirmacionAgregarStock = Console.ReadLine();
                                        if (confirmacionAgregarStock.ToLower() == "y")
                                        {
                                            Console.WriteLine("INGRESE LA CANTIDAD DE STOCK QUE DESEA AGREGAR: ");
                                            int cantidadStock = Convert.ToInt32(Console.ReadLine());
                                            producto.Stock += cantidadStock;

                                            Console.WriteLine("MOSTRADO LISTA CON STOCK ACTUALIZADO.");
                                            listaStockProducto.Add(producto);
                                        }
                                        else
                                        {
                                            listaStockProducto.Add(producto);
                                        }
                                    }                                    
                                }                                
                            }
                            else
                            {
                                throw new Exception("ERROR EN LA QUERY");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return listaStockProducto;
        }        

        //Obtener precio de venta.
        public static List<Producto> GetPricioVentaProducto(int id) 
        {
            //Variable.
            List<Producto> listaPrecioDeVentaProducto = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryObtenerPrecioDeVenta = "SELECT Id, PrecioVenta FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryObtenerPrecioDeVenta, sqlConnection))
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
                                    producto.PrecioDeVenta = Convert.ToInt32(dataReader["PrecioVenta"]);                                    
                                    listaPrecioDeVentaProducto.Add(producto);
                                }
                            }
                            else
                            {
                                throw new Exception("ERROR EN LA QUERY");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return listaPrecioDeVentaProducto;
        }

        //Obtener descripcion.
        public static List<Producto> GetDescripcionProducto(int id) 
        {
            //Variable.
            List<Producto> listaDescripcionProducto = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryObtenerPrecioDeVenta = "SELECT Id, Descripciones FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryObtenerPrecioDeVenta, sqlConnection))
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
                                    producto.Descripcion = dataReader["Descripciones"].ToString();
                                    listaDescripcionProducto.Add(producto);
                                }
                            }
                            else
                            {
                                throw new Exception("ERROR EN LA QUERY");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return listaDescripcionProducto;
        }

        //Obtener Id usuario.
        public static List<Producto> GetIdUsuarioProducto(int id) 
        {
            //Variable.
            List<Producto> listaIdUsuarioProducto = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryObtenerPrecioDeVenta = "SELECT Id, IdUsuario FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryObtenerPrecioDeVenta, sqlConnection))
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
                                    producto.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                                    listaIdUsuarioProducto.Add(producto);
                                }
                            }
                            else
                            {
                                throw new Exception("ERROR EN LA QUERY");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return listaIdUsuarioProducto;
        }


        //Cambiar Costo.
        public static bool SetCostoProducto(int id) 
        {
            //Variable.
            bool costoSeateado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryObtenerPrecioDeVenta = "SELECT Costo FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @id";

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryObtenerPrecioDeVenta, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = id });                        
                        int costoProducto = sqlCommand.ExecuteNonQuery();

                        if (costoProducto > 1)
                        {
                            Producto producto = new Producto();
                            producto.Costo = 0;

                            Console.WriteLine("POR FAVOR INGRESE EL NUEVO COSTO");
                            int nuevoValorDeCosto = Convert.ToInt32(Console.ReadLine());                            
                            producto.Costo = nuevoValorDeCosto;

                            Console.WriteLine("EL COSTO DEL PRODUCTO FUE MODIFICADO !");
                            costoSeateado = true;
                        }
                        else
                        {
                            throw new Exception("ERROR EN LA QUERY");

                            costoSeateado =false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message); 
                }                
            }
            return costoSeateado;
        }        
    }
}
