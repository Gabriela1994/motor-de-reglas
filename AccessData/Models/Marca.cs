using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Modelos = new HashSet<Modelo>();
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Modelo> Modelos { get; set; }
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
