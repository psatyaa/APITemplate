using API.Data;
using APITemplate.Domain.Models;
using APITemplate.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APITemplate.Repository.Implementation
{
    public class ApplicationRepository : BaseRepository, IApplicationRepository
    {
        public ApplicationRepository(AppDbContext context):base(context)
        {

        }
        public async Task AddAsync(Application application)
        {
            await _context.Applications.AddAsync(application);
        }

        public async  Task<IEnumerable<Application>> ListAsync()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task<Application> ListByIdAsync(int id)
        {
            return await _context.Applications.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
