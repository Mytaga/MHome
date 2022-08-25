using MHome.Data.Models;
using MHome.Data.Models.Common;
using MHome.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace MHome.Web.ViewModels.FurnitureViewModels
{
    public class CreateFurnitureInputModel : IMapTo<Furniture>
    {
        [Required(ErrorMessage = FurnitureValidationConstants.NameIsRequiredError)]
        [MinLength(FurnitureValidationConstants.NameMinLength, ErrorMessage = FurnitureValidationConstants.NameMinLengthError)]
        [MaxLength(FurnitureValidationConstants.NameMaxLength, ErrorMessage = FurnitureValidationConstants.NameMaxLengthError)]
        public string Name { get; set; }

        [Required(ErrorMessage = FurnitureValidationConstants.DescriptionIsRequiredError)]
        [MinLength(FurnitureValidationConstants.DescriptionMinLength, ErrorMessage = FurnitureValidationConstants.DescriptionMinLengthError)]
        [MaxLength(FurnitureValidationConstants.DescriptionMaxLength, ErrorMessage = FurnitureValidationConstants.DescriptionMaxLengthError)]
        public string Description { get; set; }

        [Required]
        [Range(typeof(decimal),FurnitureValidationConstants.PriceMinValue, FurnitureValidationConstants.PriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = FurnitureValidationConstants.DimensionsAreRequiredError)]
        [MinLength(FurnitureValidationConstants.DimensionsMinLength, ErrorMessage = FurnitureValidationConstants.DimensionsMinLengthError)]
        [MaxLength(FurnitureValidationConstants.DimensionsMaxLength, ErrorMessage = FurnitureValidationConstants.DimensionsMaxLengthError)]
        public string Dimensions { get; set; }

        [Range(FurnitureValidationConstants.StockQuantityMinValue, FurnitureValidationConstants.StockQuantityMaxValue)]
        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }
    }
}
