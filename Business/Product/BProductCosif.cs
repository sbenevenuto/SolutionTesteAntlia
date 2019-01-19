using Business.General;
using Context;
using Repository.General;
using Repository.Product;

namespace Business.Product
{
    public class BProductCosif : BRepository<Model.Product.ProductCosif>, IBProductCosif
    {
        public BProductCosif(SolutionContext context)
            : base(new RProductCosif(context))
        {

        }

    }

    public interface IBProductCosif : IRepository<Model.Product.ProductCosif>
    {

    }
}
