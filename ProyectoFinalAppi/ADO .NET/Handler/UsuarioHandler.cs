using Microsoft.Data.SqlClient;
using ProyectoFinalAppi.ADO_.NET.Error;
using ProyectoFinalAppi.Models;
using System.Data;


namespace ProyectoFinalAppi.ADO_.NET
{
    public static class UsuarioHandler 
    {
        //Variable.
        public const string ConnectionString = "Server=DESKTOP-A2H9T9K\\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True";

        //Funciones.

        //Eliminar Usuario.
        public static bool EliminarUsuario(long id)
        {
            //Variable.
            bool usuarioEliminado = false;            
            
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[Usuario] WHERE Id = @id";                                

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = id });                        
                        
                        int filasAfectadasDeUsuarioEliminado = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeUsuarioEliminado > 1)
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
                    "VALUES(@Nombre, @Apellido, @NombreUsuario, @Contraseña, @Mail)";

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.Nombre });
                        sqlCommand.Parameters.Add(new SqlParameter("Apellido", SqlDbType.BigInt) { Value = usuario.Apellido });
                        sqlCommand.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.BigInt) { Value = usuario.NombreUsuario });
                        sqlCommand.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.BigInt) { Value = usuario.Contraseña });
                        sqlCommand.Parameters.Add(new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.Mail });

                        int filasAfectadasDeUsuarioCreado = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeUsuarioCreado > 1)
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
                        "Nombre = @Nombre," +
                        "Apellido = @Apellido," +
                        "NombreUsuario = @NombreUsuario," +
                        "Contraseña = @Contraseña," +
                        "Mail = @Mail" +
                    "WHERE Id = @Id";

                try
                {
                    connection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, connection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                        sqlCommand.Parameters.Add(new SqlParameter("Apellido", SqlDbType.BigInt) { Value = usuario.Apellido });
                        sqlCommand.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.BigInt) { Value = usuario.NombreUsuario });
                        sqlCommand.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.BigInt) { Value = usuario.Contraseña });
                        sqlCommand.Parameters.Add(new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.Mail });

                        int filasAfectadasDeUsuarioModificado = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeUsuarioModificado > 1)
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
                                    usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                    usuario.Nombre = dataReader["Nombre"].ToString();
                                    usuario.Apellido = dataReader["Apellido"].ToString();
                                    usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                    usuario.Contraseña = dataReader["Contraseña"].ToString();
                                    usuario.Mail = dataReader["Mail"].ToString();
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
        public static List<Usuario> GetUsuariosPorId(long id)
        {
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
                                    usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                    usuario.Nombre = dataReader["Nombre"].ToString();
                                    usuario.Apellido = dataReader["Apellido"].ToString();
                                    usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                    usuario.Contraseña = dataReader["Contraseña"].ToString();
                                    usuario.Mail = dataReader["Mail"].ToString();
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
        public static bool VerificarUsuario(string nombre, string contraseña)
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
                        sqlCommand.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = contraseña });

                        sqlCommand.ExecuteNonQuery();

                        do
                        {
                            if (contraseña == contraseña && nombre == nombre)
                            {
                                logingExitoso = true;
                            }
                            else
                            {
                                Console.WriteLine("PASWORD  O NOMBRE INCORRECTO, por favor vuelva a intentarlo");
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
