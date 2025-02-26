using System;
using Microsoft.EntityFrameworkCore;
using Mission8_Section04Group2.Models;

public class TaskFormContext : DbContext
{

	public TaskFormContext(DbContextOptions<TaskFormContext> options) : base(options) { }

    public DbSet<Mission8_Section04Group2.Models.Task> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Home" },
            new Category { CategoryId = 2, CategoryName = "School" },
            new Category { CategoryId = 3, CategoryName = "Work" },
            new Category { CategoryId = 4, CategoryName = "Church" }
        );
    }
}
