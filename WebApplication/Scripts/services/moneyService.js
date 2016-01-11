appServices.factory('moneyService', function () {
    "use strict";

    var formatMoney = function (value) {
        return value;
    };

    var convertMoney = function (value) {

        if (typeof value == "undefined") {
            value = 0;
        }

        var money = {
            decimals: 2,
            thousandSeparator: ' ',
            decimalSeparator: ','
        };

        var properValue = value.toString().replace(',', '.');
        value = parseFloat(properValue.replace(/[^0-9,.-]/g, ''));
        return accounting.formatMoney(value, '', money.decimals, money.thousandSeparator, money.decimalSeparator);
    }

    return {
        formatMoney: formatMoney,
        convertMoney: convertMoney
    };
});