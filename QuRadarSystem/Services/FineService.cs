using QuRadarSystem.Models;

namespace QuRadarSystem.Services
{
    public class FineService
    {
        private readonly FineCalculator _fineCalculator;
        private readonly List<Fine> _fines = new();

        public FineService(FineCalculator fineCalculator)
        {
            _fineCalculator = fineCalculator;
        }

        public Fine Add(Observation observation)
        {
            var fine = _fineCalculator.CalculateFine(observation);

            _fines.Add(fine);

            return fine;
        }

        public IReadOnlyList<Fine> GetAllFines()
            => _fines;

        public IEnumerable<Fine> GetAllPossibleFines()
            => _fines.Where(f => f.Violations.Any());
        public Dictionary<string, int> GetViolatedRulesWithCount()
            => _fines
                .SelectMany(f => f.Violations)
                .GroupBy(v => v.Description)
                .ToDictionary(
                    g => g.Key,
                    g => g.Count());
    }
}