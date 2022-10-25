using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreEntregaV3.Modelos
{
    public class Venta
    {
        public int id { get; set; }
        public string Comentarios { get; set; }
        public int IdUsuario { get; set; }

        public Venta()
        {
            id = 0;
            Comentarios = string.Empty;
            IdUsuario = 0;
        }
        public void TraerVentas()
        {

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-7065IJ2\\SQLEXPRESS";
            conecctionbuilder.InitialCatalog = "SistemaGestion44";
            conecctionbuilder.IntegratedSecurity = true;
            var conn = conecctionbuilder.ConnectionString;
            var ventas = new List<Venta>();

            Console.WriteLine("Ingrese el ID del Usuario");
            string user = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Venta WHERE IdUsuario = @idUser";


                var param = new SqlParameter();
                param.ParameterName = "idUser";
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                param.Value = user;
                cmd.Parameters.Add(param);

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ven = new Venta();

                        ven.id = Convert.ToInt32(reader.GetValue(0));
                        ven.Comentarios = reader.GetValue(1).ToString();
                        ven.IdUsuario = Convert.ToInt32(reader.GetValue(2));


                        ventas.Add(ven);

                    }
                    Console.WriteLine("------Usuario---------");
                    Console.WriteLine("\n");
                    foreach (var venta in ventas)
                    {
                        Console.WriteLine("id = " + venta.id);
                        Console.WriteLine("Comentarios = " + venta.Comentarios);
                        Console.WriteLine("IdUsuario = " + venta.IdUsuario);
                        Console.WriteLine("\n");
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("\n");


                    }
                }
            }

        }
    }
}
