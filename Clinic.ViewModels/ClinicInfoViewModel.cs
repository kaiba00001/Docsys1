﻿using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.ViewModels
{
    public class ClinicInfoViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string City { get; set; }

        public string PinCode { get; set; }

        public string Country { get; set; }

        public ClinicInfoViewModel()
        {
                
        }

        public ClinicInfoViewModel(ClinicInfo model )
        {
            Id = model.Id;
            Name = model.Name;
            Type = model.Type;
            City = model.City;
            PinCode = model.PinCode;
            Country = model.Country;
        }

        public ClinicInfo ConvertViewModel(ClinicInfoViewModel model)
        {
            return new ClinicInfo
            {
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                City = model.City,
                PinCode = model.PinCode,
                Country = model.Country,
            };
        }
    }
}
