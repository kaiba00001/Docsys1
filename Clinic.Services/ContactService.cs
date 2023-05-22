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
    public class ContactService : IContactService
    {
        private IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteContact(int id)
        {
            var model = _unitOfWork.GenericRepo<Contact>().GetById(id);
            _unitOfWork.GenericRepo<Contact>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new ContactViewModel();
            int totalCount;
            List<ContactViewModel> vmList = new List<ContactViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepo<Contact>().GetAll(includeProperties: "Clinic")
                    .Skip(ExcludeRecords).Take(pageSize).ToList();

                totalCount = _unitOfWork.GenericRepo<Contact>().GetAll().ToList().Count;


                vmList = ConvertModelToViewModelList(modelList);
            }


            catch (Exception)
            {
                throw;
            }
            var result = new PagedResult<ContactViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
            };
            return result;

        }

        public ContactViewModel GetContactById(int ContactId)
        {
            var model = _unitOfWork.GenericRepo<Contact>().GetById(ContactId);
            var vm = new ContactViewModel(model);
            return vm;
        }

        

        public void InsertContact(ContactViewModel Contact)
        {
            var model = new ContactViewModel().ConvertViewModel(Contact);
            _unitOfWork.GenericRepo<Contact>().Add(model);
            _unitOfWork.Save();
        }
        //Created by Rishay Naidoo
        public void UpdateContact(ContactViewModel Contact)
        {
            var model = new ContactViewModel().ConvertViewModel(Contact);
            var ModelById = _unitOfWork.GenericRepo<Contact>().GetById(model.Id);
            ModelById.Phone = Contact.Phone;
            ModelById.Email = Contact.Email;
            ModelById.ClinicId = Contact.ClinicInfoId;
            
            _unitOfWork.GenericRepo<Contact>().Update(ModelById);
            _unitOfWork.Save();

        }

        private List<ContactViewModel> ConvertModelToViewModelList(List<Contact> modelList)
        {
            return modelList.Select(x => new ContactViewModel(x)).ToList();
        }
    }
}
