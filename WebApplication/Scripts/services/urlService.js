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
            getClients: createUrl(controllers.Clients, "GetClients")
        },
        accounts: {
            getAccounts: createUrl(controllers.Accounts, "GetAccounts"),
            addAccount: createUrl(controllers.Accounts, "AddAccount"),
            deleteAccount: createUrl(controllers.Accounts, "DeleteAccount")
        }
    };
}]);
