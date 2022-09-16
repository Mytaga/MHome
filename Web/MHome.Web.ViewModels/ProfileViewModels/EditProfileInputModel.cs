using MHome.Data.Models;
using MHome.Data.Models.Common;
using MHome.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace MHome.Web.ViewModels.ProfileViewModels
{
    public class EditProfileInputModel : IMapTo<Client>
    {
        [Required(ErrorMessage = ClientValidationConstants.FirstNameIsRequiredError)]
        [MinLength(ClientValidationConstants.FirstNameMinLength, ErrorMessage = ClientValidationConstants.FirstNameMinLengthError)]
        [MaxLength(ClientValidationConstants.FirstNameMaxLength, ErrorMessage = ClientValidationConstants.FirstNameMaxLengthError)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = ClientValidationConstants.LastNameIsRequiredError)]
        [MinLength(ClientValidationConstants.FirstNameMinLength, ErrorMessage = ClientValidationConstants.FirstNameMinLengthError)]
        [MaxLength(ClientValidationConstants.FirstNameMaxLength, ErrorMessage = ClientValidationConstants.FirstNameMaxLengthError)]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Town { get; set; }
    }
}
