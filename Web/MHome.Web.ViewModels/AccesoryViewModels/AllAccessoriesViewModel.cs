using System.Collections.Generic;

namespace MHome.Web.ViewModels.AccesoryViewModels
{
    public class AllAccessoriesViewModel
    {
        public ICollection<ListAllAccessoriesViewModel> AllAccessories { get; set; }

        public string SearchQuery { get; set; }
    }
}
