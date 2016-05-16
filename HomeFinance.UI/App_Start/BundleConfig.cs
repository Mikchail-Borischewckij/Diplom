using System.Web;
using System.Web.Helpers;
using System.Web.Optimization;

namespace HomeFinance.UI
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;
            RegisterScripts(bundles);
            RegisterStyles(bundles);
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            // Jquery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"
                ));

            // Jquery UI
            bundles.Add(new ScriptBundle("~/bundles/jquery_ui").Include(
                "~/Scripts/jquery-ui-{version}.js"
                ));

            // Bootstrap and extensions
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/wow.min.js",
                "~/Scripts/bootstrap ui/*.js",
                "~/Scripts/angular-notify/*.js"
                ));

            // Jquery validate (with bootstrap extension, need load after bootstrap)
            bundles.Add(new ScriptBundle("~/bundles/jquery.validate").Include(
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.validate.unobtrusive.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular_chart").Include(
                "~/Scripts/angular-chart/Chart.js",
                "~/Scripts/angular-chart/Chart.min.js",
                "~/Scripts/angular-chart/angular-chart.js",
                "~/Scripts/angular-chart/angular-chart.min.js",
                 "~/Scripts/angular-chart/Chart.bundle.js"));

            // Angular and extensions
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-resource.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/angular-touch.js",
                "~/Scripts/angular-ui-router.js",
                "~/Scripts/angular-local-storage.js",
                "~/Scripts/angular-loading-bar/*.js",
                "~/Scripts/ui-grid.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/home_finance").Include(
                "~/App/HomeFinance/*.js",
                "~/App/HomeFinance/Services/*.js",
                "~/App/HomeFinance/Services/Data/*.js",
                "~/App/HomeFinance/Directives/*.js",
                "~/App/HomeFinance/Filters/*.js",
                "~/App/HomeFinance/Controllers/*.js"
                ));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            // Bootstrap and extensions
            bundles.Add(new StyleBundle("~/styles/bootstrap").Include(
                "~/Content/bootstrap.css",
                "~/Content/animate.css",
                "~/Content/startStyle.css",
                "~/Content/magnific-popup.css",
                "~/Content/font-awesome/*.css",
                "~/Content/ui-grid.css",
                "~/Content/angular-loading-bar/*.css",
                "~/Content/angular-chart/*.css",
                "~/Content/angular-notify.css"
                ));

            bundles.Add(new StyleBundle("~/styles/home_finance").Include(
                "~/App/HomeFinance/Styles/App.css"
                ));

        }


    }
}
