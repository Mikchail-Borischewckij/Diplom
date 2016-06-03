(function () {
    'use strict';

    angular.module('homeFinance')
        .factory('planingService', [
            '$http', 'endpoints', function ($http, endpoints) {
            return $http({ method: 'GET', url: endpoints.planingEndpoint }).$promise;
        }
    ]);
}());