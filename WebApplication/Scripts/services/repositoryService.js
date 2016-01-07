'use strict';
angular.module('finLiteApp').service('repositoryService', ['$http', 'ajaxService', 'urlService', function ($http, ajaxService, urlService) {

  var getIdFromUrl = function () {
    var elems = window.location.href.split("/");
    return elems[elems.length - 1];
  };

  var saveOpenings = function(item, successFunc) {
    ajaxService.doPostWithBlock('saveOpenings', item).then(successFunc);
  };

  var getOpenings = function(successFunc) {
    ajaxService.doGet('getOpenings').then(successFunc);
  };

  var getAccounts = function(clientId, successFun) {
      ajaxService.doPost(urlService.accounts.getAccounts, {clientId: clientId}).then(successFun);
  };

  var addAccount = function(item, successFunc) {
    ajaxService.doPostWithBlock(urlService.accounts.addAccount, item).then(successFunc);
  };

  var deleteAccount = function (account, successFunc) {
    ajaxService.doPostWithBlock(urlService.accounts.deleteAccount, {account: account}).then(successFunc);
  };

  var getDocuments = function(successFun) {
    ajaxService.doGet('getDocuments').then(successFun);
  };

  var addDocument = function(item, successFunc) {
    ajaxService.doPostWithBlock('addDocuments', item).then(successFunc);
  };

  var deleteDocument = function(ident, successFunc) {
    ajaxService.doPostWithBlock('deleteDocuments', {id: ident}).then(successFunc);
  };

  var getReports = function(successFunc) {
    ajaxService.doGetWithBlock('getReports').then(successFunc);
  };

  var getClients = function (successFunc) {
      debugger;
      ajaxService.doPostWithBlock(urlService.clients.getClients).then(successFunc);
//      successFunc([
//          { id: 1, name: "UKS" },
//          { id: 2, name: "Równość" }
//      ]);
  };

  var getClient = function(successFunc) {
      //    ajaxService.doGet('getClient').then(successFunc);
      successFunc({ id: 2, name: "Równość" });
  };

  return {
    saveOpenings: saveOpenings,
    getOpenings: getOpenings,
    getClient: getClient,
    getIdFromUrl: getIdFromUrl,
    addAccount: addAccount,
    deleteAccount: deleteAccount,
    getAccounts: getAccounts,
    addDocument: addDocument,
    deleteDocument: deleteDocument,
    getDocuments: getDocuments,
    getReports: getReports,
    getClients: getClients
  }
}]);
