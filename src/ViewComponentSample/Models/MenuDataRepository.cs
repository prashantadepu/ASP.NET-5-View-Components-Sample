using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewComponentSample.Models
{
    public class MenuDataRepository
    {
        public MenuItemListModel MenuList { get; set; }

        public MenuDataRepository()
        {
            
        }

        public Task<MenuItemListModel> GetMenus()
        {
            MenuList = new MenuItemListModel();
            MenuList.MenuItems.Add(new MenuItemModel(1, "Home", "Index", "Home", "Home", 0));
            MenuList.MenuItems.Add(new MenuItemModel(2, "About", "About", "Home", "About", 0));
            MenuList.MenuItems.Add(new MenuItemModel(3, "News", "Index", "News", "News", 0));
            MenuList.MenuItems.Add(new MenuItemModel(4, "Videos", "Index", "Videos", "Videos", 0));
            MenuList.MenuItems.Add(new MenuItemModel(5, "Photos", "Index", "Photos", "Photos", 0));
            MenuList.MenuItems.Add(new MenuItemModel(6, "Contact Us", "Contact", "Home", "Contact", 0));

            MenuList.MenuItems.Add(new MenuItemModel(7, "Technology", "TechNews", "News", "Technology News", 3));
            MenuList.MenuItems.Add(new MenuItemModel(8, "Political", "PoliticalNews", "News", "Political News", 3));
            MenuList.MenuItems.Add(new MenuItemModel(9, "Sports", "SportsNews", "News", "Sports News", 3));

            MenuList.MenuItems.Add(new MenuItemModel(10, "Latest Videos", "LatestVideos", "Videos", "Latest Videos", 4));
            MenuList.MenuItems.Add(new MenuItemModel(11, "Must Watch Videos", "MustWatchVideos", "Videos", "Must Watch Videos", 4));

            return Task.FromResult<MenuItemListModel>(MenuList);
        }
    }
}
