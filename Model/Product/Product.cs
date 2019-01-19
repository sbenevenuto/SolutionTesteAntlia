using Model.General;
using Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Product
{
    public class Product : BaseModel
    {
        [Key]
        [Display(Name = "LBL_CODE", ResourceType = typeof(Resources))]
        public int ProductId { get; set; }
        [Display(Name = "LBL_DESCRIPTION", ResourceType = typeof(Resources))]
        public string Description { get; set; }
    }
}
