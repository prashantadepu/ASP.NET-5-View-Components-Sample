using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewComponentSample.Models
{
    public class MenuItemListModel
    {
        public List<MenuItemModel> MenuItems { get; set; }

        public MenuItemListModel()
        {
            MenuItems = new List<MenuItemModel>();
        }
    }
}
