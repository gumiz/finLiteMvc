'use strict';

angular.module('finLiteApp')
  .controller('OpeningBalanceCtrl', ['$scope', 'repositoryService', 'dialogService', function ($scope, repositoryService, dialogService) {

        var openings = this;
        openings.data = {};
        openings.commands = {};

        openings.data.year = 2015;
        openings.data.allYears = [2015, 2016, 2017, 2018, 2019, 2020];

        var fixDocumentProperties = function (items) {
            _.each(items, function(item) {
                debugger;
                if (typeof item.Dt === "string") {
                    item.Dt = item.Dt.replace(".", ",");
                }
                if (typeof item.Ct === "string") {
                    item.Ct = item.Ct.replace(".", ",");
                }
            });
        }

        openings.commands.getData = function () {
            repositoryService.getOpenings($scope.main.data.clientId, openings.data.year, function(data) {
                openings.data.openings = data;
            });
        }
        openings.commands.getData();

        var confirmSaved = function () {
            dialogService.showMessage("Zapisano bilans otwarcia");
        }

        openings.commands.saveOpenings = function () {
            fixDocumentProperties(openings.data.openings);
            repositoryService.saveOpenings(openings.data.openings, confirmSaved);
        };

        openings.commands.print = function () {
            repositoryService.printOpenings($scope.main.data.clientId, openings.data.year);
        }

        openings.commands.getTotal = function (propertyName) {
            var sum = 0;
            _.each(openings.data.openings, function (item) {
                if (item.Name.length === 3)
                    sum += Number(item[propertyName]);
            });
            return sum;
        }

  }]);
