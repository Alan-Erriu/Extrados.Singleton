using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kioscos
{

    public class Kiosco
    {


        public List<Producto> _productos = new List<Producto>();

        private object _lockObj = new object();

        private static readonly Kiosco instance = new Kiosco();

        private bool _enVeda = false;



        public void AgregarProducto(Producto nuevoProducto)
        {

            bool productoYaEnLista = _productos.Any(producto => producto._Id == nuevoProducto._Id);


            if (productoYaEnLista)
            {
               
                Producto producto = _productos.FirstOrDefault(p => p._Id == nuevoProducto._Id);
                lock (_lockObj)
                {  
                producto._Stock += nuevoProducto._Stock;
                }
                
                Console.WriteLine($"El stock de: {producto._Nombre} ahora es de: {producto._Stock} ");
                return;
            }

            Console.WriteLine($"Nuevo producto agregado: {nuevoProducto._Nombre}");
            lock (_lockObj)
            {
            _productos.Add(nuevoProducto);
            }


        }


        public void Vender(Producto productoAVender, Usuario usuario, int unidades, double dineroUsuario)
        {

            Producto producto = _productos.FirstOrDefault(p => p._Id == productoAVender._Id);

            if (producto == null) { Console.WriteLine($"No hay stock de {productoAVender._Nombre}"); return; }

            if (producto._Stock < unidades) { Console.WriteLine($"No hay suficiente stock de {productoAVender._Nombre}"); return; }

            if (!productoAVender._AptoParaMenores && usuario._Edad < 18) { Console.WriteLine($"El cliente {usuario._Nombre} es menor, no puede comprar {producto._Nombre}"); return; }

            if (productoAVender._ContieneAlcohol && this._enVeda) { Console.WriteLine($"Estamos en veda, no se puede vender: {producto._Nombre}"); return; }

            if (producto._Precio > dineroUsuario) { Console.WriteLine("El cliente no tiene suficiente dinero"); return; }
           
            lock (_lockObj)
            {
            producto._Stock -= unidades;
            }
            var vuelto = dineroUsuario - producto._Precio;
            Console.WriteLine($"Venta exitosa. El vuelto es: ${vuelto}, articulo vendido: {producto._Nombre}, stock restante: {producto._Stock}");

        }


        public void EnVedaElectoral(bool enVeda)
        { _enVeda = enVeda; }


        public void ProductosEnKiosco() {
            
            Console.WriteLine("Productos en el kiosko");
            foreach (var item in _productos)
            {
                Console.WriteLine($"nombre: {item._Nombre}, stock: {item._Stock}");
            }
        }

        private Kiosco()
        {
           // cumple la funcion de evitar que se instancie una nueva clase
            
        }


        public static Kiosco Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
