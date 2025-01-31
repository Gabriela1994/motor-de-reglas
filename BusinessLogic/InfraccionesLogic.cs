using DataAccess.Models;
using DataAccess.Context;
using DataAccess.Repository;
using Newtonsoft.Json;
using RulesEngine.Models;

namespace BusinessLogic
{
    public class InfraccionesLogic
    {

        private readonly BdInfraccionesContext _context;
        private readonly RepoInfraccion _RepoInfraccion;
        private readonly RepoVehiculo _RepoVehiculo;
        public InfraccionesLogic(BdInfraccionesContext context, RepoInfraccion RepoInfraccion, RepoVehiculo RepoVehiculo)
        {
            _context = context;
            _RepoInfraccion = RepoInfraccion;
            _RepoVehiculo = RepoVehiculo;
        }
        public async void ProcesarInfracciones(List<EventoCamara> eventos_camara)
        {
            //aca pasa por el motor de reglas.
            string jsonRules = System.IO.File.ReadAllText("reglas_infracciones.json");
            var workflows = JsonConvert.DeserializeObject<Workflow[]>(jsonRules);
            var rulesEngine = new RulesEngine.RulesEngine(workflows, null);

            foreach (var evento in eventos_camara)
            {
                var vehiculo = _RepoVehiculo.ObtenerVehiculoPorPatente(evento.Patente);

                if (vehiculo == null)
                {
                    Console.WriteLine("No existe el vehiculo");
                    continue;
                }

                var inputs = new List<RuleParameter>
                {
                    new RuleParameter("Luces", evento.Luces),
                    new RuleParameter("ColorSemaforo", evento.ColorSemaforo),
                    new RuleParameter("PoseeCasco", evento.PoseeCasco),
                    new RuleParameter("Velocidad", evento.Velocidad),
                    new RuleParameter("IdTipoVehiculo", vehiculo.IdTipoVehiculo)
                };

                var results = await rulesEngine.ExecuteAllRulesAsync("infracciones", inputs.ToArray());

                foreach (var ruleResult in results)
                {
                    if (ruleResult.IsSuccess == true)
                    {
                        Infraccion infraccion = new Infraccion
                        {
                            IdVehiculo = vehiculo.Id,
                            IdEstadoInfraccion = 3,
                            IdTipoInfraccion = int.Parse(ruleResult.Rule.SuccessEvent),
                            Fecha = evento.Fecha,
                            Latitud = evento.Latitud,
                            Longitud = evento.Longitud
                        };

                        await _RepoInfraccion.AgregarInfraccionAsync(infraccion);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}