using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.ViewModels
{
    public class ApplicationUserViewModel
    {
        

        public string Name { get; set; } 
        
        public string Email { get; set; }

        public string UserName { get; set; }

        public string City { get; set; }

        public Gender Gender { get; set; }  

        public  bool IsDoctor { get; set; }

        public string Specialist { get; set; }


        public ApplicationUserViewModel()
        {

        }

        public ApplicationUserViewModel(ApplicationUser user)
        {
            Name = user.Name;
            City = user.City;
            Gender = user.Gender;
            IsDoctor = user.IsDoctor;
            Specialist = user.Specialist;
            UserName = user.UserName;
            Email = user.Email;

        }

        public ApplicationUser ConvertViewModelToModel(ApplicationUserViewModel user)
        {
            return new ApplicationUser
            {
                Name = user.Name,
                City = user.City,
                Gender = user.Gender,
                IsDoctor = user.IsDoctor,
                Specialist = user.Specialist,
                UserName = user.UserName,
                Email = user.Email
            };
        }

      
        public List <ApplicationUser> Doctors { get; set; } = new List<ApplicationUser>();



    }
}
