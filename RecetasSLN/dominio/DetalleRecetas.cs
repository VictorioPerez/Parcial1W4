using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    public class DetalleRecetas
    {
        public DetalleRecetas(Ingredientes ingrediente, int cantidad)
        {
            this.ingrediente = ingrediente;
            this.cantidad = cantidad;
        }

        public Ingredientes ingrediente { get; set; }
        public int cantidad { get; set; }
    }
}
