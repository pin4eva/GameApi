using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameApi.Entities;

public class Game
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string Name { get; set; }

    [Required]
    [StringLength(20)]
    public required string Genre { get; set; }

    [Range(1, 100)]
    public Decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    [Required]
    [StringLength(150)]
    public required string ImageUrl { get; set; }

}
