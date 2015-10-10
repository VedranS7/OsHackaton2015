(function (global) {
	'use strict';

	var controller = ['$scope', '$http'];
	controller.push(function ($scope, $http) {
		$scope.showLoginForm = false;
		$scope.isFormInvalid = true;

		$scope.email = '';
		$scope.password = '';
		$scope.passwordConfirm = '';
		$scope.userGroup = -1;

		$scope.$watchGroup(['email', 'password', 'passwordConfirm', 'userGroup'], function (newValues, oldValues, scope) {
			$scope.email = newValues[0];
			$scope.password = newValues[1];
			$scope.passwordConfirm = newValues[2];
			$scope.userGroup = newValues[3];

			if ($scope.email !== '') {
				if ($scope.password === $scope.passwordConfirm) {
					if ($scope.userGroup == 1 || $scope.userGroup == 2) {
						$scope.isFormInvalid = false;
					}
				}
			}
		});

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
