using Business.General;
using Context;
using Repository.General;
using Repository.Product;

namespace Business.Product
{
    public class BProduct : BRepository<Model.Product.Product>, IBProduct
    {
        public BProduct(SolutionContext context)
            : base(new RProduct(context))
        {

        }

    }

    public interface IBProduct : IRepository<Model.Product.Product>
    {

    }
}
