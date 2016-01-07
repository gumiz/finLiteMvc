/*global appServices, $*/
appServices.factory('domService', function () {
    "use strict";

    var getBasePath = function() {
            return $('body').attr('data-baseUrl');
    };

    return {
        getBasePath: getBasePath()
    };
});
