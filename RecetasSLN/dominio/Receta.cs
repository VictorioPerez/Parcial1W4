using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    internal class Receta
    {
        public int recetaNro { get; set; }
        public string nombreReceta { get; set; }
        public int tipoReceta { get; set; }
        public string nombreCheff { get; set; }

        //Lista de detalles
        public List<DetalleRecetas> detalleRecetas { get; set; }
        public Receta()
        {
            detalleRecetas = new List<DetalleRecetas>();
        }

        public void agregarDetalle(DetalleRecetas detalleR)
        {
            detalleRecetas.Add(detalleR);
        }
        public void quitarDetalle(int posicion)
        {
            detalleRecetas.RemoveAt(posicion);
        }


    }
}
