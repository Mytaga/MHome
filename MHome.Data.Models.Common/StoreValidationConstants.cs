using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHome.Data.Models.Common
{
    public static class StoreValidationConstants
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 30;
        public const int DescriptionMaxLength = 100;
        public const int EmailMaxLength = 50;
        public const int PhoneNumberMinLength = 10;
        public const int PhoneNumberMaxLength = 20;

        public const string NameIsRequiredError = "Store name is required!";
        public const string DescriptionIsRequiredError = "Description is required!";
        public const string EmailIsRequiredError = "Email is required!";
        public const string PhoneNumberIsRequiredError = "Phone number is required!";
        public const string AddressIsRequiredError = "Address is required!";
        public const string TownNameIsRequiredError = "Town name is required!";
        public const string EmailMaxLengthError = "Email must be no more than 50 symbols!";
        public const string NameMinLengthError = "Store name must at least 3 symbols!";
        public const string NameMaxLengthError = "Store name must no more than 30 symbols!";
        public const string DescriptionMaxLengthError = "Description must no more than 100 symbols!";
        public const string PhoneNumberMinLengthError = "Phone number must at least 10 symbols!";
        public const string PhoneNumberMaxLengthError = "Phone number must no more than 20 symbols!";
    }
}
