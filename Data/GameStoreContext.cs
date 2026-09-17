using Microsoft.EntityFrameworkCore;
using GameStore.Models;

namespace GameStore.Data;

//Represent the session between your API and the database. Use in both query
//Define primary constructor: GameStoreContext(...) = public class GameStore {    public GameStore(...)    }

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    //When create an instance, it calls the child class -> child clas spass arguements to parent class 
    //After this step.... The parent class will initialize first, then come to children and so more...
    public DbSet<Game> Games => Set<Game>(); //When using =>, this become readonly
                                             //This is the shorten syntax for: get { return Set<Game>(), and Set is the method provided by DbContext, which gets the DbSet<Game> associated with the context }
    public DbSet<Genre> Genres => Set<Genre>();
    
}


/* 
You can have more options when use get; and set; in the class: 
class Person {
    public string _name; //field 
    public string Name {   //property
        get => _name; 
        set => _name = value; 
    }
}
*/