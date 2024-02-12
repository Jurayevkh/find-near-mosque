namespace FindMosque.API.DTO.Mosque;

public class UpdateMosqueDTO
{
    public string OldName { get; set; }
    public string Name { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longtitude { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string? PostCode { get; set; }
}

