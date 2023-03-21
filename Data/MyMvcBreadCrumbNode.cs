using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SmartBreadcrumbs.Nodes;

namespace wiKorki.Data
{
    public class MyMvcBreadcrumbNode : MvcBreadcrumbNode
    {
        public int Id { get; set; }

        public MyMvcBreadcrumbNode(string action, string controller, string title, int id, bool overwriteTitleOnExactMatch = false, string iconClasses = null, string areaName = null)
            : base(action, controller, title, overwriteTitleOnExactMatch, iconClasses, areaName)
        {
            Id = id;
        }
    }


}
