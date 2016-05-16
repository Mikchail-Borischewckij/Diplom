(function () {
    'use strict';

    angular.module('homeFinance')
		.controller('settingsController', ['$scope','$rootScope', '$modal', 'usersService', 'accountService',
            'editableGridFactory', 'messageServise', 'currencyService', 'uiGridConstants','incomeCategoriesService','costsCategoriesSevice',
            function ($scope, $rootScope, $modal, usersService, accountService, editableGridFactory, messageServise, currencyService,
                uiGridConstants, incomeCategoriesService, costsCategoriesSevice) {

                $scope.onClickRemove = showRemoveItemsDialog;
                $scope.AddAccount = showCreateAccountDialog;
                $scope.reloadIncomeCategories = loadingIncomeCategories;
                $scope.reloadCostsCategories = loadingCostsCategories;
                var promise = getCurrentUser();
                $scope.accountsGrid = {};
                $scope.accountsGrid.data = [];

                currencyService.query().$promise.then(function(data) {
                    $scope.currencies = data;
                    $rootScope.currencies = data;
                    createFilterByCurrency(data);
                }).catch(function() {
                    messageServise.showErrorMessage("An error occurred while load currencies!");
                });

                $scope.accountsGrid = createGrid(accountService, reloadGrid, updateAccountsPanel);
               
               
                function getCurrentUser() {
                    var promise = usersService.getCurrent().$promise;
                    promise.then(function (user) {
                        $scope.user = user;
                        loadingIncomeCategories();
                        loadingCostsCategories();
                    });
                    return promise;
                }

                $scope.addCategory=function(array,name,isIncome) {
                    var category= {
                        Id:0,
                        UserId:$scope.user.Id,
                        Name:name
                    }
                    var service = isIncome ? incomeCategoriesService : costsCategoriesSevice;
                    var title = isIncome ? 'income' : 'costs';
                    service.save({}, category).$promise.then(function (data) {
                        array.push(data);
                    }).catch(function () {
                        messageServise.showErrorMessage("An error occurred while save "+title+" category!");
                    });
                }

                $scope.removeCategory = function (array, category, isIncome) {
                    var service = isIncome ? incomeCategoriesService : costsCategoriesSevice;
                    var title = isIncome ? 'income' : 'costs';
                    service.delete({ id: category.Id }).$promise.then(function () {
                        var index = array.indexOf(category);
                        array.splice(index,1);
                    }).catch(function () {
                        messageServise.showErrorMessage("An error occurred while remove " + title + " category!");
                    });
                }

                function loadingIncomeCategories() {
                    $scope.isIncomeBusy = true;
                    incomeCategoriesService.getByUserId({ id: $scope.user.Id }).$promise.then(function (data) {
                        $scope.incomeCategories = data;
                    }).catch(function () {
                        messageServise.showErrorMessage("An error occurred while load income categories!");
                    }).finally(function() {
                        $scope.isIncomeBusy = false;
                    });
                }
               
                function loadingCostsCategories() {
                    $scope.isCostsBusy = true;
                    costsCategoriesSevice.getByUserId({ id: $scope.user.Id }).$promise.then(function (data) {
                        $scope.costsCategories = data;
                    }).catch(function () {
                        messageServise.showErrorMessage("An error occurred while load costs categories!");
                    }).finally(function () {
                        $scope.isCostsBusy = false;
                    });
                }

                function createGrid(service, loadCallback, updateItemCallback) {
                    var grid = editableGridFactory.create($scope, service, loadCallback, {
                        paginationPageSizes: [25, 50, 75],
                        paginationPageSize: 25,
                        enableGridMenu: true,
                        columnDefs: [
                            { name: 'Name', width: 100},
                            { name: 'AmountMoney', type: 'number' },
                            {
                                field:'CurrencyId',  name: 'Currency', cellTemplate: "App/HomeFinance/Views/CellTemplates/Currency.html",
                                editableCellTemplate: 'ui-grid/dropdownEditor', editDropdownValueLabel: 'value',
                                filter: {
                                    type: uiGridConstants.filter.SELECT
                                }
                            }
                            ],
                        enableFiltering: true
                    }, false, updateItemCallback);

                    grid.reloadGrid = function () {
                        if (!$scope.user) {
                            $scope.user = promise;
                        }
                        grid.data = this.resourceService.getByUserId({ id: $scope.user.Id }, {});
                        loadCallback(grid.data.$promise);
                    }

                    grid.loadList = function () {
                        $scope.safeApply(function () {
                            if (!$scope.user) {
                                $scope.user = promise;
                            }
                            grid.data = accountService.getByUserId({ id: $scope.user.Id }, {});
                        });
                    }

                    grid.loadList();
                    return grid;
                }

                function createFilterByCurrency(data) {
                    $scope.accountsGrid.columnDefs[2].editDropdownOptionsArray = [];
                    $scope.accountsGrid.columnDefs[2].filter.selectOptions = [];
                    angular.forEach(data, function(item) {
                        $scope.accountsGrid.columnDefs[2].editDropdownOptionsArray.push({ id: item.Id, value: item.Name });
                        $scope.accountsGrid.columnDefs[2].filter.selectOptions.push({ value: item.Id, label: item.Name });
                    });
                }

                function updateAccountsPanel() {
                    $scope.$emit('addedAccounts', $scope.accountsGrid.data);
                }

                function reloadGrid(promise) {
                    promise.catch(function () {
                        messageServise.showErrorMessage();
                    }).finally(function () {
                        $scope.safeApply(function () {
                            $scope.isAccountGridBusy = false;
                        });
                    });
                }

                $scope.reloadGrid = function () {
                    $scope.isAccountGridBusy = true;
                    $scope.accountsGrid.reloadGrid();
                }

                function showCreateAccountDialog() {
                    var account = {
                        Name: "",
                        AmountMoney: 0,
                        Currency: { Id: 0, Name: '' }
                    }
                    var modalInstance = $modal.open({
                        animation: true,
                        templateUrl: 'App/HomeFinance/Views/PartialViews/CreateAccount.html',
                        controller: 'createAccountController',
                        resolve: {
                            user: function() {
                                return $scope.user;
                            },
                            account: function() { return account; }
                        }
                    });

                    modalInstance.result.then(function(result) {
                        accountService.getByUserId({ id: $scope.user.Id }, {}).$promise.then(function(data) {
                            $scope.accountsGrid.data = data;
                            $scope.$emit('addedAccounts', $scope.accountsGrid.data);
                        });
                    });
                }

                function showRemoveItemsDialog(grid) {
                    messageServise.showRemoveItemsDialog($scope.accountsGrid.gridApi.selection.getSelectedRows(), "Name",
						$scope.accountsGrid.resourceService, function (removedItems) {
						    $scope.accountsGrid.removeItems.apply($scope.accountsGrid, [removedItems]);
						    $scope.$emit('addedAccounts', $scope.accountsGrid.data);
						});
                }
            }
		]);
}());
