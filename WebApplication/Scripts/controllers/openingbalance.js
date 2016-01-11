'use strict';

angular.module('finLiteApp')
  .controller('OpeningBalanceCtrl', ['$scope', 'repositoryService', 'dialogService', function ($scope, repositoryService, dialogService) {

        var openings = this;
        openings.data = {};
        openings.commands = {};

        openings.data.year = 2015;
        openings.data.allYears = [2015, 2016, 2017, 2018, 2019, 2020];

        openings.commands.getData = function () {
            debugger;
            repositoryService.getOpenings($scope.main.data.clientId, openings.data.year, function(data) {
                openings.data.openings = data;
            });
        }
        openings.commands.getData();

        var confirmSaved = function () {
            dialogService.showMessage("Zapisano bilans otwarcia");
        }

        openings.commands.saveOpenings = function () {
            repositoryService.saveOpenings(openings.data.openings, confirmSaved);
        };
  }]);
