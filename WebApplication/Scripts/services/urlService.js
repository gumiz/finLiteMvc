/*global appServices, $*/
appServices.factory('urlService', ['domService', function (domService) {
    "use strict";

    var controllers = {
        Accounts: 'Accounts',
        Documents: 'Documents',
        Reports: 'Reports',
        OpeningBalance: 'OpeningBalance',
        Clients: 'Clients',
        Creators: 'Creators'
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
            rewriteAccountsWithLastYear: createUrl(controllers.Accounts, "RewriteAccountsWithLastYear"),
            printAccounts: createUrl(controllers.Accounts, "Print"),
            addAccount: createUrl(controllers.Accounts, "AddAccount"),
            deleteAccount: createUrl(controllers.Accounts, "DeleteAccount")
        },
        openings: {
            index: createUrl(controllers.OpeningBalance, "Index"),
            getOpenings: createUrl(controllers.OpeningBalance, "GetOpenings"),
            saveOpenings: createUrl(controllers.OpeningBalance, "SaveOpenings"),
            printOpenings: createUrl(controllers.OpeningBalance, "Print")
    },
        documents: {
            index: createUrl(controllers.Documents, "Index"),
            getDocuments: createUrl(controllers.Documents, "GetDocuments"),
            deleteDocument: createUrl(controllers.Documents, "DeleteDocument"),
            addDocument: createUrl(controllers.Documents, "AddDocument"),
            updateDocument: createUrl(controllers.Documents, "UpdateDocument"),
            printDocuments: createUrl(controllers.Documents, "Print")
        },
        reports: {
            index: createUrl(controllers.Reports, "Index"),
            getReports: createUrl(controllers.Reports, "GetReports"),
            printReports: createUrl(controllers.Reports, "Print")
        },
        creators: {
            profitLoss: createUrl(controllers.Creators, "ProfitLoss"),
            getProfitLossItems: createUrl(controllers.Creators, "GetProfitLossItems"),
            saveProfitLossItems: createUrl(controllers.Creators, "SaveProfitLossItems"),
            printProfitLoss: createUrl(controllers.Creators, "PrintProfitLoss"),
            balance: createUrl(controllers.Creators, "Balance"),
            getBalanceItems: createUrl(controllers.Creators, "GetBalanceItems"),
            saveBalanceItems: createUrl(controllers.Creators, "SaveBalanceItems"),
            printBalance: createUrl(controllers.Creators, "PrintBalance")
    }


    };
}]);
