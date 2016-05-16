(function () {
    'use strict';

    angular.module('homeFinance')
        .factory('costsCategoriesSevice', [
            '$resource', 'endpoints', function ($resource, endpoints) {

            	return $resource(endpoints.costsCategoriesEndpoint, {}, {
                    getByUserId: {
                        method: 'GET',
                        url: endpoints.allCostsCategoriesEndpoint,
                        isArray: true
                    }
                });

            }
        ]);
}());
