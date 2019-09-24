using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicObjects
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent GetContent(this IHtmlHelper helper)
        {
            var content = new HtmlContentBuilder()
                             .AppendHtml("<ol class='content-body'><li>")
                             .AppendHtml(helper.ActionLink("Home", "Index", "Home"))
                             .AppendHtml("</li>")
                             ;
            

            if (1== 2)
            {
            content.AppendHtml(@"<div>
            Note `HtmlContentBuilder.AppendHtml()` is Mutable
            as well as Fluent/Chainable.
        </div>");
            }

            return content;
        }
    }
}
