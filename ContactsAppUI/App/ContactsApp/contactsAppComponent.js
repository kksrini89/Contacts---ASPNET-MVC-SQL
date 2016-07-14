(function () {
    'use strict';
    var app = angular.module('contactsApp');
    app.component('contactsMain', {
        templateUrl: '/App/ContactsApp/contactsAppComponent.html',
        $routeConfig: [
            { path: '/list', component: 'contactsList', name: 'ContactsList' },
            { path: '/new', component: 'newContact', name: 'NewContact' },
            { path: '/about', component: 'about', name: 'About' }
        ]
    });
})();