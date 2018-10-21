(function () {
    "use strict";

    contactService.$inject = ['$http'];

    function contactService($http) {

        var objServiceFactory = {};
        var serviceBase = "http://localhost:60381/";

        objServiceFactory.getStatusList = function () {

            return $http({
                method: 'GET',
                url: serviceBase + 'api/Contacts/GetStatusList'
            });
        };

        objServiceFactory.getcontacts = function () {

            return $http({
                method: 'GET',
                url: serviceBase + 'api/Contacts/GetContactList'
            });
        };

        objServiceFactory.getContactById = function (contactId) {
            return $http({
                method: 'GET',
                params: { xiContactId: contactId },
                url: serviceBase + 'api/Contacts/GetContactById',
                headers: { 'content-type': 'application/json' }
            });
        };

        objServiceFactory.insertcontact = function (data) {
            return $http({
                method: 'POST',
                data: data,
                url: serviceBase + 'api/Contacts/InsertContact',
                headers: { 'content-type': 'application/json' }
            });
        };

        objServiceFactory.updatecontact = function (data) {
            return $http({
                method: 'PUT',
                data: data,
                url: serviceBase + 'api/Contacts/UpdateContact',
                headers: { 'content-type': 'application/json' }
            });
        };

        objServiceFactory.deletecontact = function (contactId) {
            return $http({
                method: 'DELETE',
                params: { xiContactId: contactId },
                url: serviceBase + 'api/Contacts/DeleteContact',
                headers: { 'content-type': 'application/json' }
            });
        };

        return objServiceFactory;

        //var contactTypes = [
        //      { id: 1, name: "Family contact" },
        //      { id: 2, name: "Racing contact" },
        //      { id: 3, name: "Micro contact" },
        //      { id: 4, name: "Luxury contact" }
        //];

        //var contacts = [
        //            { id: 1, name: "Very colorful", type: 1, typeName: "Family contact", quantity: 5, rentPrice: 15 },
        //            { id: 2, name: "Very springy contact", type: 2, typeName: "Racing contact", quantity: 20, rentPrice: 17 },
        //            { id: 3, name: "Very classy contact", type: 3, typeName: "Micro contact", quantity: 20, rentPrice: 14 },
        //            { id: 4, name: "Very fast contact", type: 4, typeName: "Luxury contact", quantity: 20, rentPrice: 500 }
        //];

        //var updatecontactTypeName = function (contact) {
        //    angular.forEach(contactTypes, function (contactType) {
        //        if (contactType.id == contact.type) {
        //            contact.typeName = contactType.name;
        //        }
        //    });
        //};

        //return {
        //    getcontacts: function () {
        //        return contacts;
        //    },
        //    getcontact: function (contactId) {
        //        var existingcontact = null;
        //        angular.forEach(contacts, function (contact) {
        //            if (contact.Id == contactId) {
        //                existingcontact = contact;
        //            }
        //        });
        //        return existingcontact;
        //    },
        //    getcontactTypes: function () {
        //        return contactTypes;
        //    },
        //    createcontact: function () {
        //        return {
        //            type: contactTypes[0].id,
        //            typeName: contactTypes[0].name,
        //            quantity: 1,
        //            rentPrice: 10
        //        };
        //    },
        //    addcontact: function (contact) {
        //        updatecontactTypeName(contact);
        //        contact.Id = contacts.length + 1;
        //        contacts.push(contact);
        //    },
        //    updatecontact: function (contact) {
        //        updatecontactTypeName(contact);
        //    }
        //};
    //});


        return objServiceFactory;
    }

	// Register the service to the 'app' module.
    angular.module('myApp').factory('contactService', contactService);
})();