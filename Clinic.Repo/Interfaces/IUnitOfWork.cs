﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Repo.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepo<T> GenericRepo<T>() where T : class;

        void Save();

    }
}
