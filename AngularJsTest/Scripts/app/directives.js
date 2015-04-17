var directives = angular.module('directives', []);

directives.directive('sbConfirm', [function () {
    return {
        priority: 100,
        restrict: 'A',
        link: {
            pre: function (scope, element, attrs) {
                var msg = attrs.sbConfirm || "Are you sure?";

                element.bind('click', function (event) {
                    if (!confirm(msg)) {
                        event.stopImmediatePropagation();
                        event.preventDefault;
                    }
                });
            }
        }
    };
}]);