'use strict';
angular.module('finLiteApp').controller('reportsCtrl', ['$scope', 'repositoryService', 'dialogService', function ($scope, repositoryService, dialogService) {

    var reports = this;

    reports.data = {};
    reports.commands = {};

    reports.data.year = 2015;
    reports.data.allYears = [2015, 2016, 2017, 2018, 2019, 2020];


    reports.commands.refresh = function () {
        repositoryService.getReports($scope.main.data.clientId, reports.data.year, function (items) {
            reports.data.reports = items;
        });
    };

    reports.commands.refresh();

    reports.commands.getClosing = function (value1, value2) {
        debugger;
        var result = value1 - value2;
        if (result < 0) result = 0;
        return result;
    }

}]);
