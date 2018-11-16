﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Data
{
    public class ToDoContext : DbContext, IReadOnlyToDoContext
    {
        public ToDoContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().HasKey(x => x.Id).ForSqlServerIsClustered();
            modelBuilder.Entity<ToDo>().Property(x => x.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<ToDo>().HasOne(x => x.Status).WithMany(x => x.ToDos).HasForeignKey(x => x.StatusId);
            modelBuilder.Entity<ToDo>().HasIndex(x => x.StatusId).HasName($"IX_{nameof(ToDo)}_{nameof(ToDo.Status)}");
<<<<<<< HEAD
            modelBuilder.Entity<ToDo>().HasIndex(x => x.TagId).HasName($"IX_{nameof(ToDo)}_{nameof(ToDo.Tag)}");
            modelBuilder.Entity<ToDo>().HasOne(x => x.Tag).WithMany(x => x.ToDos).HasForeignKey(x => x.TagId);
=======
            modelBuilder.Entity<ToDo>().HasOne(x => x.Tag).WithMany(x => x.ToDos).HasForeignKey(x => x.TagId);
            modelBuilder.Entity<ToDo>().HasIndex(x => x.TagId).HasName($"IX_{nameof(ToDo)}_{nameof(ToDo.Tag)}");
>>>>>>> a3d359a6355c8dda578150dc02f32a18ac09e18f

            modelBuilder.Entity<Status>().HasMany(x => x.ToDos).WithOne(x => x.Status);

            modelBuilder.Entity<Tag>().HasMany(x => x.ToDos).WithOne(x => x.Tag);
        }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<ToDo> ToDos { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Tag> Tags { get; set; }

        IQueryable<ToDo> IReadOnlyToDoContext.ToDos { get => ToDos.AsNoTracking(); }

        IQueryable<Status> IReadOnlyToDoContext.Statuses { get => Statuses.AsNoTracking(); }
    }
}
