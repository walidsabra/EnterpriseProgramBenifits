﻿using System.Web;
using System.Web.Mvc;

namespace Enterprise_Program_Benefits
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
