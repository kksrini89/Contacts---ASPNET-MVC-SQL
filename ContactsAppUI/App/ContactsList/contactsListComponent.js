(function () {
    'use strict';
    var app = angular.module('contactsApp');
    var controller = ['contactService', function (contactService) {
        var model = this;
        model.searchName = '';
        var isContactsAvailable = true;
        contactService.getContacts().then(function (result) {
            if (result.data !== null)
                model.contacts = result.data;
        }, function (error) {
            console.log(error);
        });
        model.deleteContact = function (id) {
            contactService.deleteContact(id);
        }

        model.search = function (searchName) {
            contactService.search(searchName).then(function (result) {
                var filteredContacts = result.data;
                if (filteredContacts !== null && filteredContacts.length > 0) {
                    angular.copy(filteredContacts, model.contacts);
                } else {
                    isContactsAvailable = false;
                }
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