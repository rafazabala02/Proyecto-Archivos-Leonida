using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Proyecto_Archivos_Leonida.Estructuras
{
    public class Pagina
    {
        public int Numero;
        public Image Imagen;
        public string Descripcion;

        public Pagina() { }

        public Pagina(int numero, Image imagen, string descripcion)
        {
            Numero = numero;
            Imagen = imagen;
            Descripcion = descripcion;
        }
    }
}
