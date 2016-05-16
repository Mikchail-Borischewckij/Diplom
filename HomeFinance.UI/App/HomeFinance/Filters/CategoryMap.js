
(function () {
    'use strict';

    angular.module("homeFinance").filter('categoryMap', function () {
        return function (input,array) {
            if (!input) {
                return "";
            }
            var result = "";
            angular.forEach(array, function (item) {
                if (item.Id === input) {
                    result = item.Name;
                }
            });
            return result;
        };
    });
}());
