using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Archivos_Leonida.Estructuras
{
    public class ColaConBicola<T>
    {
        private Bicola<T> bicola;

        public ColaConBicola()
        {
            bicola = new Bicola<T>();
        }

        public bool Encolar(T valor)
        {
            return bicola.InsertarAlFinal(valor);
        }

        public T Desencolar()
        {
            return bicola.ExtraerAlFrente();
        }

        public bool EstaVacia()
        {
            return bicola.Vacia();
        }

        public T VerFrente()
        {
            return bicola.esFrente();
        }

        public int Cantidad()
        {
            return bicola.Tamanio();
        }

        public void RecorrerCola()
        {
            bicola.Recorrer();
        }
    }
}
