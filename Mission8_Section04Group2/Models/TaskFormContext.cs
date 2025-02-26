using System;
using Microsoft.EntityFrameworkCore;

public class TaskFormContext
{
	public TaskFormContext() : DbContext
	{
		public TaskFormContext(DbContextOptions<TaskFormContext> options) : base(options) { }

    public DbSet<Task> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Home" },
            new Category { CategoryId = 2, Name = "School" },
            new Category { CategoryId = 3, Name = "Work" },
            new Category { CategoryId = 4, Name = "Church" }
        );
    }
}
