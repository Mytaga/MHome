using MHome.Data.Common.Models;
using MHome.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MHome.Data.Models
{
    public class Client : BaseDeletableModel<string>
    {
        public Client()
        {
            this.Id = Guid.NewGuid().ToString();
            this.BoughtFurniture = new List<Furniture>();
            this.BoughtAccessories = new List<Accessory>();
            this.PaymentCards = new List<CardInfo>();
            this.Orders = new List<Order>();
        }

        [MaxLength(ClientValidationConstants.FirstNameMaxLength)]
        public string FirstName { get; set; }

        [MaxLength(ClientValidationConstants.LastNameMaxLength)]
        public string LastName { get; set; }

        [ForeignKey(nameof(Address))]
        public string AddressId { get; set; }

        public virtual Address Address { get; set; }

        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(ClietnCard))]
        public string ClientCardId { get; set; }

        public virtual ClientCard ClietnCard { get; set; }

        public virtual ICollection<Furniture> BoughtFurniture { get; set; }

        public virtual ICollection<Accessory> BoughtAccessories { get; set; }

        public virtual ICollection<CardInfo> PaymentCards { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
