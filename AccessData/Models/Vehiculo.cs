using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Infraccions = new HashSet<Infraccion>();
        }

        public int Id { get; set; }
        public int? IdTipoVehiculo { get; set; }
        public int? IdUsuario { get; set; }
        public string? Patente { get; set; }
        public string? Chasis { get; set; }
        public int? IdModelo { get; set; }
        public int? IdMarca { get; set; }

        public virtual Marca? IdMarcaNavigation { get; set; }
        public virtual Modelo? IdModeloNavigation { get; set; }
        public virtual TipoVehiculo? IdTipoVehiculoNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<Infraccion> Infraccions { get; set; }
    }
}
