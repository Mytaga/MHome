using AutoMapper;
using MHome.Data.Models;
using MHome.Data.Models.Common;
using MHome.Services.Mapping;
using MHome.Web.ViewModels.StoreViewModels;
using System.ComponentModel.DataAnnotations;

namespace MHome.Web.ViewModels.StoreViewModel
{
    public class CreateStoreInputModel : IMapTo<Store>
    {
        [Required(ErrorMessage = StoreValidationConstants.NameIsRequiredError)]
        [MinLength(StoreValidationConstants.NameMinLength, ErrorMessage = StoreValidationConstants.NameMinLengthError)]
        [MaxLength(StoreValidationConstants.NameMaxLength, ErrorMessage = StoreValidationConstants.NameMaxLengthError)]
        public string Name { get; set; }

        [Required(ErrorMessage = StoreValidationConstants.DescriptionIsRequiredError)]
        [MaxLength(StoreValidationConstants.DescriptionMaxLength, ErrorMessage = StoreValidationConstants.DescriptionMaxLengthError)]
        public string Description { get; set; }

        [Required(ErrorMessage = StoreValidationConstants.EmailIsRequiredError)]
        [EmailAddress]
        [MaxLength(StoreValidationConstants.EmailMaxLength, ErrorMessage = StoreValidationConstants.EmailMaxLengthError)]
        public string Email { get; set; }

        [Required(ErrorMessage = StoreValidationConstants.PhoneNumberIsRequiredError)]
        [MinLength(StoreValidationConstants.PhoneNumberMinLength, ErrorMessage = StoreValidationConstants.PhoneNumberMinLengthError)]
        [MaxLength(StoreValidationConstants.PhoneNumberMaxLength, ErrorMessage = StoreValidationConstants.PhoneNumberMaxLengthError)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = StoreValidationConstants.AddressIsRequiredError)]
        public string Address { get; set; }

        [Required(ErrorMessage = StoreValidationConstants.TownNameIsRequiredError)]
        public string TownName { get; set; }
    }
}
