using Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.General
{
    public class BaseModel
    {
        [Display(Name = "LBL_CREATE_DATE", ResourceType = typeof(Resources))]
        [ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }
        [Display(Name = "LBL_MODIFIELD_DATE", ResourceType = typeof(Resources))]
        [ScaffoldColumn(false)]
        public DateTime ModifieldDate { get; set; }
    }
}
