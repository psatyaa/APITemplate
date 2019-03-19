using API.Data;
using APITemplate.Domain.Models;
using APITemplate.Repository.Interface;
using APITemplate.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APITemplate.Service.Implementation
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ApplicationService(IApplicationRepository applicationRepository, IUnitOfWork unitOfWork)
        {
            _applicationRepository = applicationRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Application>> ListAsync()
        {
            return await _applicationRepository.ListAsync();
        }

        public async Task<Application> ListByIdAsync(int id)
        {
            return await _applicationRepository.ListByIdAsync(id);
        }
    }
}
