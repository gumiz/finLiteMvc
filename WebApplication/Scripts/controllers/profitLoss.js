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

    var confirmSaved = function () {
        notify.info("Zapisano Rachunek wyników");
    }

    pcController.commands.save = function () {
        repositoryService.saveProfitLossItems($scope.main.data.clientId, pcController.data.items, confirmSaved);
    };

}]);

