'use strict';

var appServices = angular.module("finLite.Services", []);
var appDirectives = angular.module("finLite.Directives", []);
var appFilters = angular.module("finLite.Filters", []);


angular.module('finLiteApp', ['finLite.Services', 'finLite.Directives', 'finLite.Filters', 'ngDialog', 'angular-growl', 'ui.bootstrap', 'ngCookies'], function ($locationProvider) {
        $locationProvider.html5Mode(true);
    }).config(['growlProvider', function (growlProvider) {
        growlProvider.globalTimeToLive(5000);
    }]);
