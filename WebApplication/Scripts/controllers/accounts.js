'use strict';
angular.module('finLiteApp').controller('AccountsCtrl', ['$scope', 'repositoryService', 'dialogService', 'notify', function ($scope, repositoryService, dialogService, notify) {

  var accController = this;
  accController.data = {};
  accController.data.year = 2015;
  accController.data.allYears = [2015, 2016, 2017, 2018, 2019, 2020];

  var gotAccounts = function(accounts){
      accController.accounts = accounts;
  };
  var refresh = function () {
      repositoryService.getAccounts($scope.main.data.clientId, accController.data.year, gotAccounts);
  };
  accController.refresh = refresh;

  accController.addAccount = function () {
      accController.newAccount.ClientId = $scope.main.data.clientId;
      accController.newAccount.Year = accController.data.year;
      repositoryService.addAccount(accController.newAccount, refresh);
  };

  var deleteAccount = function (account) {
    return function() {return repositoryService.deleteAccount(account, refresh)};
  };

  accController.deleteAccount = function (account) {
    dialogService.confirmation('Czy na pewno chcesz usunąć to konto?', deleteAccount(account));
  };

  accController.print = function() {
      repositoryService.printAccounts($scope.main.data.clientId, accController.data.year);
  }

  refresh();
}]);
