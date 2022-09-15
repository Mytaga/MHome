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
    public class ClientCard : BaseDeletableModel<string>
    {
        public ClientCard()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(ClientCardValidationConstants.CardNumberMaxLength)]
        public string CardNumber { get; set; }

        [Required]
        [MaxLength(ClientCardValidationConstants.ExpirationDateMaxLength)]
        public string ExpirationDate { get; set; }

        public int? Discount { get; set; }

        [Required]
        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
