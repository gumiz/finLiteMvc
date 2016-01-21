'use strict';
angular.module('finLiteApp').controller('AccountsCtrl', ['$scope', 'repositoryService', 'dialogService', 'notify', function ($scope, repositoryService, dialogService, notify) {

  var accController = this;

  var gotAccounts = function(accounts){
      accController.accounts = accounts;
  };
  var refresh = function () {
      repositoryService.getAccounts($scope.main.data.clientId, gotAccounts);
  };
  accController.refresh = refresh;

  accController.addAccount = function () {
      accController.newAccount.ClientId = $scope.main.data.clientId;
      repositoryService.addAccount(accController.newAccount, refresh);
  };

  var deleteAccount = function (account) {
    return function() {return repositoryService.deleteAccount(account, refresh)};
  };

  accController.deleteAccount = function (account) {
    dialogService.confirmation('Czy na pewno chcesz usunąć to konto?', deleteAccount(account));
  };

  accController.print = function() {
      repositoryService.printAccounts($scope.main.data.clientId);
  }

  refresh();
}]);
