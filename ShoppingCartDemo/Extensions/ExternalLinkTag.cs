using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartDemo.Extensions
{
    public static class ExternalLinkTag
    {
        public static MvcHtmlString ExternalLink(this HtmlHelper helper, string text, string url)
        {
            return MvcHtmlString.Create("<a href='" + url + "'>"+ text + "</a>");
        }
    }
}