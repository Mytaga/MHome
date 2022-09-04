using System.Collections;
using System.Collections.Generic;

namespace MHome.Web.ViewModels.OrderViewModels
{
    public class AllOrdersViewModel
    {
        public ICollection<ListAllOrdersViewModel> AllOrders { get; set; }

        public string SearchQuery { get; set; }
    }
}
