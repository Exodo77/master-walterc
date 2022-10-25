using PreEntregaV3.Modelos;
public class Program
{

    public static void Main(string[] args)
    {
        string OpcionElegida = string.Empty;

        while (OpcionElegida != "Z")
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Opcion A: Traer Usuario");
            Console.WriteLine("Opcion B: Traer Producto");
            Console.WriteLine("Opcion C: Traer Productos Vendidos");
            Console.WriteLine("Opcion D: Traer Ventas");
            Console.WriteLine("Opcion E: Inicio de sesión");

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Elige la opcion a Testear: A - B - C - D - E ");

            OpcionElegida = Console.ReadLine().ToUpper();
            Console.WriteLine("\n");

            switch (OpcionElegida)
            {
                case "A":
                    Usuarios usuario = new Usuarios();
                    usuario.TraerUsuario();                    
                    break;
                case "B":
                    Producto producto = new Producto();
                    producto.TraerProductos();
                    break;
                case "C":
                    ProductoVendido productoVendido = new ProductoVendido();
                    productoVendido.TraerProductosVendidos();
                    break;
                case "D":
                    Venta venta = new Venta();
                    venta.TraerVentas();
                    break;
                case "E":
                    Usuarios usuarios = new Usuarios();
                    usuarios.IniciarSesion();
                    break;
                default:
                    Console.WriteLine("La Opcion no es Correcta");
                    break;
            }
            Console.WriteLine("Preciona ENTER para intentar otra opcion");
            Console.ReadLine();
            Console.Clear();
        }
        
        OpcionElegida = Console.ReadLine().ToUpper();
        Console.WriteLine("\n");
    }
}