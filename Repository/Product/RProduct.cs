using Context;
using Repository.General;

namespace Repository.Product
{
    public class RProduct : RRepository<Model.Product.Product>
    {
        public RProduct(SolutionContext context) : base(context)
        {

        }
    }
}
