using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewComponentSample.Models;

namespace ViewComponentSample.TagHelpers
{
    [HtmlTargetElement("menulink", Attributes = "controller-name, action-name, menu-text, menu-id")]
    public class MenuLinkTagHelper : TagHelper
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        public string MenuText { get; set; }
        public int MenuId { get; set; }

        public MenuDataRepository _navigationMenu { get; set; }

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public IUrlHelperFactory _urlHelper { get; set; }

        public MenuLinkTagHelper(MenuDataRepository navigationMenu, IUrlHelperFactory urlHelper)
        {
            _navigationMenu = navigationMenu;
            _urlHelper = urlHelper;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "li";

            var routeData = ViewContext.RouteData.Values;
            var currentController = routeData["controller"];
            var currentAction = routeData["action"];

            List<MenuItemModel> subMenus = _navigationMenu.GetMenus().Result.MenuItems.Where(m => m.ParentId == MenuId).ToList();

            if (subMenus.Count > 0)
            {
                string subMenuClass = "";

                var caretSpan = new TagBuilder("span");
                caretSpan.AddCssClass("caret");

                var dropdownMenu = new TagBuilder("a");
                dropdownMenu.MergeAttribute("href", "#");
                dropdownMenu.AddCssClass("dropdown-toggle");
                dropdownMenu.MergeAttribute("data-toggle", "dropdown");
                dropdownMenu.InnerHtml.Append(MenuText);
                dropdownMenu.InnerHtml.AppendHtml(caretSpan);

                var ul = new TagBuilder("ul");
                ul.AddCssClass("dropdown-menu");

                foreach (var subMenu in subMenus)
                {
                    var li = new TagBuilder("li");

                    var urlHelper = _urlHelper.GetUrlHelper(ViewContext);

                    string subMenuUrl = urlHelper.Action(subMenu.ActionName, subMenu.ControllerName);

                    var a = new TagBuilder("a");
                    a.MergeAttribute("href", $"{subMenuUrl}");
                    a.MergeAttribute("title", subMenu.MenuItemText);
                    a.InnerHtml.Append(subMenu.MenuItemText);

                    li.InnerHtml.AppendHtml(a);

                    ul.InnerHtml.AppendHtml(li);
                }

                if (subMenus.Any(s => s.ActionName == currentAction.ToString()) && subMenus.Any(s => s.ControllerName == currentController.ToString()))
                {
                    subMenuClass = "dropdown active";
                }
                else
                {
                    subMenuClass = "dropdown";
                }

                output.Attributes.Add("class", subMenuClass);

                output.Content.AppendHtml(dropdownMenu);
                output.Content.AppendHtml(ul);

            }
            else
            {
                var urlHelper = _urlHelper.GetUrlHelper(ViewContext);

                string menuUrl = urlHelper.Action(ActionName, ControllerName);

                var a = new TagBuilder("a");
                a.MergeAttribute("href", $"{menuUrl}");
                a.MergeAttribute("title", MenuText);
                a.InnerHtml.Append(MenuText);

                if (String.Equals(ActionName, currentAction as string, StringComparison.OrdinalIgnoreCase)
                   && String.Equals(ControllerName, currentController as string, StringComparison.OrdinalIgnoreCase))
                {
                    output.Attributes.Add("class", "active");
                }

                output.Content.AppendHtml(a);
            }
        }
    }
}
