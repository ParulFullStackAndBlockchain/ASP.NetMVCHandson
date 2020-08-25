using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.CustomHtmlHelpers
{
    public static class CustomHtmlHelpers
    {
        //HTML encoding is the process of replacing ASCII characters with their 'HTML Entity' equivalents.
        //Its done to avoid cross site scripting attacks, all output is automatically html encoded in mvc. 
        //There are 2 ways to disable html encoding in razor views
        //1. @Html.Raw("YourHTMLString")
        //2. Strings of type IHtmlString are not encoded

        //public static IHtmlString Image(this HtmlHelper helper, string src, string alt)
        //{
        //    // Build <img> tag
        //    TagBuilder tb = new TagBuilder("img");
        //    // Add "src" attribute
        //    tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
        //    // Add "alt" attribute
        //    tb.Attributes.Add("alt", alt);
        //    // return MvcHtmlString. This class implements IHtmlString
        //    // interface. IHtmlStrings will not be html encoded.
        //    return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        //}

        public static string Image(this HtmlHelper helper, string src, string alt)
        {
            TagBuilder tb = new TagBuilder("img");
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            tb.Attributes.Add("alt", alt);
            return tb.ToString(TagRenderMode.SelfClosing);
        }
    }
}