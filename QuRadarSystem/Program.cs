using QuRadarSystem.Models;
using QuRadarSystem.Services;
using QuRadarSystem.Specifications;

namespace QuRadarSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var specifications = new List<ISpecification>
            {
                new TruckSpeedSpecification(),
                new PrivateCarSpeedSpecification(),
                new SeatbeltSpecification()
            };

            var fineCalculator = new FineCalculator(specifications);
            var fineService = new FineService(fineCalculator);

            var observation = new Observation
            {
                PlateNumber = "ABC1234",
                DateTime = DateTime.Now,
                CarType = CarType.Private,
                Speed = 94,
                IsSeatbeltFastned = false
            };

            fineService.Add(observation);

            Console.WriteLine("===== All Fines =====");

            foreach (var fine in fineService.GetAllFines())
            {
                Console.WriteLine($"Traffic");
                Console.WriteLine($"For car {fine.PlateNumber}");
                Console.WriteLine($"Total amount: {fine.TotalAmount} EGP");
                Console.WriteLine("Violations:");

                foreach (var violation in fine.Violations)
                {
                    Console.WriteLine($"- {violation.Description} : {violation.Amount} EGP");
                }

                Console.WriteLine();
            }

            Console.WriteLine("===== Violated Rules =====");

            foreach (var rule in fineService.GetViolatedRulesWithCount())
            {
                Console.WriteLine($"{rule.Key} : {rule.Value}");
            }
        }
    }
}
