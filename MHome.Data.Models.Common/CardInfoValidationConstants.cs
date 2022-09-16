using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHome.Data.Models.Common
{
    public static class CardInfoValidationConstants
    {
        public const int CardNumberMaxLength = 19;
        public const int ExpirationDateMaxLength = 5;
        public const int CardHolderMaxLength = 50;
        public const int CvcMaxLength = 3;
    }
}
