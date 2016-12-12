'use strict';

angular.module('crudPlayersDirectives', [])
.directive('customPicture', function () {
    var ddo = {
        restrict: 'AE',
        scope: {
            title: '@',
            url: '@'
        },
        template: '<img class="img-responsive center-block" src="{{url}}" alt="{{title}}">'
    };
    return ddo;
})
.directive('dangerButton', function () {
    var ddo = {
        restrict: 'E',
        scope: {
            action: '&',
            icon: '@',
            name: '@',
            customStyle: '@'
        },
        template: '<button ng-click="action(player)" class="btn btn-danger btn-block {{icon}}" style="{{customStyle}}"> {{name}}</button>'
    };
    return ddo;
});