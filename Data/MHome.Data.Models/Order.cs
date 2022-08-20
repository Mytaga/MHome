using MHome.Data.Common.Models;
using MHome.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHome.Data.Models
{
    public class Order : BaseDeletableModel<string>
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.OrderedFurniture = new List<Furniture>();
            this.OrderedAccesorries = new List<Accessory>();
        }

        [Required]
        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }

        public DateTime TimeOfOrder { get; set; }

        public virtual Client Client { get; set; }

        public decimal TotalPrice { get; set; }

        public DeliveryType DeliveryType { get; set; }

        public virtual ICollection<Furniture> OrderedFurniture { get; set; }

        public virtual ICollection<Accessory> OrderedAccesorries { get; set; }
    }
} 
