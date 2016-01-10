'use strict';

angular.module('finLiteApp').controller('MainCtrl', ['$scope', '$location', 'repositoryService', 'urlService', function ($scope, $location, repositoryService, urlService) {
    var main = this;

    main.data = {};
    main.commands = {};

    debugger;
    main.data.clientId = Number(urlService.getIdFromUrl());
    if (main.data.clientId === 0) main.data.clientId = 1;

    main.commands.getClass = function (path) {
      if ($location.path().substr(0, path.length) === path) {
          return "active";
      } else {
          return "";
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

    var getUrl = function(base) {
        return base + "/" + main.data.clientId;
    }
    main.commands.getUrlAccounts = function () {
        return getUrl(urlService.accounts.index);
    }
    main.commands.getUrlOpenings = function () {
        return getUrl(urlService.openings.index);
    }
    main.commands.getUrlDocuments = function () {
        return getUrl(urlService.documents.index);
    }
    main.commands.getUrlReports = function () {
        return getUrl(urlService.reports.index);
    }

}]);
