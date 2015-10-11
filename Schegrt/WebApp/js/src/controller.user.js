(function (global) {
	'use strict';

	var controller = ['$scope', '$element', '$http'];
	controller.push(function ($scope, $element, $http) {
		$scope.company = {
			CompanyName: null,
			Location: null,
			URL: null,
			Email: null,
			Description: null
		};
		$scope.companyInterests = [];
		$scope.editedInfo = false;
		$scope.newSkill = '';

		var providerId = $('#sidebar-menu').find('.user-id').val();
		var providersUrl = ('/api/Providers/:id').replace(':id', providerId),
			interestsUrl = ('/api/Interests/:id').replace(':id', providerId);

		$http.get(providersUrl).then(function (response) {
			$scope.company = response.data;
		});

		$http.get(interestsUrl).then(function (response) {
			$scope.companyInterests = response.data;
		})

		$scope.$watchGroup(['company.CompanyName', 'company.Location', 'company.URL', 'company.Email', 'company.Description'], function (newValues, oldValues, scope) { 
			$scope.company.CompanyName = newValues[0];
			$scope.company.Location = newValues[1];
			$scope.company.URL = newValues[2];
			$scope.company.Email = newValues[3];
			$scope.company.Description = newValues[4];
			
			$http({
				method: 'PUT',
				data: $scope.company,
				url: '/api/Providers/PutProviderUser'
			}).then(function (response) {
				console.log(response)
			});
		});

	});

	angular.module('app.global')
		.controller('UserController', controller);

}(this) /* Auto-invoked */ );
