'use strict';

angular.module('crudPlayersApp')
.controller('PlayersController', function ($scope, playerResource) {

    $scope.players = [];
    $scope.customFilter = '';
    $scope.message = '';

    // Get all players
    playerResource.query(
        function (players) {
            $scope.players = players;
        },
        function (error) {
            console.log(error);
        });

    // Removes an only single player
    $scope.delete = function (player) {
        playerResource.delete({ id: player.Id },
            function () {
                var playerIndex = $scope.players.indexOf(player);
                $scope.players.splice(playerIndex, 1);
                $scope.message = 'Player ' + player.Name + ' was successfully removed.';
            },
            function (error) {
                console.log(error);
                $scope.message = 'Unable to remove player ' + player.Name + '.';
            });
    };
});