using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Archivos_Leonida.Estructuras
{
    class Nodo<T>
    {
        public T Dato;
        public Nodo<T> Sig;
        public Nodo<T> Ant;

        public Nodo(T dato)
        {
            Dato = dato;
            Sig = null;
            Ant = null;
        }
    }
}
