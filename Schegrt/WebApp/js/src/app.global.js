(function(global) {
	'use strict';

	var appGlobal = angular.module('app.global', ["xeditable"]);

	appGlobal.config([function () {
		
	}]);

	appGlobal.run(function (editableOptions) {
		editableOptions.theme = 'bs3';
	});

	$(document).ready(function () {
		$('.select2').select2();
	});

}(this) /* Auto-invoked */ );