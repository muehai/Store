using System;
using System.Collections.Generic;
using System.Text;
using Store.Data.Infrastracture;
using Store.Model.Model;

namespace Store.Data.Repositories
{
   public  class GadgetRepository : RepositoryBase<Gadget>,IGadgetRepository
    {
        public GadgetRepository(IDbFactory dbFactory): base(dbFactory)
        { }
    }

    public interface IGadgetRepository : IRepository<Gadget>
    { }
}
