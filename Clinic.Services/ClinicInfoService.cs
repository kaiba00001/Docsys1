using Clinic.Models;
using Clinic.Repo.Interfaces;
using Clinic.Utilities;
using Clinic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Services
{
    public class ClinicInfoService : IClinicInfo
    {
        private IUnitOfWork _unitOfWork;

        public ClinicInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteClinicInfo(int id)
        {
            var model = _unitOfWork.GenericRepo<ClinicInfo>().GetById(id);
            _unitOfWork.GenericRepo<ClinicInfo>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<ClinicInfoViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new ClinicInfoViewModel();
            int totalCount;
            List<ClinicInfoViewModel> vmList = new List<ClinicInfoViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepo<ClinicInfo>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepo<ClinicInfo>().GetAll().ToList().Count;


                vmList = ConvertModelToViewModelList(modelList);
            }


            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<ClinicInfoViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
            };
            return result;

        }
        //Created by Rishay Naidoo
        public ClinicInfoViewModel GetClinicById(int ClinicId)
        {
            var model = _unitOfWork.GenericRepo<ClinicInfo>().GetById(ClinicId);
            var vm = new ClinicInfoViewModel(model);
            return vm;
        }

        public void InsertClinicInfo(ClinicInfoViewModel clinicInfo)
        {
            var model = new ClinicInfoViewModel().ConvertViewModel(clinicInfo);
            _unitOfWork.GenericRepo<ClinicInfo>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateClinicInfo(ClinicInfoViewModel clinicInfo)
        {
            var model = new ClinicInfoViewModel().ConvertViewModel(clinicInfo);
            var ModelById = _unitOfWork.GenericRepo<ClinicInfo>().GetById(model.Id);
            ModelById.Name = clinicInfo.Name;
            ModelById.City = clinicInfo.City;
            ModelById.PinCode = clinicInfo.PinCode;
            ModelById.Country = clinicInfo.Country;
            _unitOfWork.GenericRepo<ClinicInfo>().Update(ModelById);
            _unitOfWork.Save();

        }

        private List<ClinicInfoViewModel> ConvertModelToViewModelList(List<ClinicInfo> modelList)
        {
            return modelList.Select(x => new ClinicInfoViewModel(x)).ToList();
        }
    }
}
