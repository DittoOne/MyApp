using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Models;

[Table("ingredients")]
public partial class Ingredient
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [ForeignKey("IngredientId")]
    [InverseProperty("Ingredients")]
    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}
