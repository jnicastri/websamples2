using System.Web;
using System.Web.Optimization;

namespace WebMvc
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Bundles/basejs").Include(
                        "~/Scripts/modernizr-2.6.2.js",
                        "~/Scripts/jquery-3.3.1.min.js",
                        "~/Scripts/knockout-3.4.2.min.js",
                        "~/Scripts/knockout-validation-2.0.3.min.js"));


            bundles.Add(new StyleBundle("~/Bundles/basecss").Include(
                      //"~/Content/reset.css",
                      "~/Content/Site.css"));

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}