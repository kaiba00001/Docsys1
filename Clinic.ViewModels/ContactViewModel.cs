using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.ViewModels
{
    public class ContactViewModel
    {

        public int Id { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int ClinicInfoId { get; set; }

        

        public ContactViewModel() 
        {
                
        }

        public ContactViewModel(Contact model)
        {
            Id = model.Id;
            Email = model.Email;
            Phone = model.Phone;
            ClinicInfoId = model.ClinicId;
            
        }

        public Contact ConvertViewModel(ContactViewModel model)
        {
            return new Contact
            {
                Id = model.Id,
                Email = model.Email,
                Phone = model.Phone,
                ClinicId = model.ClinicInfoId,
            };
        }
    }
}
