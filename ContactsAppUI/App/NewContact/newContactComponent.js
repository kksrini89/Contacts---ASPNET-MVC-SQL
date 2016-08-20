(function () {
    'use strict';
    var app = angular.module('contactsApp');

    var controller = ['contactService', function (contactService) {
        var model = this;
        model.contact = {
            name: '',
            mobile: '',
            relationship: '',
            street: '',
            city: '',
            state: '',
            country: ''
        }
        model.submit = function () {
            contactService.saveContact(model.contact);
        }
    }];

    app.component('newContact', {
        templateUrl: '/App/NewContact/newContactComponent.html',        
        controller: controller,
        controllerAs: 'model'
    });
})();