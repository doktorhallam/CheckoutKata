
(function () {

    'use strict';

    var injectParams = ['$http'];

    var builder = function ($http) {

        var instance = {};

        instance.GET = function (route) {

            return $http({
                method: 'GET',
                responseType: 'json',
                url: encodeURI(route)
            });

        };

        return instance;
    };

    builder.$inject = injectParams;
    angular.module('checkoutkata.Services')
		.service('apiService', builder);

})();
