using Microsoft.Data.SqlClient;
using ProyectoFinalAppi.Models;
using System.Data;

namespace ProyectoFinalAppi.ADO_.NET
{
    public static class InicioDeSesionHandler
    {
        //Variable DataBase.
        public const string ConnectionString = "Server=DESKTOP-A2H9T9K\\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True";

        //Verificar usuario.
        public static bool VerificarUsuario(string nombre, string password) 
        {
            int cont = 0;
            bool logingExitoso = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryVerificarUsuario = "SELECT * FROM [SistemaGestion].[dbo].[Usuario] WHERE Nombre = @nombre, Contraseña = @contraseña";

                try
                {
                    sqlConnection.Open();

                    using(SqlCommand sqlCommand = new SqlCommand(queryVerificarUsuario, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = nombre });
                        sqlCommand.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = password });

                        sqlCommand.ExecuteNonQuery();

                        do
                        {
                            if (password == password)
                            {
                                logingExitoso = true;
                            }
                            else
                            {
                                Console.WriteLine("PASWORD INCORRECTA, por favor vuelva a intentarlo");
                            }

                            cont++;

                            if (cont > 5)
                            {
                                if (cont == 4)
                                {
                                    Console.WriteLine("ULTIMO INTENGO ANTES DE QUE LA APP SE CIERRE");
                                }
                                break;
                            }

                        } while (logingExitoso is false);


                        if (logingExitoso)
                        {                            
                            Console.WriteLine("BIENVENIDO!!!");
                            return logingExitoso = true;
                        }
                        else
                        {
                            Console.WriteLine("ERROR AL LOGEARSE");
                            return logingExitoso = false;
                        }                        

                    }

                    sqlConnection.Open();
                }
                catch (Exception ex)
                {

                    throw new Exception("Query definition error " + ex.Message);
                }
            }
            return logingExitoso;
        }
    }
}
