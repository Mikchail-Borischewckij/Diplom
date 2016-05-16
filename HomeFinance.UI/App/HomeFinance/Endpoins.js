(function () {
    'use strict';

    angular.module('homeFinance')
		.factory('endpoints', ['appConfig',
			function (appConfig) {

			    return {
			        // account
			        accountEndpoint: appConfig.homeFinanceApiUrl + 'account/:id',
			        allAccountEndpoint: appConfig.homeFinanceApiUrl +'account/all/:id',
			        //authenticate
			        loginEndpoint: appConfig.homeFinanceApiUrl +'authenticate/login',
			        registerEndpoint: appConfig.homeFinanceApiUrl + 'authenticate/register',
			        validateTokenEndpoint: appConfig.homeFinanceApiUrl + 'authenticate/validateToken',

			    	//consumption
			        consumptionEndpoint: appConfig.homeFinanceApiUrl + 'consumptions/:id',
			    	//costsCategories
			        costsCategoriesEndpoint: appConfig.homeFinanceApiUrl + 'costsCategories/:id',
			        allCostsCategoriesEndpoint: appConfig.homeFinanceApiUrl + 'costsCategories/all/:id',
			    	//currency
			        currencyEndpoint: appConfig.homeFinanceApiUrl + 'currency',
			        currencyValuesEndpoint: appConfig.homeFinanceApiUrl + 'currency/current',
			    	//incomeCategories
			        incomeCategoriesEndpoint: appConfig.homeFinanceApiUrl + 'incomeCategories/:id',
			        allIncomeCategoriesEndpoint: appConfig.homeFinanceApiUrl + 'incomeCategories/all/:id',
			    	//income
			        incomeEndpoint: appConfig.homeFinanceApiUrl + '/incomes/:id',
			        usersEndpoint: appConfig.homeFinanceApiUrl + 'users/current',
			        //incomePlaning
			        incomePlaningEndpoint: appConfig.homeFinanceApiUrl + 'incomePlaning/:id',
			        allIncomePlaningEndpoint: appConfig.homeFinanceApiUrl + 'incomePlaning/:id/:month',
			        monthsIncomePlaningEndpoint: appConfig.homeFinanceApiUrl + 'incomePlaning/:id',

			        //costsPlaning
			        costsPlaningEndpoint: appConfig.homeFinanceApiUrl + 'cotsPlaning/:id',
			        allCostsPlaningEndpoint: appConfig.homeFinanceApiUrl + 'cotsPlaning/:id/:month',
			        monthsCostsPlaningEndpoint: appConfig.homeFinanceApiUrl + 'incomePlaning/:id'
			        
			    };
			}
		]);
}());
