(function () {
    'use strict';

    angular.module('homeFinance')
		.controller('addDialogController', ['$scope','$modalInstance','entity','title','resourseService','categories',
            function ($scope, $modalInstance, entity, title, resourseService, categories) {

                $scope.categories = categories;
                $scope.isBusy = false;
                $scope.title = title;
                $scope.entity = entity;
                $scope.alert = {
                    type: 'Error',
                    message: '',
                    ngClass: 'alert-danger',
                    isVisible: false
                };

                $scope.ok = function() {
                    $scope.isBusy = true;
                    resourseService.save({}, entity).$promise.then(function(data) {
                        $modalInstance.close(data);
                    }).catch(function() {
                        showErrorMessage("An error occurred while create " + title.toLowerCase() + " !");
                    }).finally(function() {
                        $scope.isBusy = false;
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
