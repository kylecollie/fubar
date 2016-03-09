// adminController.js
(function () {

    "use strict";

    // Getting the existing module
    angular.module("app-admin")
        .controller("adminController", adminController);

    function adminController($http) {

        var vm = this;

        vm.products = [];

        vm.newProduct = {};

        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/products")
            .then(function (response) {
                // success
                angular.copy(response.data, vm.products);
            }, function (error) {
                // failure
                vm.errorMessage = "Failed to load data: " + error;
            })
        .finally(function () {
            vm.isBusy = false;
        });

        vm.addProduct = function () {

            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("/api/products", vm.newProduct)
                .then(function (response) {
                    // success
                    vm.products.push(response.data);
                    vm.newProduct = {};
                }, function () {
                    // failure
                    vm.errorMessage = "Failed to save new product.";
                })
            .finally(function () {
                vm.isBusy = false;
            })

        };


    }

})();