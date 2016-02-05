appDirectives.directive('currencyMask', ['moneyService', function (moneyService) {
    return {
        restrict: 'A',
        require: '^ngModel',
        scope: true,
        link: function (scope, el, attrs, ngModelCtrl) {


            function formatter(value) {
                var result = moneyService.convertMoney(value);
                el.val(result);
                return result;
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