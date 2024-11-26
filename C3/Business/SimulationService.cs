using C3.Domain.Services;
using LaverieEntities.Entities;


namespace C3.Business
{
    public class SimulationService
    {
        private readonly IDataService _dataService;
        private readonly INotificationService _notificationService;

        public SimulationService(IDataService dataService, INotificationService notificationService)
        {
            _dataService = dataService;
            _notificationService = notificationService;
        }

        public async Task SimulateLaundromatAsync(CancellationToken cancellationToken)
        {
            var proprietaires = await _dataService.GetProprietairesAsync(cancellationToken);

            foreach (var proprietaire in proprietaires)
            {
                foreach (var laverie in proprietaire.propLaverie)
                {
                    foreach (var machine in laverie.machinesLaverie)
                    {
                        // Choose the desired cycle to run
                        var desiredCycle = machine.cyclesMachine.FirstOrDefault(c => c.NomCycle == "Lavage Rapide");

                        // Run the machine with the desired cycle
                        RunMachine(machine, desiredCycle);

                        // Update the machine state
                        UpdateMachineState(machine);

                        // Notify the API
                        await _notificationService.NotifyAPIAsync(machine, cancellationToken);
                    }
                }
            }
        }

        private void RunMachine(Machine machine, Cycle cycle)
        {
            // Simulate running the machine with the specified cycle
            Console.WriteLine($"Running machine {machine.IdMachine} with cycle '{cycle.NomCycle}' ({cycle.DureeCycleHR} hours)");

            // Update the machine state to "En service"
            machine.EtatMachine = "En service";

            // Simulate the duration of the cycle
            Thread.Sleep(cycle.DureeCycleHR * 1000);
        }

        private void UpdateMachineState(Machine machine)
        {
            // Update the machine state to "Disponible"
            machine.EtatMachine = "Disponible";
        }
    }

}
