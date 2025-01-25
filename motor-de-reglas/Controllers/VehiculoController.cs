using DataAccess.Models;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace motor_de_reglas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        #region ContextDataBase
        private readonly BdInfraccionesContext _context;

        public VehiculoController(BdInfraccionesContext context)
        {
            _context = context;
        }
        #endregion


        // GET: api/<VehiculoController>
        [HttpGet]
        public List<Vehiculo> Get()
        {
            var lista = _context.Vehiculos.ToList();
            return lista;
        }

        // GET api/<VehiculoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VehiculoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VehiculoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VehiculoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
