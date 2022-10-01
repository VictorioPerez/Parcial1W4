using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos.interfaz
{
    internal interface InombreDao
    {
        int obtenerProximoID();
        List<Ingredientes> ToGetNombre();
        bool crear(Receta receta);
    }
}
