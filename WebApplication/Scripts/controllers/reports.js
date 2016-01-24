'use strict';
angular.module('finLiteApp').controller('reportsCtrl', ['$scope', 'repositoryService', 'dialogService', function ($scope, repositoryService, dialogService) {

    var reports = this;

    reports.data = {};
    reports.commands = {};

    reports.commands.refresh = function () {
        repositoryService.getReports($scope.main.data.clientId, $scope.main.data.year, function (items) {
            reports.data.reports = items;
        });
    };

    reports.commands.refresh();

    reports.commands.getClosing = function (value1, value2) {
        var result = value1 - value2;
        if (result < 0) result = 0;
        return result;
    }

    reports.commands.print = function () {
        repositoryService.printReports($scope.main.data.clientId, $scope.main.data.year);
    }

}]);
