'use strict';
angular.module('finLiteApp').controller('ProfitLossCtrl', ['$scope', 'repositoryService', 'dialogService', 'notify', function ($scope, repositoryService, dialogService, notify) {

    var pcController = this;

    pcController.data = {};
    pcController.commands = {};

    pcController.commands.refresh = function () {
        repositoryService.getProfitLossItems($scope.main.data.clientId, function (data) {
            pcController.data.items = data;
        });
    };

    pcController.commands.refresh();

    pcController.commands.print = function () {
        repositoryService.printProfitLoss($scope.main.data.clientId, $scope.main.data.year);
    };

}]);

