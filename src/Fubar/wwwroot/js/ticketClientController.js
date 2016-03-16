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

        $scope.categories = {
            "Other": 1,
            "Feature Request": 2,
            "Bug": 3
        };

        $scope.severities = {
            "Trivial": 1,
            "Minor": 2,
            "Major": 3,
            "Unspecified": 4
        };
        
        $scope.priorities = {
            "Unspecified": 1,
            "Normal": 2,
            "High": 3,
            "Urgent": 4
        };

        $scope.resolutions = {
            "Will not fix": 1,
            "Invalid": 2,
            "Fixed": 3,
            "Works for me": 4,
            "Duplicate": 5
        };
        
        $scope.statuses = {
            "Unconfirmed": 1,
            "Confirmed": 2,
            "In Progress": 3,
            "Resolved": 4,
            "Verified": 5
        };

        $scope.products = {
            "Timber!": 1,
            "Chipper": 2,
            "Woody": 3,
            "Splitter!": 4,
            "Super Maul": 5
        };
        

        
    }

})();