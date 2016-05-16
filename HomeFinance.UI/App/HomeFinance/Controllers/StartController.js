(function () {
	'use strict';

	angular.module('homeFinance')
		.controller('startController', [
			'$rootScope', '$scope', '$modal', 'authService',
            function ($rootScope, $scope, $modal, authService) {
                $scope.Authorization = authService.authentication;
				function showAuthorizationDialog(isLogin) {
					var modalInstance = $modal.open({
					    animation: true,
					    backdrop: 'static',
					    keyboard: false,
						templateUrl: 'App/HomeFinance/Views/PartialViews/Authorization.html',
						controller: 'authorizationController',
						resolve: {
							isLogin: function () { return isLogin; }
						}
					});

					return modalInstance.result;
				}

				$scope.singIn = function () {
					showAuthorizationDialog(true);
				};
				$scope.singUp = function () {
					showAuthorizationDialog(false);
				}

                $scope.logOut = function() {
                    $scope.safeApply(function() {
                        authService.logOut();
                    });
                }
			}
		]);
}());
