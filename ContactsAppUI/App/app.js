(function () {
    'use strict';
    var app = angular.module('contactsApp', ['ngComponentRouter']);
    app.value('$routerRootComponent', 'contactsMain');
    app.component('about', {
        template : '<h2>I am about Page!!!</h2>'
    });
})();