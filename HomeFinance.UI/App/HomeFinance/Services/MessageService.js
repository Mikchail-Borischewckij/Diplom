(function () {
    'use strict';

    angular.module('homeFinance')
        .service('messageServise', [
        '$modal', 'notify', function ($modal, notify) {
      

            this.showSuccessMessage = function (message) {
                if (!message) {
                    message = 'Changes save successfully!';
                }
                notify({
                    message: message,
                    templateUrl: 'App/HomeFinance/Views/Notify/Notify_Success.html',
                    position: 'right',
                    duration: 5000
                });
            }

            this.showInfoMessage = function (message) {
            notify({
                    message: message,
                    templateUrl: 'App/HomeFinance/Views/Notify/Notify_Info.html',
                    position: 'right',
                    duration: 5000
                });
            }

            this.showBlackMessage = function (message) {
                notify({
                    message: message,
                    templateUrl: 'App/HomeFinance/Views/Notify/Notify_Black.html',
                    position: 'right',
                    duration: 5000
                });
            }

            this.showErrorMessage = function (message) {
                if (!message) {
                    message = "An error occurred while saving!";
                }

                notify({
                    message: message,
                    templateUrl: 'App/HomeFinance/Views/Notify/Notify_Error.html' ,
                    position: 'right',
                    duration: 5000
                });
            }

            // Shows dialog which can remove items on the server after user confirmation
            this.showRemoveItemsDialog = function (itemsToRemove, displayedPropertyNameFromItem, resourceService, onItemsRemovedCallback) {
                var modalInstance = $modal.open({
                    animation: true,
                    keyboard: true,
                    backdrop: 'static',
                    templateUrl: 'App/HomeFinance/Views/PartialViews/RemoveItemsDialog.html',
                    controller: 'removeItemsDialogController',
                    resolve: {
                        removeItemsOptions: function () {
                            return {
                                itemsToRemove: itemsToRemove,
                                displayedPropertyNameFromItem: displayedPropertyNameFromItem,
                                resourceService: resourceService
                            };
                        }
                    }
                });
                modalInstance.result.then(onItemsRemovedCallback);
            }

        }
        ]);
}());