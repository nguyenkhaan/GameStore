using static System.Runtime.InteropServices.JavaScript.JSType;
namespace GameStore.Dtos;

public record UpdateGameDto(
    string? Name, string? Genre, decimal? Price, DateOnly? ReleaseDate
); 