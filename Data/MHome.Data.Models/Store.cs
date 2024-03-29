﻿using MHome.Data.Common.Models;
using MHome.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [MaxLength(StoreValidationConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(StoreValidationConstants.EmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(StoreValidationConstants.PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [Required]
        [ForeignKey(nameof(Address))]
        public string AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Furniture> FurnitureForSale { get; set; }

        public virtual ICollection<Accessory> AccessoriesForSale { get; set; }
    }
}
