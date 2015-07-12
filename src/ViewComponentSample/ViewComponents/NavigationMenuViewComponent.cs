using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewComponentSample.Models;

namespace ViewComponentSample.ViewComponents
{    
    public class NavigationMenuViewComponent : ViewComponent
    {
        MenuDataRepository _menuDataRepository;
        public NavigationMenuViewComponent(MenuDataRepository menuDataRepository)
        {
            _menuDataRepository = menuDataRepository;
        }

        //public IViewComponentResult Invoke()
        //{
        //    MenuItemListModel model = _menuDataRepository.GetMenus();
        //    return View(model);
        //}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            MenuItemListModel model = await _menuDataRepository.GetMenus();
            return View(model);
        }
    }
}
