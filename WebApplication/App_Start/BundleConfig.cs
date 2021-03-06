﻿using System.Web;
using System.Web.Optimization;

namespace WebApplication
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/gridmvc").Include(
                       "~/Scripts/gridmvc.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            "~/Scripts/jquery-ui-1.12.1.js"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération (bluid) sur http://modernizr.com pour choisir uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Gridmvc.css",
                      "~/Content/site.css"));


            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                          "~/Content/themes/base/jquery.ui.core.css",
                          "~/Content/themes/base/jquery.ui.resizable.css",
                          "~/Content/themes/base/jquery.ui.selectable.css",
                          "~/Content/themes/base/jquery.ui.accordion.css",
                          "~/Content/themes/base/jquery.ui.autocomplete.css",
                          "~/Content/themes/base/jquery.ui.button.css",
                          "~/Content/themes/base/jquery.ui.dialog.css",
                          "~/Content/themes/base/jquery.ui.slider.css",
                          "~/Content/themes/base/jquery.ui.tabs.css",
                          "~/Content/themes/base/jquery.ui.datepicker.css",
                          "~/Content/themes/base/jquery.ui.progressbar.css",
                          "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}
