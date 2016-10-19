
(function () {

    'use strict';

    var injectParams = ['$scope', 'apiService'];

    var builder = function ($scope, apiService) {

        var instance = {};

        instance.clear = function () {

            apiService.GET('http://localhost:52498/api/clear')
                .then(function (response) {
                    instance.cart = response.data;
                });

        };

        instance.decrement = function (sku) {

            apiService.GET('http://localhost:52498/api/decrement?sku=' + sku)
                .then(function (response) {
                    instance.cart = response.data;
                });

        };

        instance.increment = function (sku) {

            apiService.GET('http://localhost:52498/api/increment?sku=' + sku)
                .then(function (response) {
                    instance.cart = response.data;
                });

        };

        instance.init = function () {

            var deferredPromises = [
                apiService.GET('http://localhost:52498/api/clear'),
                apiService.GET('http://localhost:52498/api/products')
            ];

            Promise.all(deferredPromises)
                .then(function (responses) {
                    instance.cart = responses[0].data;
                    instance.products = responses[1].data;
                    console.log(instance.products);
                    $scope.$apply();
                });

        };

        return instance;
    };

    builder.$inject = injectParams;
    angular.module('checkoutkata.Controllers')
		.controller('checkoutController', builder);

})();
