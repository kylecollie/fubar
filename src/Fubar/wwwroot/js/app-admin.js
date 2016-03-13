// app-admin.js
(function () {

    "use strict";

    // Creating the module
    angular.module("app-admin", ["simpleControls", "ngRoute"])
        .config(function ($routeProvider) {

            $routeProvider.when("/", {
                controller: "adminController",
                controllerAs: "vm",
                templateUrl: "/views/adminView.html"
            });

            $routeProvider.when("/productEditor/:id", {
                controller: "productEditorController",
                controllerAs: "vm",
                templateUrl: "/views/productEditorView.html"
            });

            $routeProvider.otherwise({ redirectTo: "/"});

        });

})();