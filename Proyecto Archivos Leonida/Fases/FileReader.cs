using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto_Archivos_Leonida.Fases
{
    public class FileReader
    {
        public string leer(string ruta)
        {
            return File.ReadAllText(ruta);
        }
    }
}