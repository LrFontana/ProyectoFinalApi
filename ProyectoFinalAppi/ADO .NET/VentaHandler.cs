using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using ProyectoFinalAppi.ADO_.NET.Error;
using ProyectoFinalAppi.Models;
using System.Data;

namespace ProyectoFinalAppi.ADO_.NET
{
    public static class VentaHandler 
    {
        //Variable.
        public const string ConnectionString = "Server=DESKTOP-A2H9T9K\\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True";

        //Funciones.

        //Eliminar Venta.
        public static bool EliminarVenta(int id)
        {
            //Varibale.
            bool ventaEliminada = false;            
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[Venta] WHERE Id = @Id;";

                SqlParameter sqlParameter = new SqlParameter("Id", SqlDbType.BigInt) { Value = id };                

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {

                        sqlCommand.Parameters.Add(sqlParameter);

                        int cantidadDeVentasEliminadas = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeVentasEliminadas > 1)
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
                    "VALUES(@comentarios)";
                
                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = venta.Comentarios });

                        int cantidadDeVentasCreadas = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeVentasCreadas > 1)
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
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = venta.Id });
                        sqlCommand.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = venta.Comentarios });

                        int cantidadDeVentasModificadas = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeVentasModificadas > 1)
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
        public static List<Venta> GetVentas()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("        MOSTRANDO TODAS LAS VENTAS       ");
            Console.WriteLine("*****************************************\n");

            //Variable
            List<Venta> listaObtenerVentas = new List<Venta>();
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetVentas = "SELECT * FROM [SistemaGestion].[dbo].[Usuario]";

                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand(queryGetVentas, sqlConnection))
                    {
                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    Venta venta = new Venta();
                                    venta.Id = Convert.ToInt32(dataReader["Id"]);
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
    }
}
