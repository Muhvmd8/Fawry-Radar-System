using QuRadarSystem.Constants;
using QuRadarSystem.Models;

namespace QuRadarSystem.Specifications
{
    public class TruckSpeedSpecification : ISpecification
    {
        public Violation CreateViolation(Observation observation)
            => new Violation
            {
                Description = $"- speed of {observation.Speed} exceeded max allowed {TrunkCarSpeedConstants.MaxSpeed}",
                Amount = PrivateCarSpeedConstants.FineAmount
            };

        public bool IsSatisfiedBy(Observation observation)
            => observation.CarType == CarType.Truck && observation.Speed > 60;
    }
}