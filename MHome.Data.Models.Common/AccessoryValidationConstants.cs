using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHome.Data.Models.Common
{
    public static class AccessoryValidationConstants
    {
        public const string NameIsRequiredError = "Accessory name is required!";
        public const string NameMinLengthError = "Accessory name must be at least 3 symbols!";
        public const string NameMaxLengthError = "Accessory name must no more than 50 symbols!";
        public const string DescriptionIsRequiredError = "Accessory description is required!";
        public const string DescriptionMinLengthError = "Accessory description must be at least 10 symbols!";
        public const string DescriptionMaxLengthError = "Accessory description must no more than 100 symbols!";
        public const string PriceIsRequiredError = "Accessory price is required!";

        public const int NameMaxLength = 50;
        public const int NameMinLength = 3;
        public const int DescriptionMaxLength = 100;
        public const int DescriptionMinLength = 10;
        public const int StockQuantityMinValue = 0;
        public const int StockQuantityMaxValue = int.MaxValue;

        public const string PriceMinValue = "0";
        public const string PriceMaxValue = "79228162514264337593543950335";
    }
}
