using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public int? IdRol { get; set; }

        public virtual Rol? IdRolNavigation { get; set; }
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
