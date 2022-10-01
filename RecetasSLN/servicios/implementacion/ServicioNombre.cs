using RecetasSLN.datos.implementacion;
using RecetasSLN.datos.interfaz;
using RecetasSLN.dominio;
using RecetasSLN.servicios.interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.servicios.implementacion
{                   //ServicioRecetas
    internal class ServicioNombre : IServicio
    {
        private InombreDao dao;
        public ServicioNombre()
        {
            dao = new nombreDao();
        }

        public bool guardarAlta(Receta receta)
        {
            return dao.crear(receta);
        }

        public List<Ingredientes> obtenerNombre()
        {
            return dao.ToGetNombre();
        }
        public int proximoID()
        {
            return dao.obtenerProximoID();
        }
    }
}
