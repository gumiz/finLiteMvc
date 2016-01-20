'use strict';

angular.module('finLiteApp').controller('documentsCtrl', ['$scope', 'repositoryService', 'dialogService', 'notify', 'datepickerService', 'dateUtils', '$q',
    function ($scope, repositoryService, dialogService, notify, datepickerService, dateUtils, $q) {

    var documents = this;

    documents.data = {};
    documents.commands = {};

    documents.data.year = 2015;
    documents.data.allYears = [2015, 2016, 2017, 2018, 2019, 2020];

    var cleanNewDocument = function () {
        documents.data.newDocument = { Price: 0, Date: dateUtils.getActualDate() };
    }
    cleanNewDocument();

    documents.commands.refresh = function () {
        var def = $q.defer();
        repositoryService.getDocuments($scope.main.data.clientId, documents.data.year, function (items) {
            documents.data.documents = items;
            def.resolve();
        });
        return def.promise;
    };
    
    var fixDocumentProperties = function (item) {
        if (item.Price) {
            item.Price = item.Price.replace(".", ",");
        }
        item.Date = dateUtils.dateToString(item.Date);
    }

    documents.commands.addDocument = function () {
        debugger;
        fixDocumentProperties(documents.data.newDocument);
        documents.data.newDocument.ClientId = $scope.main.data.clientId;
        repositoryService.addDocument(documents.data.newDocument, documents.commands.refresh);
        cleanNewDocument();
    };

    var deleteDocument = function (id) {
        return function () {
            return repositoryService.deleteDocument(id, documents.commands.refresh);
        };
    };

    var gotAccounts = function (accounts) {
        documents.data.accounts = accounts;
    };
    repositoryService.getAccounts($scope.main.data.clientId, gotAccounts);

    documents.commands.refresh().then(function () {
        documents.data.datepicker = datepickerService.initDatePicker(documents.data.newDocument.Date);
    });

    documents.commands.setItemToEdit = function (item) {
        documents.data.editItem = JSON.parse(JSON.stringify(item));
        documents.data.editItem.Date = dateUtils.dateToString(documents.data.editItem.Date);
    }

    documents.commands.edit = function () {
        fixDocumentProperties(documents.data.editItem);
        repositoryService.addDocument(documents.data.editItem, function (){
            documents.commands.refresh();
            notify.info("Dokument został zmieniony.");
        });
        $('#myModal').modal('hide');
    };

    documents.commands.deleteDocument = function (id) {
        $('#myModal').modal('hide');
        dialogService.confirmation('Czy na pewno chcesz usunąć dokument?', deleteDocument(id));
    };

}]);
