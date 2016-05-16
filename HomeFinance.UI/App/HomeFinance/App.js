(function () {
	'use strict';

	angular.module('homeFinance', [
        'ngResource', 'ngAnimate', 'ngTouch',
        'ui.router', 'ui.bootstrap', 'ui.bootstrap.modal', 'LocalStorageModule', 'angular-loading-bar', 'cgNotify',
        'ui.grid', 'ui.grid.selection', 'ui.grid.edit', 'ui.grid.rowEdit', 'ui.grid.cellNav',
        'ui.grid.exporter', 'ui.grid.pagination', 'ui.grid.autoResize', 'chart.js'
	]);
}());
