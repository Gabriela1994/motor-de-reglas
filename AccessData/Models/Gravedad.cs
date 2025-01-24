using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Gravedad
    {
        public Gravedad()
        {
            Infraccions = new HashSet<Infraccion>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Infraccion> Infraccions { get; set; }
    }
}
