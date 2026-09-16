using static System.Runtime.InteropServices.JavaScript.JSType;
namespace GameStore.Dtos;

// A DTO is a contract between client and server since it represents a shared agreement 
//about how data will be transferred and used. 
public record GameDto
{
    public string ID { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public Decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public GameDto(string ID, string Name, string Genre, Decimal Price, DateOnly ReleaseDate)
    {
        this.ID = ID;
        this.Name = Name;
        this.Genre = Genre;
        this.Price = Price;
        this.ReleaseDate = ReleaseDate;
    }
};
//Only create a primary constructor with parameters. Not creating a default constructor with zero parameter
//DateOnly: Only store day/month/year, not include hour, minute, second 
//DateTime: store day, month, year, hour, minute, second
/* 
A record is a data structure, used to store data. It's immutable, so you 
can't change it 
public record Person(string firstName, string lastName); 
When we define like this, the record will generate a public record class 
with a constructor, receive 2 parameters. 
We can create an instance from the record 
var p1 = new Person("Alice", "Smith"); 
Console.WriteLine(r1.firstName); 
Console.WriteLine(r2.lastName);

Another way to define record: 
public record Person {
    string firstName {get; init;} (read + initialization)
    string lastName {get; init;}
}

*/ 