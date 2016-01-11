﻿'use strict';
angular.module('finLiteApp').service('repositoryService', ['$http', 'ajaxService', 'urlService', function ($http, ajaxService, urlService) {

  var getIdFromUrl = function () {
    var elems = window.location.href.split("/");
    return elems[elems.length - 1];
  };

  var saveOpenings = function(item, successFunc) {
    ajaxService.doPostWithBlock(urlService.openings.saveOpenings, item).then(successFunc);
  };

  var getOpenings = function (clientId, year, successFunc) {
      ajaxService.doPost(urlService.openings.getOpenings, { clientId: clientId, year: year }).then(successFunc);
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

  var getDocuments = function(clientId, year, successFun) {
    ajaxService.doPost(urlService.documents.getDocuments, {clientId: clientId, year: year}).then(successFun);
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
      ajaxService.doPostWithBlock(urlService.clients.getClients).then(successFunc);
  };

  var initData = function (successFunc) {
      ajaxService.doPost(urlService.clients.initData).then(successFunc);
  };

  return {
    saveOpenings: saveOpenings,
    getOpenings: getOpenings,
    getIdFromUrl: getIdFromUrl,
    addAccount: addAccount,
    deleteAccount: deleteAccount,
    getAccounts: getAccounts,
    addDocument: addDocument,
    deleteDocument: deleteDocument,
    getDocuments: getDocuments,
    getReports: getReports,
    getClients: getClients,
    initData: initData
  }
}]);
