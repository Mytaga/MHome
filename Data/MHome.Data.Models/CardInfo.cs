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
    public class CardInfo : BaseDeletableModel<string>
    {
        public CardInfo()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(CardInfoValidationConstants.CardNumberMaxLength)]
        public string CardNumber { get; set; }

        [Required]
        [MaxLength(CardInfoValidationConstants.ExpirationDateMaxLength)]
        public string ExpirationDate { get; set; }

        [Required]
        [MaxLength(CardInfoValidationConstants.CardHolderMaxLength)] 
        public string CardHolder { get; set; }

        [Required]
        [MaxLength(CardInfoValidationConstants.CvcMaxLength)]
        public string Cvc { get; set; }

        [Required]
        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
