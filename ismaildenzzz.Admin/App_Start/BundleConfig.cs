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
            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/LayoutUI_UstJS")
                .Include("~/ContentUser/vendor/jquery/jquery.min.js")
                .Include("~/ckeditor/plugins/codesnippet/lib/highlight/highlight.pack.js"));

            bundles.Add(new ScriptBundle("~/bundles/LayoutUI_AltJS")
               .Include("~/ContentUser/vendor/bootstrap/js/bootstrap.bundle.min.js")
               .Include("~/ContentUser/js/GlobalUI.js"));

            bundles.Add(new StyleBundle("~/bundles/LayoutUI_UstCSS")
               .Include("~/ContentUser/vendor/bootstrap/css/bootstrap.min.css")
               .Include("~/ContentUser/css/blog-home.min.css")
               .Include("~/ContentUser/css/bootstrap-social.css")
               .Include("~/ckeditor/plugins/codesnippet/lib/highlight/styles/github.css")
               .Include("~/ContentUser/css/hoverEffect.css"));

        }
    }
}