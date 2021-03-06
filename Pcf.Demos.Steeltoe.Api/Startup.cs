﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pcf.Demos.Steeltoe.Api.Commands;
using Pcf.Demos.Steeltoe.Api.Services;
using Pivotal.Discovery.Client;
using Steeltoe.CircuitBreaker.Hystrix;
using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace Pcf.Demos.Steeltoe.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //configuration
            services.AddOptions();
            services.ConfigureCloudFoundryOptions(Configuration);

            //discovery
            services.AddDiscoveryClient(Configuration);

            services.AddSingleton<ICircuitBreakerCustomerWishlistService, CircuitBreakerCustomerWishlistService>();

            //hystrix/circuit breaker
            services.AddHystrixCommand<CircuitBreakerCustomerWishlistCommand>(
                "pcf-demos-steeltoe-api", Configuration);

            //services.AddHystrixMetricsStream(Configuration);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDiscoveryClient();

            app.UseMvc();
        }
    }
}