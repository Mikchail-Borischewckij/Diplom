(function() {
    'use strict';

    angular.module('homeFinance')
		.factory('appConfig', [
			'$window', function ($window) {
			    return {
			        homeFinanceApiUrl: $window.appSettings.homeFinanceApiUrl
			    };
			}
		]);

    angular.module('homeFinance').config(function ($httpProvider, ChartJsProvider) {
        $httpProvider.interceptors.push('authInterceptorService');
        $httpProvider.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
        ChartJsProvider.setOptions({ colors: ['#337ab7', '#33b86c', '#f13c6e'] });
        ChartJsProvider.setOptions('Doughnut', {
            animateScale: true
        });
    });

    angular.module('homeFinance').run([
        '$rootScope', '$window', '$location', 'authService',
        function($rootScope, $window, $location, authService) {
            authService.fillAuthData();

            $rootScope.safeApply = function(fn) {
                var phase = this.$root.$$phase;
                if (phase === '$apply' || phase === '$digest') {
                    if (fn && (typeof (fn) === 'function')) {
                        fn();
                    }
                } else {
                    this.$apply(fn);
                }
            };

            $rootScope.$on('$stateChangeStart',
                function(event, toState) {
                    if (toState.data !== undefined) {
                        if (toState.data.isSecurity) {
                            if (!authService.chekAuthentication()) {
                                $window.location.href = '/';
                            }
                        }
                    }
                });
        }
    ]);

}());
