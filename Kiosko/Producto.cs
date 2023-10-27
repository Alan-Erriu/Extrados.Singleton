using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kioscos
{
    public class Producto 
    {
        public int _Id;
        public string _Nombre;
        public double _Precio;
        public int _Stock;
        public bool _ContieneAlcohol;
        public bool _AptoParaMenores;


        public Producto(int id,string nombre, double precio, int stock, bool contieneAlcohol, bool AptoParaMenores)
        {
            _Id = id;
            _Nombre = nombre;
            _Precio = precio;
            _Stock = stock;
            _ContieneAlcohol = contieneAlcohol;
            _AptoParaMenores = AptoParaMenores;
        }
    }

    
}
