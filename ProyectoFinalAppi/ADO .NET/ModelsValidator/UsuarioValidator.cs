using Microsoft.Data.SqlClient;
using ProyectoFinalAppi.Models;
using System.Data;

namespace ProyectoFinalApi.Models.ModelsValidaton
{
    public class UsuarioValidator
    {
        //Variable.
        private const string ConnectionString = @"Server=DESKTOP-A2H9T9K\LEOGESTIO;DataBase=SistemaGestion;Trusted_connection=True";


        //Logica Usuario.

        //Get Id.
        public static List<Usuario> GetIdUsuario(int id)
        {
            //Variable.
            List<Usuario> listaIdUsuario = new List<Usuario>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetIdUsuario = "SELECT Id FROM [SistemaGestion].[dbo].[Usuario] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetIdUsuario, sqlConnection))
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
                                    Usuario usuarios = new Usuario();
                                    usuarios.Id = Convert.ToInt32(dataReader["Id"]);
                                    listaIdUsuario.Add(usuarios);
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
            return listaIdUsuario;
        }

        //Get nombre.
        public static List<Usuario> GetNombreUsuario(int id)
        {
            //Variable.
            List<Usuario> listaNombreUsuario = new List<Usuario>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetNombreUsuario = "SELECT Id, Nombre FROM [SistemaGestion].[dbo].[Usuario] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetNombreUsuario, sqlConnection))
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
                                    listaNombreUsuario.Add(usuario);
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
            return listaNombreUsuario;
        }

        //Get apellido.
        public static List<Usuario> GetApellidoUsuario(int id)
        {
            //variable.
            List<Usuario> listaApellidoUsuario = new List<Usuario>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetApellidoUsuario = "SELECT Id, Apellido FROM [SistemaGestion].[dbo].[Usuario] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetApellidoUsuario, sqlConnection))
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
                                    usuario.Apellido = dataReader["Stock"].ToString();
                                    listaApellidoUsuario.Add(usuario);
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
            return listaApellidoUsuario;
        }

        //Get nombre de usuario.
        public static List<Usuario> GetNombreDeUsuario(int id)
        {
            //Variable.
            List<Usuario> listaNombreDeUsuario = new List<Usuario>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetNombreDeUsuario = "SELECT Id, NombreUsuario FROM [SistemaGestion].[dbo].[Usuario] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetNombreDeUsuario, sqlConnection))
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
                                    usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                    listaNombreDeUsuario.Add(usuario);
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
            return listaNombreDeUsuario;
        }

        //Get mail.
        public static List<Usuario> GetMailUsuario(int id)
        {
            //Variable.
            List<Usuario> listaMailUsuario = new List<Usuario>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetMailUsuario = "SELECT Id, Mail FROM [SistemaGestion].[dbo].[Usuario] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetMailUsuario, sqlConnection))
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
                                    usuario.Mail = dataReader["Mail"].ToString();
                                    listaMailUsuario.Add(usuario);
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
            return listaMailUsuario;
        }

        //Get password.
        public static List<Usuario> GetPasswordUsuario(int id)
        {
            //Variable.
            List<Usuario> listaPasswordUsuario = new List<Usuario>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryGetPasswordUsuario = "SELECT Id, Contraseña FROM [SistemaGestion].[dbo].[Usuario] WHERE Id = @id";

                using (SqlCommand sqlCommand = new SqlCommand(queryGetPasswordUsuario, sqlConnection))
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
                                    usuario.Password = dataReader["Contraseña"].ToString();
                                    listaPasswordUsuario.Add(usuario);
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
            return listaPasswordUsuario;
        }


        //Set Costo.
        public static bool SetNombreUsiario(Usuario Usuario)
        {
            //Variable.
            bool nombreSeteado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySetNombreUsuaurio = "UPDATE [SistemaGestion].[dbo].[Usuario]" +
                    "SET " +
                        "Nombre = @nombre" +
                    "WHERE Codigo = @id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetNombreUsuaurio, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = Usuario.Id });
                        sqlCommand.Parameters.Add(new SqlParameter("Costo", SqlDbType.BigInt) { Value = Usuario.Nombre });
                        int filasAfectadasDeNombreUsuario = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeNombreUsuario > 1)
                        {
                            Console.WriteLine("NOMBRE MODIFICADO CON EXITO!");
                            nombreSeteado = true;
                        }
                        else
                        {
                            throw new Exception("ERROR EN LA QUERY");
                            nombreSeteado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return nombreSeteado;
        }

        //Set stock.
        public static bool SetApellidoUsuario(Usuario usuario)
        {
            //Variable.
            bool apellidoSeteado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySetApellidoUsuario = "UPDATE [SistemaGestion].[dbo].[Usuario]" +
                    "SET " +
                        "Apellido = @apellido" +
                    "WHERE Codigo = @id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetApellidoUsuario, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = usuario.Id });
                        sqlCommand.Parameters.Add(new SqlParameter("Stock", SqlDbType.BigInt) { Value = usuario.Apellido });
                        int filasAfectadasDeApellidoUsuario = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeApellidoUsuario > 1)
                        {
                            Console.WriteLine("APELLIDO CAMBIADO CON EXITO!!");
                            apellidoSeteado = true;
                        }
                        else
                        {
                            throw new Exception("ERROR EN LA QUERY");
                            apellidoSeteado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return apellidoSeteado;
        }

        //Set precio de venta.
        public static bool SetNombreDeUsuario(Usuario usuario)
        {
            //Variable.
            bool nombreDeUsuarioSeateado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySetNombreDeUsuario = "UPDATE [SistemaGestion].[dbo].[Usuario]" +
                    "SET " +
                        "NombreUsuario = @nombreUsuario" +
                    "WHERE Codigo = @id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetNombreDeUsuario, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = usuario.Id });
                        sqlCommand.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.BigInt) { Value = usuario.NombreUsuario });
                        int filasAfectadasDeNombreDeUsuario = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeNombreDeUsuario > 1)
                        {
                            Console.WriteLine("NOMBRE DE USUARIO CAMBIADO CON EXITO!!");
                            nombreDeUsuarioSeateado = true;
                        }
                        else
                        {
                            throw new Exception("ERROR EN LA QUERY");
                            nombreDeUsuarioSeateado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return nombreDeUsuarioSeateado;
        }

        //Set descripcion.
        public static bool SetMailUsuario(Usuario usuario)
        {
            //Variable.
            bool mailSeateado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySetMailUsuario = "UPDATE [SistemaGestion].[dbo].[Usuario]" +
                    "SET " +
                        "Mail = @mail" +
                    "WHERE Codigo = @id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetMailUsuario, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = usuario.Id });
                        sqlCommand.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = usuario.Mail });
                        int filasAfectadasDeMailUsuario = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDeMailUsuario > 1)
                        {
                            Console.WriteLine("MAIL CAMBIADO CON EXITO!!");
                            mailSeateado = true;
                        }
                        else
                        {
                            throw new Exception("ERROR EN LA QUERY");
                            mailSeateado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return mailSeateado;
        }

        //Set id usuario.
        public static bool SetPasswordUsuario(Usuario usuario)
        {
            //Variable.
            bool passwordSeateado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySetPasswordUsuario = "UPDATE [SistemaGestion].[dbo].[Usuario]" +
                    "SET " +
                        "Contraseña = @password" +
                    "WHERE Codigo = @id"; ;

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySetPasswordUsuario, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = usuario.Id });
                        sqlCommand.Parameters.Add(new SqlParameter("Categorias", SqlDbType.BigInt) { Value = usuario.Password });
                        int filasAfectadasDePasswordUsuario = sqlCommand.ExecuteNonQuery();

                        if (filasAfectadasDePasswordUsuario > 1)
                        {
                            Console.WriteLine("CONTRASE{A CAMBIADA CON EXITO!!");
                            passwordSeateado = true;
                        }
                        else
                        {
                            throw new Exception("ERROR EN LA QUERY");
                            passwordSeateado = false;
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return passwordSeateado;
        }
    }
}
