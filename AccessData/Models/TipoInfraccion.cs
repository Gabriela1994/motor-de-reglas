using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class TipoInfraccion
    {
        public TipoInfraccion()
        {
            Infracciones = new HashSet<Infraccion>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Infraccion> Infracciones { get; set; }
    }
}
