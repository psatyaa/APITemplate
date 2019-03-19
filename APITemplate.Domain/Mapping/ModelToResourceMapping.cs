using APITemplate.Domain.Models;
using APITemplate.Domain.Resources.Responses;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace APITemplate.Domain.Mapping
{
    public class ModelToResourceMapping:Profile
    {
        public ModelToResourceMapping()
        {
            CreateMap<Application, ApplicationResource>();
        }
    }
}
