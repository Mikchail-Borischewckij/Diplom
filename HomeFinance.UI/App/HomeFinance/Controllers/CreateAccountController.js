(function () {
	'use strict';

	angular.module('homeFinance')
		.controller('createAccountController', [
			'$scope','user', 'account', '$modalInstance', 'currencyService','accountService',
            function ($scope, user, account, $modalInstance, currencyService, accountService) {

                $scope.alert = {
                    type: 'Error',
                    message: '',
                    ngClass: 'alert-danger',
                    isVisible: false
                };

			     currencyService.query().$promise.then(function(data) {
			         $scope.currencies = data;
			         $scope.account = account;
			         $scope.account.UserId = user.Id;
			         getDefaultCurrency();
			     });
			    
				$scope.ok = function () {
				    $scope.isWorking = true;
				    accountService.save({}, $scope.account).$promise.then(function() {
				        $modalInstance.close($scope.account);
				    }).catch(function() {
				        showErrorMessage("An error occurred while create account!");
				    }).finally(function() {
				        $scope.isWorking = false;
				    });
					
				}

				$scope.cancel = function () {
					$modalInstance.dismiss();
				}

				function getDefaultCurrency() {
				    angular.forEach($scope.currencies, function(item) {
				        if (item.Name.toLowerCase() === "BRL".toLowerCase()) {
				            $scope.account.CurrencyId = item.Id;
				        }
				    });
				}

				function showErrorMessage(message) {
				    $scope.alert.isVisible = true;
				    $scope.alert.message = message;
				}
			}
		]);
}());
