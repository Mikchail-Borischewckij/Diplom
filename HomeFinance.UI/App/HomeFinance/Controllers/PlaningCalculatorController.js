(function () {
    'use strict';

    angular.module('homeFinance')
            .controller('planingCalculatorController', ['$scope', '$http', '$modalInstance', 'account', 'endpoints',
        function ($scope, $http, $modalInstance, account, endpoints) {
            $scope.isBusy = false;
            $scope.account = account;
            $scope.isResult = false;
            $scope.series = [''];
            $scope.months = [];
            $scope.types = [
            { Name: 'Accumulated capital for the period', Value: 1 },
            { Name: 'Define the period for the purchase of anything', Value: 2 }
            ];

            $scope.steps = [
            { Name: 'Step 1', Code: '1', active: true },
            { Name: 'Step 2', Code: '2', active: false },
            { Name: 'Step 3', Code: '3', active: false }
            ];
            $scope.alert = {
                type: 'Error',
                message: '',
                ngClass: 'alert-danger',
                isVisible: false
            };
            getAverageBalance();

            $scope.cancel = function () {
                $modalInstance.dismiss();
            }

            $scope.getResult = function () {
                var r = $scope.averageBalance;
                if (angular.isDefined($scope.costs)) {
                    r = r - $scope.costs;
                }
                if ($scope.type === '1') {
                    if ($scope.period > 1) {
                        var resultArr = [];
                        var sum = 0;
                        for (var i = 1; i <= $scope.period; i++) {
                            $scope.months.push(i);
                            sum += r;
                            resultArr.push(sum);
                        }
                        $scope.dataLine = [resultArr];
                    }
                    $scope.result = r * $scope.period;
                } else {
                    if ($scope.money < r) {
                        $scope.result = 1;
                    } else {
                        $scope.result = $scope.money / r;
                        var count = parseInt($scope.result, 10);
                        var resultArr = [];
                        var sum = 0;
                        for (var i = 1; i <= count; i++) {
                            $scope.months.push(i);
                            sum += r;
                            resultArr.push(sum);
                        }
                        $scope.dataLine = [resultArr];
                    }
                   
                }
                
            }

            function getAverageBalance() {
                $scope.isBusy = true;
                $http({ method: 'GET', url: endpoints.planingEndpoint + $scope.account.Id }).then(function (data) {
                    $scope.averageBalance = data.data;
                }).catch(function () {
                    showErrorMessage("Can not load the average balance!");
                }).finally(function () {
                    $scope.isBusy = false;
                });
            }


            function showErrorMessage(message) {
                $scope.alert.isVisible = true;
                $scope.alert.message = message;
            }
        }
            ]);
}());
