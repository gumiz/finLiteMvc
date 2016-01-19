/*global appServices, $*/
appServices.factory('urlService', ['domService', function (domService) {
    "use strict";

    var controllers = {
        Accounts: 'Accounts',
        Documents: 'Documents',
        Reports: 'Reports',
        OpeningBalance: 'OpeningBalance',
        Clients: 'Clients'
};

    var getBasePath = function () {
        return domService.getBasePath;
    };

    var createUrl = function (ctrlName, actionName) {
        return getBasePath() + ctrlName + '/' + actionName;
    };

    var getIdFromUrl = function() {
        var elems = window.location.href.split("/");
        return elems[elems.length - 1];
    };

    return {
        getIdFromUrl: getIdFromUrl,
        getBasePath: getBasePath(),
        clients: {
            getClients: createUrl(controllers.Clients, "GetClients"),
            initData: createUrl(controllers.Clients, "InitData")
        },
        accounts: {
            index: createUrl(controllers.Accounts, "Index"),
            getAccounts: createUrl(controllers.Accounts, "GetAccounts"),
            addAccount: createUrl(controllers.Accounts, "AddAccount"),
            deleteAccount: createUrl(controllers.Accounts, "DeleteAccount")
        },
        openings: {
            index: createUrl(controllers.OpeningBalance, "Index"),
            getOpenings: createUrl(controllers.OpeningBalance, "GetOpenings"),
            saveOpenings: createUrl(controllers.OpeningBalance, "SaveOpenings")
        },
        documents: {
            index: createUrl(controllers.Documents, "Index"),
            getDocuments: createUrl(controllers.Documents, "GetDocuments"),
            deleteDocument: createUrl(controllers.Documents, "DeleteDocument"),
            addDocument: createUrl(controllers.Documents, "AddDocument")
        },
        reports: {
            index: createUrl(controllers.Reports, "Index"),
            getReports: createUrl(controllers.Reports, "GetReports")
    }

    };
}]);
