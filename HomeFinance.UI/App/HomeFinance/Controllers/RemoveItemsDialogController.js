(function () {
    'use strict';

    angular.module('homeFinance')
           .controller('removeItemsDialogController', [
            '$scope', '$q', '$modalInstance', 'removeItemsOptions', function ($scope, $q, $modalInstance, removeItemsOptions) {

                $scope.isLoading = false;
                $scope.isProcessed = false;
                $scope.alert = {
                    ngClass: "alert-danger",
                    message: "",
                    isVisible: false
                }
                $scope.itemsToRemove = angular.copy(removeItemsOptions.itemsToRemove);
                $scope.displayedPropertyNameFromItem = removeItemsOptions.displayedPropertyNameFromItem
                    ? removeItemsOptions.displayedPropertyNameFromItem : "Name";
                $scope.onClickYes = removeItems;
                $scope.onClickNo = dismissDialog;
                $scope.onClickOk = closeDialog;

                function removeItems() {
                    var promises = [];
                    $scope.isLoading = true;
                    angular.forEach($scope.itemsToRemove, function (item, key) {
                        var promise = removeItemsOptions.resourceService.remove({ id: item.Id }).$promise;
                        promise.then(createCallBackForSuccessfulRemoveEvent(item))
                               .catch(createCallBackForFailedRemoveEvent(item));
                        promises.push(promise);
                    });

                    // Wait to complete all
                    $q.all(promises).then(closeDialog).catch(function (err) {
                        showErrorMessage("An error(s) occurred while removing!");
                    }).finally(function () {
                        $scope.isLoading = false;
                        $scope.isProcessed = true;
                    });
                }

                function closeDialog() {
                    var removedItems = [];
                    angular.forEach($scope.itemsToRemove, function (value, key) {
                        if (value.isRemoved === true) {
                            removedItems.push(value);
                        }
                    });
                    $modalInstance.close(removedItems);
                }

                function dismissDialog() {
                    if (!$scope.isLoading) {
                        $modalInstance.dismiss();
                    }
                }

                function createCallBackForSuccessfulRemoveEvent(item) {
                    return function (result) {
                        item.isRemoved = true;
                    }
                }

                function createCallBackForFailedRemoveEvent(item) {
                    return function (result) {
                        item.isRemoved = false;
                    }
                }

                function showErrorMessage(message) {
                    $scope.alert.message = message;
                    $scope.alert.isVisible = true;
                }
            }
           ]);
}());
