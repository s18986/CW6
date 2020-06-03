using System.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Zestaw_6.Services;

namespace Zestaw_6
{
    public class Startup
    {
        static private string ConString = "Data Source=db-mssql;Initial Catalog=s18986;Integrated Security=True";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IStudentDbService, SqlServerStudentDbService>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<Middleware.Middleware>();

            app.Use(async (context, next) =>
            {
                if (!context.Request.Headers.ContainsKey("Index"))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Nie podano indeksu");
                    return;
                }

                string indexNumber = context.Request.Headers["Index"].ToString();

                using (var con = new SqlConnection(ConString))
                using (var com = new SqlCommand())
                {

                    com.Connection = con;
                    con.Open();

                    com.CommandText = "select IndexNumber from Student where IndexNumber = @IndexNumber";
                    com.Parameters.AddWithValue("IndexNumber", indexNumber);

                    var dr = com.ExecuteReader();

                    if (!dr.Read())
                    {

                        dr.Close();
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync("Taki student nie istnieje");
                        return;
                    }

                    dr.Close();
                    com.Parameters.Clear();

                    await next();
                }
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
