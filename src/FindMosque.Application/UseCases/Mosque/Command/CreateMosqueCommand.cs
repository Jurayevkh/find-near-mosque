using MediatR;

namespace FindMosque.Application.UseCases.Mosque.Command;

public class CreateMosqueCommand:IRequest<bool>
{
    public required string Name { get; set; }
    public required decimal Latitude { get; set; }
    public required decimal Longtitude { get; set; }
    public required string Address { get; set; }
    public required string City { get; set; }
    public string? PostCode { get; set; }
}

