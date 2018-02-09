using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data.Infrastracture
{
    public interface IUnitOfWork
    {
        void Commit(); //Send command to register database CRUD
    }
}
