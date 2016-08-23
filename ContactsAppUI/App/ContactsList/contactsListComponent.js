(function () {
    'use strict';
    var app = angular.module('contactsApp');
    var controller = ['contactService', function (contactService) {
        var model = this;
        model.searchName = '';
        contactService.getContacts().then(function (result) {
            if (result.data !== null)
                model.contacts = result.data;
        }, function (error) {
            console.log(error);
        });
        model.deleteContact = function (id) {
            contactService.deleteContact(id);
        }
        model.search = function (name) {
            contactService.search(name).then(function (result) {
                console.log(result);
            }, function (error) {
                console.log(error);
            });
        }
    }];
    app.component('contactsList', {
        templateUrl: '/App/ContactsList/contactsListComponent.html',
        controllerAs: 'model',
        controller: controller
    });
})();