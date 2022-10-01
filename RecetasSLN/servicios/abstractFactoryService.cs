using RecetasSLN.servicios.interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.servicios
{
    internal abstract class abstractFactoryService
    {
        public abstract IServicio crearServicio();
    }
}
