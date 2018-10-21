using EH.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EH.DAL.Interface
{
    public interface IContactService
    {
        Task<List<StatusVM>> GetStatusList();
        Task<List<ContactVM>> GetContactList();
        Task<ContactVM> GetContactById(int xiContactId);
        Task<bool> InsertContact(ContactVM xiContactVM);
        Task<bool> UpdateContact(ContactVM xiContactVM);
        Task<bool> DeleteContact(int xiContactId);
    }
}
