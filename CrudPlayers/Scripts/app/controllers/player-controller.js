'use strict';

angular.module('crudPlayersApp')
.controller('PlayerController', function ($scope, $location, $routeParams, playerResource) {

    $scope.player = {};
    $scope.ages = [];
    $scope.message = '';

    // Read
    if ($routeParams.id) {
        playerResource.get({ id: $routeParams.id },
            function (player) {
                $scope.player = player;

                for (var i = 1; i <= 100; i++) {
                    $scope.ages.push(i);
                }
            },
            function (error) {
                console.log(error);
                $scope.message = 'Could not retrieve player data.';
            });
    }
    else {
        for (var i = 1; i <= 100; i++) {
            $scope.ages.push(i);
        }
    }

    $scope.toSubmit = function () {
        if ($scope.playerForm.$valid) {
            // Update
            if ($scope.player.Id) {
                playerResource.update({ id: $scope.player.Id }, $scope.player,
                    function () {
                        $scope.message = 'Player ' + $scope.player.Name + ' was successfully registered.';
                    },
                    function (error) {
                        $scope.message = 'Could not change player ' + $scope.player.Name + '.';
                        console.log(error);
                    });
            }
            // Create
            else {
                playerResource.save($scope.player,
                    function () {
                        $scope.player = {};
                        $scope.message = 'Player successfully registered.';
                    },
                    function (error) {
                        $scope.message = 'Could not register the player.';
                        console.log(error);
                    });
            }
        }
    };

});