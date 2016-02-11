'use strict';
angular.module('finLiteApp').controller('BalanceCtrl', ['$scope', 'repositoryService', 'dialogService', 'notify', function ($scope, repositoryService, dialogService, notify) {

    var balanceController = this;

    balanceController.data = {};
    balanceController.commands = {};

    balanceController.commands.refresh = function () {
        repositoryService.getBalanceItems($scope.main.data.clientId, function (data) {
            balanceController.data.items = data;
        });
    };

    balanceController.commands.refresh();

    balanceController.commands.print = function () {
        repositoryService.printBalance($scope.main.data.clientId, $scope.main.data.year);
    };

    var confirmSaved = function () {
        notify.info("Zapisano Bilans");
    }

    balanceController.commands.save = function () {
        repositoryService.saveBalanceItems($scope.main.data.clientId, balanceController.data.items, confirmSaved);
    };

}]);

