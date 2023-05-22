using Clinic.Models;
using Clinic.Repo.Interfaces;
using Clinic.Utilities;
using Clinic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Services
{
    public class DoctorService : IDoctorService
    {
        private IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTiming(TimingViewModel timing)
        {
            var model = new TimingViewModel().ConvertViewModel(timing);
            _unitOfWork.GenericRepo<Timing>().Add(model);
            _unitOfWork.Save();
        }

        public void DeleteTiming(int TimingId)
        {
            var model = _unitOfWork.GenericRepo<Timing>().GetById(TimingId);
            _unitOfWork.GenericRepo<Timing>().Delete(model);
            _unitOfWork.Save();
        }
        //Created by 22048474 Rishay Naidoo
        public PagedResult<TimingViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new TimingViewModel();
            int totalCount;
            List<TimingViewModel>vmList = new List<TimingViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepo<Timing>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepo<Timing>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<TimingViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize

            };
            return result;
        }


        public IEnumerable<TimingViewModel> GetAll()
        {
            var TimingList = _unitOfWork.GenericRepo<Timing>().GetAll().ToList();
            var vmList = ConvertModelToViewModelList(TimingList);
            return vmList;
        }

        public TimingViewModel GetTimingById(int TimingId)
        {
            var model = _unitOfWork.GenericRepo<Timing>().GetById(TimingId);
            var vm = new TimingViewModel(model);
            return vm;
        }

        public void UpdateTiming(TimingViewModel timing)
        {
            var model = new TimingViewModel().ConvertViewModel(timing);
            var ModelById = _unitOfWork.GenericRepo<Timing>().GetById(model.Id);
            ModelById.Id = timing.Id;
            ModelById.DoctorId = timing.DoctorId;
            ModelById.Status = timing.Status;
            ModelById.Duration = timing.Duration;
            ModelById.MorningShiftStartTime = timing.MorningShiftStartTime;
            ModelById.MorningShiftEndTime = timing.MorningShiftEndTime;
            ModelById.AfternoonShiftStartTime = timing.AfternoonShiftStartTime;
            ModelById.AfternoonShiftEndTime = timing.AfternoonShiftEndTime;

            _unitOfWork.GenericRepo<Timing>().Update(ModelById);
            _unitOfWork.Save();
        }
    

        private List<TimingViewModel> ConvertModelToViewModelList(List<Timing> modelList)
        {
          return modelList.Select(x => new TimingViewModel(x)).ToList();
        }
    
    }
}

