using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreEntregaV3.Modelos
{
    public class ProductoVendido
    {
        public int id { get; set; }
        public int IdProducto { get; set; }
        public int Stock { get; set; }
        public int IdVenta { get; set; }

        public ProductoVendido()
        {
            id = 0;
            IdProducto = 0;
            Stock = 0;
            IdVenta = 0;
        }
        public void TraerProductosVendidos()
        {


            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "DESKTOP-7065IJ2\\SQLEXPRESS";
            conecctionbuilder.InitialCatalog = "SistemaGestion44";
            conecctionbuilder.IntegratedSecurity = true;
            var conn = conecctionbuilder.ConnectionString;

            var ListaProducto = new List<Producto>();
            var productoVendi = new List<ProductoVendido>();

            Console.WriteLine("Ingrese el Id del Usuario");
            string Iduser = Console.ReadLine();

            Console.WriteLine();

            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT P.Id, P.Descripciones, PV.Stock from Producto p inner join ProductoVendido pv on P.Id = PV.IdProducto where IdUsuario = @userId";


                var param = new SqlParameter();
                param.ParameterName = "userId";
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                param.Value = Iduser;
                cmd.Parameters.Add(param);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var producto = new Producto();
                        var pv = new ProductoVendido();

                        producto.id = Convert.ToInt32(reader.GetValue(0));
                        producto.Descripcion = reader.GetValue(1).ToString();
                        pv.Stock = Convert.ToInt32(reader.GetValue(2));

                        ListaProducto.Add(producto);
                        productoVendi.Add(pv);


                    }
                    Console.WriteLine("------Productos---------");
                    Console.WriteLine("\n");
                    foreach (var producto in ListaProducto)
                    {
                        Console.WriteLine("id = " + producto.id);
                        Console.WriteLine("Descripcion = " + producto.Descripcion);
                        Console.WriteLine("\n");
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("\n");
                    }
                    foreach (var pv in productoVendi)
                    {
                        Console.WriteLine("Vendidos = " + pv.Stock);
                    }
                }
            }
        }
    }
}
