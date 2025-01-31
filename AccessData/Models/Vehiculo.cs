using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataAccess.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Infracciones = new HashSet<Infraccion>();
        }

        public int Id { get; set; }
        public int? IdTipoVehiculo { get; set; }
        public string? Patente { get; set; }
        public string? Chasis { get; set; }
        public int? IdModelo { get; set; }

        public virtual Modelo? IdModeloNavigation { get; set; }
        public virtual TipoVehiculo? IdTipoVehiculoNavigation { get; set; }
        public virtual ICollection<Infraccion> Infracciones { get; set; }
    }
}
