(function () {
    'use strict';

    angular.module('homeFinance')
        .factory('consumptionService', [
            '$resource', 'endpoints', function ($resource, endpoints) {

            	return $resource(endpoints.consumptionEndpoint, {}, {
                    getByAccountId: {
                        method: 'GET',
                        url: endpoints.consumptionEndpoint,
                        isArray: true
                    }
                });
            }
        ]);
}());
