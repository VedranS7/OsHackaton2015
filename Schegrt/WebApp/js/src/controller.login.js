(function (global) {
	'use strict';

	var controller = ['$scope', '$http'];
	controller.push(function ($scope, $http) {
		$scope.showLoginForm = false;

		$scope.loginClick = function () {
			$scope.showLoginForm = !$scope.showLoginForm;
		};

		$scope.authTypeClick = function (e) {
			var $this = angular.element(e.currentTarget);

			$this.parent().find('label').removeClass('active');
			$this.addClass('active');
		};
	});

	angular.module('app.global')
		.controller('AuthController', controller);

}(this) /* Auto-invoked */ );
