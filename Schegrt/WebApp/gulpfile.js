(function () {

'use strict';

var config = require('./config.json');

// Main gulp library
var gulp = require('gulp');

// Gulp helper dependencies
var sass		= require('gulp-sass'),
	slash 		= require('gulp-slash'),
	concat 		= require('gulp-concat'),
	uglify 		= require('gulp-uglify'),
	jshint		= require('gulp-jshint'),
	jshintStylish 	= require('jshint-stylish'),
	fileReporter	= require('gulp-jshint-file-reporter'),
	include 	= require('gulp-include'),
	rename 		= require('gulp-rename'),
	plumber 	= require('gulp-plumber'),
		minifyCss = require('gulp-minify-css');

var mapStream 	= require('map-stream'),
	fs 			= require('fs');

var paths = {
	sources: {
		scripts: 	[
						'js/source/src/**/*.js'
					],
		styles: 	['css/source/src/**/*.scss'],
		fonts: 		['css/fonts/*'],
		images: 	['img/*']
	},

	scriptsLib: 	['js/source/lib/**/*.js'],
	scripts: 		[
						'js/source/inc/**/*.js'
					],
	stylesLib: 		['css/source/lib/**/*.scss'],
	styles: 		['css/source/inc/*.scss'],

	compile: {
		scriptsLib: 	'js/dist',
		scripts: 		'js/dist',
		stylesLib: 		'css/dist',
		styles: 		'css/dist', 
		fonts: 			'css/fonts',
		images: 		'img'
	}
};

var errorReporter = mapStream(function (file, cb) {
	if (file.jshint.success) {
		cb(null, file);
	} else {
		this.emit('end');
	}
});

var productionErrorHandler = function (err) {
	console.log(err.toString());
};

	var developmentErrorHandler = function(err) {
		console.log(err.toString());
	};

var errorHandler = function (err) {
	console.log(err);
};

/*
| ===================================================
| Tasks 
| ===================================================
| 
| 1. scriptsLib (all)
| 2. scripts-dev (development)
| 3. scripts (production)
	| 4. build-scripts (pre-production build to verify source integrity) | mail alert
	| 5. build-scripts-dev (pre-production build to verify source integrity) | console output
	| 6. stylesLib (production)
	| 7. styles-dev (development)

	| 10. styles (production)
	| 11. build-styles (pre-production build to verify styles [Sass] file integrity)
|
	| 12. watch (development environment watcher for all changes)
|
	| 13. development - run internally by gulp
	| 14. deploy - run internally by gulp
|
	| 15. build - run by deploy script | mail alert
	| 16. build-dev - run by developers | console output
	| 17. default - run by developers
	| 18. dev - run by developers
*/

// 1.
gulp.task('scriptsLib', function () {
	return gulp.src(paths.scriptsLib)
			.pipe(plumber({
				errorHandler: errorHandler
			}))
		.pipe(include())
		// .pipe(ulgify())
		.pipe(
			rename(function (path) {
				path.extname 	= '.min' + path.extname;
			})
		)
		.pipe(gulp.dest(paths.compile.scriptsLib))
		.on('error', errorHandler);
});

// 2.
gulp.task('scripts-dev', function () {
	var currentDate = new Date();
		
	return gulp.src(paths.scripts)
			.pipe(plumber({
				errorHandler: errorHandler
			}))
		.pipe(include())
		// .pipe(sourcemaps.init())
		// .pipe(jshint('./.jshintrc'))
		// .pipe(jshint.reporter('jshint-stylish'))
		// .pipe(jshint.reporter('fail'))
		// .pipe(sourcemaps.write())
		.pipe(
			rename(function (path) {
				path.extname 	= '.min' + path.extname;
			})
		)
		.pipe(gulp.dest(paths.compile.scripts))
		.on('error', errorHandler);
});

// 3. 
gulp.task('scripts', function () {
	return gulp.src(paths.scripts)
		.pipe(include())
		.pipe(jshint('./.jshintrc'))
		.pipe(jshint.reporter('fail', productionErrorHandler))
		.pipe(uglify())
		.pipe(
			rename(function (path) {
				path.extname 	= '.min' + path.extname;
			})
		)
		.pipe(gulp.dest(paths.compile.scripts))
		.on('error', productionErrorHandler);
});

// 4. 
gulp.task('build-scripts', function () {
	return gulp.src(paths.scripts)
		.pipe(plumber())
		.pipe(include())
		.pipe(jshint('./.jshintrc'))
		.pipe(jshint.reporter('jshint-stylish'))
		.pipe(jshint.reporter('fail', productionErrorHandler))
		.on('error', productionErrorHandler);
});


	// 6.
gulp.task('stylesLib', function () {
	return gulp.src(paths.stylesLib)
		.pipe(plumber())
			.pipe(sass({
				errLogToConsole: true
			}))
			.pipe(minifyCss({
				keepBreaks: true
			}))
		.pipe(
			rename(function (path) {
				path.extname 	= '.min' + path.extname;
			})
		)
		.pipe(gulp.dest(paths.compile.stylesLib))
		.on('error', errorHandler);
});

	// 7.
gulp.task('styles-dev', function () {
	return gulp.src(paths.styles)
			.pipe(plumber({
				errorHandler: errorHandler
			}))
		.pipe(slash())
			.pipe(sass({
				sourceComments: 'map',
				errLogToConsole: true
			}))
		//.pipe(sass({  errLogToConsole: true }))
		.pipe(
			rename(function (path) {
				path.extname 	= '.min' + path.extname;
			})
		)
		.pipe(gulp.dest(paths.compile.styles))
		.on('error', errorHandler);
});

	
	// 10.
gulp.task('styles', function () {
	return gulp.src(paths.styles)
			.pipe(sass({
				onError: productionErrorHandler
			}))
			.pipe(minifyCss({
				keepBreaks: true
			}))
		.pipe(
			rename(function (path) {
				path.extname 	= '.min' + path.extname;
			})
		)
		.pipe(gulp.dest(paths.compile.styles))
		.on('error', productionErrorHandler);
});

	// 11.
gulp.task('build-styles', function () {
	return gulp.src(paths.styles)
		.pipe(plumber())
			.pipe(sass({
				errLogToConsole: true
			}))
		.on('error', productionErrorHandler);
});


	// 13.
gulp.task('watch', function () {
	gulp.watch(paths.scriptsLib, ['scriptsLib']);
	gulp.watch(paths.scripts, ['scripts-dev']);
	gulp.watch(paths.sources.scripts, ['scripts-dev']);

	gulp.watch(paths.stylesLib, ['stylesLib']);
	gulp.watch(paths.styles, ['styles-dev']);
	gulp.watch(paths.sources.styles, ['styles-dev']);
});

// 10. 
gulp.task('development', ['scriptsLib', 'stylesLib', 'scripts-dev', 'styles-dev']);

	// 15.
gulp.task('deploy', ['scriptsLib', 'stylesLib', 'scripts', 'styles']);

	// 16.
gulp.task('build', ['build-scripts', 'build-styles']);

	// 18.
gulp.task('default', ['development', 'watch']);

	// 19.
gulp.task('dev', ['development', 'watch']);

	// 20.
}());