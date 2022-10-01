using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    public class Ingredientes
    {
        public Ingredientes()
        {
        }

        public Ingredientes(int ingredienteID, string nombre, string unidad)
        {
            this.ingredienteID = ingredienteID;
            this.nombre = nombre;
            this.unidad = unidad;
        }

        public int ingredienteID { get; set; }
        public string nombre { get; set; }
        public string unidad { get; set; }
    }
}
