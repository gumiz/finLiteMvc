'use strict';
angular.module('finLiteApp').service('repositoryService', ['$http', 'ajaxService', 'urlService', function ($http, ajaxService, urlService) {

  var getIdFromUrl = function () {
    var elems = window.location.href.split("/");
    return elems[elems.length - 1];
  };

  var showPdf = function (data) {
      window.open("data:application/pdf;base64, " + data);
  };

  var saveOpenings = function(item, successFunc) {
    ajaxService.doPostWithBlock(urlService.openings.saveOpenings, item).then(successFunc);
  };

  var getOpenings = function (clientId, year, successFunc) {
      ajaxService.doPost(urlService.openings.getOpenings, { clientId: clientId, year: year }).then(successFunc);
  };

  var getAccounts = function(clientId, year, successFun) {
      ajaxService.doPost(urlService.accounts.getAccounts, {clientId: clientId, year: year}).then(successFun);
  };

  var rewriteAccountsWithLastYear = function (clientId, year, successFun) {
      ajaxService.doPost(urlService.accounts.rewriteAccountsWithLastYear, { clientId: clientId, year: year }).then(successFun);
  };

  var addAccount = function(item, successFunc) {
    ajaxService.doPostWithBlock(urlService.accounts.addAccount, item).then(successFunc);
  };

  var deleteAccount = function (account, successFunc) {
    ajaxService.doPostWithBlock(urlService.accounts.deleteAccount, {account: account}).then(successFunc);
  };

  var getDocuments = function(clientId, year, successFun) {
    ajaxService.doPost(urlService.documents.getDocuments, {clientId: clientId, year: year}).then(successFun);
  };

  var addDocument = function(item, successFunc) {
      ajaxService.doPostWithBlock(urlService.documents.addDocument, item).then(successFunc);
  };

  var updateDocument = function (item, successFunc) {
      ajaxService.doPostWithBlock(urlService.documents.updateDocument, item).then(successFunc);
  };

  var deleteDocument = function (ident, successFunc) {
      ajaxService.doPostWithBlock(urlService.documents.deleteDocument, { id: ident }).then(successFunc);
  };

  var getReports = function (clientId, year, successFunc) {
      ajaxService.doPostWithBlock(urlService.reports.getReports, { clientId: clientId, year: year }).then(successFunc);
  };

  var getClients = function (successFunc) {
      ajaxService.doPostWithBlock(urlService.clients.getClients).then(successFunc);
  };

  var initData = function (successFunc) {
      ajaxService.doPost(urlService.clients.initData).then(successFunc);
  };

  var printAccounts = function (clientId, year) {
      ajaxService.doGet(urlService.accounts.printAccounts + '?clientId=' + clientId + '&year=' + year).then(showPdf);
  };

  var printOpenings = function (clientId, year) {
      ajaxService.doGet(urlService.openings.printOpenings + '?clientId=' + clientId + '&year=' + year).then(showPdf);
  };

  var printDocuments = function (clientId, year) {
      ajaxService.doGet(urlService.documents.printDocuments + '?clientId=' + clientId + '&year=' + year).then(showPdf);
  };

  var printReports = function (clientId, year) {
      ajaxService.doGet(urlService.reports.printReports + '?clientId=' + clientId + '&year=' + year).then(showPdf);
  };

  return {
    saveOpenings: saveOpenings,
    getOpenings: getOpenings,
    getIdFromUrl: getIdFromUrl,
    addAccount: addAccount,
    deleteAccount: deleteAccount,
    getAccounts: getAccounts,
    rewriteAccountsWithLastYear: rewriteAccountsWithLastYear,
    addDocument: addDocument,
    updateDocument: updateDocument,
    deleteDocument: deleteDocument,
    getDocuments: getDocuments,
    getReports: getReports,
    getClients: getClients,
    initData: initData,
    printAccounts: printAccounts,
    printOpenings: printOpenings,
    printDocuments: printDocuments,
    printReports: printReports
  }
}]);
