var gulp = require('gulp');
var gutil = require('gulp-util');
var browserify = require('gulp-browserify');
var rename = require("gulp-rename");
var connect = require('gulp-connect');
var watchLess = require('gulp-watch-less');
var less = require('gulp-less');
var minifyCSS = require('gulp-minify-css');
var debugMode = true;
var keepBreaks = false;

// js code
gulp.task('mainjs', function () {
    return gulp.src('UI/_main.js')
        .pipe(browserify({
            debug: debugMode
        }).on('error', gutil.log))
        .pipe(rename('../static/_main.js'))
        .pipe(gulp.dest('./'));
});

gulp.task('watchjs', function () {
    gulp.watch(['./UI/*.js'], ['mainjs']);
});

// less code
gulp.task('mainless', function () {
    return gulp.src('../less/UI/_main.less')
        .pipe(less().on('error', gutil.log))
		.pipe(minifyCSS({ keepBreaks: keepBreaks }))
		.pipe(rename('../static/_main.css'))
        .pipe(gulp.dest('./'));
});

gulp.task('watchless', function () {
    gulp.watch(['../less/UI/*.less'], ['mainless']);
});

gulp.task('server', function () {
    connect.server();
});

gulp.task('default', ['mainjs', 'mainless', 'watchjs', 'watchless', 'server']);