using DataAccess.Context;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class RepoInfraccion
    {
        private readonly IDbContextFactory<BdInfraccionesContext> _dbContextFactory;

        public RepoInfraccion(IDbContextFactory<BdInfraccionesContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task AgregarInfraccionAsync(Infraccion infraccion)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                await dbContext.Infracciones.AddAsync(infraccion);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
