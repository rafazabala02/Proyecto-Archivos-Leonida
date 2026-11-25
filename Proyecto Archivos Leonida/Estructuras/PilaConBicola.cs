using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Archivos_Leonida.Estructuras
{
    public class PilaConBicola<T>
    {
        private Bicola<T> bicola;

        public PilaConBicola()
        {
            bicola = new Bicola<T>();
        }

        public bool Apilar(T valor)
        {
            return bicola.InsertarAlFrente(valor);
        }

        public T Desapilar()
        {
            return bicola.ExtraerAlFrente();
        }

        public T VerTope()
        {
            return bicola.esFrente();
        }

        public int Cantidad()
        {
            return bicola.Tamanio();
        }

        public bool EstaVacia()
        {
            return bicola.Vacia();
        }

        public void RecorrerPila()
        {
            bicola.Recorrer();
        }
    }
}
