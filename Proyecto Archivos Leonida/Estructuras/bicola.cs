using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Archivos_Leonida.Estructuras
{
    public class Bicola<T>
    {
        private Nodo<T> Frente;
        private Nodo<T> Final;
        private int contador;
        public Bicola()
        {
            Frente = null;
            Final = null;
            contador = 0;
        }
        public bool InsertarAlFinal(T valor)
        {
            Nodo<T> nuevoNodo = new Nodo<T>(valor);
            if (Vacia())
            {
                Frente = nuevoNodo;
                Final = nuevoNodo;
            }
            else
            {
                Final.Sig = nuevoNodo;
                nuevoNodo.Ant = Final;
                Final = nuevoNodo;
            }
            contador++;
            return true;
        }
        public bool InsertarAlFrente(T valor)
        {
            Nodo<T> nuevoNodo = new Nodo<T>(valor);
            if (Vacia())
            {
                Frente = nuevoNodo;
                Final = nuevoNodo;
            }
            else
            {
                nuevoNodo.Sig = Frente;
                Frente.Ant = nuevoNodo;
                Frente = nuevoNodo;
            }
            contador++;
            return true;

        }
        public T ExtraerAlFinal()
        {
            if (Vacia())
            {
                return default(T);
            }
            T ItemRetorno = Final.Dato;
            Nodo<T> nodoSacar = Final;
            if (Frente == Final)
            {
                Frente = null;
                Final = null;
            }
            else
            {
                Final = Final.Ant;
                Final.Sig = null;
            }
            contador--;
            return ItemRetorno;
        }
        public T ExtraerAlFrente()
        {
            if (Vacia())
            {
                return default(T);
            }
            Nodo<T> nodoSacar = Frente;
            T ItemRetorno = Frente.Dato;
            Frente = Frente.Sig;
            if (Frente == null)
            {
                Final = null;
            }
            else
            {
                Frente.Ant = null;
            }
            contador--;
            return ItemRetorno;
        }
        public bool Vacia()
        {
            return Frente == null;
        }
        public int Tamanio()
        {
            return contador;
        }
        public T Fondo()
        {
            if (Vacia())
            {
                return default(T);
            }
            return Final.Dato;
        }
        public T esFrente()
        {
            if (Vacia())
            {
                return default(T);
            }
            return Frente.Dato;
        }
        public void Recorrer()
        {
            Nodo<T> actual = Frente;
            while (actual != null)
            {
                Console.WriteLine(actual.Dato);
                actual = actual.Sig;
            }
        }
        public void RecorrerInversa()
        {
            Nodo<T> actual = Final;
            while (actual != null)
            {
                Console.WriteLine(actual.Dato);
                actual = actual.Ant;
            }
        }
    }
}
