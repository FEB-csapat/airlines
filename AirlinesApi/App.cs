using Newtonsoft.Json;

namespace AirlinesApi
{
    public class App
    {
        static WebApplicationBuilder builder;
        static WebApplication app;

        private static void Initialize(string[]? args)
        {
            builder = WebApplication.CreateBuilder(args ?? new string[0]);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            app = builder.Build();


            app.UseCors(builder => builder.WithOrigins("*").AllowAnyHeader());


            app.UseAuthorization();

            app.MapControllers();
        }

        public static void RunDev(string[]? args = null)
        {
            Initialize(args);
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.Run();
        }

        public static void RunTest(string[]? args = null)
        {
            Initialize(args);
            app.Run();
        }
    }
}