(function () {
    'use strict';

    angular.module('homeFinance')
        .factory('incomePlaningService', [
            '$resource', 'endpoints', function ($resource, endpoints) {

                return $resource(endpoints.incomePlaningEndpoint, {}, {
                    getPlanings: {
                		method: 'GET',
                		url: endpoints.allIncomePlaningEndpoint,
                		isArray: true
                    },
                    getMonths: {
                        method: 'GET',
                        url: endpoints.monthsIncomePlaningEndpoint,
                        isArray: true
                    }
                });
            }
        ]);
}());