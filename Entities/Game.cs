using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameApi.Entities;

public class Game
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Genre { get; set; }
    public Decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    public required string ImageUrl { get; set; }

}
