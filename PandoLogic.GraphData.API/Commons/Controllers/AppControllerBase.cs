using AutoMapper;
using Commons.Enums;
using Commons.Extensions;
using Commons.Helpers;
using Commons.Validation.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Commons.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class AppControllerBase<ServiceType> : ControllerBase
    {
        #region Private Members
        private string _correlationId;
        #endregion

        #region Protected Properties
        protected IMapper Mapper { get; }
        protected IRequestValidator RequestValidator { get; }
        protected ServiceType Service { get; }
        protected string CorrelationId
        {
            get
            {
                if(string.IsNullOrEmpty(_correlationId))
                {
                    _correlationId = Request.Query["correlationId"].ToString();

                    if (string.IsNullOrEmpty(_correlationId))
                        _correlationId = Guid.NewGuid().ToString();
                }

                return _correlationId;
            }
        }
        
        
        protected EnvironmentType EnvironmentType => EnvironmentTypeHelper.GetEnvironmentType();
        #endregion

        public AppControllerBase(IMapper mapper, IRequestValidator requestValidator, ServiceType service)
        {
            Mapper = mapper;
            RequestValidator = requestValidator;
            Service = service;
        }
    }
}
