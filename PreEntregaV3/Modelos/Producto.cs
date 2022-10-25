using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreEntregaV3.Modelos
{
    public class Producto
    {
        public int id { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }

        public Producto()
        {
            id = 0;
            Descripcion = string.Empty;
            Costo = 0;
            PrecioVenta = 0;
            Stock = 0;
            IdUsuario = 0;
        }
        public void TraerProductos()
        {
            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-7065IJ2\\SQLEXPRESS";
            conecctionbuilder.InitialCatalog = "SistemaGestion44";
            conecctionbuilder.IntegratedSecurity = true;
            var conn = conecctionbuilder.ConnectionString;
            var ListaProducto = new List<Producto>();

            Console.WriteLine("Ingrese el Id del Usuario");
            string Iduser = Console.ReadLine();

            Console.WriteLine();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Producto WHERE IdUsuario = @UserId";


                var param = new SqlParameter();
                param.ParameterName = "UserId";
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                param.Value = Iduser;
                cmd.Parameters.Add(param);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var producto = new Producto();

                        producto.id = Convert.ToInt32(reader.GetValue(0));
                        producto.Descripcion = reader.GetValue(1).ToString();
                        producto.Costo = Convert.ToInt32(reader.GetValue(2));
                        producto.PrecioVenta = Convert.ToInt32(reader.GetValue(3));
                        producto.Stock = Convert.ToInt32(reader.GetValue(4));
                        producto.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                        ListaProducto.Add(producto);

                    }
                    Console.WriteLine("------Productos---------");
                    Console.WriteLine("\n");
                    foreach (var producto in ListaProducto)
                    {
                        Console.WriteLine("id = " + producto.id);
                        Console.WriteLine("Descripcion = " + producto.Descripcion);
                        Console.WriteLine("Costo = " + producto.Costo);
                        Console.WriteLine("PrecioVenta = " + producto.PrecioVenta);
                        Console.WriteLine("Stock = " + producto.Stock);
                        Console.WriteLine("IdUsuario = " + producto.IdUsuario);
                        Console.WriteLine("\n");
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("\n");


                    }
                }
            }

        }
    }
}
