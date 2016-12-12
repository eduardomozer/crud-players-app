'use strict';

angular.module('crudPlayersApp', ['ngRoute', 'crudPlayersDirectives', 'crudPlayersServices'])
.config(function ($routeProvider) {

    $routeProvider.when('/', {
        controller: 'PlayersController',
        templateUrl: '/Views/Player/Players.html'
    });

    $routeProvider.when('/players', {
        controller: 'PlayersController',
        templateUrl: '/Views/Player/Players.html'
    });

    $routeProvider.when('/player/add', {
        controller: 'PlayerController',
        templateUrl: '/Views/Player/Player.html'
    });

    $routeProvider.when('/player/edit/:id', {
        controller: 'PlayerController',
        templateUrl: '/Views/Player/Player.html'
    });

    $routeProvider.otherwise({ redirectTo: '/' });
});