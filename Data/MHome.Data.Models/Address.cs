using MHome.Data.Common.Models;
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
    public class Address : BaseDeletableModel<string>
    {
        public Address()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Clients = new List<Client>();
        }

        [Required]
        [MaxLength(AddressValidationConstants.AddressMaxLength)]
        public string AddressText { get; set; }

        [Required]
        [MaxLength(AddressValidationConstants.TownMaxLength)]
        public string TownName { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        [ForeignKey(nameof(Store))]
        public string StoreId { get; set; }

        public virtual Store Store { get; set; }
    }
}
