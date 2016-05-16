(function () {
    'use strict';

    angular.module('homeFinance')
		.controller('dashboardHomeController', ['$scope', '$rootScope', '$http', 'accountService', 'messageServise',
            'currencyService', 'currenciesImages','colorsClasses',
        function ($scope, $rootScope, $http, accountService, messageServise, currencyService, currenciesImages, colorsClasses) {

            $scope.date = new Date();
            $scope.isBusy = false;
            $scope.currencies = [];
            getCurrencies();
            getAccounts();
  
          
            function getAccounts() {
                $scope.isBusy = true;
                accountService.getByUserId({ id: $rootScope.currentUser.Id }, {}).$promise.then(function(data) {
                    $scope.accounts = data;
                    getColor();
                }).catch(function() {
                    messageServise.showErrorMessage('An error occurred while loading accounts!');
                }).finally(function() {
                    $scope.isBusy = false;
                });
            }

            $scope.$on("addAccount", function () {
                getAccounts();
            });

            function getColor() {
                angular.forEach($scope.accounts, function (item) {
                    item.color = colorsClasses[Math.floor(Math.random() * colorsClasses.length)];
                });
            }
           
            function getCurrencies() {
                $scope.isCurrencyBusy = true;
                currencyService.getCurrentValues().$promise.then(function (data) {
                    angular.forEach(data, function (item) {
                        angular.forEach(currenciesImages, function (currency) {
                            if (item.Name.toLowerCase() === currency.Name.toLowerCase()) {
                                item.ImageURL = currency.ImageURL;
                            }
                        });
                    });
                    $scope.currencies = data;
                }).finally(function() {
                    $scope.isCurrencyBusy = false;
                });
            }
        }
		]);
}());