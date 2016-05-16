(function () {
    'use strict';

    angular.module('homeFinance')
		.controller('accountController', [
			'$scope', '$rootScope', 'editableGridFactory', 'incomeService', 'consumptionService', 'uiGridConstants', 'messageServise',
            '$modal', 'accountService', 'incomeCategoriesService','costsCategoriesSevice',
            function ($scope, $rootScope, editableGridFactory, incomeService, consumptionService,
                uiGridConstants, messageServise, $modal, accountService, incomeCategoriesService, costsCategoriesSevice) {

                function showRemoveItemsDialog(grid) {
                    messageServise.showRemoveItemsDialog(grid.gridApi.selection.getSelectedRows(), "Description",
                        grid.resourceService, function (removedItems) {
                            grid.removeItems.apply(grid, [removedItems]);
                        });
                }

                $scope.onClickRemove = showRemoveItemsDialog;
                $scope.isIncomeBusy = false;
                $scope.isCostsBusy = false;
                $scope.date = new Date();

                function createFilterByCategory(grid,data,index) {
                    grid.columnDefs[index].editDropdownOptionsArray = [];
                    grid.columnDefs[index].filter.selectOptions = [];
                    angular.forEach(data, function (item) {
                        grid.columnDefs[index].editDropdownOptionsArray.push({ id: item.Id, value: item.Name });
                        grid.columnDefs[index].filter.selectOptions.push({ value: item.Id, label: item.Name });
                    });
                }

                function convertToDate(array, property) {
                    angular.forEach(array, function (item) {
                        var date = item[property];
                        if (date) {
                            item[property] = new Date(date);
                        }
                    });
                }

                function loadingCostsCategories() {
                    var promise = costsCategoriesSevice.getByUserId({ id: $rootScope.currentUser.Id }).$promise;
                    promise.then(function (data) {
                        $scope.costsCategories = data;
                        if (!data || data.length === 0) {
                            messageServise.showInfoMessage('Please,create costs categories in "Setting"');
                        }
                        createFilterByCategory($scope.costsGrid, $scope.costsCategories, 4);
                    }).catch(function () {
                        messageServise.showErrorMessage("An error occurred while load costs categories!");
                    });
                }

             

                function loadingIncomeCategories() {
                    var promise = incomeCategoriesService.getByUserId({ id: $rootScope.currentUser.Id }).$promise;
                    promise.then(function (data) {
                        $scope.incomeCategories = data;
                        if (!data || data.length === 0) {
                            messageServise.showInfoMessage('Please,create income categories in "Setting"');
                        }

                        createFilterByCategory($scope.incomesGrid, $scope.incomeCategories, 4);
                    }).catch(function() {
                        messageServise.showErrorMessage("An error occurred while load income categories!");
                    });
                }

                function loadData() {
                    $scope.safeApply(function () {
                        $scope.account = $scope.$parent.selectedAccount;
                        loadingIncomeCategories();
                        loadingCostsCategories();
                        convertToDate($scope.account.Incomes, "CreatedDate");
                        convertToDate($scope.account.Incomes, "UpdatedDate");
                        convertToDate($scope.account.Сonsumptions, "CreatedDate");
                        convertToDate($scope.account.Сonsumptions, "UpdatedDate");
                        $scope.incomesGrid = createGrid(incomeService, $scope.account.Incomes, reloadIncome, "AddIncome", "incomeCategories");
                        $scope.costsGrid = createGrid(consumptionService, $scope.account.Сonsumptions, reloadConsumption, "AddCosts", "costsCategories");
                      
                    });
                }

                loadData();

                $scope.reloadCosts = function () {
                    $scope.isCostsBusy = true;
                    $scope.costsGrid.reloadGrid($scope.isCostsBusy);
                }

                $scope.reloadIncome = function () {
                    $scope.isIncomeBusy = true;
                    $scope.incomesGrid.reloadGrid($scope.isIncomeBusy);
                }

                function createGrid(service, data, loadCallback, createFromEntityCallbackName,categories) {
                    var grid = editableGridFactory.create($scope, service, loadCallback, {
                        paginationPageSizes: [25, 50, 75],
                        paginationPageSize: 25,
                        enableGridMenu: true,
                        cellEditableCondition: function($scope) {
                            return $scope.row.entity.TransactionType === 2; // ability to edit monthly transaction
                        },
                        columnDefs: [
                            {
                                field: 'actions', displayName: "", width: 30, enableFiltering: false,
                                cellTemplate: '<button type="button" class="btn btn-default btn-xs" ng-click="grid.appScope.'+createFromEntityCallbackName+'(row.entity)"><i class="fa fa-share"></i></button>'
                            },
                            { name: 'Amount', width: 100, type: 'number' },
                            { name: 'Description' },
                            { name: 'CreatedDate', type: 'date', enableFiltering: false, cellFilter: 'date:\'medium\'' },
                            {
                                field: 'CategoryId', name: 'Category',editableCellTemplate: 'ui-grid/dropdownEditor', 
                                editDropdownValueLabel: 'value',
                                filter: {
                                    type: uiGridConstants.filter.SELECT
                                },
                                cellTemplate: '<div class="ui-grid-cell-contents">{{COL_FIELD | categoryMap:grid.appScope.'+categories+'}}</div>'
                            },
                             { name: 'UpdatedDate', type: 'date', enableFiltering: false, cellFilter: 'date:\'longDate\'' },
                            {
                                field: 'TransactionType', name: 'TransactionType', width: 128, type: 'boolean',
                                editableCellTemplate: 'ui-grid/dropdownEditor', cellTemplate: "App/HomeFinance/Views/CellTemplates/TransactionType.html",
                                editDropdownOptionsArray: [
                                    { id: 1, value: 'Single' },
                                    { id: 2, value: 'Monthly' }
                                ], editDropdownValueLabel: 'value',

                                filter: {
                                    type: uiGridConstants.filter.SELECT,
                                    selectOptions: [{ value: 1, label: 'Single' }, { value: 2, label: 'Monthly' }]
                                }
                            }
                        ],
                        enableFiltering: true
                    }, false);

                    grid.updateItem = function (item) {
                        var promise = this.resourceService.save({ id: item.Id }, item).$promise;
                        promise.then(function (data) {
                            item = data;
                            $scope.account = accountService.getCurrent({ id: $scope.account.Id });
                        });
                        this.gridApi.rowEdit.setSavePromise(item, promise.promise);
                        return promise;
                    }

                    grid.reloadGrid = function() {
                        grid.data = this.resourceService.getByAccountId({ id: $scope.account.Id });
                        loadCallback(grid.data.$promise);
                    }

                    grid.loadList = function () {
                        $scope.safeApply(function () {
                            grid.data = data;
                        });
                    }

                    grid.loadList();
                    return grid;
                }

                function showAddedDialog(grid, title, resourseService,rowEntity,categories) {
                    var entity = {};
                    if (rowEntity) {
                        entity = angular.copy(rowEntity);
                        entity.Description += "-new";
                        entity.UpdatedDate = "";
                    } else {
                        entity = {
                            Amount: undefined,
                            Comment: '',
                            TransactionType: 1,
                            UpdatedDate: "",
                            AccountId: $scope.account.Id
                        };
                    }

                    var modalInstance = $modal.open({
                        animation: true,
                        templateUrl: 'App/HomeFinance/Views/PartialViews/AddDialog.html',
                        controller: 'addDialogController',
                        resolve: {
                            entity: function () { return entity; },
                            title: function () { return title; },
                            resourseService: function () {
                                return resourseService;
                            },
                            categories:function() {
                                return categories;
                            }
                        }
                    });

                    modalInstance.result.then(function (result) {
                        grid.data.push(result);
                         accountService.getCurrent({ id: $scope.account.Id }).$promise.then(function(data) {
                             $scope.account = data;
                         }).catch(function() {
                             messageServise.showErrorMessage(null);
                         });
                    });
                }

                $scope.AddIncome = function (entity) {
                    showAddedDialog($scope.incomesGrid, "Income", incomeService, entity, $scope.incomeCategories);
                }

                $scope.AddCosts = function (entity) {
                    showAddedDialog($scope.costsGrid, "Cost", consumptionService, entity, $scope.costsCategories);
                }

                function reloadIncome(promise) {
                    promise.catch(function () {
                        messageServise.showErrorMessage();
                    }).finally(function () {
                        $scope.safeApply(function () {
                            $scope.isIncomeBusy = false;
                        });
                    });
                }

                function reloadConsumption(promise) {
                    promise.catch(function () {
                        messageServise.showErrorMessage();
                    }).finally(function () {
                        $scope.safeApply(function () {
                            $scope.isCostsBusy = false;
                        });
                    });
                }
            }
		]);
}());