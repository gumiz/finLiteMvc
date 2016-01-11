'use strict';

angular.module('finLiteApp').controller('documentsCtrl', ['$scope', 'repositoryService', 'dialogService', 'notify', 'datepickerService', 'dateUtils', function ($scope, repositoryService, dialogService, notify, datepickerService, dateUtils) {

    var documents = this;

    documents.data = {};
    documents.commands = {};

    documents.data.year = 2015;
    documents.data.allYears = [2015, 2016, 2017, 2018, 2019, 2020];

    var cleanNewDocument = function() {
        documents.data.newDocument = {};
    }
    cleanNewDocument();

    documents.data.newDocument = {};
    var gotDocuments = function (items) {
        documents.data.documents = items;
    };
    documents.commands.refresh = function () {
        repositoryService.getDocuments($scope.main.data.clientId, documents.data.year, gotDocuments);
    };
    
    var fixPrice = function () {
        debugger;
        if (documents.data.newDocument.price) {
            documents.data.newDocument.price = documents.data.newDocument.price.replace(",", ".");
        }
    }

    documents.commands.addDocument = function () {
        fixPrice();
        documents.newDocument.date = dateUtils.dateToString(documents.data.newDocument.date);
        repositoryService.addDocument(documents.data.newDocument, documents.commands.refresh);
        cleanNewDocument();
    };

    var deleteDocument = function (id) {
        return function () {
            return repositoryService.deleteDocument(id, documents.commands.refresh);
        };
    };

    documents.commands.deleteDocument = function (id) {
        dialogService.confirmation('Czy na pewno chcesz usunąć dokument?', deleteDocument(id));
    };

    var gotAccounts = function (accounts) {
        documents.data.accounts = accounts;
    };
    repositoryService.getAccounts($scope.main.data.clientId, gotAccounts);
    documents.data.datepicker = datepickerService.initDatePicker(documents.data.newDocument.date);
    documents.commands.refresh();
}]);
