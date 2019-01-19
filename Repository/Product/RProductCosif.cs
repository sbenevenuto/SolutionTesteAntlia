using Context;
using Repository.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Product
{
    public class RProductCosif : RRepository<Model.Product.ProductCosif>
    {
        public RProductCosif(SolutionContext context) : base(context)
        {

        }
    }
}
