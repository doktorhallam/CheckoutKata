
(function () {

    'use strict';

    var injectParams = ['$scope', 'apiService'];

    var builder = function ($scope, apiService) {

        var instance = {};

        //instance.cart = {};
        //instance.products = [];

        instance.clear = function (event) {

            event.preventDefault();

            apiService.GET('http://localhost:52498/api/clear')
                .then(function (response) {
                    instance.cart = response.data;
                });

        };

        instance.decrement = function (event, sku) {

            event.preventDefault();

            apiService.GET('http://localhost:52498/api/decrement?sku=' + sku)
                .then(function (response) {
                    instance.cart = response.data;
                });

        };

        instance.increment = function (event, sku) {

            event.preventDefault();

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
                });

        };

        return instance;
    };

    builder.$inject = injectParams;
    angular.module('checkoutkata.Controllers')
		.controller('checkoutController', builder);

})();
