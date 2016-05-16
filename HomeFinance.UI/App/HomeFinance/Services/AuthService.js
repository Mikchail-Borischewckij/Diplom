(function () {
    'use strict';

    angular.module('homeFinance').factory('authService', ['$rootScope', '$location', '$q', 'localStorageService', 'authenticateService',
        function ($rootScope, $location, $q, localStorageService, authenticateService) {

            var authServiceFactory = {};

            var authentication = {
                isAuth: false,
                userName: ""
            };

            var chekAuthentication = function () {
                if (authentication.isAuth) {
                    return true;
                }
                return false;
            }
            var saveRegistration = function (user) {
                var deferred = $q.defer();
                logOut();
                authenticateService.register({}, user).$promise.then(function (response) {
                    var token = response.$httpHeaders('Token');
                    localStorageService.set('authorizationData', { token: token, userName: user.Name });
                    $location.path('/dashboard');
                    authentication.isAuth = true;
                    authentication.userName = user.Name;
                    deferred.resolve(response.data);
                }).catch(function (err) {
                    logOut();
                    deferred.reject(err);
                });
                return deferred.promise;
            };

            var login = function (user) {
                var deferred = $q.defer();
                authenticateService.login({}, user).$promise.then(function (response) {
                    var token = response.$httpHeaders('Token');
                    localStorageService.set('authorizationData', { token: token, userName: user.Name });
                    $location.path('/dashboard');
                    authentication.isAuth = true;
                    authentication.userName = user.Name;
                    deferred.resolve(response.data);
                }).catch(function (err) {
                    logOut();
                    deferred.reject(err);
                });
                return deferred.promise;

            };
            var logOut = function () {
                $rootScope.safeApply(function() {
                    localStorageService.remove('authorizationData');
                    authentication.isAuth = false;
                    authentication.userName = "";
                });
            };

            var fillAuthData = function () {
                authenticateService.validateToken().$promise.then(function (response) {
                    var authData = localStorageService.get('authorizationData');
                    if (authData) {
                        authentication.isAuth = true;
                        authentication.userName = authData.userName;
                        authentication.token = authData.token;

                    }
                }).catch(function () {
                    logOut();
                });
            };

            authServiceFactory.saveRegistration = saveRegistration;
            authServiceFactory.login = login;
            authServiceFactory.logOut = logOut;
            authServiceFactory.chekAuthentication = chekAuthentication;
            authServiceFactory.fillAuthData = fillAuthData;
            authServiceFactory.authentication = authentication;


            return authServiceFactory;
        }]);

}());