'use strict';

angular.module('finLiteApp').controller('documentsCtrl', ['$scope', 'repositoryService', 'dialogService', 'notify', 'datepickerService', 'dateUtils', '$q', 'cookieService',
    function ($scope, repositoryService, dialogService, notify, datepickerService, dateUtils, $q, cookieService) {

    var documents = this;

    documents.data = {
        newDocument: {}
    };
    documents.commands = {};

    var getLastUsedDate = function() {
        var result = cookieService.getValue("documentDate");
        if (!result)
            result = dateUtils.getActualDate();
        return result;
    }

    var cleanNewDocument = function () {
        documents.data.newDocument = { Price: 0, Date: getLastUsedDate() };
    }
    cleanNewDocument();

    var gotAccounts = function (accounts) {
        documents.data.accounts = accounts;
    };
    repositoryService.getAccounts($scope.main.data.clientId, $scope.main.data.year, gotAccounts);

    documents.commands.refresh = function () {
        var def = $q.defer();
        repositoryService.getDocuments($scope.main.data.clientId, $scope.main.data.year, function (items) {
            documents.data.documents = items;
            repositoryService.getAccounts($scope.main.data.clientId, $scope.main.data.year, gotAccounts);
            def.resolve();
        });
        return def.promise;
    };
    
    var fixDocumentProperties = function (item) {
        if (typeof item.Price === "string") {
           item.Price = item.Price.replace(".", ",");
        }
        item.Date = dateUtils.dateToString(item.Date);
    }

    documents.commands.addDocument = function () {
        if ($scope.main.data.year !== documents.data.newDocument.Date.getFullYear()) {
            notify.error("Data dokumentu niezgodna z wybranym rokiem obrotowym");
        } else {
            cookieService.setValue("documentDate", documents.data.newDocument.Date);
            fixDocumentProperties(documents.data.newDocument);
            documents.data.newDocument.ClientId = $scope.main.data.clientId;
            repositoryService.addDocument(documents.data.newDocument, documents.commands.refresh);
            cleanNewDocument();
        }
    };

    var deleteDocument = function (id) {
        return function () {
            return repositoryService.deleteDocument(id, documents.commands.refresh);
        };
    };

    documents.commands.refresh().then(function () {
        documents.data.datepicker = datepickerService.initDatePicker(documents.data.newDocument.Date);
    });

    documents.commands.setItemToEdit = function (item) {
        documents.data.editItem = JSON.parse(JSON.stringify(item));
        documents.data.editItem.Date = dateUtils.dateToString(documents.data.editItem.Date);
    }

    documents.commands.edit = function () {
        fixDocumentProperties(documents.data.editItem);
        repositoryService.updateDocument(documents.data.editItem, function (){
            documents.commands.refresh();
            notify.info("Dokument został zmieniony.");
        });
        $('#myModal').modal('hide');
    };

    documents.commands.deleteDocument = function (id) {
        $('#myModal').modal('hide');
        dialogService.confirmation('Czy na pewno chcesz usunąć dokument?', deleteDocument(id));
    };

    documents.commands.print = function () {
        repositoryService.printDocuments($scope.main.data.clientId, $scope.main.data.year);
    }
}]);
