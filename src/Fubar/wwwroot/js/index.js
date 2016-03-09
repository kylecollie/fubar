// index.js
(function () {

    "use strict";

    var index = angular.module('index', []);
    index.controller('indexController', function ($scope, $http) {

        var arrProducts = new Array();
        $http.get("/api/products").success(function (data) {

            $.map(data, function(item) {
                arrProducts.push(item.Name);
            });

            $scope.products = arrProducts;
        }).error(function (status){
            alert(status);
        });
    });
})();
