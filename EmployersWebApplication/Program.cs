using EmployersWebApplication.Services;

namespace EmployersWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<IEmployersRepository, EmployerRepository>();
            
            
            var app = builder.Build();



            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //app.MapGet("/", () => "Hello World!");

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            
            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}