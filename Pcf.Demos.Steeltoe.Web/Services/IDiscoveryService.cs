﻿using Steeltoe.Extensions.Configuration.CloudFoundry;
using System.Threading.Tasks;

namespace Pcf.Demos.Steeltoe.Web.Services
{
    public interface IDiscoveryService
    {
        Task<CloudFoundryApplicationOptions> GetServiceDetails();
    }
}