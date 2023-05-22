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
    public class RoomViewModel
    {

        public int Id { get; set; }

        public string RoomNumber { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public int ClinicInfoId { get; set; }

        public ClinicInfo ClinicInfo { get; set; }
        

        public RoomViewModel()
        {
                
        }

        public RoomViewModel(Room model)
        {
            Id = model.Id;
            RoomNumber = model.RoomNumber;
            Type = model.Type;
            Status = model.Status;
            ClinicInfoId = model.ClinicId;
            ClinicInfo = model.Clinic;
        }

        public Room ConvertViewModel(RoomViewModel model)
        {
            return new Room
            {
                Id = model.Id,
                Type = model.Type,
                RoomNumber = model.RoomNumber,
                Status = model.Status,
                ClinicId = model.ClinicInfoId,
                Clinic = model.ClinicInfo
            };
        }
    }
}
