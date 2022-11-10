using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Software_Lanch.Context;
using Software_Lanch.Models;
using Software_Lanch.Repositories;
using Software_Lanch.Repositories.Interfaces;

namespace Software_Lanch;
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
        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddTransient<ILanchRepository,LancheRepository>();
       
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        //Especial
        services.AddScoped(sp => CarrinhoCompraRepository.GetCarrinho(sp));


        services.AddControllersWithViews();
        //Registro dos Middlewares
        services.AddMemoryCache();
        services.AddSession();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) 
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        //Uso de Session
        app.UseSession();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name:"categoriaFiltro",
                pattern:"Lanche/{action}/{categoria?}",
                defaults:new {Controller="Lanche",action="Index"}
                );
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            // endpoints.MapDefaultControllerRoute();
        });
    }
}