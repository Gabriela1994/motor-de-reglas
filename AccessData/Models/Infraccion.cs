using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Infraccion
    {
        public int Id { get; set; }
        public int? IdVehiculo { get; set; }
        public int? IdTipoInfraccion { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }
        public int? IdEstadoInfraccion { get; set; }
        public string? Coordenada { get; set; }
        public double? MontoApagar { get; set; }
        public int? IdGravedad { get; set; }

        public virtual EstadoInfraccion? IdEstadoInfraccionNavigation { get; set; }
        public virtual Gravedad? IdGravedadNavigation { get; set; }
        public virtual TipoInfraccion? IdTipoInfraccionNavigation { get; set; }
        public virtual Vehiculo? IdVehiculoNavigation { get; set; }
    }
}
