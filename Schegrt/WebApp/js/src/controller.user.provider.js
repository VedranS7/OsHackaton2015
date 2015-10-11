(function (global) {
	'use strict';

	var controller = ['$scope', '$element', '$http', '$timeout'];
	controller.push(function ($scope, $element, $http, $timeout) {
		$scope.company = {
			CompanyName: null,
			Location: null,
			URL: null,
			Email: null,
			Description: null
		};
		$scope.companyInterests = [];
		$scope.userRecommendations = [];
		$scope.editedInfo = false;
		$scope.newSkill = '';

		var providerId = $('#sidebar-menu').find('.user-id').val();
		var providersUrl = ('/api/Providers/:id').replace(':id', providerId),
			interestsUrl = ('/api/Interests/:id').replace(':id', providerId),
			matchesUrl = ('/api/UserRecommendations/:id').replace(':id', providerId);

		$http.get(providersUrl).then(function (response) {
			$scope.company = response.data;
		});

		$http.get(interestsUrl).then(function (response) {
			$scope.companyInterests = response.data;
		});

		$http.get(matchesUrl).then(function (response) {
			$scope.userRecommendations = response.data;
		})

		$scope.addSkill = function () {

		};

		$timeout(function () {
			$scope.$watchGroup(['company.CompanyName', 'company.Location', 'company.URL', 'company.Description'], function (newValues, oldValues, scope) { 
				$scope.company.CompanyName = newValues[0];
				$scope.company.Location = newValues[1];
				$scope.company.URL = newValues[2];
				$scope.company.Description = newValues[3];
				
				$http({
					method: 'PUT',
					data: $scope.company,
					url: '/api/Providers/PutProviderUser'
				}).then(function (response) {
				});
			});
		}, 1000);

	});

	angular.module('app.global')
		.controller('UserProviderController', controller);

}(this) /* Auto-invoked */ );
