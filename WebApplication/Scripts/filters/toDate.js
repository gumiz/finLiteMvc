appFilters.filter('toDate', function ($filter) {

    return function (input) {
        input = input.replace(/\//g, '');
        var myDate = new Date(input.match(/\d+/)[0] * 1);
        return $filter('date')(myDate, 'yyyy-MM-dd');
    };
});