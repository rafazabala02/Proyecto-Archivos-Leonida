using Proyecto_Archivos_Leonida.Estructuras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Archivos_Leonida.Fases
{
    public class ChannelEnqueuer
    {
        public void Encolar(string contenido, ColaConBicola<Registro> canal1,
            ColaConBicola<Registro> canal2, ColaConBicola<Registro> canal3)
        {
            foreach (string textolimpio in contenido.Split('\n'))
            {
                string linea = textolimpio.TrimEnd('\r');
                if (linea.Length == 0)
                {
                    continue;
                }

                Registro reg = Extraeregistro(linea);

                if (reg.Canal == 1)
                {
                    canal1.Encolar(reg);

                }
                else if (reg.Canal == 2)
                {
                    canal2.Encolar(reg);

                }
                else if (reg.Canal == 3)
                {
                    canal3.Encolar(reg);
                }

            }
        }

        private Registro Extraeregistro(string linea)
        {
            PilaConBicola<char> pila = new PilaConBicola<char>();
            StringBuilder buffer = new StringBuilder();

            int id = 0;
            int canal = 0;
            string operacion = "";
            string payload = "";

            foreach (char c in linea)
            {
                if (c == '(' || c == '[' || c == '<' || c == '{')
                {
                    pila.Apilar(c);
                    buffer.Clear();

                }
                else if (c == ')' || c == ']' || c == '>' || c == '}')
                {
                    char apertura = pila.Desapilar();
                    string valor = buffer.ToString();

                    switch (apertura)
                    {
                        case '(':

                            id = int.Parse(valor);
                            break;
                        case '[':

                            canal = int.Parse(valor);
                            break;

                        case '<':
                            operacion = valor;
                            break;

                        case '{':
                            payload = valor;
                            break;
                    }

                    buffer.Clear();
                }
                else if (!pila.EstaVacia())
                {
                    buffer.Append(c);
                }
            }

            return new Registro(id, canal, payload, operacion);

        }
    }
}
