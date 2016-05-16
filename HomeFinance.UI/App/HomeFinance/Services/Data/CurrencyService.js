(function () {
    'use strict';

    angular.module('homeFinance')
        .factory('currencyService', [
            '$resource', 'endpoints', function ($resource, endpoints) {

                return $resource(endpoints.currencyEndpoint, {}, {
                    getCurrentValues: {
                        method: 'GET',
                        url: endpoints.currencyValuesEndpoint,
                        isArray: true
                    }
                });

            }
        ]);
}());
