using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewComponentSample.Models
{
    public class MenuItemModel
    {
        public int Id { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string MenuItemText { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }

        public MenuItemModel()
        {

        }

        public MenuItemModel(int id, string menuItemText, string action, string controller, string title, int parentid)
        {
            Id = id;
            MenuItemText = menuItemText;
            ActionName = action;
            ControllerName = controller;
            Title = title;
            ParentId = parentid;
        }
    }
}
