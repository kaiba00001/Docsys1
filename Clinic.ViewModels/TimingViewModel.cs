using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Clinic.ViewModels
{
    public class TimingViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int MorningShiftStartTime { get; set; }

        public int MorningShiftEndTime { get; set; }

        public int AfternoonShiftStartTime { get; set; }

        public int AfternoonShiftEndTime { get; set; }

        public int Duration { get; set; }

        public Status Status { get; set; }
        List<SelectListItem> MorningShiftStart = new List<SelectListItem>();
        List<SelectListItem> MorningShiftEnd = new List<SelectListItem>();
        List<SelectListItem> AfternoonShiftStart = new List<SelectListItem>();
        List<SelectListItem> AfternoonShiftEnd = new List<SelectListItem>();

        public ApplicationUser DoctorId { get; set; }


        public TimingViewModel()
        {

        }

        public TimingViewModel(Timing model)
        {
            Id = model.Id;
            Date = model.Date;
            MorningShiftStartTime = model.MorningShiftStartTime;
            MorningShiftEndTime = model.MorningShiftEndTime;
            AfternoonShiftStartTime = model.AfternoonShiftStartTime;
            AfternoonShiftEndTime = model.AfternoonShiftEndTime;
            Duration = model.Duration;
            Status = model.Status;
            DoctorId = model.DoctorId;
        }

        public Timing ConvertViewModel(TimingViewModel model)
        {
            return new Timing
            { 
            Id = model.Id,
            Date = model.Date,
            MorningShiftStartTime = model.MorningShiftStartTime,
            MorningShiftEndTime = model.MorningShiftEndTime,
            AfternoonShiftStartTime = model.AfternoonShiftStartTime,
            AfternoonShiftEndTime = model.AfternoonShiftEndTime,
            Duration = model.Duration,
            Status = model.Status,
            DoctorId = model.DoctorId,
        };
      
    }



    }
}
