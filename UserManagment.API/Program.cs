using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using UserManagment.API.Infrastructure.Repositories;
using UserManagment.API.Infrastructure.Contexts;
using UserManagment.API.Application.Validators;
using UserManagment.API.Infrastructure.FileStorage;
using MediatR;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers(options =>
{

     options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

// Register FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<UserDetailsCreateViewModelValidator>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                            .WithMethods("GET", "POST", "PUT", "DELETE") // Specify the allowed methods, including DELETE
                           .AllowAnyHeader(); // Allow any header// Allow any header ;


                      });
});
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFileStorageService>(x => 
    new LocalFileStorageService("Uploads"));

IServiceCollection serviceCollection = builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "UserManagment API",
        Description = "User Managment Web API",

    });


});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
  {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Managment API V1");
      c.RoutePrefix = string.Empty; 
  });
}

app.UseCors(MyAllowSpecificOrigins);
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Uploads")),
    RequestPath = "/uploads"
});
app.MapControllers();
app.Run();
