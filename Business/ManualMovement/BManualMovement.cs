using Business.General;
using Context;
using Repository.General;
using Repository.ManualMovement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ManualMovement
{
    public class BManualMovement : BRepository<Model.ManualMovement.ManualMovement>, IBManualMovement
    {
        public BManualMovement(SolutionContext context)
            : base(new RManualMovement(context))
        {

        }

    }

    public interface IBManualMovement : IRepository<Model.ManualMovement.ManualMovement>
    {

    }
}
