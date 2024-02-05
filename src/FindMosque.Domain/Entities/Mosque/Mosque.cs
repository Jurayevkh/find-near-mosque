namespace FindMosque.Domain.Entities.Mosque;

public class Mosque:BaseEntity
{
    public required string Name { get; set; }
    public required decimal Latitude { get; set; }
    public required decimal Longtitude { get; set; }
    public required string Address { get; set; }
    public required string City { get; set; }
    public string? PostCode { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

