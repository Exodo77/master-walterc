using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreEntregaV3.Modelos
{
    public class Usuarios
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Mail { get; set; }

        public Usuarios()
        {
            id = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            NombreUsuario = string.Empty;
            Contraseña = string.Empty;
            Mail = string.Empty;
        }
        public void TraerUsuario()
        {

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-7065IJ2\\SQLEXPRESS";
            conecctionbuilder.InitialCatalog = "SistemaGestion44";
            conecctionbuilder.IntegratedSecurity = true;
            var conn = conecctionbuilder.ConnectionString;
            var ListaUser = new List<Usuarios>();

            Console.WriteLine("Ingrese el Nombre del Usuario");
            string user = Console.ReadLine();

            Console.WriteLine();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = @UserNom";


                var param = new SqlParameter();
                param.ParameterName = "UserNom";
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                param.Value = user;
                cmd.Parameters.Add(param);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user2 = new Usuarios();

                        user2.id = Convert.ToInt32(reader.GetValue(0));
                        user2.Nombre = reader.GetValue(1).ToString();
                        user2.Apellido = reader.GetValue(2).ToString();
                        user2.NombreUsuario = reader.GetValue(3).ToString();
                        user2.Contraseña = reader.GetValue(4).ToString();
                        user2.Mail = reader.GetValue(5).ToString();

                        ListaUser.Add(user2);

                    }
                    Console.WriteLine("------Usuario---------");
                    Console.WriteLine("\n");
                    foreach (var user2 in ListaUser)
                    {
                        Console.WriteLine("id = " + user2.id);
                        Console.WriteLine("Nombre = " + user2.Nombre);
                        Console.WriteLine("Apellido = " + user2.Apellido);
                        Console.WriteLine("NombreUsuario = " + user2.NombreUsuario);
                        Console.WriteLine("Contraseña = " + user2.Contraseña);
                        Console.WriteLine("Mail = " + user2.Mail);
                        Console.WriteLine("\n");
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("\n");


                    }
                }
            }

        }
        public void IniciarSesion()
        {
            int getID = 0;
            string userName = string.Empty;
            string pass = string.Empty;
            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-7065IJ2\\SQLEXPRESS";
            conecctionbuilder.InitialCatalog = "SistemaGestion44";
            conecctionbuilder.IntegratedSecurity = true;
            var conn = conecctionbuilder.ConnectionString;


            var Usuario = new List<Usuarios>();

            Console.WriteLine("Ingrese Nombre de Usuario");
            userName = Console.ReadLine();
            Console.WriteLine("Ingrese Contraseña");
            pass = Console.ReadLine();


            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = @userName and Contraseña = @userPass;";


                var param = new SqlParameter();
                param.ParameterName = "userName";
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                param.Value = userName;
                cmd.Parameters.Add(param);

                var param2 = new SqlParameter();
                param2.ParameterName = "userPass";
                param2.SqlDbType = System.Data.SqlDbType.VarChar;
                param2.Value = pass;
                cmd.Parameters.Add(param2);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var User = new Usuarios();

                            User.id = Convert.ToInt32(reader.GetValue(0));
                            User.Nombre = reader.GetValue(1).ToString();
                            User.Apellido = reader.GetValue(2).ToString();
                            User.NombreUsuario = reader.GetValue(3).ToString();
                            User.Contraseña = reader.GetValue(4).ToString();
                            User.Mail = reader.GetValue(5).ToString();

                            Usuario.Add(User);

                        }
                        Console.WriteLine("------Datos Del Usuario---------");
                        Console.WriteLine("\n");
                        foreach (var User in Usuario)
                        {
                            Console.WriteLine("id = " + User.id);
                            Console.WriteLine("Nombre = " + User.Nombre);
                            Console.WriteLine("Apellido = " + User.Apellido);
                            Console.WriteLine("NombreUsuario = " + User.NombreUsuario);
                            Console.WriteLine("Contraseña = " + User.Contraseña);
                            Console.WriteLine("Mail = " + User.Mail);
                            Console.WriteLine("\n");
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("\n");

                        }
                    }
                    else
                    {
                        Console.WriteLine("El Usuario No Existe en la base de Datos!");
                        var usuario = new Usuarios();

                        Console.WriteLine("id = " + usuario.id);
                        Console.WriteLine("Nombre = " + usuario.Nombre);
                        Console.WriteLine("Apellido = " + usuario.Apellido);
                        Console.WriteLine("Nombre de Usuario = " + usuario.NombreUsuario);
                        Console.WriteLine("Contraseña = " + usuario.Contraseña);
                        Console.WriteLine("Mail = " + usuario.Mail);
                        Console.WriteLine("--------------");

                        
                    }

                }
            }

        }
    }
}
