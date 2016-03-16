// app-ticket.js
(function () {

    "use strict";

    // create the module
    angular.module("app-ticket", ["simpleControls", "ngRoute"])
        .config(function ($routeProvider) {

            $routeProvider.when("/", {
                controller: "ticketClientController",
                controllerAs: "vm",
                templateUrl: "/views/ticketView.html"
            });

            $routeProvider.otherwise({ redirectTo: "/" });

        });
})();