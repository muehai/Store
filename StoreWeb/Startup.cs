  using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Data;
using Microsoft.EntityFrameworkCore; 
using Store.Model.Model;
using Autofac;
using System.Reflection;
using Store.Data.Infrastracture;
using Store.Data.Repositories;
using Store.Service;

namespace StoreWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            // Mapps all file to servre  for container
           //SetAutofacContainer();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();

            ////Dataabse services
            services.AddDbContext<StorEntities>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("StoreEntitiesDb")));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, StorEntities context)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Stores}/{action=Index}/{id?}");
            });

            //Initialize the Store db
            StoreSeedData.SeedStor(context);
        }

        //public void SetAutofacContainer()
        //{
        //    var builder = new ContainerBuilder();
        //  builder.RegisterControllers(Assembly.GetExecutingAssembly());
        //    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
        //    builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

        //    // Repositories
        //    builder.RegisterAssemblyTypes(typeof(GadgetRepository).Assembly)
        //        .Where(t => t.Name.EndsWith("Repository"))
        //        .AsImplementedInterfaces().InstancePerRequest();
        //    // Services
        //    builder.RegisterAssemblyTypes(typeof(GadgetService).Assembly)
        //       .Where(t => t.Name.EndsWith("Service"))
        //       .AsImplementedInterfaces().InstancePerRequest();

        //    IContainer container = builder.Build();
        //    DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        //}
    }
}
