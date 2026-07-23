using QuRadarSystem.Constants;
using QuRadarSystem.Models;

namespace QuRadarSystem.Specifications
{
    public class PrivateCarSpeedSpecification : ISpecification
    {

        public Violation CreateViolation(Observation observation)
            => new Violation
            {
                Description = $"speed of {observation.Speed} exceeded max allowed {PrivateCarSpeedConstants.MaxSpeed}",
                Amount = PrivateCarSpeedConstants.FineAmount
            };
        public bool IsSatisfiedBy(Observation observation)
            => observation.CarType == CarType.Private && observation.Speed > PrivateCarSpeedConstants.MaxSpeed;
    }
}