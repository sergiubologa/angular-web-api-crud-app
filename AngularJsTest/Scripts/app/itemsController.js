var itemsControllers = angular.module('itemsControllers', []);

itemsControllers.controller('itemsListController', ['$scope', '$http', 'Items', 'UnitsOfMeasure', function ($scope, $http, Items, UnitsOfMeasure) {
    $scope.UnitsOfMeasure = UnitsOfMeasure;
    $scope.Items = Items;

    Items.query(function (items) {
        $scope.items = items;
    });

    $scope.delete = function (id) {
        Items.delete({ id: id }, function () {
            $.each($scope.items, function (index) {
                var item = $scope.items[index];
                if (item.id == id) {
                    $scope.items.splice(index, 1);
                    return false;
                }
            });
        }, function () {
            $scope.deleteError = 'An error occured. Please try again.';
        });
    };
}]);

itemsControllers.controller('addItemController', function ($scope, $location) {
    $scope.title = 'Add new item';
    $scope.$parent.UnitsOfMeasure.query(function (unitsList) {
        $scope.umOptions = unitsList;
        $scope.selectedUm = $scope.umOptions[0];
    });

    $scope.save = function () {
        $scope.saveError = null;
        var itemToCreate = {
            description: $scope.item.description,
            measure: $scope.item.measure,
            um: $scope.selectedUm.id
        };

        $scope.$parent.Items.add(itemToCreate, function (result) {
            $location.path("/items");
        }, function () {
            $scope.saveError = 'An error occured. Please try again.';
        });
    };
});

itemsControllers.controller('editItemController', function ($scope, $location, $routeParams) {
    $scope.title = 'Edit item';

    $scope.$parent.Items.get({ id: $routeParams.itemId },
        function (result) {
            $scope.item = result;
            $scope.$parent.UnitsOfMeasure.query(function (unitsList) {
                $scope.umOptions = unitsList;
                for (var index = 0; index < unitsList.length; index++) {
                    if (unitsList[index].id == $scope.item.um) {
                        $scope.selectedUm = $scope.umOptions[index];
                        break;
                    }
                }
            });
        }, function () {
            $scope.itemNotFound = "Sorry. The item not found. Please go back and select another item.";
        });

    $scope.save = function () {
        $scope.saveError = null;
        var itemToSave = {
            id: $scope.item.id,
            description: $scope.item.description,
            measure: $scope.item.measure,
            um: $scope.selectedUm.id
        };

        $scope.$parent.Items.edit(itemToSave, function (result) {
            $location.path("/items");
        }, function () {
            $scope.saveError = 'An error occured. Please try again.';
        });
    };
});