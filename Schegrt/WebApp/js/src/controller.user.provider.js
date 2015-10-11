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
		$scope.newSkillLevel = '';
		$scope.newSkillName = -1;
		$scope.interestsList = [];

		var providerId = $('#sidebar-menu').find('.user-id').val();
		var providersUrl = ('/api/Providers/:id').replace(':id', providerId),
			interestsUrl = ('/api/Interests/:id').replace(':id', providerId),
			matchesUrl = ('/api/UserRecommendations/:id').replace(':id', providerId),
			interestsListUrl = ('/api/FOIs/GetFields');

		$http.get(providersUrl).then(function (response) {
			$scope.company = response.data;
		});

		

		$http.get(interestsListUrl).then(function (odgovora) {
			$scope.interestsList = odgovora.data;
		});

		$('.select2').select2().on('change', function (e) {
			var $this = $(e.currentTarget);
			$scope.newSkillName = $this.val();
		});

		$scope.addSkill = function () {
			var data = {
				FOIId: parseInt($scope.newSkillName),
				Level: parseInt($scope.newSkillLevel)
			};

			$http({
				method: 'POST',
				url: '/api/interests',
				data: data
			}).then(function (response) {
				loadMatchesInterests();
			});
		};

		$scope.deleteSkill = function (id) {
			$http({
				method: 'DELETE',
				url: '/api/Interests/' + id
			}).then(function (response) {
				loadMatchesInterests();
			});
		};

		function loadMatchesInterests () {
			$http.get(interestsUrl).then(function (response) {
				$scope.companyInterests = response.data;
			});
			$http.get(matchesUrl).then(function (response) {
				$scope.userRecommendations = response.data;
			});
		}

		loadMatchesInterests();

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
