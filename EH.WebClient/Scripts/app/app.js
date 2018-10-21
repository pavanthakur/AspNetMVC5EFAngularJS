(function () {
    "use strict";

    var myAppModule = angular.module('myApp', ['ngRoute', 'ui.bootstrap']);

    myAppModule.config(['$provide', function ($provide) {
        $provide.decorator('$exceptionHandler', ['$delegate', function ($delegate) {
            return function (exception, cause) {
                $delegate(exception, cause);
                alert(exception.message);
            };
        }]);
    }]);

    myAppModule.config([
        '$routeProvider', function ($routeProvider) {
            
            $routeProvider.when('/', { templateUrl: 'Scripts/app/views/contactIndex.html', controller: 'contactIndexController' });
            $routeProvider.when('/contacts', { templateUrl: 'Scripts/app/views/contactIndex.html', controller: 'contactIndexController' });
            $routeProvider.when('/contacts/new', { templateUrl: 'Scripts/app/views/contactEdit.html', controller: 'contactEditController' });
            $routeProvider.when('/contacts/:contactId/edit', { templateUrl: 'Scripts/app/views/contactEdit.html', controller: 'contactEditController' });
        }
    ]);

})();