


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Services;
using  YashilUserManagement.Web.Areas.UserMng.ViewModels;

namespace YashilUserManagement.Web.Areas.UserMng.Controllers
{
	public class MenuController : BaseController<Menu ,int,MenuListViewModel,  MenuEditModel,MenuSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService, IMapper mapper) : base(menuService, mapper)
        {
            _mapper=mapper;
            _menuService=menuService;
        }
        [HttpGet("UserMenu")]
        public async Task<object> UserMenu()
        {
            var menuTreeViewModels = new List<MenuTreeViewModel>();
            if (CurrentUserId != null)
            {
                var menus = await _menuService.GetUserMenus(CurrentUserId.Value);
                foreach (var menu in menus)
                {
                    if (!menu.ParentId.HasValue)
                    {
                        var menuTreeViewModel = new MenuTreeViewModel
                        {
                            Title = menu.Title,
                            BadgeClass = menu.BadgeClass ?? "",
                            Badge = menu.Badge ?? "",
                            Class = menu.Class ?? "",
                            Icon = menu.Icon ?? "",
                            Path = menu.Path ?? "",
                            IsExternalLink = false,
                            Submenu = menus.Where(x => x.ParentId == menu.Id).OrderByDescending(x => x.OrderNo.HasValue).ThenBy(x => x.OrderNo).Select(x =>
                                new MenuTreeViewModel()
                                {
                                    Title = x.Title,
                                    BadgeClass = x.BadgeClass ?? "",
                                    Badge = x.Badge ?? "",
                                    Class = x.Class ?? "",
                                    Icon = x.Icon ?? "",
                                    Path = x.Path ?? "",
                                    IsExternalLink = false
                                }).ToList()
                        };
                        var sCount = menuTreeViewModel.Submenu.Count;
                        if (sCount > 0)
                        {
                            menuTreeViewModel.Class = "has-sub";
                            menuTreeViewModel.Badge = sCount.ToString();
                            menuTreeViewModel.BadgeClass = "badge badge-pill badge-danger float-right mr-1 mt-1";
                        }

                        if (sCount != 0 || !string.IsNullOrWhiteSpace(menu.Path))
                            menuTreeViewModels.Add(menuTreeViewModel);
                    }
                }
            }

            return menuTreeViewModels;
        }
    }
}      