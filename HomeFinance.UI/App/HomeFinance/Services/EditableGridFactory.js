(function () {
    'use strict';

    angular.module('homeFinance')
           .service('editableGridFactory', [ function () {

               // Creates instance of editable grid
               this.create = function (scope, resourceService, loadSaveCallback, baseGridSettings, autoLoadList,updateItemCallback) {
                   var instance = {
                       resourceService: resourceService,
                       onRegisterApi: function (gridApi) {
                           this.gridApi = gridApi;
                           var thisObjectClosure = this;
                           gridApi.rowEdit.on.saveRow(scope, function (rowEntity) {
                               var promise = thisObjectClosure.updateItem.apply(thisObjectClosure, [rowEntity]);
                               gridApi.rowEdit.setSavePromise(rowEntity, promise);
                               return promise;
                           });
                       },

                       loadList: function() {
                           this.data = this.resourceService.query();
                           loadSaveCallback(this.data.$promise);
                       },

               
                       updateItem: function (item) {
                           var promise = this.resourceService.save({ id: item.Id }, item).$promise;
                           promise.then(function(data) {
                               item = data;
                               if (updateItemCallback) {
                                   updateItemCallback();
                               }
                           });
                           this.gridApi.rowEdit.setSavePromise(item, promise.promise);
                           return promise;
                       },

                       addOrUpdateItem: function (item) {
                           var existEntitlement = this.getItemById(item.Id);
                           if (existEntitlement === null) {
                               // Add new item to grid
                               this.data.push(item);
                           } else {
                               // Update exist item in the grid
                               angular.copy(item, existEntitlement);
                           }
                       },

                       removeItem: function (id) {
                           var index = this.getItemIndexById(id);
                           if (index !== null) {
                               this.data.splice(index, 1);
                               return true;
                           }
                           return false;
                       },
                       removeItems: function (items) {
                           for (var i in items) {
                               this.removeItem(items[i].Id);
                           }
                       },

                       getItemById: function (id) {
                           var i = this.getItemIndexById(id);
                           return i ? this.data[i] : null;
                       },

                       getItemIndexById: function (id) {
                           for (var i in this.data) {
                               if (this.data[i].Id === id) {
                                   return i;
                               }
                           }
                           return null;
                       }
                   };
                   angular.extend(instance, baseGridSettings);
                   if (autoLoadList) {
                       instance.loadList();
                   }
                   return instance;
               };
           }
           ]);
}());
