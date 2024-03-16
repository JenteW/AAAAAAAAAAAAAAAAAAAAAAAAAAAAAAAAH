using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using weatherboy.Data;

namespace weatherboy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //adjust ConfigureServices-method
            builder.Services.AddCors(s => s.AddPolicy("MyPolicy", builder => builder.AllowAnyOrigin()
                                               .AllowAnyMethod()
                                               .AllowAnyHeader()));

            // Add authentication services and specify the BasicAuthenticationHandler
            builder.Services
                .AddAuthentication("BasicAuthenticationScheme") // This should match the scheme name in the AddPolicy call
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthenticationScheme", options => { });


            // Add authorization policy that uses the Basic Authentication Scheme
            builder.Services.AddAuthorization(options => {
                options.AddPolicy("BasicAuthentication",
                    new AuthorizationPolicyBuilder("BasicAuthenticationScheme").RequireAuthenticatedUser().Build());
            });


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IAnonymousEurosongDataContext, AnonymousEurosongDatabase>();
            builder.Services.AddControllers();
            var app = builder.Build();

            app.UseCors("MyPolicy");
            //Configure in Startup.cs
            app.UseHttpsRedirection();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}