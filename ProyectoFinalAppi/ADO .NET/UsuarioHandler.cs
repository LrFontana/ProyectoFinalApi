using Microsoft.Data.SqlClient;
using ProyectoFinalAppi.ADO_.NET.Error;
using ProyectoFinalAppi.Models;
using System.Data;


namespace ProyectoFinalAppi.ADO_.NET
{
    public static class UsuarioHandler 
    {
        //Variable DataBase.
        public const string ConnectionString = "Server=DESKTOP-A2H9T9K\\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True";

        //Funciones.

        //Eliminar Usuario.
        public static bool EliminarUsuario(int id)
        {
            //Variable.
            bool usuarioEliminado = false;            
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[Usuario] WHERE Id = @id;";

                SqlParameter sqlParameter = new SqlParameter("id", SqlDbType.BigInt) { Value = id};
                
                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(sqlParameter);
                        int cantidadDeUsuariosEliminado = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeUsuariosEliminado > 1)
                        {
                            Console.WriteLine("USUARIO ELIMINADO CON EXITO!");
                            usuarioEliminado = true;
                        }
                        else
                        {
                            throw new EliminarErrorException("ERROR AL ELIMINAR EL USUARIO! POR FAVOR VERIFIQUE LA QUERY");
                            usuarioEliminado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (EliminarErrorException ex)
                {
                    Console.WriteLine(ex.Message); 
                }                
            }
            return usuarioEliminado;
        }

        //Crear Usuario.
        public static bool CreartUsuario(Usuario usuario)
        {
            //Variable.
            bool usuarioCreado = false;

            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryAdd = "INSERT INTO [SistemaGestion].[dbo].[Usuario] (Nombre, Apellido, NombreUsuario, Contraseña, Mail)" +
                    "VALUES(@nombre, @apellido, @nombreUsuario, @contraseña, @mail)";

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.usuario_Nombre });
                        sqlCommand.Parameters.Add(new SqlParameter("Apellido", SqlDbType.BigInt) { Value = usuario.usuario_Apellido });
                        sqlCommand.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.BigInt) { Value = usuario.usuario_NombreUsuario });
                        sqlCommand.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.BigInt) { Value = usuario.usuario_Password });
                        sqlCommand.Parameters.Add(new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.usuario_Mail });

                        int cantidadDeUsuariosCreados = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeUsuariosCreados > 1)
                        {
                            Console.WriteLine("USUARIO CREADO CON EXITO!");
                            return usuarioCreado = true;
                        }
                        else
                        {
                            throw new CrearErrorException("ERROR AL CREAR EL USUARIO! POR FAVOR VERIFIQUE LA QUERY");
                            return usuarioCreado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (CrearErrorException ex)
                {
                    Console.WriteLine(ex.Message); 
                }                
            }
            return usuarioCreado;            
        }

        //Modificar Usuario.
        public static bool ModificarUsuario(Usuario usuario)
        {
            //Variable.
            bool usuarioModificado = false;
            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryUpdate = "UPDATE [SistemaGestion].[dbo].[Usuario]" +
                    "SET " +
                        "Nombre = @nombre," +
                        "Apellido = @apellido," +
                        "NombreUsuario = @nombreUsuario," +
                        "Contraseña = @password," +
                        "Mail = @mail" +
                    "WHERE Id = @id";

                try
                {
                    connection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, connection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.usuario_Nombre });
                        sqlCommand.Parameters.Add(new SqlParameter("Apellido", SqlDbType.BigInt) { Value = usuario.usuario_Apellido });
                        sqlCommand.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.BigInt) { Value = usuario.usuario_NombreUsuario });
                        sqlCommand.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.BigInt) { Value = usuario.usuario_Password });
                        sqlCommand.Parameters.Add(new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.usuario_Mail });

                        int cantidadDeUsuariosModificados = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeUsuariosModificados > 1)
                        {
                            Console.WriteLine("USUARIO CREADO CON EXITO!");
                            return usuarioModificado = true;
                        }
                        else
                        {
                            throw new ModificarErrorException("ERROR AL MODIFICAR EL USUARIO! POR FAVOR VERIFIQUE LA QUERY");
                        }
                    }
                    connection.Close();
                }
                catch (ModificarErrorException ex)
                {
                    Console.WriteLine(ex.Message); 
                }                
            }
            return usuarioModificado;            
        }

        //Obtener Usuarios.
        public static List<Usuario> GetUsuarios()
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("   MOSTRANDO TODOS LOS USUARIOS  ");
            Console.WriteLine("*********************************\n");

            //Variable.
            List<Usuario> listaGetUsuarios = new List<Usuario>();
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetUsuarios = "SELECT * FROM [SistemaGestion].[dbo].[Usuario]";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetUsuarios, sqlConnection))
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
                                    Usuario usuario = new Usuario();
                                    usuario.usuario_Id = Convert.ToInt32(dataReader["Id"]);
                                    usuario.usuario_Nombre = dataReader["Nombre"].ToString();
                                    usuario.usuario_Apellido = dataReader["Apellido"].ToString();
                                    usuario.usuario_NombreUsuario = dataReader["NombreUsuario"].ToString();
                                    usuario.usuario_Password = dataReader["Contraseña"].ToString();
                                    usuario.usuario_Mail = dataReader["Mail"].ToString();
                                    listaGetUsuarios.Add(usuario);
                                }
                            }
                            else
                            {
                                throw new GetErrorException("ERROR AL OBTENER LOS USUARIOS! POR FAVOR VERIFIQUE LA QUERY");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (GetErrorException ex)
                    {
                        Console.WriteLine(ex.Message); 
                    }                    
                }
            }            
            return listaGetUsuarios;
        }

        //Obtener usuarios por id.
        public static List<Usuario> GetUsuariosPorId(int id)
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("    MOSTRANDO USUARIOS POR ID    ");
            Console.WriteLine("*********************************\n");

            //Variable
            List<Usuario> listaGetUsuariosPorId = new List<Usuario>();
            
            using(SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetUsuariosId = "SELECT * FROM [SistemaGestion].[dbo].[Usuario]" +
                    "WHERE Id = @id";

                using(SqlCommand sqlCommand = new SqlCommand(queryGetUsuariosId, sqlConnection))
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
                                    Usuario usuario = new Usuario();
                                    usuario.usuario_Id = Convert.ToInt32(dataReader["Id"]);
                                    usuario.usuario_Nombre = dataReader["Nombre"].ToString();
                                    usuario.usuario_Apellido = dataReader["Apellido"].ToString();
                                    usuario.usuario_NombreUsuario = dataReader["NombreUsuario"].ToString();
                                    usuario.usuario_Password = dataReader["Contraseña"].ToString();
                                    usuario.usuario_Mail = dataReader["Mail"].ToString();
                                    listaGetUsuariosPorId.Add(usuario);
                                }
                            }
                            else
                            {
                                throw new GetErrorException("ERROR AL OBTENER LOS USUARIOS POR ID! POR FAVOR VERIFIQUE LA QUERY");
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (GetErrorException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }                    
                }
            }            
            return listaGetUsuariosPorId;
        }
        
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

                    using (SqlCommand sqlCommand = new SqlCommand(queryVerificarUsuario, sqlConnection))
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
                                    Console.WriteLine("ULTIMO INTENGO ANTES DE QUE EL PROGRAMA SE CIERRE");
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
                    Console.WriteLine(ex.Message);
                }
            }
            return logingExitoso;
        }
    }
}
