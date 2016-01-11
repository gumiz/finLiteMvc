appDirectives.directive('currencyMask', ['moneyService', function (moneyService) {
    return {
        restrict: 'A',
        require: '^ngModel',
        scope: true,
        link: function (scope, el, attrs, ngModelCtrl) {


            function formatter(value) {
                return moneyService.convertMoney(value);
            }

            ngModelCtrl.$formatters.push(formatter);

            el.bind('focus', function () {
            });

            el.bind('blur', function () {
                formatter(el.val());
            });
        }
    };
}]);