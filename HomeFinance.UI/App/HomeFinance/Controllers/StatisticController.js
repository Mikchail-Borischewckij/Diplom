(function () {
    'use strict';

    angular.module('homeFinance')
		.controller('statisticController', ['$scope', '$rootScope', 'accountService', 'usersService', 'messageServise',
            'costsCategoriesSevice', 'incomeCategoriesService', 'currencyService', '$filter',
            function ($scope, $rootScope, accountService, usersService, messageServise, costsCategoriesSevice,
                incomeCategoriesService, currencyService, $filter) {

                $scope.months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
                $scope.monthsCopy = angular.copy($scope.months);
                $scope.dropDownMonths = [];
                $scope.showTransactionChart = showTransactionChart;
                $scope.showChartByCostsCategory = showChartByCostsCategory;
                $scope.showChartByIncomeCategory = showChartByIncomeCategory;
                $scope.data = [1, 1];
                $scope.dataLine = [1, 1];
                function getColorsArray(count) {
                    var result = [];
                    for (var i = 0; i < count; i++) {
                        result.push(getRandomColor);
                    }
                    return result;
                }

                function getAmountByCategoryId(array, categoryId) {
                    var result = 0;
                    angular.forEach(array, function (item) {
                        if (item.CategoryId === categoryId) {
                            result += item.Amount;
                        }
                    });
                    return result;
                }

                function uniq(a) {
                    var seen = {};
                    return a.filter(function (item) {
                        return seen.hasOwnProperty(item) ? false : (seen[item] = true);
                    });
                }

                function getCategories(array) {
                    var result = [];
                    angular.forEach(array, function (item) {
                        result.push(item.CategoryId);
                    });
                    return uniq(result);
                }


                function showChartByIncomeCategory() {
                    var month = {};
                    var data = new Date();
                    if (!$scope.incomesCategoryMontch) {
                        month = data.getMonth() + 1;
                        $scope.incomesCategoryMontch = month;
                    } else {
                        month = $scope.incomesCategoryMontch;
                    }
                    var array = getTransactionByMonth($scope.selectedAccount.Incomes, month);
                    var categories = getCategories(array);
                    $scope.incomesCategoriesMonthsList = getdropDownListCategories($scope.selectedAccount.Incomes, getCategories($scope.selectedAccount.Incomes));
                    var result = [];
                    $scope.incomeCategorieslabels = [];
                    angular.forEach(categories, function (item) {
                        result.push(getAmountByCategoryId(array, item));
                        angular.forEach($scope.incomeCategories, function (category) {
                            if (category.Id === item) {
                                $scope.incomeCategorieslabels.push(category.Name);
                            }
                        });
                    });
                    $scope.safeApply(function () {
                        $scope.incomeColors = getColorsArray(result.length);
                        $scope.incomeCategorieslabels = uniq($scope.incomeCategorieslabels);
                        $scope.incomeCategoriesData = result;
                    });
                }

                function getMonths() {
                    if (!$scope.year) {
                        $scope.year = new Date().getFullYear();
                    }
                    var months = [];
                    angular.forEach($scope.selectedAccount.Incomes, function (item) {
                        var date = new Date(item.CreatedDate.toString());
                        if (date.getFullYear() === $scope.year) {
                            months.push(date.getMonth() + 1);
                        }
                    });

                    angular.forEach($scope.selectedAccount.Сonsumptions, function (item) {
                        var date = new Date(item.CreatedDate.toString());
                        if (date.getFullYear() === $scope.year) {
                            months.push(date.getMonth() + 1);
                        }
                    });
                    return uniq(months);
                }

                function getSummByProperty(array, property) {
                    var result = 0;
                    angular.forEach(array, function (item) {
                        result += item[property];
                    });
                    return result;
                }

                function getTransactionByMonth(array, month) {
                    var result = [];
                    angular.forEach(array, function (item) {
                        var date = new Date(item.CreatedDate.toString());
                        if (date.getMonth() + 1 === month) {
                            result.push(item);
                        }
                    });
                    return result;
                }

                function generateLineChart() {
                    $scope.months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
                    var months = getMonths();
                    var incomes = [];
                    var costs = [];
                    var temp = [];
                    angular.forEach(months, function (item) {
                        var income = getSummByProperty(getTransactionByMonth($scope.selectedAccount.Incomes, item), "Amount");
                        incomes.push(income);
                        var cost = getSummByProperty(getTransactionByMonth($scope.selectedAccount.Сonsumptions, item), "Amount");
                        costs.push(cost);
                        temp.push($scope.months[item-1]);
                    });
                    temp.sort(function (a, b) {
                        return $scope.months.indexOf(a) > $scope.months.indexOf(b);
                    });

                    if (temp.length < 2) {
                        if ($scope.IsVisibleLineChart) {
                            messageServise.showBlackMessage('Chart "INCOME AND COSTS 2016" currently unavailable!');
                        }
                        $scope.IsVisibleLineChart = false;
                        return;
                    }
                    $scope.safeApply(function () {
                        $scope.IsVisibleLineChart = true;
                        $scope.months = temp;
                        $scope.dataLine = [incomes, costs];
                    });
                }

                function showLineChart() {
                    var date = new Date();
                    $scope.year = date.getFullYear();
                    if ($scope.selectedAccount === null) {
                        return;
                    }
                    $scope.safeApply(function () {
                        $scope.series = ['Incomes', 'Costs'];
                        generateLineChart();
                    });
                }


                function showTransactionChart() {
                    var data = new Date();

                    var month = {};
                    if (!$scope.transactionMontch) {
                        month = data.getMonth() + 1;
                        $scope.transactionMontch = month;
                    } else {
                        month = $scope.transactionMontch;
                    }

                    $scope.labels = ["Incomes", "Costs"];
                    if ($scope.selectedAccount === null) {
                        return;
                    }
                    $scope.safeApply(function () {
                        $scope.month = angular.copy($scope.monthsCopy[month]);
                        $scope.year = data.getFullYear();
                        $scope.data = [
                            getSummByProperty(getTransactionByMonth($scope.selectedAccount.Incomes, month), "Amount"),
                            getSummByProperty(getTransactionByMonth($scope.selectedAccount.Сonsumptions, month), "Amount")
                        ];
                    });
                }

                function loadingIncomeCategories() {
                    var promise = incomeCategoriesService.getByUserId({ id: $scope.user.Id }).$promise;
                    promise.then(function (data) {
                        $scope.incomeCategories = data;
                    }).catch(function () {
                        messageServise.showErrorMessage("An error occurred while load costs categories!");
                    });
                    return promise;
                }

                function loadingCostsCategories() {
                    var promise = costsCategoriesSevice.getByUserId({ id: $scope.user.Id }).$promise;
                    promise.then(function (data) {
                        $scope.costsCategories = data;
                    }).catch(function () {
                        messageServise.showErrorMessage("An error occurred while load costs categories!");
                    });
                    return promise;
                }

                function getdropDownListCategories(array, categories) {
                    if (!$scope.year) {
                        $scope.year = new Date().getFullYear();
                    }
                    var months = [];
                    angular.forEach(array, function (item) {
                        angular.forEach(categories, function (category) {
                            var date = new Date(item.CreatedDate.toString());
                            if (date.getFullYear() === $scope.year && item.CategoryId === category) {
                                months.push(date.getMonth() + 1);
                            }
                        });
                    });

                    var result = [];
                    angular.forEach(uniq(months), function (item) {
                        result.push({ Id: item, Name: $scope.monthsCopy[item - 1] });
                    });
                    return $filter('orderBy')(result, 'Id');;
                }

                function showChartByCostsCategory() {
                    var month = {};
                    var data = new Date();
                    if (!$scope.costsCategoryMontch) {
                        month = data.getMonth() + 1;
                        $scope.costsCategoryMontch = month;
                    } else {
                        month = $scope.costsCategoryMontch;
                    }
                    var array = getTransactionByMonth($scope.selectedAccount.Сonsumptions, month);
                    var categories = getCategories(array);
                    $scope.costsCategoriesMonthsList = getdropDownListCategories($scope.selectedAccount.Сonsumptions, getCategories($scope.selectedAccount.Сonsumptions));
                    var result = [];
                    $scope.costsCategorieslabels = [];
                    angular.forEach(categories, function (item) {
                        result.push(getAmountByCategoryId(array, item));
                        angular.forEach($scope.costsCategories, function (category) {
                            if (category.Id === item) {
                                $scope.costsCategorieslabels.push(category.Name);
                            }
                        });
                    });
                    $scope.safeApply(function () {
                        $scope.costsColors = getColorsArray(result.length);
                        $scope.costsCategorieslabels = uniq($scope.costsCategorieslabels);
                        $scope.costsCategoriesData = result;
                    });
                }

                function showCharts() {
                    chekVisibilityChart();
                    showTransactionChart();
                    showLineChart();
                    
                    var promiseIncome = loadingIncomeCategories();
                    promiseIncome.then(function () {
                        showChartByIncomeCategory();
                    });

                    var costsIncome = loadingCostsCategories();
                    costsIncome.then(function () {
                        showChartByCostsCategory();
                    });
                    showLineChart();
                    $scope.$broadcast("$reload", {});
                }

                function getDropDownListMonths() {
                    var result = [];
                    var months = getMonths();
                    angular.forEach(months, function (item) {
                        result.push({ Id: item, Name: $scope.monthsCopy[item - 1] });
                    });
                    return $filter('orderBy')(result, 'Id');;
                }

                $scope.changeAccount = function () {
                    $scope.dropDownMonths = getDropDownListMonths();
                    showCharts();
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
                   
                    $scope.dropDownMonths = getDropDownListMonths();
                    showCharts();
                }

                function chekVisibilityChart() {
                    var result = false;
                    $scope.isVisibleCharts = true;
                    $scope.isVisibleIncome = true;
                    $scope.isVisibleCosts = true;
                    if ($scope.selectedAccount.Incomes.length === 0 && $scope.selectedAccount.Сonsumptions.length === 0) {
                        result = true;
                        $scope.isVisibleCharts = false;
                    }
                    if ($scope.selectedAccount.Incomes.length === 0) {
                        result = true;
                        $scope.isVisibleIncome = false;
                    }
                    if ($scope.selectedAccount.Сonsumptions.length === 0) {
                        result = true;
                        $scope.isVisibleCosts = false;
                    }
                    if (result) {
                        messageServise.showBlackMessage('Some charts are temporarily unavailable!');
                    }

                }

                function getAccounts(user) {
                    accountService.getByUserId({ id: user.Id }, {}).$promise.then(function (data) {
                        $scope.accounts = data;
                            getSelectedAccount();
                    }).catch(function () {
                        messageServise.showErrorMessage("An error occurred while load accounts!");
                    });
                }

                $scope.$on('create', function (event, chart) {
                    if (chart.chart.canvas.id.toLowerCase() === 'line'.toLowerCase()) {
                        chart.chart.height = 250;
                        return;
                    }
                    chart.chart.height = 150;
                });

                usersService.getCurrent().$promise.then(function (user) {
                    $scope.user = user;
                    getAccounts(user);
                });

                function getRandomColor() {
                    var letters = '0123456789ABCDEF'.split('');
                    var color = '#';
                    for (var i = 0; i < 6; i++) {
                        color += letters[Math.floor(Math.random() * 16)];
                    }
                    return color;
                }
            }
		]);
}());
