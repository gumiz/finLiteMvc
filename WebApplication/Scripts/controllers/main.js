'use strict';

angular.module('finLiteApp').controller('MainCtrl', ['$scope', '$location', 'repositoryService', 'urlService', '$cookies', function ($scope, $location, repositoryService, urlService, $cookies) {
    var main = this;

    main.data = {};
    main.commands = {};
    main.data.allYears = [2015, 2016, 2017, 2018, 2019, 2020];

    main.data.year = Number($cookies['finliteYear']);
    if (!main.data.year)
        main.data.year = 2015;

    main.data.clientId = Number(urlService.getIdFromUrl());
    if (isNaN(main.data.clientId))
        main.data.clientId = 1;
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

    var getUrl = function (base) {
        return base + "/" + main.data.clientId;
    }

    main.refresh = function () {
        $cookies.finliteYear = main.data.year;
        window.location = getUrl(urlService.accounts.index);
    }

//    main.commands.initData = function() {
//        repositoryService.initData();
//    };

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
    main.commands.getUrlCreatorsProfitLoss = function () {
        return getUrl(urlService.creators.profitLoss);
    }

}]);
