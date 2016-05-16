(function () {
    'use strict';
    angular.module('homeFinance').directive("currentTime", function (dateFilter) {
    return function(scope, element, attrs){
        var format = 'h:mm:ss a';

        function updateTime(){
            var dt = dateFilter(new Date(), format);
            element.text(dt);
        }

        function updateLater() {
            setTimeout(function() {
              updateTime(); // update DOM
              updateLater(); // schedule another update
            }, 1000);
        }
        
        updateLater();
    }
});
}());