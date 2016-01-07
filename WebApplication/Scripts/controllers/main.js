'use strict';

angular.module('finLiteApp').controller('MainCtrl', ['$scope', '$location', 'repositoryService', function ($scope, $location, repositoryService) {
    var main = this;

    main.clientId = 1;

    main.getClass = function (path) {
      if ($location.path().substr(0, path.length) == path) {
        return "active"
      } else {
        return ""
      }
    };

    repositoryService.getClient(function (data) {
      $scope.client = data;
    });

    repositoryService.getClients(function (data) {
        main.clients = data;
    });

  }]);
