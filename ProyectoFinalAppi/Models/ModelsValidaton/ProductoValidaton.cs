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
                                        Console.WriteLine("PRESIONE 'Y' PARA AGREGAR STOCK O 'N' PARA SALIR: ");
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
        public static List<Producto> GetPrecioVentaProducto(int id) 
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
                string queryObtenerDescripcionProducto = "SELECT Id, Descripciones FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryObtenerDescripcionProducto, sqlConnection))
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
                string queryObtenerUsuarioIdProducto = "SELECT Id, IdUsuario FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryObtenerUsuarioIdProducto, sqlConnection))
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
        public static bool SetCostoProducto(Producto producto) 
        {
            //Variable.
            bool costoSeateado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySetCostoProducto = "UPDATE [SistemaGestion].[dbo].[Producto]" +
                    "SET " +
                        "Costo = @costo" +
                    "WHERE Codigo = @id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetCostoProducto, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = producto.Id });                        
                        sqlCommand.Parameters.Add(new SqlParameter("Costo", SqlDbType.BigInt) { Value = producto.Costo });                        
                        int costoProducto = sqlCommand.ExecuteNonQuery();

                        if (costoProducto > 1)
                        {                           

                            Console.WriteLine("POR FAVOR INGRESE EL NUEVO COSTO");
                            int nuevoCostoProducto = Convert.ToInt32(Console.ReadLine());                            
                            producto.Costo = nuevoCostoProducto;

                            Console.WriteLine("EL COSTO DEL PRODUCTO FUE MODIFICADO CON EXITO!");
                            Console.WriteLine($"EL NUEVO COSTO DEL PRODUCTO ES: {producto.Costo}");
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

        //Cambiar stock.
        public static bool SetStockProducto(Producto producto) 
        {
            //Variable.
            bool stockSeateado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySetStockProducto = "UPDATE [SistemaGestion].[dbo].[Producto]" +
                    "SET " +                        
                        "Stock = @stock" +                        
                    "WHERE Codigo = @id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetStockProducto, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = producto.Id });
                        sqlCommand.Parameters.Add(new SqlParameter("Stock", SqlDbType.BigInt) { Value = producto.Stock });
                        int stockProducto = sqlCommand.ExecuteNonQuery();

                        if (stockProducto > 1)
                        {
                            Console.WriteLine("POR FAVOR INGRESE UNA NUEVA CANTIDAD DE STOCK: ");
                            int nuevoStockProducto = Convert.ToInt32(Console.ReadLine());
                            producto.Stock += nuevoStockProducto;

                            Console.WriteLine("STOCK CAMBIADO CON EXITO!!");
                            Console.WriteLine($"EL NUEVO STOCK DEL PRODUCTO ES: {producto.Stock}");
                            stockSeateado = true;
                        }
                        else
                        {
                            throw new Exception("ERROR EN LA QUERY");
                            stockSeateado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return stockSeateado;
        }

        //Cambiar precio de venta.
        public static bool SetPrecioVentaProducto(Producto producto) 
        {
            //Variable.
            bool precioVentaSeateado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySetPrecioVentaProducto = "UPDATE [SistemaGestion].[dbo].[Producto]" +
                    "SET " +
                        "PrecioVenta = @precioDeVenta" +
                    "WHERE Codigo = @id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetPrecioVentaProducto, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = producto.Id });
                        sqlCommand.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.BigInt) { Value = producto.PrecioDeVenta });
                        int precioVentaProducto = sqlCommand.ExecuteNonQuery();

                        if (precioVentaProducto > 1)
                        {
                            Console.WriteLine("POR FAVOR INGRESE UN NUEVO PRECIO DE VENTA: ");
                            int nuevoPrecioVentaProducto = Convert.ToInt32(Console.ReadLine());
                            producto.Stock = nuevoPrecioVentaProducto;

                            Console.WriteLine("PRECIO DE VENTA CAMBIADO CON EXITO!!");
                            Console.WriteLine($"EL NUEVO PRECIO DE VENTA DEL PRODUCTO ES: {producto.PrecioDeVenta}");
                            precioVentaSeateado = true;
                        }
                        else
                        {
                            throw new Exception("ERROR EN LA QUERY");
                            precioVentaSeateado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return precioVentaSeateado;
        }

        //Cambiar descripcion.
        public static bool SetDescripcionProducto(Producto producto) 
        {
            //Variable.
            bool descripcionSeateado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySetDescripcionProducto = "UPDATE [SistemaGestion].[dbo].[Producto]" +
                    "SET " +
                        "Descripciones = @descripcion" +
                    "WHERE Codigo = @id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetDescripcionProducto, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = producto.Id });
                        sqlCommand.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripcion });
                        int precioVentaProducto = sqlCommand.ExecuteNonQuery();

                        if (precioVentaProducto > 1)
                        {
                            Console.WriteLine("POR FAVOR INGRESE UNA NUEVA DESCRIPCION ");
                            String nuevaDescripcionProducto = Console.ReadLine();
                            producto.Descripcion = nuevaDescripcionProducto;

                            Console.WriteLine("DESCRIPCION CAMBIADA CON EXITO!!");
                            Console.WriteLine($"LA NUEVA DESCRIPCION DEL PRODUCTO ES: {producto.Descripcion}");
                            descripcionSeateado = true;
                        }
                        else
                        {
                            throw new Exception("ERROR EN LA QUERY");
                            descripcionSeateado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return descripcionSeateado;
        }

        //Cambiar id usuario.
        public static bool SetIdUsuarioProducto(Producto producto) 
        {
            //Variable.
            bool idUsuarioSeateado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySetiDuSUARIOProducto = "UPDATE [SistemaGestion].[dbo].[Producto]" +
                    "SET " +
                        "Categorias = @idUsuario" +
                    "WHERE Codigo = @id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetiDuSUARIOProducto, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = producto.Id });
                        sqlCommand.Parameters.Add(new SqlParameter("Categorias", SqlDbType.BigInt) { Value = producto.IdUsuario });
                        int idUsuarioProducto = sqlCommand.ExecuteNonQuery();

                        if (idUsuarioProducto > 1)
                        {
                            Console.WriteLine("POR FAVOR INGRESE EL NUEVO ID USUARIO: ");
                            int nuevoIdUsuarioProducto = Convert.ToInt32(Console.ReadLine());
                            producto.IdUsuario = nuevoIdUsuarioProducto;

                            Console.WriteLine("ID USUARIO CAMBIADO CON EXITO!!");
                            Console.WriteLine($"EL NUEVO ID USUARIO DEL PRODUCTO ES: {producto.IdUsuario}");
                            idUsuarioSeateado = true;
                        }
                        else
                        {
                            throw new Exception("ERROR EN LA QUERY");
                            idUsuarioSeateado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return idUsuarioSeateado;
        }
    }
}
