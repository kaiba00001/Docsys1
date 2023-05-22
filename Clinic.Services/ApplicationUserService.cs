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
    public class ApplicationUserService : IApplicationUserService
    {
        private IUnitOfWork _unitOfWork;

        public ApplicationUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PagedResult<ApplicationUserViewModel> GetAll(int PageNumber, int PageSize)
        {
            var vm = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> vmList = new List<ApplicationUserViewModel>();
            try
            {
                int ExcludeRecords = (PageSize * PageNumber) - PageSize;

                var modelList = _unitOfWork.GenericRepo<ApplicationUser>().GetAll()
                    .Skip(ExcludeRecords).Take(PageSize).ToList();

                totalCount = _unitOfWork.GenericRepo<ApplicationUser>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModel(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<ApplicationUserViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = PageNumber,
                PageSize = PageSize,
            };
            return result;
        }
        //Created by Rishay Naidoo

        public PagedResult<ApplicationUserViewModel> GetAllDoctor(int PageNumber, int PageSize)
        {
            var vm = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> vmList = new List<ApplicationUserViewModel>();
            try
            {
                int ExcludeRecords = (PageSize * PageNumber) - PageSize;

                var modelList = _unitOfWork.GenericRepo<ApplicationUser>().GetAll(x=>x.IsDoctor==true)
                    .Skip(ExcludeRecords).Take(PageSize).ToList();

                totalCount = _unitOfWork.GenericRepo<ApplicationUser>().GetAll(x=>x.IsDoctor==true).ToList().Count;

                vmList = ConvertModelToViewModel(modelList);
            }
            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<ApplicationUserViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = PageNumber,
                PageSize = PageSize,
            };
            return result;
        }

        public PagedResult<ApplicationUserViewModel> GetAllPatient(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        public PagedResult<ApplicationUserViewModel> SearchDoctor(int PageNumber, int PageSize, string Spicility = null)
        {
            throw new NotImplementedException();
        }

        private List<ApplicationUserViewModel> ConvertModelToViewModel(List<ApplicationUser> modelList)
        {
            return modelList.Select(x => new ApplicationUserViewModel(x)).ToList();
        }
    }
}
