namespace FindMosque.Domain.Entities.Mosque;

public class Mosque:BaseEntity
{
    public string Name { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longtitude { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string? PostCode { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

