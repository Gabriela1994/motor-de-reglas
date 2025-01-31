using DataAccess.Context;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class RepoVehiculo
    {
        private readonly IDbContextFactory<BdInfraccionesContext> _dbContextFactory;
        public RepoVehiculo(IDbContextFactory<BdInfraccionesContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public Vehiculo ObtenerVehiculoPorPatente(string patente)
        {
            try
            {
                using (var dbContext = _dbContextFactory.CreateDbContext())
                {
                    var vehiculo = dbContext.Vehiculos.Where(x => x.Patente == patente).FirstOrDefault();
                    return vehiculo;      
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
