(function(global) {
	'use strict';

	var appGlobal = angular.module('app.global', ["xeditable"]);

	appGlobal.config([function () {
		
	}]);

	appGlobal.run(function (editableOptions) {
		editableOptions.theme = 'bs3';
	});

}(this) /* Auto-invoked */ );