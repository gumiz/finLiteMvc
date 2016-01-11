'use strict';

var appServices = angular.module("finLite.Services", []);
var appDirectives = angular.module("finLite.Directives", []);
var appFilters = angular.module("finLite.Filters", []);


angular.module('finLiteApp', ['finLite.Services', 'finLite.Directives', 'finLite.Filters', 'ngDialog', 'angular-growl'], function($locationProvider) {
        $locationProvider.html5Mode(true);
    }).config(['growlProvider', function (growlProvider) {
        growlProvider.globalTimeToLive(5000);
    }])

//  .directive('autoActive', ['$location', function ($location) {
//    return {
//      restrict: 'A',`
//      scope: false,
//      link: function (scope, element) {
//        function setActive() {
//          var path = $location.path();
//          if (path) {
//            angular.forEach(element.find('li'), function (li) {
//              var anchor = li.querySelector('a');
//              if (anchor.href.match('#' + path + '(?=\\?|$)')) {
//                angular.element(li).addClass('active');
//              } else {
//                angular.element(li).removeClass('active');
//              }
//            });
//          }
//        }
//
//        setActive();
//
//        scope.$on('$locationChangeSuccess', setActive);
//      }
//    }
//  }])
//
//  .directive('phonenumberDirective', ['$filter', function($filter) {
//    function link(scope, element, attributes) {
//      scope.inputValue = scope.phonenumberModel;
//      scope.$watch('inputValue', function(value, oldValue) {
//        value = String(value);
//        var number = value.replace(/[^0-9]+/g, '');
//        scope.phonenumberModel = number;
//        scope.inputValue = $filter('phonenumber')(number);
//      });
//    }
//
//    return {
//      link: link,
//      restrict: 'E',
//      scope: {
//        phonenumberPlaceholder: '=placeholder',
//        phonenumberModel: '=model'
//      },
//      //templateUrl: '/static/phonenumberModule/template.html',
//      template: '<input ng-model="inputValue" type="tel" class="phonenumber" placeholder="{{phonenumberPlaceholder}}" title="Phonenumber (Format: (999) 9999-9999)">',
//    };
//  }])
//
//
  .filter('total', function () {
    return function (input, property) {
      var i = input instanceof Array ? input.length : 0;
      if (typeof property === 'undefined' || i === 0) {
        return i;
      } else if (isNaN(input[0][property])) {
        throw 'filter total can count only numeric values';
      } else {
        var total = 0;
        while (i--)
          total += Number(input[i][property]);
        return total;
      }
    };
  });
