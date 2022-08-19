﻿namespace MHome.Data.Models
{
    using MHome.Data.Common.Models;
    using MHome.Data.Models.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Furniture : BaseDeletableModel<string>
    {
        public Furniture()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Orders = new List<Order>();
        }

        [Required]
        [MaxLength(FurnitureValidationConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(FurnitureValidationConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(FurnitureValidationConstants.DimensionsMaxLength)]
        public string Dimensions { get; set; }

        [ForeignKey(nameof(Category))]
        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [ForeignKey(nameof(Owner))]
        public int? ClientId { get; set; }

        public virtual Client Owner { get; set; }

        public int StockQuantity { get; set; }

        public virtual ICollection<Store> Stores { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
