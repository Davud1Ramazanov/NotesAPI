using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using NotesAPI;
using NotesAPI.Models;

namespace WildNature_Back.Context;

public partial class NotesDbContext : DbContext
{
    protected IConfiguration configuration;
    public NotesDbContext(DbContextOptions options)
        : base(options)
    {}

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

}