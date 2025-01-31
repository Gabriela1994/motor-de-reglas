using BusinessLogic;
using DataAccess.Clases;
using DataAccess.Context;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace motor_de_reglas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfraccionController : ControllerBase
    {
        private readonly BdInfraccionesContext _context;
        private readonly RepoInfraccion _RepoInfraccion;
        private readonly RepoVehiculo _RepoVehiculo;
        public InfraccionController(BdInfraccionesContext context, RepoInfraccion RepoInfraccion, RepoVehiculo RepoVehiculo)
        {
            _context = context;
            _RepoInfraccion = RepoInfraccion;
            _RepoVehiculo = RepoVehiculo;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("evaluar-infracciones")]
        public void EvaluarInfracciones(List<EventoCamara> eventos)
        {
            InfraccionesLogic infraccionesLogic = new InfraccionesLogic(_context, _RepoInfraccion, _RepoVehiculo);
            infraccionesLogic.ProcesarInfracciones(eventos);
        }
    }
}
