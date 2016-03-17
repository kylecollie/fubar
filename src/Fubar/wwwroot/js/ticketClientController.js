// ticketClientController.js
(function () {

    "use strict";

    // get the existing module
    angular.module("app-ticket")
        .controller("ticketClientController", ticketClientController);

    function ticketClientController($http, $scope) {

        var vm = this;
        vm.tickets = [];
        vm.newTicket = {};
        //vm.products = {};
        vm.isBusy = true;
        vm.errorMessage = "";

        vm.addTicket = function () {

            $http.post("/api/tickets", vm.newTicket)
                .then(function (response) {
                    // success

                }, function (err) {
                    // failure
                    vm.errorMessage = "Failed to save new ticket.";
                })
            .finally(function () {
                vm.isBusy = false;
            })
        };

        $scope.categories = [];
        $http.get("/api/categories")
            .then(function (response) {
                // success
                angular.copy(response.data, $scope.categories);
            }, function (error) {
                // failure
                vm.errorMessage = "Failed to load data: " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });

        $scope.severities = [];
        $http.get("/api/severities")
            .then(function (response) {
                // success
                angular.copy(response.data, $scope.severities);
            }, function (error) {
                // failure
                vm.errorMessage = "Failed to load data: " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });

        $scope.priorities = [];
        $http.get("/api/priorities")
            .then(function (response) {
                // success
                angular.copy(response.data, $scope.priorities);
            }, function (error) {
                // failure
                vm.errorMessage = "Failed to load data: " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });

        $scope.resolutions = [];
        $http.get("/api/resolutions")
            .then(function (response) {
                // success
                angular.copy(response.data, $scope.resolutions);
            }, function (error) {
                // failure
                vm.errorMessage = "Failed to load data: " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });

        $scope.statuses = [];
        $http.get("/api/statuses")
            .then(function (response) {
                // success
                angular.copy(response.data, $scope.statuses);
            }, function (error) {
                // failure
                vm.errorMessage = "Failed to load data: " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });


        $scope.products = [];
        $http.get("/api/products")
            .then(function (response) {
                // success
                angular.copy(response.data, $scope.products);
            }, function (error) {
                // failure
                vm.errorMessage = "Failed to load data: " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });
    }

})();