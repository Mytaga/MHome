using System.Collections.Generic;

namespace MHome.Web.ViewModels.FurnitureViewModels
{
    public class AllFurnitureViewModel
    {
        public ICollection<ListAllFurnitureViewModel> AllFurniture { get; set; }

        public ICollection<string> Categories { get; set; }

        public string SearchQuery { get; set; }
    }
}