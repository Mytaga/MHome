using MHome.Data.Models;
using MHome.Services.Mapping;
using System;
using System.ComponentModel.DataAnnotations;

namespace MHome.Web.ViewModels.ClientCardViewModels
{
    public class CreateClientCardInputModel : IMapTo<ClientCard>
    {
        private readonly Random random = new Random();

        [Required]
        public string CardNumber => this.random.Next(1, 100000).ToString();

        [Required]
        public string ExpirationDate => DateTime.Now.AddYears(2).ToString();

        public int? Discount => 10;

        public string ClientId { get; set; }
    }
}
