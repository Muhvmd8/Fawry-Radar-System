using QuRadarSystem.Models;

namespace QuRadarSystem.Specifications
{
    public interface ISpecification
    {
        bool IsSatisfiedBy(Observation Observation);
        Violation CreateViolation(Observation Observation);
    }
}