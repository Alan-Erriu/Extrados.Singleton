using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kioscos
{
    public class Usuario 
    {
        public int _Id {get ; set;}

        public string _Nombre {get ; set;}

        public byte _Edad {get ; set;}


        public Usuario(int id, string nombre, byte edad)
        {
            _Id = id;
            _Nombre = nombre;
            _Edad = edad;
        }
    }
}
