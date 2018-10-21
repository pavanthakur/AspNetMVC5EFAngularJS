(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('contactIndexController', ['$scope', 'contactService',
        function ($scope, contactService) {
            InitPage();

            function InitPage() {
                contactService.getcontacts().then(function (results) {

                    $scope.contacts = results.data;

                }, function (error) {
                    alert(error.data.message);
                });
            }

            $scope.deletecontact = function (contactId) {
                contactService.deletecontact(contactId).then(function (results) {

                    alert(results.data);

                    InitPage();

                }, function (error) {
                    alert(error.data.message);
                });
            };
        }
    ]);
})();