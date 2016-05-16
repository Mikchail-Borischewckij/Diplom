(function () {
    'use strict';

    angular.module("homeFinance").filter('transactionTypeFilter', function () {
        return function (input) {
            if (!input) {
                return;
            }
            if (input === 1) {
                return "Single";
            }
            return "Monthly";
        };
    });
}());
