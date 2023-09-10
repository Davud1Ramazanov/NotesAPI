using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NotesAPI.Configuration;
using NotesAPI.LocalControllers;
using WildNature_Back.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<NoteLocalRepository>();
builder.Services.AddTransient<UserLocalRepository>();
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddDbContext<NotesDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("dbconn"),
        b => b.MigrationsAssembly(typeof(NotesDbContext).Assembly.FullName));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseSession();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
