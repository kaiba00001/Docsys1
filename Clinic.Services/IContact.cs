using Clinic.Utilities;
using Clinic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Services
{
    public interface IContactService
    {

        PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize);
        
        ContactViewModel GetContactById (int ContactId);

        void UpdateContact(ContactViewModel Contact);

        void InsertContact(ContactViewModel Contact);

        void DeleteContact(int id);
        
    }
}
