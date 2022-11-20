using Emloyee_Management_System.Database.DataContexts;

namespace Emloyee_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services
                .AddMvc();

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}");

            app.Run();

        }
    }
}