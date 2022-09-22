﻿using Microsoft.Data.SqlClient;
using ProyectoFinalAppi.Models;
using System.Data;

namespace ProyectoFinalApi.ADO_.NET.ModelsValidator
{
    public class VentaValidator
    {
        //Variable.
        private const string ConnectionString = @"Server=DESKTOP-A2H9T9K\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True";


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
                                    Venta venta = new Venta();
                                    venta.Id = Convert.ToInt32(dataReader["Id"]);
                                    listaIdVenta.Add(venta);
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
            return listaIdVenta;
        }

        //Get comentarios.
        public static List<Venta> GetComentariosVenta(int id)
        {
            //Variable.
            List<Venta> listaComentariosVenta = new List<Venta>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetComentariosVenta = "SELECT Id, Comentarios FROM [SistemaGestion].[dbo].[Venta] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetComentariosVenta, sqlConnection))
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
                                    Venta venta = new Venta();
                                    venta.Id = Convert.ToInt32(dataReader["Id"]);
                                    venta.Comentarios = dataReader["Comentarios"].ToString();
                                    listaComentariosVenta.Add(venta);
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
                        "Comentarios = @comentarios" +
                    "WHERE Codigo = @id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetComentariosVenta, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = venta.Id });
                        sqlCommand.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.BigInt) { Value = venta.Comentarios });
                        int filasAfectadasDeNombreUsuario = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeNombreUsuario > 1)
                        {
                            Console.WriteLine("COMENTARIOS MODIFICADOS CON EXITO!");
                            comentariosVentaSeteado = true;
                        }
                        else
                        {
                            throw new Exception("ERROR EN LA QUERY");
                            comentariosVentaSeteado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return comentariosVentaSeteado;
        }
    }
}
