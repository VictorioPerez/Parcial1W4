using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.servicios.interfaz
{
    internal interface IServicio
    {
        int proximoID();    //Nombre de la lista en este caso
                                //ingredientes
        List<Ingredientes> obtenerNombre();
        bool guardarAlta(Receta receta);
    }
}
