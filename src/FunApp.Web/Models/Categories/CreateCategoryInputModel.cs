using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FunApp.Web.Models.Categories
{
    public class CreateCategoryInputModel
    {
        [Required]
        [MinLength(3)]
        [DisplayName("Category Name")]
        [ValidCategoryNameAttribute]
        public string CategoryName { get; set; }
    }
}
