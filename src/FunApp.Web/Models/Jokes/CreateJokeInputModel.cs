using FunApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FunApp.Services.Models.Jokes
{
    public class CreateJokeInputModel
    {
        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        [DisplayName("Category")]
        [ValidCategoryId]
        public int CategoryId { get; set; }
    }
}
