(function () {
    'use strict';

    angular.module('homeFinance')
        .factory('costsPlaningService', [
            '$resource', 'endpoints', function ($resource, endpoints) {

                return $resource(endpoints.costsPlaningEndpoint, {}, {
                    getPlanings: {
                        method: 'GET',
                        url: endpoints.allCostsPlaningEndpoint,
                        isArray: true
                    },
                    getMonths: {
                        method: 'GET',
                        url: endpoints.monthsCostsPlaningEndpoint,
                        isArray: true
                    }
                });
            }
        ]);
}());