(function () {
    'use strict';

    angular.module('homeFinance')
        .config(function($httpProvider, $stateProvider, $urlRouterProvider) {
            $httpProvider.defaults.useXDomain = true;
        delete $httpProvider.defaults.headers.common['X-Requested-With'];

        $urlRouterProvider.otherwise("/home");
        $stateProvider
            .state('root', {
                abstract: true,
                url: '/',
                template: "<ui-view/>"
            })
            .state('home', {
                url: '/home',
                templateUrl: "App/HomeFinance/Views/Start.html",
                controller: 'startController'
            })
            .state('dashboard', {
                url: '/dashboard',
                templateUrl: "App/HomeFinance/Views/Dashboard.html",
                controller: 'dashboardController',
                data: {
                    isSecurity: true
                }
            })
            .state('dashboard.accounts', {
                url: "/account/:id",
                templateUrl: "App/HomeFinance/Views/PartialViews/Account.html",
                controller: "accountController",
                data: {
                    isSecurity: true
                }
            })
            .state('dashboard.statistic', {
                url: "/statistic",
                templateUrl: "App/HomeFinance/Views/PartialViews/Statistic.html",
                controller: "statisticController",
                data: {
                    isSecurity: true
                }
            })
            .state('dashboard.planing', {
                url: "/planing",
                templateUrl: "App/HomeFinance/Views/PartialViews/Planing.html",
                controller: "planingController",
                data: {
                    isSecurity: true
                }
            })
            .state('dashboard.home', {
                url: "/home",
                templateUrl: "App/HomeFinance/Views/PartialViews/DashboardHome.html",
                controller: "dashboardHomeController",
                data: {
                    isSecurity: true
                }
            })
            .state('dashboard.settings', {
                url: "/settings",
                templateUrl: "App/HomeFinance/Views/PartialViews/Settings.html",
                controller: "settingsController",
                data: {
                    isSecurity: true
                }
            });
    });
}());
