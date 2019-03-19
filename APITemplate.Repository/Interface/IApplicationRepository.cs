using APITemplate.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APITemplate.Repository.Interface
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Application>> ListAsync();
        Task<Application> ListByIdAsync(int id);
        Task AddAsync(Application application);
    }
}
