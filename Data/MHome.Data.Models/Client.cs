using MHome.Data.Common.Models;
using MHome.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MHome.Data.Models
{
    public class Client : BaseDeletableModel<string>
    {
        public Client()
        {
            this.Id = Guid.NewGuid().ToString();
            this.BoughtFurniture = new List<Furniture>();
            this.BoughtAccessories = new List<Accessory>();
        }

        [Required]
        [MaxLength(ClientValidationConstants.NameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Furniture> BoughtFurniture { get; set; }

        public virtual ICollection<Accessory> BoughtAccessories { get; set; }
    }
}
