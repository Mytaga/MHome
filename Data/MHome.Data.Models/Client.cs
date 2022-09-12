using MHome.Data.Models.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MHome.Data.Models
{
    public class Client : ApplicationUser
    {
        public Client()
        {
            this.BoughtFurniture = new List<Furniture>();
            this.BoughtAccessories = new List<Accessory>();
            this.PaymentCards = new List<CardInfo>();
            this.Orders = new List<Order>();
        }

        [ForeignKey(nameof(Address))]
        public string AddressId { get; set; }

        public virtual Address Address { get; set; }

        [ForeignKey(nameof(ClietnCard))]
        public string ClientCardId { get; set; }

        public virtual ClientCard ClietnCard { get; set; }

        public virtual ICollection<Furniture> BoughtFurniture { get; set; }

        public virtual ICollection<Accessory> BoughtAccessories { get; set; }

        public virtual ICollection<CardInfo> PaymentCards { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
