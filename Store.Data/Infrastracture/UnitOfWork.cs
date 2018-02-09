using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Store.Data.Infrastracture
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly IDbFactory dbFactory;
        private StorEntities dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public StorEntities DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.init()); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
