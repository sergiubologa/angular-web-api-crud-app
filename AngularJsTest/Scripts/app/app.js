var mainApp = angular.module('mainApp', ['ngRoute', 'itemsControllers', 'itemsServices', 'directives']);

mainApp.config([
    '$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            when('/items', {
                templateUrl: '/Scripts/app/Views/list.html',
                controller: 'itemsListController'
            }).
            when('/items/add', {
                templateUrl: '/Scripts/app/Views/addEdit.html',
                controller: 'addItemController'
            }).
            when('/items/edit/:itemId', {
                templateUrl: '/Scripts/app/Views/addEdit.html',
                controller: 'editItemController'
            }).
            otherwise({
                redirectTo: '/items'
            });
    }
]);