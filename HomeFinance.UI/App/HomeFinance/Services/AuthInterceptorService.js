(function () {
    'use strict';

    angular.module('homeFinance').factory('authInterceptorService', ['$q','$window', '$injector', '$location', 'localStorageService', function ($q,$window, $injector, $location, localStorageService) {

        var authInterceptorServiceFactory = {};

        var request = function (config) {

            config.headers = config.headers || {};

            var authData = localStorageService.get('authorizationData');
            if (authData) {
                config.headers.Token = authData.token;
            } 

            return config;
        }

        var responseError = function (rejection) {
            if (rejection.status === 401) {
                var authService = $injector.get('authService');
                authService.logOut();
                $location.path('/home');
            }
            return $q.reject(rejection);
        }

        authInterceptorServiceFactory.request = request;
        authInterceptorServiceFactory.responseError = responseError;

        return authInterceptorServiceFactory;
    }]);
}());
