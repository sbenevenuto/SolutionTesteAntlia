using Context;
using Repository.General;

namespace Repository.ManualMovement
{
    public class RManualMovement : RRepository<Model.ManualMovement.ManualMovement>
    {
        public RManualMovement(SolutionContext context) : base(context)
        {

        }
    }
}
