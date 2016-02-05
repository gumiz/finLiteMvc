'use strict';
angular.module('finLiteApp').controller('ProfitLossCtrl', ['$scope', 'repositoryService', 'dialogService', 'notify', function ($scope, repositoryService, dialogService, notify) {

    var pcController = this;

    pcController.data = {};
    pcController.commands = {};

    var shouldBeBoldNumber = function (value) {
        var test = (",1,4,5,6,13,14,15,16,17,18,19,".indexOf(','+value+',') > -1);
        return test;
    }

    var updateStyleCssInfo = function() {
        _.each(pcController.data.items, function(item) {
            item.BoldCss = shouldBeBoldNumber(item.Id) ? "bold" : "";
        });
    };

    pcController.commands.refresh = function () {
        repositoryService.getProfitLossItems(function (data) {
            pcController.data.items = data;
            updateStyleCssInfo();
        });
    };

    pcController.commands.refresh();

    pcController.commands.print = function () {
        repositoryService.printProfitLoss($scope.main.data.clientId, $scope.main.data.year);
    };

}]);

