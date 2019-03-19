using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Data
{
   public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
