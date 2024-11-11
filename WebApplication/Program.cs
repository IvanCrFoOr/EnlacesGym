using Application;
using Persistence;
using System.Reflection;
using MediatR;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);
        builder.Services.AddAplicationLayer();
        builder.Services.AddPersistenceInfraestructure(builder.Configuration);
        builder.Services.AddControllersWithViews();
        builder.Services.AddControllers();
        //builder.Services.AddApiVersioning();
        builder.Services.AddRazorPages();
        // Add services to the container.
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();

    }
}
