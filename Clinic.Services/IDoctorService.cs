using Clinic.Utilities;
using Clinic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Services
{
    public interface IDoctorService
    {
        PagedResult<TimingViewModel> GetAll(int pageNumber, int pageSize);

        IEnumerable<TimingViewModel> GetAll();

        TimingViewModel GetTimingById(int TimingId);

        void UpdateTiming(TimingViewModel timing);

        void AddTiming(TimingViewModel timing);

        void DeleteTiming(int TimingId);
    }
}
