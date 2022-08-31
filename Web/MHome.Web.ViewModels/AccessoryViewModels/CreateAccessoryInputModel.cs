using MHome.Data.Models;
using MHome.Data.Models.Common;
using MHome.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace MHome.Web.ViewModels.AccessoryViewModels
{
    public class CreateAccessoryInputModel : IMapTo<Accessory>
    {
        [Required(ErrorMessage = AccessoryValidationConstants.NameIsRequiredError)]
        [MinLength(AccessoryValidationConstants.NameMinLength, ErrorMessage = AccessoryValidationConstants.NameMinLengthError)]
        [MaxLength(AccessoryValidationConstants.NameMaxLength, ErrorMessage = AccessoryValidationConstants.NameMaxLengthError)]
        public string Name { get; set; }

        [Required(ErrorMessage = AccessoryValidationConstants.DescriptionIsRequiredError)]
        [MinLength(AccessoryValidationConstants.DescriptionMinLength, ErrorMessage = AccessoryValidationConstants.DescriptionMinLengthError)]
        [MaxLength(AccessoryValidationConstants.DescriptionMaxLength, ErrorMessage = AccessoryValidationConstants.DescriptionMaxLengthError)]
        public string Description { get; set; }

        [Required(ErrorMessage = AccessoryValidationConstants.PriceIsRequiredError)]
        [Range(typeof(decimal), FurnitureValidationConstants.PriceMinValue, FurnitureValidationConstants.PriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Range(FurnitureValidationConstants.StockQuantityMinValue, FurnitureValidationConstants.StockQuantityMaxValue)]
        public int StockQuantity { get; set; }
    }
}
