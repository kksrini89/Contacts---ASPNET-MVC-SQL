(function () {
    'use strict';
    var app = angular.module('contactsApp');
    app.service('contactService', ['$http', function ($http) {
        var contact = this;
        var url = 'http://localhost:14922/';
        contact.saveContact = function (newContact) {
            return $http.post(url + 'api/contact/save', newContact);
        }
        return contact;
    }]);
}());