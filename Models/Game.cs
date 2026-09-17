namespace GameStore.Models;

public class Game
{
    public string Id { get; set; }
    public required string Name { get; set; }
    public Genre Genre { get; set; }
    public string GenreId { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
    
    //Tell the compiler that when we create an object, we will always have to provide information to the Name 


}
