'use strict';
angular.module('finLiteApp').controller('AccountsCtrl', ['$scope', 'repositoryService', 'dialogService', 'notify', function ($scope, repositoryService, dialogService, notify) {

    var accController = this;

    accController.data = {};
    accController.commands = {};

    var gotAccounts = function(accounts){
      accController.accounts = accounts;
    };

    accController.commands.refresh = function () {
        repositoryService.getAccounts($scope.main.data.clientId, $scope.main.data.year, gotAccounts);
    };

    accController.commands.addAccount = function () {
        accController.newAccount.ClientId = $scope.main.data.clientId;
        accController.newAccount.Year = $scope.main.data.year;
        repositoryService.addAccount(accController.newAccount, accController.commands.refresh);
    };

    var deleteAccount = function (account) {
        return function () { return repositoryService.deleteAccount(account, accController.commands.refresh) };
    };

    accController.commands.deleteAccount = function (account) {
        dialogService.confirmation('Czy na pewno chcesz usunąć to konto?', deleteAccount(account));
    };

    accController.commands.print = function () {
        repositoryService.printAccounts($scope.main.data.clientId, $scope.main.data.year);
    }

    var rewriteAccountsWithLastYear = function () {
        return function () { return repositoryService.rewriteAccountsWithLastYear($scope.main.data.clientId, $scope.main.data.year, function() {
            accController.commands.refresh();
            notify.info("Import zakończony");
        }) };
    };

    accController.commands.rewriteAccountsWithLastYear = function () {
        dialogService.confirmation('Ta funkcja \ obecny plan kont (' + $scope.main.data.year + '),<br /> kontami roku poprzedniego.<br /><br />Czy na pewno chcesz dodać zeszłoroczne konta?', rewriteAccountsWithLastYear());
    };


    accController.commands.refresh();
}]);

