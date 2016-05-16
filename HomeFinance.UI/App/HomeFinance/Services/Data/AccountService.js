(function () {
    'use strict';

    angular.module('homeFinance')
        .factory('accountService', [
            '$resource', 'endpoints', function ($resource, endpoints) {

                return $resource(endpoints.accountEndpoint, {}, {
                    getByUserId: {
                        method: 'GET',
                        url: endpoints.allAccountEndpoint,
                        isArray: true
                    },
                    getCurrent: {
                        method: 'GET',
                        url: endpoints.accountEndpoint
                    }
                });

            }
        ]);
}());
