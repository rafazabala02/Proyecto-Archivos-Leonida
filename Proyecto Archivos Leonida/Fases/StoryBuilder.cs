using Proyecto_Archivos_Leonida.Estructuras;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;

namespace Proyecto_Archivos_Leonida.Fases
{
    public class Stringbuilder
    {
        public (Bicola<Pagina> paginas, string audio) StoryBuilder(ColaConBicola<Registro> colaGuardado)
        {
            Bicola<Pagina> bicolaPaginas = new Bicola<Pagina>();
            Image imagenActual = null;
            string audio = "";
            int numeroPagina = 1;
            while (!colaGuardado.EstaVacia())
            {
                Registro reg = colaGuardado.Desencolar();
                switch (reg.Operacion)
                {
                    case "AUDIO":
                        audio = reg.Payload;
                        break;

                    case "IMAGEN":
                        byte[] bytesImagen = Convert.FromBase64String(reg.Payload);
                        using (var ms = new MemoryStream(bytesImagen))
                        {
                            using (var imaTemporal = Image.FromStream(ms))
                            {
                                imagenActual = new Bitmap(imaTemporal);
                            }
                        }
                        break;

                    case "TEXTO":
                        string texto = DesifrarTexto(reg.Payload);
                        Pagina pagina = new Pagina(numeroPagina++, imagenActual, texto);
                        bicolaPaginas.InsertarAlFinal(pagina);
                        break;
                }
            }
            return (bicolaPaginas, audio);
        }
        private string DesifrarTexto(string Texto)
        {
            PilaConBicola<char> pila = new PilaConBicola<char>();

            foreach (char c in Texto)
            {
                pila.Apilar(c);
            }
            StringBuilder sb = new StringBuilder();
            while (!pila.EstaVacia())
            {
                sb.Append(pila.Desapilar());
            }

            return sb.ToString();
        }
    }
}