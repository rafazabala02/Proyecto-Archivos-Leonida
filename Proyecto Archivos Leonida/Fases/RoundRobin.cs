using Proyecto_Archivos_Leonida.Estructuras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Archivos_Leonida.Fases
{
    public class RoundRobin
    {
        //El round robin
        public (ColaConBicola<Registro> colaGuardado, ColaConBicola<Registro> colaEliminados) RoundRobinSimulator(
                ColaConBicola<Registro> canal1,
                ColaConBicola<Registro> canal2,
                ColaConBicola<Registro> canal3)
        {
            var colaGuardado = new ColaConBicola<Registro>();
            var colaEliminados = new ColaConBicola<Registro>();
            var pilaAuxiliar = new PilaConBicola<Registro>();
            int turno = 1;

            //Mientras los tres no esten vacios hacer
            while (!canal1.EstaVacia() || !canal2.EstaVacia() || !canal3.EstaVacia())
            {
                //Aqui creo canal actual para saber cual voy a estar
                ColaConBicola<Registro> canalActual;
                if (turno == 1)
                {
                    canalActual = canal1;
                }
                else if (turno == 2)
                {
                    canalActual = canal2;
                }
                else
                {
                    canalActual = canal3;
                }
                //Si el canal no esta vacio hace su proceso sino va con el otro
                if (!canalActual.EstaVacia())
                {
                    Registro registro = canalActual.Desencolar();
                    ProcesarOperacion(registro, colaGuardado, colaEliminados, pilaAuxiliar);
                }
                //Si el turno es 3 pasa a 1
                if (turno == 3)
                {
                    turno = 1;
                }
                else
                {
                    //sino solo lo incrementa
                    turno++;
                }
            }
            //Cuando termine que ya no hay mas ps, devuelve la colaguardado y la de eliminar
            return (colaGuardado, colaEliminados);
        }
        //Esta funcion es para que valide el tipo de operación
        public void ProcesarOperacion(Registro registro, ColaConBicola<Registro> ColaGuardar,
        ColaConBicola<Registro> ColaEliminar, PilaConBicola<Registro> pilaAux)
        {
            switch (registro.Operacion)
            {
                case "AUDIO":
                case "IMAGEN":
                case "TEXTO":
                    ColaGuardar.Encolar(registro);
                    break;

                case "DESTRUIR":
                    ColaEliminar.Encolar(registro);
                    break;

                case "INVERTIR":

                    Invertir(ColaGuardar, pilaAux);
                    break;
            }
        }
        //esta es cuando la operacion es invertir , uso la pila y la cola 
        public void Invertir(ColaConBicola<Registro> cola, PilaConBicola<Registro> pilaAux)
        {
            while (!cola.EstaVacia())
            {
                pilaAux.Apilar(cola.Desencolar());
            }
            while (!pilaAux.EstaVacia())
            {
                cola.Encolar(pilaAux.Desapilar());
            }
        }
    }
}