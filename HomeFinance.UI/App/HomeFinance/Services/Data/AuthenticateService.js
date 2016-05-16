(function () {
    'use strict';

    angular.module('homeFinance')
        .factory('authenticateService', [
            '$resource', 'endpoints', function ($resource, endpoints) {

            	return $resource(endpoints.loginEndpoint, {}, {
                    login: {
                        method: 'POST',
                        url: endpoints.loginEndpoint,
                        interceptor: {
                            response: function (response) {
                                response.resource.$httpHeaders = response.headers;
                                return response.resource;
                            }
                        }
                    },
                    register: {
                        method: 'POST',
                        url: endpoints.registerEndpoint,
                        interceptor: {
                            response: function (response) {
                                response.resource.$httpHeaders = response.headers;
                                return response.resource;
                            }
                        }
                    },
                    validateToken: {
                        method: 'GET',
                        url: endpoints.validateTokenEndpoint
                    }
                });

            }
        ]);
}());
