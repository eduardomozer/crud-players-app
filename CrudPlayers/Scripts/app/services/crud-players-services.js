'use strict';

angular.module('crudPlayersServices', ['ngResource'])
.factory('playerResource', function ($resource) {
    return $resource(
        'api/player/:id',
        { id: "@id" },
        { update: { method: 'PUT' } });
});