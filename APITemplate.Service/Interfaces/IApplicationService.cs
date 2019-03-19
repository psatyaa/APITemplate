using APITemplate.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APITemplate.Service.Interfaces
{
   public interface IApplicationService
    {
        Task<IEnumerable<Application>> ListAsync();
        Task<Application> ListByIdAsync(int id);
       // Task<SaveApplicationResponse> SaveAsync(Application application);
       // Task<SaveApplicationResponse> UpdateAsync(int id, Application application);
    }
}
