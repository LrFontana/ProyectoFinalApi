﻿using Microsoft.Data.SqlClient;
using ProyectoFinalAppi.Models;
using System.Data;


namespace ProyectoFinalAppi.ADO_.NET
{
    public static class UsuarioHandler 
    {
        //Variable DataBase.
        public const string ConnectionString = "Server=DESKTOP-A2H9T9K\\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True";

        //Funciones.

        //Borrar Usuario.
        public static bool EliminarUsuario(int id)
        {
            //Variable.
            bool eliminarUsuario = false;
            
            
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
                            Console.WriteLine("Usuario Eliminado con ¡EXITO!");
                            eliminarUsuario = true;
                        }
                        else
                        {
                            Console.WriteLine("ERROR! El usuario no se pudo eliminar, por favor intentelo de nuevo");
                            eliminarUsuario = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {

                    throw new Exception("Query definition error" + ex.Message); 
                }                
            }
            return eliminarUsuario;
        }

        //Agregar Usuario.
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

                        int cantidadDeUsuarioCreado = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeUsuarioCreado > 1)
                        {
                            Console.WriteLine("Usuario Ceado con exito");
                            return usuarioCreado = true;
                        }
                        else
                        {
                            Console.WriteLine("ERROR! El Usuario no se pudo crear, por favor intentelo de nuevo.");
                            return usuarioCreado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {

                    throw new Exception("Querry definition error " + ex.Message); 
                }                
            }
            return usuarioCreado;
            
        }

        //Actualizar Usuario.
        public static bool ModificarUsuario(Usuario usuario)
        {
            //Variable.
            bool modificarUsuario = false;
            
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

                        int cantidadDeFilasAfectadas = sqlCommand.ExecuteNonQuery();

                        if (cantidadDeFilasAfectadas > 1)
                        {
                            return modificarUsuario = true;
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Querry definition error " + ex.Message); 
                }
                
            }
            return modificarUsuario;
            
        }

        //Obtener Usuarios.
        public static List<Usuario> GetUsuarios()
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("   MOSTRANDO TODOS LOS USUARIOS  ");
            Console.WriteLine("*********************************\n");

            //Variable.
            List<Usuario> listaUsuario = new List<Usuario>();
            
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
                                    listaUsuario.Add(usuario);
                                }
                            }                            
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Query error definition " + ex.Message); 
                    }                    
                }
            }            
            return listaUsuario;
        }

        //Obtener usuarios por id.
        public static List<Usuario> GetUsuariosPorId(int id)
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("    MOSTRANDO USUARIOS POR ID    ");
            Console.WriteLine("*********************************\n");

            List<Usuario> listaUsuarioId = new List<Usuario>();

            
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
                                    listaUsuarioId.Add(usuario);
                                }
                            }
                            dataReader.Close();
                        }
                        sqlConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Querydefinition error" + ex.Message);
                    }                    
                }
            }            
            return listaUsuarioId;
        }
        
    }

}
