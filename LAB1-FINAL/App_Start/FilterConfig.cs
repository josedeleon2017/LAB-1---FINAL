﻿using System.Web;
using System.Web.Mvc;

namespace LAB1_FINAL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
