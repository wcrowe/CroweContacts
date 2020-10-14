using System.Collections.Generic;
using System.Threading.Tasks;
using CroweContacts.Models.ContactVM;

namespace CroweContacts.Service
{
    public interface IContactService
    {
        Task<List<ContactVm>> GetContactListAsync();
        Task<ContactVm> GetContactByIdAsync(int? id);
        bool ContactVmExists(int id);

        Task SaveChangesAsync(ContactVm contactVm);
    }
}