using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace Store.Data.Infrastracture
{
    public class DbFactory:Disposable, IDbFactory
    {
        StorEntities dbContext;

        //intialize
        public StorEntities init()
        {

            return dbContext = new StorEntities();
           
        }
         
        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
