'use strict';

angular.module('finLiteApp').controller('MainCtrl', ['$scope', '$location', 'repositoryService', 'urlService', function ($scope, $location, repositoryService, urlService) {
    var main = this;

    main.data = {};
    main.commands = {};

    main.data.clientId = Number(urlService.getIdFromUrl());
    debugger;
    if (main.data.clientId === 0) main.data.clientId = 1;

    main.getClass = function (path) {
      if ($location.path().substr(0, path.length) === path) {
        return "active"
      } else {
        return ""
      }
    };

    repositoryService.getClients(function (data) {
        main.clients = data;
    });

    main.refresh = function() {
        window.location = "/" + main.data.clientId;
    }

    main.commands.initData = function() {
        repositoryService.initData();
    };

}]);
