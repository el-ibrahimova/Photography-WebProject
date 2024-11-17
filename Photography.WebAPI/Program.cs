using Photography.WebAPI.Interface;
using Photography.WebAPI.Service;

namespace Photography.WebAPI
{
    using Azure.Storage.Blobs;
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton(x =>
                new BlobServiceClient(builder.Configuration.GetValue<string>("AzureStorage:ConnectionString"))
            );
            
            builder.Services.AddScoped<IBlobService, BlobService>();
            
            

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
