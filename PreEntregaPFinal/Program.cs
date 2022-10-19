using PreEntregaPFinal.Models;
using PreEntregaPFinal.Handlers;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;




class Program
{
    static void Main(string[] args)
    {
        var listaUsuario = new List<Usuario>();
        var listaProducto = new List<Producto>();
        var listaProductoVendido = new List<ProductoVendido>();
        var listaVenta = new List<Venta>();

        SqlConnectionStringBuilder conecctionbuilder = new();
        conecctionbuilder.DataSource = "DESKTOP-7065IJ2\\SQLEXPRESS";
        conecctionbuilder.InitialCatalog = "SistemaGestion";
        conecctionbuilder.IntegratedSecurity = true;
        var cs = conecctionbuilder.ConnectionString;


        using (SqlConnection conn = new SqlConnection(cs))
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            

        }
    }
}
