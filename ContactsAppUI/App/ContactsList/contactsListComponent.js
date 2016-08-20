(function () {
    'use strict';
    var app = angular.module('contactsApp');
    var controller = ['contactService', function (contactService) {
        var model = this;
        contactService.getContacts().then(function (result) {
            if (result.data !== null)
                model.contacts = result.data;
        }, function (error) {
            console.log(error);
        });
        model.deleteContact = function (id) {
            contactService.deleteContact(id);
        }
        //model.contacts = contactService.getContacts();
    }];
    app.component('contactsList', {
        templateUrl: '/App/ContactsList/contactsListComponent.html',
        controllerAs: 'model',
        controller: controller
    });
})();