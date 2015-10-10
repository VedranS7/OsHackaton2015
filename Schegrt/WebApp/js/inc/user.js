(function (global) {
	'use strict';

	var controller = ['$scope', '$http'];
	controller.push(function ($scope, $http) {
		console.log($scope)

		$http.get('/api/Providers/6').then(function (response) {
			console.log(response.data);
		});


	});

	angular.module('app.global')
		.controller('UserController', controller);

}(this) /* Auto-invoked */ );
