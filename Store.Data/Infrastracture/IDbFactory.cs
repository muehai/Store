using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data.Infrastracture
{
   public interface IDbFactory: IDisposable
    {
        //Create a factory Interface responsible to initialize instances of this class.
        StorEntities init();
    }
}
