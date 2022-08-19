using MHome.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHome.Data.Models
{
    public class ClientCard : BaseDeletableModel<string>
    {
        public ClientCard()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
