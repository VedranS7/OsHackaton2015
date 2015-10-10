(function (global) {
	'use strict';

	var controller = ['$scope', '$http'];
	controller.push(function ($scope, $http) {
		console.log($scope)
	});

	angular.module('app.global')
		.controller('UserController', controller);

}(this) /* Auto-invoked */ );
