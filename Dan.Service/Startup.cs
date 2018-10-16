﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CorrelationId;
using Dan.Service.ApiClients.PaulServiceClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Extensions.Http;
using Swashbuckle.AspNetCore.Swagger;

namespace Dan.Service
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
            services.AddCorrelationId();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Dan's API", Version = "v1" });
            });

            services
                .AddTransient<CorrelationIdDelegatingHandler>()
                .AddHttpClient<PaulServiceClient>(client => client.BaseAddress = new Uri(Configuration["ServiceUrls:PaulService"]))
                .AddTransientHttpErrorPolicy(builder =>
                    builder.WaitAndRetryAsync(4, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))))
                .AddTransientHttpErrorPolicy(builder =>
                    builder.CircuitBreakerAsync(handledEventsAllowedBeforeBreaking: 3, durationOfBreak: TimeSpan.FromSeconds(60)))
                .AddHttpMessageHandler<CorrelationIdDelegatingHandler>()
                ;

            services.AddDistributedRedisCache(opt =>
            {
                opt.Configuration = "redis";
                opt.InstanceName = "Redis";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCorrelationId(new CorrelationIdOptions { UseGuidForCorrelationId = true });
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
