using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data;

public partial class MenuBlazorDataContext : DbContext
{
    public MenuBlazorDataContext()
    {
    }

    public MenuBlazorDataContext(DbContextOptions<MenuBlazorDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dish> Dishes { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-5903S8A\\SQLEXPRESS;Initial Catalog=MenuBlazor_Data;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dish>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Dishes__3213E83FD06FA357");

            entity.HasMany(d => d.Ingredients).WithMany(p => p.Dishes)
                .UsingEntity<Dictionary<string, object>>(
                    "Dishingredient",
                    r => r.HasOne<Ingredient>().WithMany()
                        .HasForeignKey("IngredientId")
                        .HasConstraintName("FK__Dishingre__Ingre__276EDEB3"),
                    l => l.HasOne<Dish>().WithMany()
                        .HasForeignKey("DishId")
                        .HasConstraintName("FK__Dishingre__DishI__267ABA7A"),
                    j =>
                    {
                        j.HasKey("DishId", "IngredientId").HasName("PK__Dishingr__A369A47584E91B40");
                        j.ToTable("Dishingredients");
                    });
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ingredie__3213E83F2E620DC3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
