using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartDemo.Extensions
{
    public static class ExternalLinkExtensions
    {
        public static string ExternalLink(this UrlHelper helper, string uri)
        {
            if (uri.StartsWith("http://")) return uri;
            return string.Format("http://{0}", uri);
        }
    }
}