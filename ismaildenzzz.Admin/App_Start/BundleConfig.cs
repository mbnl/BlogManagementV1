using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ismaildenzzz.Admin.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            bundles.Add(new ScriptBundle("~/bundles/LayoutUI_UstJS")
                .Include("~/ContentUser/vendor/jquery/jquery.min.js")
                .Include("~/ckeditor/plugins/codesnippet/lib/highlight/highlight.pack.js"));
            bundles.Add(new ScriptBundle("~/bundles/LayoutUI_AltJS", @"//cdnjs.cloudflare.com/ajax/libs/limonte-sweetalert2/7.0.6/sweetalert2.min.js")
               .Include("~/ContentUser/vendor/bootstrap/js/bootstrap.bundle.min.js")
               .Include("~/ContentUser/js/GlobalUI.js"));

            bundles.Add(new StyleBundle("~/bundles/LayoutUI_UstCSS", @"//cdnjs.cloudflare.com/ajax/libs/limonte-sweetalert2/7.0.6/sweetalert2.min.css")
               .Include("~/ContentUser/vendor/bootstrap/css/bootstrap.min.css")
               .Include("~/ContentUser/css/blog-home.min.css")
               .Include("~/ContentUser/css/bootstrap-social.css")
               .Include("~/ckeditor/plugins/codesnippet/lib/highlight/styles/default.css"));

        }
    }
}