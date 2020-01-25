using System.Collections.Generic;

namespace YashilUserManagement.Web.Areas.UserMng.ViewModels
{
    public class MenuTreeViewModel
    {
        public MenuTreeViewModel()
        {
            Submenu = new List<MenuTreeViewModel>();
        }

        public int Id { get; set; }

        public string Path { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }

        public string Class { get; set; }

        public string Badge { get; set; }

        public string BadgeClass { get; set; }

        public bool? IsExternalLink { get; set; }

        public int? ParentId { get; set; }
        public string ParentTitle { get; set; }

        public int? ResourceId { get; set; }
        public string ResourceTitle { get; set; }
        public List<MenuTreeViewModel> Submenu { get; set; }
        public int? OrderNo { get; set; }
    }
}
