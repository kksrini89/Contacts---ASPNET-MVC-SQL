(function () {
    'use strict';
    var app = angular.module('contactsApp', []);
    app.component('NewContactComponent', {
        template: '<h1>Wow</h1>',
        controllerAs: 'vm',
        controller: function () {
            var model = this;
            model.name = 'Srinivasan';
        }
    });
})();