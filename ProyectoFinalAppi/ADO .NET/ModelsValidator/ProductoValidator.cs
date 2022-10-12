using Microsoft.Data.SqlClient;
using ProyectoFinalAppi.Models;
using System.Data;
using ProyectoFinalApi.ADO_.NET.Error.ValidatorErrors;

namespace ProyectoFinalApi.Models.GetModels
{
    public static class ProductoValidator
    {
        //Variable.
        private const string ConnectionString = @"Server=DESKTOP-A2H9T9K\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True;TrustServerCertificate=True;";        

        //Logica Producto.
        //Get Id.
        public static List<Producto> GetIdProducto(int id) 
        {
            //Variable.
            List<Producto> listaIdProducto = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetIdProducto = "SELECT Id FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetIdProducto, sqlConnection))
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
                                    listaIdProducto.Add(producto);
                                }
                            }
                            else
                            {
                                throw new ProductoValidatorError("ERROR AL INTENTAR OBTENER EL ID, POR FAVOR VERIFIQUE LA QUERY!");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (ProductoValidatorError ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return listaIdProducto;
        }
        //Get costo.
        public static List<Producto> GetCostoProducto(int id)
        {
            //Variable.
            List<Producto> listaCostoProducto = new List<Producto>();

            using(SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetCostoProducto = "SELECT Id, Costo, Descripciones FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetCostoProducto, sqlConnection)) 
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
                                    producto.Costo = Convert.ToInt32(dataReader["Costo"]);                                    
                                    listaCostoProducto.Add(producto);
                                }
                            }
                            else
                            {
                                throw new ProductoValidatorError("ERROR AL INTENTAR OBTENER EL COSTO, POR FAVOR VERIFIQUE LA QUERY!");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (ProductoValidatorError ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return listaCostoProducto;
        }
        //Get stock.
        public static List<Producto> GetStockProducto(int id) 
        {
            //variable.
            List<Producto> listaStockProducto = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetStockProducto = "SELECT Id, Stock FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetStockProducto, sqlConnection))
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
                                    listaStockProducto.Add(producto);
                                }                                
                            }
                            else
                            {
                                throw new ProductoValidatorError("ERROR AL INTENTAR OBTENER EL STOCK, POR FAVOR VERIFIQUE LA QUERY!");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (ProductoValidatorError ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return listaStockProducto;
        }
        //Get precio de venta.
        public static List<Producto> GetPrecioVentaProducto(int id) 
        {
            //Variable.
            List<Producto> listaPrecioDeVentaProducto = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetPrecioDeVenta = "SELECT Id, PrecioVenta FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetPrecioDeVenta, sqlConnection))
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
                                    producto.PrecioVenta = Convert.ToInt32(dataReader["PrecioVenta"]);                                    
                                    listaPrecioDeVentaProducto.Add(producto);
                                }
                            }
                            else
                            {
                                throw new ProductoValidatorError("ERROR AL INTENTAR OBTENER EL PRECIO DE VENTA, POR FAVOR VERIFIQUE LA QUERY!");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (ProductoValidatorError ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return listaPrecioDeVentaProducto;
        }
        //Get descripcion.
        public static List<Producto> GetDescripcionProducto(int id) 
        {
            //Variable.
            List<Producto> listaDescripcionProducto = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetDescripcionProducto = "SELECT Id, Descripciones FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetDescripcionProducto, sqlConnection))
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
                                    producto.Descripciones = dataReader["Descripciones"].ToString();
                                    listaDescripcionProducto.Add(producto);
                                }
                            }
                            else
                            {
                                throw new ProductoValidatorError("ERROR AL INTENTAR OBTENER LA DESCRIPCION, POR FAVOR VERIFIQUE LA QUERY!");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (ProductoValidatorError ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return listaDescripcionProducto;
        }
        //Get Id usuario.
        public static List<Producto> GetIdUsuarioProducto(int id) 
        {
            //Variable.
            List<Producto> listaIdUsuarioProducto = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetUsuarioIdProducto = "SELECT Id, IdUsuario FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetUsuarioIdProducto, sqlConnection))
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
                                    producto.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                                    listaIdUsuarioProducto.Add(producto);
                                }
                            }
                            else
                            {
                                throw new ProductoValidatorError("ERROR AL INTENTAR OBTENER EL ID USUARIO, POR FAVOR VERIFIQUE LA QUERY!");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (ProductoValidatorError ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return listaIdUsuarioProducto;
        }
        //Set Costo.
        public static bool SetCostoProducto(Producto producto) 
        {
            //Variable.
            bool costoSeateado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySetCostoProducto = "UPDATE [SistemaGestion].[dbo].[Producto]" +
                    "SET " +
                        "Costo = @Costo" +
                    "WHERE Codigo = @Id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetCostoProducto, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Costo", producto.Costo);
                        int filasAfectadasDeCostoProducto = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeCostoProducto > 1)
                        {  
                            Console.WriteLine("EL COSTO DEL PRODUCTO FUE MODIFICADO CON EXITO!");                            
                            costoSeateado = true;
                        }
                        else
                        {
                            throw new ProductoValidatorError("ERROR AL INTENTAR CAMBIAR EL COSTO, POR FAVOR VERIFIQUE LA QUERY!");
                            costoSeateado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (ProductoValidatorError ex)
                {
                    Console.WriteLine(ex.Message); 
                }                
            }
            return costoSeateado;
        }
        //Set stock.
        public static bool SetStockProducto(Producto producto) 
        {
            //Variable.
            bool stockSeateado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySetStockProducto = "UPDATE [SistemaGestion].[dbo].[Producto]" +
                    "SET " +                        
                        "Stock = @Stock" +                        
                    "WHERE Codigo = @Id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetStockProducto, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Stock", producto.Stock);
                        int filasAfectadasDeStockProducto = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeStockProducto > 1)
                        {
                            Console.WriteLine("STOCK CAMBIADO CON EXITO!!");                            
                            stockSeateado = true;
                        }
                        else
                        {
                            throw new ProductoValidatorError("ERROR AL INTENTAR CAMBIAR EL STOCK, POR FAVOR VERIFIQUE LA QUERY!");
                            stockSeateado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (ProductoValidatorError ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return stockSeateado;
        }
        //Set precio de venta.
        public static bool SetPrecioVentaProducto(Producto producto) 
        {
            //Variable.
            bool precioVentaSeateado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySetPrecioVentaProducto = "UPDATE [SistemaGestion].[dbo].[Producto]" +
                    "SET " +
                        "PrecioVenta = @PrecioVenta" +
                    "WHERE Codigo = @Id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetPrecioVentaProducto, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                        int filasAfectadasDePrecioVentaProducto = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDePrecioVentaProducto > 1)
                        {
                            Console.WriteLine("PRECIO DE VENTA CAMBIADO CON EXITO!!");                            
                            precioVentaSeateado = true;
                        }
                        else
                        {
                            throw new ProductoValidatorError("ERROR AL INTENTAR CAMBIAR EL PRECIO DE VENTA, POR FAVOR VERIFIQUE LA QUERY!");
                            precioVentaSeateado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (ProductoValidatorError ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return precioVentaSeateado;
        }
        //Set descripcion.
        public static bool SetDescripcionProducto(Producto producto) 
        {
            //Variable.
            bool descripcionSeateado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySetDescripcionProducto = "UPDATE [SistemaGestion].[dbo].[Producto]" +
                    "SET " +
                        "Descripciones = @Descripciones" +
                    "WHERE Codigo = @Id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetDescripcionProducto, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Descripciones", producto.Descripciones);
                        int filasAfectadasDeDescripcionProducto = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeDescripcionProducto > 1)
                        {
                            Console.WriteLine("DESCRIPCION CAMBIADA CON EXITO!!");                            
                            descripcionSeateado = true;
                        }
                        else
                        {
                            throw new ProductoValidatorError("ERROR AL INTENTAR CAMBIAR LA DESCRIPCION, POR FAVOR VERIFIQUE LA QUERY!");
                            descripcionSeateado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (ProductoValidatorError ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return descripcionSeateado;
        }
        //Set id usuario.
        public static bool SetIdUsuarioProducto(Producto producto) 
        {
            //Variable.
            bool idUsuarioSeateado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySetIdUsuarioProducto = "UPDATE [SistemaGestion].[dbo].[Producto]" +
                    "SET " +
                        "Categorias = @IdUsuario" +
                    "WHERE Codigo = @Id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetIdUsuarioProducto, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                        int filasAfectadasDeIdUsuarioProducto = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeIdUsuarioProducto > 1)
                        {
                            Console.WriteLine("ID DE USUARIO CAMBIADO CON EXITO!!");                            
                            idUsuarioSeateado = true;
                        }
                        else
                        {
                            throw new ProductoValidatorError("ERROR AL INTENTAR CAMBIAR EL ID USUARIO, POR FAVOR VERIFIQUE LA QUERY!");
                            idUsuarioSeateado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (ProductoValidatorError ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return idUsuarioSeateado;
        }
    }
}
