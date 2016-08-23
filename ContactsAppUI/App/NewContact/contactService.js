(function () {
    'use strict';
    var app = angular.module('contactsApp');
    app.service('contactService', ['$http', function ($http) {
        var contact = this;
        var url = 'http://localhost:14922/';
        contact.getContacts = function () {
            return $http.get(url + 'api/contact/getall');
            //.then(function (data) {
            //    return data;
            //}, function (error, status, config) { console.log(error + '--' + status) });
        }
        contact.search = function (name) {
            return $http({
                method: 'GET',
                url: url + 'api/contact/search',
                data: { name: name }
            });
            //return $http.get(url + 'api/contact/search', name);
        }
        contact.saveContact = function (newContact) {
            return $http.post(url + 'api/contact/save', newContact);
        }
        contact.deleteContact = function (id) {
            $http.delete(url + 'api/contact/delete', id);
        }
        return contact;
    }]);
}());