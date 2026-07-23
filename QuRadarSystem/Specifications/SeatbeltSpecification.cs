using QuRadarSystem.Constants;
using QuRadarSystem.Models;

namespace QuRadarSystem.Specifications
{
    public class SeatbeltSpecification : ISpecification
    {
        public Violation CreateViolation(Observation observation)
            => observation.IsSeatbeltFastned == false ?
                   new Violation
                   {
                       Description = $"Seatbelt not fastened",
                       Amount = SeatbeltConstants.FineAmount
                   } :
                   new Violation { Description = "No seatbelt violation", Amount = 0 };

        public bool IsSatisfiedBy(Observation observation)
            => !observation.IsSeatbeltFastned;
    }
}