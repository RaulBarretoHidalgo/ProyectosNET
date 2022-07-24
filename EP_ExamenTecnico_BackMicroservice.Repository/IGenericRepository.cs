using System;
using System.Collections.Generic;
using System.Text;

namespace EP_Planning_BackMicroservice.Repository
{
    public interface IGenericRepository<T> where T: class
    {   
        bool Update(T item);
        bool Delete(long id);
        bool Delete(string id);
   }
}
