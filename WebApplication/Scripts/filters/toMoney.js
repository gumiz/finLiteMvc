appFilters.filter('toMoney', ['moneyService', function (moneyService) {

    return moneyService.convertMoney;

}])