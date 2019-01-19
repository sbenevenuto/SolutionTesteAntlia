using Model.General;
using Model.Product;
using Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.ManualMovement
{
    public class ManualMovement : BaseModel
    {
        [Key]
        [Display(Name = "LBL_CODE", ResourceType = typeof(Resources))]
        public int ManualMovementId { get; set; }
        [Display(Name = "LBL_MONTH", ResourceType = typeof(Resources))]
        public int Month { get; set; }
        [Display(Name = "LBL_YEAR", ResourceType = typeof(Resources))]
        public int Year { get; set; }
        [Display(Name = "LBL_PRODUCT", ResourceType = typeof(Resources))]
        public int ProductId { get; set; }
        public Product.Product Product { get; set; }
        [Display(Name = "LBL_PRODUCT_COSIF", ResourceType = typeof(Resources))]
        public int ProductCosifId { get; set; }
        public ProductCosif ProductCosif { get; set; }
        [Display(Name = "LBL_VALUE", ResourceType = typeof(Resources))]
        public decimal Value { get; set; }
        [Display(Name = "LBL_DESCRIPTION", ResourceType = typeof(Resources))]
        public string Description { get; set; }
    }
}
