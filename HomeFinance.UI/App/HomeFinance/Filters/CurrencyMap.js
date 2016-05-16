
(function () {
    'use strict';

    angular.module("homeFinance").filter('currencyMap', ['$rootScope', function ($rootScope) {
        return function (input) {
            if (!input) {
                return "";
            }
            var result = "";
            angular.forEach($rootScope.currencies, function (item) {
                if (item.Id === input) {
                    result = item.Name;
                }
            });
            return result;
        };
    }]);
}());
