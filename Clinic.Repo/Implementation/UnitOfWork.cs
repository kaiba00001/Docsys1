using Clinic.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Repo.Implementation
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbcontext _context;

        public UnitOfWork(ApplicationDbcontext context)
        {
            _context = context;
        }
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public IGenericRepo<T> GenericRepo<T>() where T : class
        {
            IGenericRepo<T> repo = new GenericRepo<T>(_context);
            return repo;   
        }
        public void save()
        {
            _context.SaveChanges();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
