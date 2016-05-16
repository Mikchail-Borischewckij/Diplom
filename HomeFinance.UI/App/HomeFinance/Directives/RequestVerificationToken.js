(function () {
    'use strict';
    angular.module('homeFinance').directive('ncgRequestVerificationToken', ['$http', function ($http) {
        return function (scope, element, attrs) {
            $http.defaults.headers.common['RequestVerificationToken'] = attrs.ncgRequestVerificationToken || "no request verification token";
        };
    }]);
}());