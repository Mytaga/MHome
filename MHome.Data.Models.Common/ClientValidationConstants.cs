using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHome.Data.Models.Common
{
    public static class ClientValidationConstants
    {
        public const int FirstNameMinLength = 2;
        public const int FirstNameMaxLength = 30;
        public const int LastNameMinLength = 2;
        public const int LastNameMaxLength = 30;

        public const string FirstNameIsRequiredError = "Client first name is required!";
        public const string LastNameIsRequiredError = "Client last name is required!";
        public const string FirstNameMinLengthError = "Client first name must be at least 2 symbols!";
        public const string FirstNameMaxLengthError = "Client first name must no more than 30 symbols!";
        public const string LastNameMinLengthError = "Client last name must be at least 2 symbols!";
        public const string LastNameMaxLengthError = "Client last name must no more than 30 symbols!";
    }
}
