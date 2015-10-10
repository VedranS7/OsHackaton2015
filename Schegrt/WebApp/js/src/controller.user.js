(function (global) {
	'use strict';

	var controller = ['$scope', '$http'];
	controller.push(function ($scope, $http) {
		$scope.company = {};
		$scope.companyInterests = [];

		$http.get('/api/Providers/1').then(function (response) {
			$scope.company = response.data;
		});

		$http.get('/api/interests/1').then(function (response) {
			$scope.companyInterests = response.data;
		})


	});

	angular.module('app.global')
		.controller('UserController', controller);

}(this) /* Auto-invoked */ );
