(function() {
    'use strict';
    var app = angular.module('homeFinance');
    app.constant('currenciesImages', [
            { Name: "BLR", ImageURL: "Content/Images/belarus-flag-128x128.png" },
            { Name: "RUB", ImageURL: "Content/Images/russia-flag.png" },
            { Name: "USD", ImageURL: "Content/Images/united-states-flag_9870.png" },
            { Name: "EUR", ImageURL: "Content/Images/european-union-flag-128x128.png" }
    ]);

    app.constant('months', ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December']);
    app.constant('colorsClasses', ['bg-primary', 'bg-success', 'bg-purple', 'bg-warning', 'bg-danger', 'bg-muted', 'bg-inverse', 'bg-pink']);

    app.constant('incomeFooterTemplate', '<div class="ui-grid-cell-contents" ng-class="col.getAggregationValue()>=0 ? \'green\':  \'red\'">total: {{col.getAggregationValue()}}</div>');
    app.constant('costsFooterTemplate', '<div class="ui-grid-cell-contents" ng-class="col.getAggregationValue()<=0? \'green\': \'red\'">total: {{col.getAggregationValue()}}</div>');

}());