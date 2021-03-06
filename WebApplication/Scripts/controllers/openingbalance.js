'use strict';

angular.module('finLiteApp')
  .controller('OpeningBalanceCtrl', ['$scope', 'repositoryService', 'notify', function ($scope, repositoryService, notify) {

        var openings = this;
        openings.data = {};
        openings.commands = {};

        var fixDocumentProperties = function (items) {
            _.each(items, function(item) {
                if (typeof item.Dt === "string") {
                    item.Dt = item.Dt.replace(".", ",");
                }
                if (typeof item.Ct === "string") {
                    item.Ct = item.Ct.replace(".", ",");
                }
            });
        }

        openings.commands.getData = function () {
            repositoryService.getOpenings($scope.main.data.clientId, $scope.main.data.year, function (data) {
                openings.data.openings = data;
            });
        }
        openings.commands.getData();

        var confirmSaved = function () {
            notify.info("Zapisano bilans otwarcia");
        }

        openings.commands.saveOpenings = function () {
            fixDocumentProperties(openings.data.openings);
            repositoryService.saveOpenings(openings.data.openings, confirmSaved);
        };

        openings.commands.print = function () {
            repositoryService.printOpenings($scope.main.data.clientId, $scope.main.data.year);
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
