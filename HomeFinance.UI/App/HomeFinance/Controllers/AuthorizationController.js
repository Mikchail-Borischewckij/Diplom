(function() {
    'use strict';

    angular.module('homeFinance')
        .controller('authorizationController', [
            '$scope', '$rootScope', '$modalInstance', 'isLogin', '$timeout', 'authService',
            function($scope, $rootScope, $modalInstance, isLogin, $timeout, authService) {
                $scope.isLogin = isLogin;
                $scope.isWorking = false;
                $scope.alert = {
                    type: 'Error',
                    message: '',
                    ngClass:'alert-danger',
                    isVisible: false
                };

                $scope.user = {
                    Name: '',
                    Email: '',
                    Password: '',
                    ConfirmPassword: ''
                };

                $scope.ok = function() {
                    $scope.isWorking = true;

                    if ($scope.isLogin) {
                        authService.login($scope.user).then(function (data) {
                            $modalInstance.close(data);
                        }).catch(function() {
                            showErrorMessage("An error occurred while sing in!");
                        }).finally(function() {
                            $scope.isWorking = false;
                        });

                    } else {
                        authService.saveRegistration($scope.user).then(function (data) {
                            $modalInstance.close(data);
                        }).catch(function () {
                            showErrorMessage("An error occurred while sing up!");
                        }).finally(function () {
                            $scope.isWorking = false;
                        });
                    }
                }

                $scope.cancel = function() {
                    $modalInstance.dismiss();
                }

                function showErrorMessage(message) {
                    $scope.alert.isVisible = true;
                    $scope.alert.message = message;
                }
            }
        ]);
}());
