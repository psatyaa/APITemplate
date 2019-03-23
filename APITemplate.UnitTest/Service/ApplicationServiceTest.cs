using API.Data;
using APITemplate.Domain.Models;
using APITemplate.Repository.Interface;
using APITemplate.Service.Implementation;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APITemplate.UnitTest.Service
{
    [TestClass]
    public class ApplicationServiceTest
    {
        IEnumerable<Application> applications = new List<Application>()
        {
            new Application{ AppName ="" },
            new Application{ AppName ="" },
        };

        [TestMethod]
        public void ListAsync()
        {
            var applicationRepository = new Mock<IApplicationRepository>();
            applicationRepository.Setup(x => x.ListAsync()).Returns( Task.FromResult(applications));
            //var unitOfWork = new Mock<UnitOfWork>();
            //unitOfWork.Setup(x => x.CompleteAsync()).Returns(Task.FromResult(applications));
            var applicationService = new ApplicationService(applicationRepository.Object, null);
            var result = applicationService.ListAsync();
            var value = result.Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(value, applications);
        }
    }
}
