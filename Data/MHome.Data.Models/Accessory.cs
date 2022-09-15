using MHome.Data.Common.Models;
using MHome.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MHome.Data.Models
{
    public class Accessory : BaseDeletableModel<string>
    {
        public Accessory()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Stores = new List<Store>();
            this.Orders = new List<Order>();
        }

        [Required]
        [MaxLength(AccessoryValidationConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(AccessoryValidationConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [ForeignKey(nameof(Owner))]
        public string ClientId { get; set; }

        public virtual Client Owner { get; set; }

        public int StockQuantity { get; set; }

        public virtual ICollection<Store> Stores { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
