(function () {
    'use strict';

    angular.module('homeFinance')
		.controller('addPlaningController', ['$scope', '$modalInstance', 'resourseService', 'categories', 'months',
            'selectedMonth', 'isIncome','account','gridData',
            function ($scope, $modalInstance, resourseService, categories, months, selectedMonth, isIncome, account, gridData) {

                $scope.gridData = gridData;
                $scope.months = months;
                $scope.categories = categories;
                $scope.isIncome = isIncome;
                $scope.selectedMonth = selectedMonth;
                $scope.isBusy = false;
                $scope.entity = {}
                $scope.alert = {
                    type: 'Error',
                    message: '',
                    ngClass: 'alert-danger',
                    isVisible: false
                };

                $scope.ok = function () {
                    if (checkExistingPlaning($scope.entity)) {
                        return;
                    }
                   $scope.entity.Date = new Date(new Date().getFullYear(), $scope.selectedMonth - 1,10,2,30,10);
                    $scope.entity.AccountId = account.Id;
                    $scope.isBusy = true;
                    resourseService.save({}, $scope.entity).$promise.then(function (data) {
                        $modalInstance.close(data);
                    }).catch(function () {
                        showErrorMessage("An error occurred while create planing!");
                    }).finally(function () {
                        $scope.isBusy = false;
                    });
                }

                function checkExistingPlaning(entity) {
                    var isFound = false;
                    angular.forEach($scope.gridData, function(item) {
                        if ($scope.entity.CategoryId === item.CategoryId) {
                            isFound = true;
                        }
                    });
                }

                $scope.cancel = function () {
                    $modalInstance.dismiss();
                }

                function showErrorMessage(message) {
                    $scope.alert.isVisible = true;
                    $scope.alert.message = message;
                }
            }
		]);
}());
