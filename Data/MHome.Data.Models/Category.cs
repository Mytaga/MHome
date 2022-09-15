using MHome.Data.Common.Models;
using MHome.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MHome.Data.Models
{
    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Furnitures = new List<Furniture>();
        }

        [Required]
        [MaxLength(CategoryValidationConstants.NameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Furniture> Furnitures { get; set; }
    }
}