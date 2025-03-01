using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Models;

public partial class Dish
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("imageUrl")]
    [StringLength(255)]
    [Unicode(false)]
    public string? ImageUrl { get; set; }

    [Column("price")]
    public double Price { get; set; }

    [ForeignKey("DishId")]
    [InverseProperty("Dishes")]
    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}
