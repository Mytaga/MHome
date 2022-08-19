using MHome.Data.Common.Models;
using MHome.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHome.Data.Models
{
    public class Store : BaseDeletableModel<string>
    {
        public Store()
        {
            this.Id = Guid.NewGuid().ToString();
            this.FurnitureForSale = new List<Furniture>();
            this.AccessoriesForSale = new List<Accessory>();
        }

        [Required]
        [MaxLength(StoreValidationConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(StoreValidationConstants.AddressMaxLength)]
        public string Address { get; set; }

        [Required]
        [MaxLength(StoreValidationConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        public virtual ICollection<Furniture> FurnitureForSale { get; set; }

        public virtual ICollection<Accessory> AccessoriesForSale { get; set; }
    }
}
