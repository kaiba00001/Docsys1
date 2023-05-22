using Clinic.Utilities;
using Clinic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Services
{
    public interface IClinicInfo
    {

        PagedResult<ClinicInfoViewModel> GetAll(int pageNumber, int pageSize);
        
        ClinicInfoViewModel GetClinicById (int ClinicId);

        void UpdateClinicInfo(ClinicInfoViewModel hospitalInfo);

        void InsertClinicInfo(ClinicInfoViewModel hospitalInfo);

        void DeleteClinicInfo(int id);





    }
}
