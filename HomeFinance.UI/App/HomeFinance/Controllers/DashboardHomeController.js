(function () {
    'use strict';

    angular.module('homeFinance')
		.controller('dashboardHomeController', ['$scope', '$rootScope','$q', '$http', 'accountService', 'messageServise',
            'currencyService', 'currenciesImages','colorsClasses',
        function ($scope, $rootScope,$q, $http, accountService, messageServise, currencyService, currenciesImages, colorsClasses) {

            $scope.date = new Date();
            $scope.isBusy = false;
            $scope.currencies = [];
            load();
          
            function getAccounts() {
                $scope.isBusy = true;
                var promise = accountService.getByUserId({ id: $rootScope.currentUser.Id }, {}).$promise
                promise.then(function (data) {
                    $scope.accounts = data;
                    getColor();
                }).catch(function() {
                    messageServise.showErrorMessage('An error occurred while loading accounts!');
                }).finally(function() {
                    $scope.isBusy = false;
                });
                return promise;
            }

            $scope.$on("addAccount", function () {
                load();
            });

            function getColor() {
                angular.forEach($scope.accounts, function (item) {
                    item.color = colorsClasses[Math.floor(Math.random() * colorsClasses.length)];
                });
            }

            function load() {
                $q.all([getAccounts(), getCurrencies()]).then(function() {
                    showChart();
                });
            }

            function showChart() {
                $scope.labels = getLabels();
                $scope.data = getData();
            }
            
            $scope.$on('create', function (event, chart) {
                    chart.chart.height = 300;
            });

            function getData() {
                var result = [];
                angular.forEach($scope.accounts, function(account) {
                    if (account.Currency.Name.toLowerCase() !== 'BLR'.toLowerCase()) {
                        result.push(account.AmountMoney * getCurrecncyValueByName(account.Currency.Name));
                    } else {
                        result.push(account.AmountMoney);
                    }
                });
                return result;
            }

            function getCurrecncyValueByName(name) {
                var result = {};
                angular.forEach($scope.currencies, function (currency) {
                    if (name.toLowerCase() === currency.Name.toLowerCase()) {
                        result = currency.Value;
                    }
                });
                return result;
            }

            function getLabels() {
                var result = [];
                angular.forEach($scope.accounts, function (account) {
                    result.push(account.Name);

                });
                return result;
            }

            function getCurrencies() {
                $scope.isCurrencyBusy = true;
                var promise = currencyService.getCurrentValues().$promise;
                promise.then(function (data) {
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
                return promise;
            }
        }
		]);
}());