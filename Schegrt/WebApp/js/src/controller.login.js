(function (global) {
	'use strict';

	var controller = ['$scope', '$http'];
	controller.push(function ($scope, $http) {
		$scope.showLoginForm = false;

		$scope.loginClick = function () {
			$scope.showLoginForm = !$scope.showLoginForm;
		};
	});

	angular.module('app.global')
		.controller('AuthController', controller);

}(this) /* Auto-invoked */ );
