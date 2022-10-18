using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.ObjectPool;
using ProyectoFinalAppi.ADO_.NET.Error;
using ProyectoFinalAppi.Controllers.DTOS;
using ProyectoFinalAppi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace ProyectoFinalAppi.ADO_.NET
{
    public static class VentaHandler 
    {
        //Variable.
        public const string ConnectionString = "Server=DESKTOP-A2H9T9K\\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True;TrustServerCertificate=True;";

        //Funciones.

        //Eliminar Venta.
        public static bool EliminarVenta(int id)
        {
            //Varibale.
            bool ventaEliminada = false;            
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[Venta] WHERE Id = @Id;";                               

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@id", id);
                        int filasAfectadasDeVentaEliminada = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeVentaEliminada > 1)
                        {
                            Console.WriteLine("VENTA ELIMINADA CON EXITO!");
                            return ventaEliminada = true;
                        }
                        else
                        {
                            throw new EliminarErrorException("ERROR AL ELIMINAR LA VENTA! POR FAVOR VERIFIQUE LA QUERY");
                            return ventaEliminada = false;
                        }
                    }
                    sqlConnection.Close();
                }                
                catch (EliminarErrorException ex)
                {
                    Console.WriteLine(ex.Message);
                }                              
            }
            return ventaEliminada;

        }

        //Crear Venta.
        public static bool CrearVenta(Venta venta)
        {
            //Variable.
            bool ventaCreada = false;
                       
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryAdd = "INSERT INTO [SistemaGestion].[dbo].[Venta] (Comentarios)" +
                    "VALUES(@Comentarios)";
                
                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                        int filasAfectadasDeVentaCreada = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeVentaCreada > 1)
                        {
                            Console.WriteLine("VENTA CREADA CON EXITO!");
                            return ventaCreada = true;
                        }
                        else
                        {
                            throw new CrearErrorException("ERROR AL CREAR LA VENTA! POR FAVOR VERIFIQUE LA QUERY");
                            return ventaCreada = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (CrearErrorException ex)
                {
                    Console.WriteLine(ex.Message);
                }               
            }
            return ventaCreada;            
        }

        //Modificar Venta.
        public static bool ModificarVenta(Venta venta)
        {
            //Variable
            bool ventaModificada = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryUpdate = "UPDATE [SistemaGestion].[dbo].[Venta]" +
                    "SET " +                        
                        "Comentarios = @comentarios," +                            
                    "WHERE Id = @id"; 
                
                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Id", venta.Id);
                        sqlCommand.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                        int filasAfectadasDeVentaModificada = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeVentaModificada > 1)
                        {
                            Console.WriteLine("VENTA MODIFICADA CON EXITO!");
                            return ventaModificada = true;
                        }
                        else
                        {
                            throw new ModificarErrorException("ERROR AL MODIFICAR LA VENTA! POR FAVOR VERIFIQUE LA QUERY");
                            return ventaModificada = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (ModificarErrorException ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }
            return ventaModificada;
        }

        //Obtener Ventas.
        public static List<Venta> GetVentas(int id)
        {
            //Variable
            List<Venta> listaObtenerVentas = new List<Venta>();
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetVentas = "SELECT * FROM [SistemaGestion].[dbo].[Venta]";

                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand(queryGetVentas, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@id", id);
                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    Venta venta = new Venta();                                    
                                    venta.Comentarios = dataReader["Comentarios"].ToString();
                                    listaObtenerVentas.Add(venta);
                                }
                            }
                            else
                            {
                                throw new GetErrorException("ERROR AL OBTENER LAS VENTAS! POR FAVOR VERIFIQUE LA QUERY");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                }
                catch (GetErrorException ex)
                {
                    Console.WriteLine(ex.Message); 
                }                
            }
            return listaObtenerVentas;
        }

        //Carga Venta.
        public static bool CargarVenta(List<Producto> listaProducto, int idUsuario)
        {
            //Variable.
            bool ventaCargada = false;
            listaProducto = new List<Producto>();
            int idVenta = 0;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                try
                {
                    string cargarVenta = "INSERT INTO [SistemaGestion].[dbo].[Venta] (Comentarios, IdUsuario) VALUES(@Descripciones, @idUsuario); SELECT @@IDENTITY";

                    using (SqlCommand sqlCommand = new SqlCommand(cargarVenta, sqlConnection))
                    {
                        foreach (var producto in listaProducto)
                        {
                            sqlCommand.Parameters.AddWithValue("@Descripciones", producto.Descripciones);
                        }                        
                        sqlCommand.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        idVenta = Convert.ToInt32(sqlCommand.ExecuteScalar()); //devuelve la primer columna.
                        return idVenta > 0;                        
                    }
                    
                    string cargarProductoVendido = "INSERT INTO [SistemaGestion].[dbo].[ProductoVendido] (IdVenta, IdProducto, Stock) VALUES(@idVenta, @listaProducto, @listaProducto)";
                    
                    using (SqlCommand sqlCommand = new SqlCommand(cargarProductoVendido, sqlConnection))
                    {
                        foreach (var producto in listaProducto)
                        {
                            sqlCommand.Parameters.AddWithValue("@Stock", producto.Stock);
                            sqlCommand.Parameters.AddWithValue("@IdProducto",producto.Id);
                        }                        
                        sqlCommand.Parameters.AddWithValue("@IdVenta", (int)idVenta);                        
                        sqlCommand.ExecuteNonQuery();
                    }

                    string descontarStockProducto = "UPDATE [SistemaGestion].[dbo].[Producto] SET Stock = @listaProducto";

                    using (SqlCommand sqlCommand = new SqlCommand(descontarStockProducto, sqlConnection))
                    {
                        foreach (var producto in listaProducto)
                        {
                            sqlCommand.Parameters.AddWithValue("Stock", producto.Stock);
                        }                        
                        sqlCommand.ExecuteNonQuery();
                    }
                    ventaCargada = true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                sqlConnection.Close();
                listaProducto.Clear();
            }

            return ventaCargada;
        }

    }
}
