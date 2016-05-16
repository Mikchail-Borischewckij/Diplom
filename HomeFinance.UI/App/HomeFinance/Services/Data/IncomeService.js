(function () {
    'use strict';

    angular.module('homeFinance')
        .factory('incomeService', [
            '$resource', 'endpoints', function ($resource, endpoints) {

            	return $resource(endpoints.incomeEndpoint, {}, {
                    getByAccountId: {
                        method: 'GET',
                        url: endpoints.incomeEndpoint,
                        isArray: true
                    }
                });
            }
        ]);
}());
