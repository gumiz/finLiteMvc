/*global appServices, $*/
angular.module('finLiteApp').service('cookieService', ['$cookies', function ($cookies) {
   "use strict";

   var getValue = function (name) {
       return $cookies[name];
   };
    var setValue = function (name, value) {
        $cookies[name] = value;
    };

    return {
        getValue: getValue,
        setValue: setValue
    };
}]);
