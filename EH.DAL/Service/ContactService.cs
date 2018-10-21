using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EH.Entity;
using EH.ViewModel;
using EH.DAL.Interface;

namespace EH.DAL.Service
{
    public class ContactService : IContactService
    {
        private readonly IApplicationRepository _repo;

        public ContactService(IApplicationRepository repo) 
        {
            _repo = repo;
        }

        public async Task<List<ContactVM>> GetContactList()
        {
            try
            {
                var objContactList = (await _repo.FindAllAsync<Contact>());
                var objStatusList = (await _repo.FindAllAsync<Status>());

                var result = (from objContact in objContactList
                              join objStatus in objStatusList on objContact.StatusID equals objStatus.Id

                              select new ContactVM
                              {
                                  Id = objContact.Id,
                                  FirstName = objContact.FirstName,
                                  LastName = objContact.LastName,
                                  Email = objContact.Email,
                                  PhoneNumber = objContact.PhoneNumber,
                                  StatusID = objContact.StatusID,
                                  StatusName = objStatus.Type
                              }).OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;//Write exception Logger or Handle with GlobalErrorHandler Filter
            }
        }

        public async Task<List<StatusVM>> GetStatusList()
        {
            try
            {
                var objStatusList = (await _repo.FindAllAsync<Status>());

                var result = (from objStatus in objStatusList

                              select new StatusVM
                              {
                                  Id = objStatus.Id,
                                  Type = objStatus.Type
                              }).OrderBy(x => x.Type).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;//Write exception Logger or Handle with GlobalErrorHandler Filter
            }
        }

        public async Task<ContactVM> GetContactById(int xiContactId)
        {
            try
            {
                var objContact = (await _repo.FindAsync<Contact>(_ => _.Id.Equals(xiContactId)));

                ContactVM objContactVM = new ContactVM
                {
                    Id = objContact.Id,
                    FirstName = objContact.FirstName,
                    LastName = objContact.LastName,
                    Email = objContact.Email,
                    PhoneNumber = objContact.PhoneNumber,
                    StatusID = objContact.StatusID
                };

                return objContactVM;

            }
            catch (Exception ex)
            {
                throw ex;//Write exception Logger or Handle with GlobalErrorHandler Filter
            }
        }

        public async Task<bool> InsertContact(ContactVM xiContactVM)
        {
            bool result = false;
            try
            {
                Contact objContact = new Contact {
                    FirstName = xiContactVM.FirstName,
                    LastName = xiContactVM.LastName,
                    Email = xiContactVM.Email,
                    PhoneNumber = xiContactVM.PhoneNumber,
                    StatusID = xiContactVM.StatusID
                };

                _repo.Add<Contact>(objContact);
                await _repo.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;//Write exception Logger or Handle with GlobalErrorHandler Filter
            }
            return result;
        }

        public async Task<bool> UpdateContact(ContactVM xiContactVM)
        {
            bool result = false;
            try
            {
                var objContact = (await _repo.QueryAsync<Contact>(_ => _.Id.Equals(xiContactVM.Id))).FirstOrDefault();

                objContact.FirstName = xiContactVM.FirstName;
                objContact.LastName = xiContactVM.LastName;
                objContact.Email = xiContactVM.Email;
                objContact.PhoneNumber = xiContactVM.PhoneNumber;
                objContact.StatusID = xiContactVM.StatusID;

                await _repo.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;//Write exception Logger or Handle with GlobalErrorHandler Filter
            }
            return result;
        }

        public async Task<bool> DeleteContact(int xiContactId)
        {
            bool result = false;
            try
            {
                var objContact = (await _repo.QueryAsync<Contact>(_ => _.Id.Equals(xiContactId))).FirstOrDefault();
                await _repo.DeleteAsync(objContact);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;//Write exception Logger or Handle with GlobalErrorHandler Filter
            }
            return result;
        }
    }
}
