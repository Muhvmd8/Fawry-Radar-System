using QuRadarSystem.Models;
using QuRadarSystem.Specifications;

namespace QuRadarSystem.Services
{
    public class FineCalculator
    {
        private readonly IEnumerable<ISpecification> _specifications;

        public FineCalculator(IEnumerable<ISpecification> specifications)
        {
            _specifications = specifications;
        }

        public Fine CalculateFine(Observation observation)
        {
            var violations = new List<Violation>();

            foreach (var specification in _specifications)
            {
                if (!specification.IsSatisfiedBy(observation))
                    continue;

                violations.Add(specification.CreateViolation(observation));
            }

            return new Fine
            {
                PlateNumber = observation.PlateNumber,
                Violations = violations,
                TotalAmount = violations.Sum(v => v.Amount)
            };
        }
    }
}
