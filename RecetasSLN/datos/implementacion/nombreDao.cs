using RecetasSLN.datos.interfaz;
using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace RecetasSLN.datos.implementacion
{
    internal class nombreDao : InombreDao
    {
        public bool crear(Receta receta)
        {
            return HelperDao.obtenerInstancia().CrearMaestroDetalleReceta("SP_INSERTAR_RECETA", "SP_INSERTAR_DETALLES", receta);
        }

        public int obtenerProximoID()
        {
            return HelperDao.obtenerInstancia().proximoID("SP_Proximo_ID","@next");
        }

        public List<Ingredientes> ToGetNombre()
        {
            List<Ingredientes> listaIngrediente = new List<Ingredientes>();
            DataTable tabla = HelperDao.obtenerInstancia().combo("SP_CONSULTAR_INGREDIENTES");
            foreach (DataRow dr in tabla.Rows)
            {
                //Ingreso las columnas de SQL en el dr[]
                Ingredientes ingrediente = new Ingredientes();
                ingrediente.ingredienteID = Convert.ToInt32(dr["id_ingrediente"]);
                ingrediente.nombre = (string)dr["n_ingrediente"];
                ingrediente.unidad = (string)dr["unidad_medida"];
                listaIngrediente.Add(ingrediente);
            }
            return listaIngrediente;
        }
    }
}
