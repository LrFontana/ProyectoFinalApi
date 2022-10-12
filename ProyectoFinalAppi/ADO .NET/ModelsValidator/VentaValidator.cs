using Microsoft.Data.SqlClient;
using ProyectoFinalApi.ADO_.NET.Error.ValidatorErrors;
using ProyectoFinalAppi.Models;
using System.Data;

namespace ProyectoFinalApi.ADO_.NET.ModelsValidator
{
    public class VentaValidator
    {
        //Variable.
        private const string ConnectionString = @"Server=DESKTOP-A2H9T9K\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True;TrustServerCertificate=True;";


        //Logica Venta.

        //Get Id.
        public static List<Venta> GetIdVenta(int id)
        {
            //Variable.
            List<Venta> listaIdVenta = new List<Venta>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetIdVenta = "SELECT Id FROM [SistemaGestion].[dbo].[Venta] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetIdVenta, sqlConnection))
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
                                    Venta venta = new Venta();
                                    venta.Id = Convert.ToInt32(dataReader["Id"]);
                                    listaIdVenta.Add(venta);
                                }
                            }
                            else
                            {
                                throw new VentaValidatorError("ERROR AL INTENTAR OBTENER EL ID, POR FAVOR VERIFIQUE LA QUERY!");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (VentaValidatorError ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return listaIdVenta;
        }

        //Get comentarios.
        public static List<Venta> GetComentariosVenta(int id)
        {
            //Variable.
            List<Venta> listaComentariosVenta = new List<Venta>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetComentariosVenta = "SELECT Comentarios FROM [SistemaGestion].[dbo].[Venta] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetComentariosVenta, sqlConnection))
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
                                    Venta venta = new Venta();
                                    venta.Comentarios = dataReader["Comentarios"].ToString();
                                    listaComentariosVenta.Add(venta);
                                }
                            }
                            else
                            {
                                throw new VentaValidatorError("ERROR AL INTENTAR OBTENER LOS COMENTARIOS, POR FAVOR VERIFIQUE LA QUERY!");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (VentaValidatorError ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return listaComentariosVenta;
        }

        //Set Costo.
        public static bool SetComentariosVenta(Venta venta)
        {
            //Variable.
            bool comentariosVentaSeteado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySetComentariosVenta = "UPDATE [SistemaGestion].[dbo].[Venta]" +
                    "SET " +
                        "Comentarios = @Comentarios" +
                    "WHERE Codigo = @Id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetComentariosVenta, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                        int filasAfectadasDeNombreUsuario = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeNombreUsuario > 1)
                        {
                            Console.WriteLine("COMENTARIOS MODIFICADOS CON EXITO!");
                            comentariosVentaSeteado = true;
                        }
                        else
                        {
                            throw new VentaValidatorError("ERROR AL INTENTAR CAMBIAR LOS COMENTARIOS, POR FAVOR VERIFIQUE LA QUERY!");
                            comentariosVentaSeteado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (VentaValidatorError ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return comentariosVentaSeteado;
        }
    }
}
