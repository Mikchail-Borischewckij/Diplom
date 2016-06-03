(function () {
	'use strict';

	angular.module('homeFinance').controller('planingController', [
        '$rootScope', '$scope', '$q','$modal', 'editableGridFactory', 'incomePlaningService', 'costsPlaningService', 'messageServise', 'incomeCategoriesService',
		'costsCategoriesSevice', 'accountService','uiGridConstants','incomeFooterTemplate','costsFooterTemplate','months',
	    function ($rootScope, $scope, $q,$modal, editableGridFactory, incomePlaningService, costsPlaningService, messageServise, 
            incomeCategoriesService, costsCategoriesSevice, accountService, uiGridConstants, incomeFooterTemplate, costsFooterTemplate, months) {
	    	$scope.isCostsBusy = false;
	    	$scope.isIncomeBusy = false;
	    	$scope.selectedMonth = new Date().getMonth() + 1;

	    	$scope.incomesGrid = createGrid(incomePlaningService, reloadIncome, "incomeCategories",incomeFooterTemplate, true);
	    	$scope.costsGrid = createGrid(costsPlaningService, reloadCosts, "costsCategories",costsFooterTemplate, false);
            
	    	function showRemoveItemsDialog(grid) {
	    	    messageServise.showRemoveItemsDialog(grid.gridApi.selection.getSelectedRows(), "Amount",
                    grid.resourceService, function (removedItems) {
                        grid.removeItems.apply(grid, [removedItems]);
                    });
	    	}

	    	$scope.onClickRemove = showRemoveItemsDialog;

	    
	    	function loadData() {
	    	    $q.all([getAccounts(), loadingIncomeCategories(), loadingCostsCategories()]).then(function () {
	    			$scope.safeApply(function () {
	    			    getMonths();
	    			    createFilterByCategory($scope.incomesGrid, $scope.incomeCategories, 1);
	    			    createFilterByCategory($scope.costsGrid, $scope.costsCategories, 1);
	    			    $scope.incomesGrid.loadList();
	    			    $scope.costsGrid.loadList();
	    			});
	    		});
	    	}

	    	function getSummByProperty(array, property) {
	    		var result = 0;
	    		angular.forEach(array, function (item) {
	    			result += item[property];
	    		});
	    		return result;
	    	}

	    	function getResultForItem(data, array, month) {
	    		angular.forEach(data, function (item) {
	    			item.Result = getSummByProperty(getTransactionByMonthAndCategory(array, month, item.CategoryId), "Amount");
				    item.Difference = item.Result - item.Amount;
			    });
	    	}

	    	function getMonths() {
	    	    var result = [];
		        $q.all([getIncomeMonths(), getCostsMonths()]).then(function() {
		            var data = $scope.incomesMonths.concat($scope.costsMonths);

		            angular.forEach(data, function (item) {
		                result.push({ id: item, value: months[item - 1] });
		            });

		            //add current month
		            result.push({ id: new Date().getMonth() + 1, value: months[new Date().getMonth()] });
		            // add next month
		            result.push({ id: new Date().getMonth() + 2, value: months[new Date().getMonth() + 1] });

		            $scope.months = trim(result, "id");
		        });
	    	}

	        function getIncomeMonths() {
	            var promise = incomePlaningService.getMonths({ id: $scope.selectedAccount.Id }, {}).$promise;
	            promise.then(function (data) {
	                $scope.incomesMonths = data;
	            }).catch(function() {
	                messageServise.showErrorMessage('An error occurred while loading the available months!');
	            });
	            return promise;
	        }

	        function getCostsMonths() {
	            var promise = costsPlaningService.getMonths({ id: $scope.selectedAccount.Id }, {}).$promise;
	            promise.then(function (data) {
	                $scope.costsMonths = data;
	            }).catch(function () {
	                messageServise.showErrorMessage('An error occurred while loading the available months!');
	            });
	            return promise;
	        }
	        function trim(arr, key) {
	            var values = {};
	            return arr.filter(function (item) {
	                var val = item[key];
	                var exists = values[val];
	                values[val] = true;
	                return !exists;
	            });
	        }

	    	loadData();

	    	$scope.change = function () {
	    	    getMonths();
	    	    $scope.incomesGrid.reloadGrid();
	    	    $scope.costsGrid.reloadGrid();
		    }

	    	function getAccounts() {
		        var promise = accountService.getByUserId({ id: $rootScope.currentUser.Id }, {}).$promise;
	    		promise.then(function (data) {
	    			$scope.accounts = data;
	    			getSelectedAccount();
	    		}).catch(function () {
	    			messageServise.showErrorMessage('An error occurred while loading accounts!');
	    		});
	    		return promise;
	    	}

	    	var getCssClass = function (row, isIncome) {
	    	    var result = {};
	    	    if (isIncome) {
	    	        result = row.entity.Result >= row.entity.Amount ? 'green' : 'red';
	    	        return result;
	    	    } else {
	    	        result = row.entity.Result >= row.entity.Amount ? 'red' : 'green';
	    	        return result;
	    	    }
	    	}
            
	    	function createGrid(service, loadCallback, categories,footerTemplate,isIncome) {
	    	    var grid = editableGridFactory.create($scope, service, loadCallback, {
	    	        showColumnFooter: true,
	    			paginationPageSizes: [25, 50, 75],
	    			paginationPageSize: 25,
	    			enableGridMenu: true,
	    			columnDefs: [
                        	    {
                        	        field: 'CategoryId',
                        	        name: 'Category',
                        	        editableCellTemplate: 'ui-grid/dropdownEditor',
                        	        editDropdownValueLabel: 'value',
                        	        enableCellEdit: false,
                        	        cellTemplate: '<div class="ui-grid-cell-contents">{{COL_FIELD | categoryMap:grid.appScope.' + categories + '}}</div>',
                        	    },
				        {
				            name: 'Amount', width: 100, type: 'number',
				            enableCellEdit: false,
				            aggregationType: uiGridConstants.aggregationTypes.sum,
				           },
					    {
					        name: 'Result', displayName: 'Result', enableCellEdit: false, cellClass: function(grid,row) {
					            return getCssClass(row, isIncome);
					        },
					        aggregationType: uiGridConstants.aggregationTypes.sum,
					       },
				        {
				            name: 'Difference', enableCellEdit: false, cellClass: function (grid, row) {
				                if (isIncome) {
				                    return row.entity.Difference < 0 ? 'red' : 'green';
				                }
				                return row.entity.Difference > 0 ? 'red' : 'green';
				            },
				            aggregationType: uiGridConstants.aggregationTypes.sum,
				            footerCellTemplate: footerTemplate
				        }
				    ],
	    			enableFiltering: false
	    	    }, false, reload);
	    		grid.reloadGrid = function () {
	    		    grid.data = this.resourceService.getPlanings({ id: $scope.selectedAccount.Id, month: $scope.selectedMonth });
	    			loadCallback(grid.data.$promise);
	    		}

	    		grid.loadList = function () {
	    		    grid.data = this.resourceService.getPlanings({ id: $scope.selectedAccount.Id, month: $scope.selectedMonth });
	    			loadCallback(grid.data.$promise);
	    		}
	    		
	    		return grid;
	    	}


	    	$scope.addIncome=function() {
	    	    showAddedDialog($scope.incomesGrid, incomePlaningService, $scope.incomeCategories,true);
	    	}

	    	$scope.addCost = function () {
	    	    showAddedDialog($scope.costsGrid, costsPlaningService, $scope.costsCategories, true);
	    	}

	    	function showAddedDialog(grid, resourseService, categories,isIncome,data) {
	    	    var modalInstance = $modal.open({
	    	        animation: true,
	    	        templateUrl: 'App/HomeFinance/Views/PartialViews/AddPlaningDialog.html',
	    	        controller: 'addPlaningController',
	    	        resolve: {
	    	            resourseService: function () {
	    	                return resourseService;
	    	            },
	    	            categories: function () {
	    	                return categories;
	    	            },
                        months:function() {
                            return angular.copy($scope.months);
                        },
                        selectedMonth:function() {
                            return $scope.selectedMonth;
                        },
	    	            isIncome:function() {
		                    return isIncome;
	    	            },
                        account:function() {
                            return $scope.selectedAccount;
                        },
                        gridData:function() {
                            return data;
                        }
	    	        }
	    	    });

	    	    modalInstance.result.then(function (result) {
	    	        grid.reloadGrid();
	    	    });
	    	}

	    	function createFilterByCategory(grid, data, index) {
	    		grid.columnDefs[index].editDropdownOptionsArray = [];
	    		angular.forEach(data, function (item) {
	    			grid.columnDefs[index].editDropdownOptionsArray.push({ id: item.Id, value: item.Name });
	    		});
	    	}

	        function reload() {
	            $scope.incomesGrid.reloadGrid();
	            $scope.costsGrid.reloadGrid();
	        }

	    	function reloadIncome(promise) {
	    		promise.then(function () {
	    		    getResultForItem($scope.incomesGrid.data, $scope.selectedAccount.Incomes, $scope.selectedMonth);
	    		}).catch(function () {
	    			messageServise.showErrorMessage("An error occurred while load planing incomes!");
	    		}).finally(function () {
	    			$scope.safeApply(function () {
	    				$scope.isIncomeBusy = false;
	    			});
	    		});
	    	}

	    	function reloadCosts(promise) {
	    	    promise.then(function () {
	    	        getResultForItem($scope.costsGrid.data, $scope.selectedAccount.Сonsumptions, $scope.selectedMonth);
	    	    }).catch(function () {
	    			messageServise.showErrorMessage("An error occurred while load costs planing!");
	    		}).finally(function () {
	    			$scope.safeApply(function () {
	    				$scope.isCostsBusy = false;
	    			});
	    		});
	    	}

	    	function loadingIncomeCategories() {
	    		var promise = incomeCategoriesService.getByUserId({ id: $rootScope.currentUser.Id }).$promise;
	    		promise.then(function (data) {
	    			$scope.incomeCategories = data;
	    			if (!data || data.length === 0) {
	    				messageServise.showInfoMessage('Please,create income categories in "Setting"');
	    			}
	    		}).catch(function () {
	    			messageServise.showErrorMessage("An error occurred while load income categories!");
	    		});
	    		return promise;
	    	}

	    	function loadingCostsCategories() {
	    		var promise = costsCategoriesSevice.getByUserId({ id: $rootScope.currentUser.Id }).$promise;
	    		promise.then(function (data) {
	    			$scope.costsCategories = data;
	    			if (!data || data.length === 0) {
	    				messageServise.showInfoMessage('Please,create costs categories in "Setting"');
	    			}
	    		}).catch(function () {
	    			messageServise.showErrorMessage("An error occurred while load costs categories!");
	    		});
	    		return promise;
	    	}


	    	function getSelectedAccount() {
	    		if (!$rootScope.selected) {
	    			$scope.selectedAccount = $scope.accounts[0];
	    		} else {
	    			angular.forEach($scope.accounts, function (item) {
	    				if (item.Name.toLowerCase() === $rootScope.selected.Name.toLowerCase()) {
	    					$scope.selectedAccount = item;
	    				}
	    			});
	    		}
	    	}

	    	$scope.showPlaningCalculator = function () {
	    	    var modalInstance = $modal.open({
	    	        animation: true,
                    templateUrl: 'App/HomeFinance/Views/PartialViews/PlaningCalculator.html',
                    controller: 'planingCalculatorController',
                    resolve: {
                        account: function () { return angular.copy($scope.selectedAccount); }
		            }
		        });
	    	}

	    	function getTransactionByMonthAndCategory(array, month, categoryId) {
	    		var result = [];
	    		angular.forEach(array, function (item) {
	    			var date = new Date(item.CreatedDate.toString());
	    			if (date.getMonth() + 1 === month && categoryId === item.CategoryId) {
	    				result.push(item);
	    			}
	    		});
	    		return result;
               }
	    }
	]);
}());
