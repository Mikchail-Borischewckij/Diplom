(function () {
    'use strict';

    angular.module('homeFinance')
        .factory('incomeCategoriesService', [
            '$resource', 'endpoints', function ($resource, endpoints) {

            	return $resource(endpoints.incomeCategoriesEndpoint, {}, {
                    getByUserId: {
                        method: 'GET',
                        url: endpoints.allIncomeCategoriesEndpoint,
                        isArray: true
                    }
                });

            }
        ]);
}());
