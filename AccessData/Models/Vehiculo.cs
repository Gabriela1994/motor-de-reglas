using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataAccess.Models
{
    public partial class Vehiculo
    {
        public int Id { get; set; }
        public int? IdTipoVehiculo { get; set; }
        public string? Patente { get; set; }
        public string? Chasis { get; set; }
        public int? IdModelo { get; set; }
        public int? IdMarca { get; set; }

        [JsonIgnore]
        public virtual Marca? IdMarcaNavigation { get; set; }
        [JsonIgnore]
        public virtual Modelo? IdModeloNavigation { get; set; }
        [JsonIgnore]
        public virtual TipoVehiculo? IdTipoVehiculoNavigation { get; set; }
    }
}
