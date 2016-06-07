(function () {
	'use strict';

	angular.module('homeFinance')
		.controller('startController', [
			'$rootScope', '$scope', '$modal','$window', 'authService', '$state',
            function ($rootScope, $scope, $modal,$window, authService, $state) {
                $scope.Authorization = authService.authentication;
                $scope.isLoading = false;

                $scope.$on('cfpLoadingBar:loading', function () {
                    $scope.isLoading = true;
                });

                $scope.$on(' cfpLoadingBar:started', function () {
                    $scope.isLoading = true;
                });
               
                $scope.$on('cfpLoadingBar:loaded', function () {
                    $scope.isLoading = false;
                });
                
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
				$scope.getLink =function() {
				    if ($scope.Authorization.isAuth) {
				        $state.go('dashboard');
				    } else {
				        showAuthorizationDialog(true);
				    }
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
