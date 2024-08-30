using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    // Clase que representa un postre
    public class Postres
    {
        // Propiedad que almacena el ID del postre
        public int IdPostre { get; set; }

        // Propiedad que almacena el nombre del postre
        public string Nombre { get; set; }
        // Propiedad que almacena la descripción del postre
        public string Descripcion { get; set; }

        // Propiedad que almacena el precio del postre
        public decimal Precio { get; set; }

        // Propiedad que almacena la fecha de vencimiento del postre
        public DateTime FechaVencimiento { get; set; }

        // Propiedad que indica si el postre está disponible (estado)
        public bool Estado { get; set; }

        // Propiedad que almacena la cantidad en stock del postre
        public int Stock { get; set; }

        // Propiedad que almacena la cantidad de calorías del postre
        public int Calorias { get; set; }
    }
}
