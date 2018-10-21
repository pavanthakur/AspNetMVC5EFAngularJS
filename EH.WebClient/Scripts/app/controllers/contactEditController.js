(function () {
    "use strict";

    var myAppModule = angular.module('myApp');

    myAppModule.controller('contactEditController', ['$scope', '$location', '$routeParams', 'contactService',
        function ($scope, $location, $routeParams, contactService) {
            $scope.isNew = !$routeParams.contactId;

            InitPage();

            function InitPage() {
                contactService.getStatusList().then(function (results) {

                    $scope.statusTypes = results.data;

                }, function (error) {
                    alert(error.data.message);
                });

                if ($scope.isNew) {
                    $scope.contact = [];
                    $scope.contact.StatusID = 2;
                    $scope.formTitle = "Add new contact";
                } else {
                    contactService.getContactById($routeParams.contactId).then(function (results) {

                        $scope.contact = results.data;

                    }, function (error) {
                        alert(error.data.message);
                    });

                    $scope.formTitle = "Update contact";
                }
            }

            $scope.submit = function () {
                if ($scope.isNew) {

                    contactService.insertcontact(getContactViewModel()).then(function (results) {

                        alert(results.data);

                        $location.path('/contacts');

                    }, function (error) {
                        alert(error.data.message);
                    });
                } else {
                    contactService.updatecontact($scope.contact).then(function (results) {

                        alert(results.data);

                        $location.path('/contacts');

                    }, function (error) {
                        alert(error.data.message);
                    });
                }
            };

            function getContactViewModel() {
                return {
                    Id: 0,
                    FirstName: $scope.contact.FirstName,
                    LastName: $scope.contact.LastName,
                    Email: $scope.contact.Email,
                    PhoneNumber: $scope.contact.PhoneNumber,
                    StatusID: $scope.contact.StatusID,
                    StatusName: null
                };
            }

            $scope.cancel = function () {
                $location.path('/contacts');
            };
        }
    ]);
})();