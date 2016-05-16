(function () {
    'use strict';

    angular.module('homeFinance')
		.controller('dashboardController', [
			'$scope', '$rootScope','$q', '$modal', '$timeout','$window','$location', 'authService', 'usersService','accountService',
            function ($scope, $rootScope, $q, $modal, $timeout,$window,$location, authService, usersService, accountService) {

                $scope.logOut = logOut;
                $scope.accounts = [];
                function showCreateAccountDialog() {
                    var account = {
                        Name: "",
                        AmountMoney: 0,
                        Currency: { Id: 0, Name: '' }
                    }
                    var modalInstance = $modal.open({
                        animation: true,
                        backdrop: 'static',
                        keyboard: false,
                        templateUrl: 'App/HomeFinance/Views/PartialViews/CreateAccount.html',
                        controller: 'createAccountController',
                        resolve: {
                            user: function () {
                                return $scope.user;
                            },
                            account: function () { return account; }
                        }
                    });

                    modalInstance.result.then(function (result) {
                        getAccounts($scope.user);
                        $scope.$broadcast('addAccount');
                    });
                }

                $scope.addAccount = showCreateAccountDialog;

                function createAccount() {
                    $timeout(function () {
                        showCreateAccountDialog();
                    }, 1000);
                    return [];
                }

                function getAccounts(user) {
                    accountService.getByUserId({ id: user.Id }, {}).$promise.then(function(data) {
                        $scope.accounts = data;
                        if ($scope.accounts.length <= 0) {
                            createAccount();
                        }
                    }).catch(function() {
                        createAccount();
                    });
                }

                usersService.getCurrent().$promise.then(function (user) {
                    $scope.user = user;
                    $rootScope.currentUser = user;
                    $scope.activeDashboard = true;
                    $location.path('/dashboard/home');
                    getAccounts(user);
                });

                $scope.$on('addedAccounts', function (event, data) {
                    $scope.safeApply(function() {
                        $scope.accounts = data;
                    });
                });

                function logOut() {
                    $scope.safeApply(function () {
                        authService.logOut();
                        $window.location.href = '/';
                    });
                }

                $scope.selected = function (account) {
                    $scope.safeApply(function () {
                        $rootScope.selected = account;
                        $scope.selectedAccount = account;
                    });
                };
            }
		]);
}());
