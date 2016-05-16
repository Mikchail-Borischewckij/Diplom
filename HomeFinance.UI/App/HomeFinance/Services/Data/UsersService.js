(function () {
    'use strict';

    angular.module('homeFinance')
        .factory('usersService', [
            '$resource', 'endpoints', function ($resource, endpoints) {

            	return $resource(endpoints.usersEndpoint, {}, {
                    getCurrent: {
			            method: 'GET',
			            url: endpoints.usersEndpoint
		            }
	            });

            }
        ]);
}());
