using RecetasSLN.servicios.implementacion;
using RecetasSLN.servicios.interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.servicios
{
    internal class serviceFactoryImpl : abstractFactoryService
    {
        public override IServicio crearServicio()
        {
            return new ServicioNombre();
        }
    }
}
