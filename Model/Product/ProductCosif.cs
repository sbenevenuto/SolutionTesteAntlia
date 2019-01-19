using Model.General;
using Resource;
using System.ComponentModel.DataAnnotations;

namespace Model.Product
{
    public class ProductCosif : BaseModel
    {
        [Key]
        [Display(Name = "LBL_CODE", ResourceType = typeof(Resources))]
        public int ProductCosifId { get; set; }
        [Display(Name = "LBL_CODE_COSIF", ResourceType = typeof(Resources))]
        public int CodProductCosif { get; set; }
    }
}
